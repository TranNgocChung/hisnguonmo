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
using ACS.API.Base;
using ACS.EFMODEL.DataModels;
using ACS.MANAGER.Manager;
using ACS.SDO;
using Inventec.Backend.MANAGER;
using Inventec.Core;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ACS.API.Controllers
{
    public partial class AcsApplicationController : BaseApiController
    {
        [HttpPost]
        [ActionName("CreateSdo")]
        public ApiResult CreateSdo(ApiParam<AcsApplicationWithDataSDO> param)
        {
            try
            {
                ApiResultObject<AcsApplicationWithDataSDO> result = new ApiResultObject<AcsApplicationWithDataSDO>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(AcsApplicationManager), "Create", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    AcsApplicationWithDataSDO resultData = managerContainer.Run<AcsApplicationWithDataSDO>();
                    result = PackResult<AcsApplicationWithDataSDO>(resultData);
                }
                return new ApiResult(result, this.ActionContext);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                return null;
            }
        }

        [HttpPost]
        [ActionName("UpdateSdo")]
        public ApiResult UpdateSdo(ApiParam<AcsApplicationWithDataSDO> param)
        {
            try
            {
                ApiResultObject<AcsApplicationWithDataSDO> result = new ApiResultObject<AcsApplicationWithDataSDO>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(AcsApplicationManager), "Update", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    AcsApplicationWithDataSDO resultData = managerContainer.Run<AcsApplicationWithDataSDO>();
                    result = PackResult<AcsApplicationWithDataSDO>(resultData);
                }
                return new ApiResult(result, this.ActionContext);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                return null;
            }
        }
               
    }
}
