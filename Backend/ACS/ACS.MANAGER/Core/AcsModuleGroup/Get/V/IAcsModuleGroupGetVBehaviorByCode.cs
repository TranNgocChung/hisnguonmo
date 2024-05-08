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
using ACS.MANAGER.Base;
using Inventec.Core;
using System;

namespace ACS.MANAGER.Core.AcsModuleGroup.Get.V
{
    class AcsModuleGroupGetVBehaviorByCode : BeanObjectBase, IAcsModuleGroupGetV
    {
        string code;

        internal AcsModuleGroupGetVBehaviorByCode(CommonParam param, string filter)
            : base(param)
        {
            code = filter;
        }

        V_ACS_MODULE_GROUP IAcsModuleGroupGetV.Run()
        {
            try
            {
                return DAOWorker.AcsModuleGroupDAO.GetViewByCode(code, new AcsModuleGroupViewFilterQuery().Query());
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }
    }
}
