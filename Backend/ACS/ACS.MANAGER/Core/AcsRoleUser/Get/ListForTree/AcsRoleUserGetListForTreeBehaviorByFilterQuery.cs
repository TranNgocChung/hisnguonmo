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
using ACS.MANAGER.Core.AcsRole.Get;
using ACS.SDO;
using Inventec.Core;
using System;
using System.Collections.Generic;

namespace ACS.MANAGER.Core.AcsRoleUser.Get.ListForTree
{
    class AcsRoleUserGetListForTreeBehaviorByFilterQuery : BeanObjectBase, IAcsRoleUserGetListForTree
    {
        AcsRoleUserViewFilterQuery filterQuery;

        internal AcsRoleUserGetListForTreeBehaviorByFilterQuery(CommonParam param, AcsRoleUserViewFilterQuery filter)
            : base(param)
        {
            filterQuery = filter;
        }

        List<AcsRoleUserSDO> IAcsRoleUserGetListForTree.Run()
        {
            try
            {
                List<AcsRoleUserSDO> result = new List<AcsRoleUserSDO>();
                AcsRoleFilterQuery roleFilterQuery = new AcsRole.Get.AcsRoleFilterQuery();
                roleFilterQuery.KEY_WORD = filterQuery.KEY_WORD;
                var roles = DAOWorker.AcsRoleDAO.Get(roleFilterQuery.Query(), param);
                if (roles != null && roles.Count > 0)
                {
                    foreach (var item in roles)
                    {
                        AcsRoleUserSDO sdoRoleUser = new AcsRoleUserSDO();
                        sdoRoleUser.ROLE_ID = item.ID;
                        sdoRoleUser.ROLE_CODE = item.ROLE_CODE;
                        sdoRoleUser.ROLE_NAME = item.ROLE_NAME;
                        result.Add(sdoRoleUser);
                    }
                }
                var roleUsers = DAOWorker.AcsRoleUserDAO.GetView(filterQuery.Query(), param);
                if (roleUsers != null && roleUsers.Count > 0)
                {
                    foreach (var item in result)
                    {
                        var chkItem = roleUsers.Find(o => o.ROLE_ID == item.ROLE_ID);
                        if (chkItem != null)
                        {
                            item.USER_ID = chkItem.USER_ID;
                            item.USERNAME = chkItem.USERNAME;
                            item.LOGINNAME = chkItem.LOGINNAME;
                        }
                    }
                }

                return result;
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
