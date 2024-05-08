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
using ACS.MANAGER.Core.TokenSys.Authentication;
using ACS.MANAGER.Core.TokenSys.LoginByAuthenRequest;
using ACS.MANAGER.Core.TokenSys.LoginByEmail;
using ACS.MANAGER.Core.TokenSys.LoginBySecretKey;
using ACS.SDO;
using System;
using System.Collections.Generic;

namespace ACS.MANAGER.Core.TokenSys
{
    partial class AcsTokenBO : BusinessObjectBase
    {
        internal AcsTokenBO()
            : base()
        {

        }

        internal ACS_USER Login(object data)
        {
            ACS_USER result = null;
            try
            {
                ITokenDelegacy delegacy = new AcsTokenLogin(param, data);
                result = delegacy.Execute();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = null;
            }
            return result;
        }

        internal Inventec.Token.Core.TokenData LoginBySecretKey(object data)
        {
            Inventec.Token.Core.TokenData result = null;
            try
            {
                ITokenSysLoginBySecretKey delegacy = new AcsTokenLoginBySecretKey(param, data);
                result = delegacy.Run();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = null;
            }
            return result;
        }

        internal Inventec.Token.Core.TokenData LoginByAuthenRequest(object data)
        {
            Inventec.Token.Core.TokenData result = null;
            try
            {
                ILoginByAuthenRequest delegacy = new AcsTokenLoginByAuthenRequest(param, data);
                result = delegacy.Run();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = null;
            }
            return result;
        }

        internal Inventec.Token.Core.TokenData LoginByEmail(object data)
        {
            Inventec.Token.Core.TokenData result = null;
            try
            {
                ITokenSysLoginByEmail delegacy = new AcsTokenLoginByEmail(param, data);
                result = delegacy.Run();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = null;
            }
            return result;
        }

        internal ACS.SDO.AcsAuthorizeSDO Authorize(object data)
        {
            ACS.SDO.AcsAuthorizeSDO result = null;
            try
            {
                IAuthorizeDelegacy delegacy = new AcsTokenAuthorize(param, data);
                result = delegacy.Execute();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = null;
            }
            return result;
        }

        internal ACS_USER AuthenticationResource(object data)
        {
            ACS_USER result = null;
            try
            {
                ITokenDelegacy delegacy = new AcsTokenAuthenticationResource(param, data);
                result = delegacy.Execute();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = null;
            }
            return result;
        }

        internal bool Authentication(object data)
        {
            bool result = false;
            try
            {
                var checkAutho = new AuthorizeRoleForUsers(param, (AcsTokenAuthenticationSDO)data).Run();
                result = (checkAutho != null && checkAutho.Count > 0);

                //IDelegacy delegacy = new AcsTokenAuthentication(param, data);
                //result = delegacy.Execute();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        internal bool SyncToken(object data)
        {
            bool result = false;
            try
            {
                IAcsTokenSync delegacy = new AcsTokenSync(param, data);
                result = delegacy.Run();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }
    }
}
