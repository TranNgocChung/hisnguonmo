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
using ACS.MANAGER.Core.AcsApplicationRole.Get;
using Inventec.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACS.MANAGER.Core.AcsRole.Get.ListEv
{
    class AcsRoleGetListEvBehaviorByFilterQuery : BeanObjectBase, IAcsRoleGetListEv
    {
        AcsRoleFilterQuery filterQuery;

        internal AcsRoleGetListEvBehaviorByFilterQuery(CommonParam param, AcsRoleFilterQuery filter)
            : base(param)
        {
            filterQuery = filter;
        }

        List<ACS_ROLE> IAcsRoleGetListEv.Run()
        {
            try
            {
                if (filterQuery.APPLICATION_ID > 0)
                {
                    //Lay danh sach role da duoc phan quyen cua 1 ung dung
                    AcsApplicationRoleViewFilterQuery applicationRoleViewFilterQuery = new AcsApplicationRole.Get.AcsApplicationRoleViewFilterQuery();
                    applicationRoleViewFilterQuery.APPLICATION_ID = filterQuery.APPLICATION_ID;
                    var appRoles = DAOWorker.AcsApplicationRoleDAO.GetView(applicationRoleViewFilterQuery.Query(), param);
                    if (appRoles != null)
                    {
                        filterQuery.IDs = appRoles.Select(o => o.ROLE_ID).Distinct().ToList();
                    }
                    else
                    {
                        filterQuery.ID = -1;
                    }
                }

                return DAOWorker.AcsRoleDAO.Get(filterQuery.Query(), param);
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
