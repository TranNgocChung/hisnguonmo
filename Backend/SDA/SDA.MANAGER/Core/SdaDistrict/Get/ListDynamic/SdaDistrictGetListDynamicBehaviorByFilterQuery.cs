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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDA.MANAGER.Core.SdaDistrict.Get.ListDynamic
{
    class SdaDistrictGetListDynamicBehaviorByFilterQuery: DynamicBase, ISdaDistrictGetListDynamic
    {
        SdaDistrictViewFilterQuery filterQuery;

        internal SdaDistrictGetListDynamicBehaviorByFilterQuery(CommonParam param, SdaDistrictViewFilterQuery filter)
            : base(param)
        {
            filterQuery = filter;
        }

        List<object> ISdaDistrictGetListDynamic.Run()
        {
            List<object> result = new List<object>();
            try
            {
                result = this.RunBase("V_SDA_DISTRICT", filterQuery);
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
            if (filterQuery.PROVINCE_ID.HasValue)
            {
                strFilterCondition += string.Format(" AND PROVINCE_ID = {0}", filterQuery.PROVINCE_ID.Value);
            }
            return strFilterCondition;
        }
    }
}
