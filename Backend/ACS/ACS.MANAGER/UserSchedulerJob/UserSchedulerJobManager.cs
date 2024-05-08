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
using Inventec.Common.Logging;
using Inventec.Core;
using ACS.EFMODEL.DataModels;
using ACS.MANAGER.Base;
using ACS.SDO;
using System;
using System.Linq;
using System.Collections.Generic;
using ACS.Filter;
using Inventec.Backend.MANAGER;

namespace ACS.MANAGER.UserSchedulerJob
{

    public class UserSchedulerJobManager : ACS.MANAGER.Base.BusinessBase
    {
        public UserSchedulerJobManager()
            : base()
        {

        }

        public UserSchedulerJobManager(CommonParam param)
            : base(param)
        {

        }

        [Logger]
        public ApiResultObject<List<UserSchedulerJobResultSDO>> Get(UserSchedulerJobFilter filter)
        {
            ApiResultObject<List<UserSchedulerJobResultSDO>> result = null;
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(filter);
                List<UserSchedulerJobResultSDO> resultData = null;
                if (valid)
                {
                    resultData = new UserSchedulerJobGetSql(param).Get(filter);
                }
                result = this.PackSuccess(resultData);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }

            return result;
        }
    }
}
