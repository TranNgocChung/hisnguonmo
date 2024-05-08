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
using SDA.EFMODEL.DataModels;
using SDA.MANAGER.Base;
using Inventec.Core;
using System;
using System.Collections.Generic;

namespace SDA.MANAGER.Core.SdaTrouble.Get.ListEv
{
    class SdaTroubleGetListEvBehaviorByFilterQuery : BeanObjectBase, ISdaTroubleGetListEv
    {
        SdaTroubleFilterQuery filterQuery;

        internal SdaTroubleGetListEvBehaviorByFilterQuery(CommonParam param, SdaTroubleFilterQuery filter)
            : base(param)
        {
            filterQuery = filter;
        }

        List<SDA_TROUBLE> ISdaTroubleGetListEv.Run()
        {
            try
            {
                return DAOWorker.SdaTroubleDAO.Get(filterQuery.Query(), param);
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
