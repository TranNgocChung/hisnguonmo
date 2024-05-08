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
using ACS.API.Base;
using ACS.Filter;
using ACS.MANAGER.UserSchedulerJob;
using ACS.SDO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ACS.API.Controllers
{
    public class UserSchedulerJobController : ApiController
    {
        [HttpGet]
        [ApiParamFilter(typeof(ApiParam<UserSchedulerJobFilter>), "param")]
        [ActionName("Get")]
        public ApiResult Get(ApiParam<UserSchedulerJobFilter> param)
        {
            try
            {
                ApiResultObject<List<UserSchedulerJobResultSDO>> result = null;
                if (param != null)
                {
                    UserSchedulerJobManager mng = new UserSchedulerJobManager(param.CommonParam);
                    result = mng.Get(param.ApiData);
                }
                return new ApiResult(result, this.ActionContext);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                return null;
            }
        }
    }
}
