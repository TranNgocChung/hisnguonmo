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

namespace ACS.MANAGER.AcsToken
{
    partial class AcsTokenUpdate : BusinessBase
    {
		private List<ACS_TOKEN> beforeUpdateAcsTokens = new List<ACS_TOKEN>();
		
        internal AcsTokenUpdate()
            : base()
        {

        }

        internal AcsTokenUpdate(CommonParam paramUpdate)
            : base(paramUpdate)
        {

        }

        internal bool Update(ACS_TOKEN data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                AcsTokenCheck checker = new AcsTokenCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                ACS_TOKEN raw = null;
                valid = valid && checker.VerifyId(data.ID, ref raw);
                valid = valid && checker.IsUnLock(raw);
                valid = valid && checker.ExistsCode(data.TOKEN_CODE, data.ID);
                if (valid)
                {
					if (!DAOWorker.AcsTokenDAO.Update(data))
                    {
                        ACS.MANAGER.Base.BugUtil.SetBugCode(param, ACS.LibraryBug.Bug.Enum.AcsToken_CapNhatThatBai);
                        throw new Exception("Cap nhat thong tin AcsToken that bai." + LogUtil.TraceData("data", data));
                    }
					
					this.beforeUpdateAcsTokens.Add(raw);
                    
                    result = true;
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

        internal bool UpdateList(List<ACS_TOKEN> listData)
        {
            bool result = false;
            try
            {
                bool valid = true;
                valid = IsNotNullOrEmpty(listData);
                AcsTokenCheck checker = new AcsTokenCheck(param);
                List<ACS_TOKEN> listRaw = new List<ACS_TOKEN>();
                List<long> listId = listData.Select(o => o.ID).ToList();
                valid = valid && checker.VerifyIds(listId, listRaw);
                valid = valid && checker.IsUnLock(listRaw);
                foreach (var data in listData)
                {
                    valid = valid && checker.VerifyRequireField(data);
                    valid = valid && checker.ExistsCode(data.TOKEN_CODE, data.ID);
                }
                if (valid)
                {
					if (!DAOWorker.AcsTokenDAO.UpdateList(listData))
                    {
                        ACS.MANAGER.Base.BugUtil.SetBugCode(param, ACS.LibraryBug.Bug.Enum.AcsToken_CapNhatThatBai);
                        throw new Exception("Cap nhat thong tin AcsToken that bai." + LogUtil.TraceData("listData", listData));
                    }
					this.beforeUpdateAcsTokens.AddRange(listRaw);
                    result = true;
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
		
		internal void RollbackData()
        {
            if (IsNotNullOrEmpty(this.beforeUpdateAcsTokens))
            {
                if (!DAOWorker.AcsTokenDAO.UpdateList(this.beforeUpdateAcsTokens))
                {
                    LogSystem.Warn("Rollback du lieu AcsToken that bai, can kiem tra lai." + LogUtil.TraceData("AcsTokens", this.beforeUpdateAcsTokens));
                }
				this.beforeUpdateAcsTokens = null;
            }
        }
    }
}
