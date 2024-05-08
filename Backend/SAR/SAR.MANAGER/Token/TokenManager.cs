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
using Inventec.Core;
using Inventec.Token.AuthSystem;
using SAR.MANAGER.Base;
using System;
using System.Web.Http.Controllers;

namespace SAR.MANAGER.Token
{
    /// <summary>
    /// Khong cho phep thua ke
    /// </summary>
    public sealed partial class TokenManager : BusinessBase
    {
        AuthTokenManager authManager;

        public TokenManager()
            : base()
        {

        }

        public TokenManager(CommonParam param)
            : base(param)
        {

        }

        public ApiResultObject<Inventec.Token.Core.TokenData> Login(HttpActionContext httpActionContext)
        {
            ApiResultObject<Inventec.Token.Core.TokenData> result = new ApiResultObject<Inventec.Token.Core.TokenData>(null, false);
            try
            {
                Inventec.Token.Core.TokenData token = Inventec.Token.Manager.Login(httpActionContext);
                if (token != null)
                {
                    result = new ApiResultObject<Inventec.Token.Core.TokenData>(token, true);
                }
                else
                    result.SetValue(null, false, param);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = new ApiResultObject<Inventec.Token.Core.TokenData>(null, false);
            }
            return result;
        }

        public ApiResultObject<bool> ChangePassword(string oldPassword, string newPassword)
        {
            ApiResultObject<bool> result = new ApiResultObject<bool>(false);
            try
            {
                bool success = Inventec.Token.Manager.ChangePassword(oldPassword, newPassword);
                result = new ApiResultObject<bool>(success, success);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = new ApiResultObject<bool>(false);
            }
            return result;
        }

        public ApiResultObject<bool> Logout()
        {
            ApiResultObject<bool> result = new ApiResultObject<bool>(false);
            try
            {
                bool success = Inventec.Token.Manager.Logout();
                result = new ApiResultObject<bool>(success, success);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = new ApiResultObject<bool>(false);
            }
            return result;
        }
    }
}
