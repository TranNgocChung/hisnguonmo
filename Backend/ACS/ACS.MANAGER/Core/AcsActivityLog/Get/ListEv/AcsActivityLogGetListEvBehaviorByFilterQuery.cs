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

namespace ACS.MANAGER.Core.AcsActivityLog.Get.ListEv
{
    class AcsActivityLogGetListEvBehaviorByFilterQuery : BeanObjectBase, IAcsActivityLogGetListEv
    {
        AcsActivityLogFilterQuery filterQuery;

        internal AcsActivityLogGetListEvBehaviorByFilterQuery(CommonParam param, AcsActivityLogFilterQuery filter)
            : base(param)
        {
            filterQuery = filter;
        }

        List<ACS_ACTIVITY_LOG> IAcsActivityLogGetListEv.Run()
        {
            try
            {
                return DAOWorker.AcsActivityLogDAO.Get(filterQuery.Query(), param);
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
