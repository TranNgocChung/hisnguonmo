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
using Inventec.Core;
using System;

namespace ACS.MANAGER.Core.TokenSys
{
    partial class AcsTokenAuthenticationResource : BeanObjectBase, ITokenDelegacy
    {
        object entity;

        internal AcsTokenAuthenticationResource(CommonParam param, object data)
            : base(param)
        {
            entity = data;
        }

        ACS_USER ITokenDelegacy.Execute()
        {
            ACS_USER result = null;
            try
            {
                if (TypeCollection.AcsToken.Contains(entity.GetType()))
                {
                    ITokenSysAuthenticationResource behavior = TokenSysAuthenticationResourceBehaviorFactory.MakeIAcsTokenAuthentication(param, entity);
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
