/* IVT
 * @Project : hisnguonmo
 * Copyright (C) 2017 INVENTEC
 *  
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *  
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
 * GNU General Public License for more details.
 *  
 * You should have received a copy of the GNU General Public License
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */
using Inventec.Common.Logging;
using Inventec.Core;
using ACS.EFMODEL.DataModels;
using ACS.MANAGER.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACS.MANAGER.AcsToken
{
    partial class AcsTokenUpdateExpireTime : BusinessBase
    {
        internal AcsTokenUpdateExpireTime()
            : base()
        {

        }

        internal AcsTokenUpdateExpireTime(CommonParam paramUpdateExpireTime)
            : base(paramUpdateExpireTime)
        {

        }

        internal bool UpdateExpireTime(long expireTime)
        {
            bool result = false;
            try
            {
                bool valid = true;
                AcsTokenCheck checker = new AcsTokenCheck(param);
                ACS_TOKEN raw = null;
                valid = valid && checker.VerifyTokenCode(Inventec.Token.ResourceSystem.ResourceTokenManager.GetTokenCode(), ref raw);
                valid = valid && checker.VerifyExpireTime(expireTime, raw);
                if (valid)
                {
                    if (expireTime == raw.EXPIRE_TIME)
                    {
                        result = true;
                    }
                    else
                    {
                        raw.EXPIRE_TIME = expireTime;
                        if (!DAOWorker.AcsTokenDAO.Update(raw))
                        {
                            ACS.MANAGER.Base.BugUtil.SetBugCode(param, ACS.LibraryBug.Bug.Enum.AcsToken_CapNhatThatBai);
                            MessageUtil.SetMessage(param, LibraryMessage.Message.Enum.Common__CapNhatThatBai);
                            throw new Exception("Cap nhat thong tin AcsToken that bai." + LogUtil.TraceData("expireTime", expireTime));
                        }
                        UpdateTokenReferrence(raw);
                        Inventec.Token.ResourceSystem.ResourceTokenManager.UpdateExpireTime(expireTime);

                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = false;
            }
            return result;
        }

        private async Task UpdateTokenReferrence(ACS_TOKEN token)
        {
            ACS.MANAGER.Token.TokenManager tokenManager = new ACS.MANAGER.Token.TokenManager();
            tokenManager.RemoveTokenInRam(new List<string> { token.TOKEN_CODE });
            await tokenManager.InitThreadSyncTokenDelete(token.TOKEN_CODE);

            Inventec.Token.AuthSystem.ExtraTokenData extraTokenData = tokenManager.GenerateExtraToken(token);
            tokenManager.InsertTokenInRam(extraTokenData);

            await tokenManager.InitThreadSyncTokenInsert(extraTokenData);

        }

        internal void RollbackData()
        {

        }
    }
}
