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
using ACS.MANAGER.Core.TokenSys.Login;
using ACS.MANAGER.Core.TokenSys.LoginByEmail;
using Inventec.Core;
using System;

namespace ACS.MANAGER.Core.TokenSys
{
    partial class AcsTokenLoginByEmail : BeanObjectBase, ITokenSysLoginByEmail
    {
        object entity;

        internal AcsTokenLoginByEmail(CommonParam param, object data)
            : base(param)
        {
            entity = data;
        }

        Inventec.Token.Core.TokenData ITokenSysLoginByEmail.Run()
        {
            Inventec.Token.Core.TokenData result = null;
            try
            {
                if (TypeCollection.AcsToken.Contains(entity.GetType()))
                {
                    ITokenSysLoginByEmail behavior = TokenSysLoginByEmailBehaviorFactory.MakeIAcsTokenLoginByEmail(param, entity);
                    result = behavior != null ? behavior.Run() : null;
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = null;
            }
            return result;
        }
    }
}
