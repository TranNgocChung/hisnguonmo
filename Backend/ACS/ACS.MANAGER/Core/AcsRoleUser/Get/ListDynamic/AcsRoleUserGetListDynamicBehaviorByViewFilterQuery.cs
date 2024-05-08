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
using System.Collections.Generic;
using System.Linq;

namespace ACS.MANAGER.Core.AcsRoleUser.Get.ListDynamic
{
    class AcsRoleUserGetListDynamicBehaviorByViewFilterQuery : DynamicBase, IAcsRoleUserGetListDynamic
    {
        AcsRoleUserViewFilterQuery filterQuery;

        internal AcsRoleUserGetListDynamicBehaviorByViewFilterQuery(CommonParam param, AcsRoleUserViewFilterQuery filter)
            : base(param)
        {
            filterQuery = filter;
        }

        List<object> IAcsRoleUserGetListDynamic.Run()
        {
            List<object> result = new List<object>();
            try
            {
                result = this.RunBase("V_ACS_ROLE_USER", filterQuery);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
            return result;
        }

        protected override string ProcessFilterQuery()
        {
            string strFilterCondition = "";
            if (filterQuery.USER_ID.HasValue)
            {
                strFilterCondition += string.Format(" AND USER_ID = {0}", filterQuery.USER_ID.Value);
            }
            if (filterQuery.ROLE_ID.HasValue)
            {
                strFilterCondition += string.Format(" AND ROLE_ID = {0}", filterQuery.ROLE_ID.Value);
            }
            if (!String.IsNullOrEmpty(filterQuery.LOGINNAME))
            {
                strFilterCondition += string.Format(" AND LOGINNAME = \"{0}\"", filterQuery.LOGINNAME);
            }
            if (!String.IsNullOrEmpty(filterQuery.ROLE_CODE))
            {
                strFilterCondition += string.Format(" AND ROLE_CODE = \"{0}\"", filterQuery.ROLE_CODE);
            }
            return strFilterCondition;
        }
    }
}
