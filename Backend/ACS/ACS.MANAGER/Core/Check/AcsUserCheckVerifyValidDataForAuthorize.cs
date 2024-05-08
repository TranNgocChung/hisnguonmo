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
using ACS.EFMODEL.DataModels;
using ACS.MANAGER.Core.AcsUser;
using Inventec.Core;
using System;
using System.Collections.Generic;

namespace ACS.MANAGER.Core.Check
{
    class AcsUserCheckVerifyValidDataForAuthorize
    {
        internal static bool Verify(CommonParam param, ref ACS_USER user, string loginName)
        {
            bool result = false;
            try
            {
                if (!String.IsNullOrEmpty(loginName))
                {
                    user = new AcsUserBO().Get<ACS_USER>(loginName);
                    if (user != null && user.ID > 0)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
                param.HasException = true;
            }

            if (!result)
            {
                ACS.MANAGER.Base.MessageUtil.SetMessage(param, LibraryMessage.Message.Enum.Core_AcsUser_TenDangNhapHoacMatKhauKhongChinhXac);
            }

            return result;
        }
    }
}
