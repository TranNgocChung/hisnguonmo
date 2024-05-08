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
using ACS.MANAGER.Core.AcsUser.CopyRole;
using ACS.MANAGER.Core.AcsUser.Create;
using Inventec.Core;
using System;
using System.Collections.Generic;

namespace ACS.MANAGER.Core.AcsUser
{
    partial class AcsUserCopyRole : BeanObjectBase, IAcsUserCopyRole
    {
        object entity;

        internal AcsUserCopyRole(CommonParam param, object data)
            : base(param)
        {
            entity = data;
        }
        
        public List<ACS_ROLE_USER> Run()
        {
            List<ACS_ROLE_USER> result = null;
            try
            {
                if (TypeCollection.AcsUser.Contains(entity.GetType()))
                {
                    IAcsUserCopyRole behavior = AcsUserCopyRoleBehaviorFactory.MakeIAcsUserCopyRole(param, entity);
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
