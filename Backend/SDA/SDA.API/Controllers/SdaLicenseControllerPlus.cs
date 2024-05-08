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
using SDA.API.Base;
using SDA.EFMODEL.DataModels;
using SDA.MANAGER.Manager;
using Inventec.Core;
using System;
using System.Collections.Generic;
using System.Web.Http;
using SDA.SDO;

namespace SDA.API.Controllers
{
    public partial class SdaLicenseController : BaseApiController
    {
        [HttpGet]
        [ApiParamFilter(typeof(ApiParam<SDA.MANAGER.Core.SdaLicense.Get.SdaLicenseFilterQuery>), "param")]
        [ActionName("GetLast")]
        [AllowAnonymous]
        public ApiResult GetLast(ApiParam<SDA.MANAGER.Core.SdaLicense.Get.SdaLicenseFilterQuery> param)
        {
            try
            {
                ApiResultObject<SDA_LICENSE> result = new ApiResultObject<SDA_LICENSE>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(SdaLicenseManager), "GetLast", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    SDA_LICENSE resultData = managerContainer.Run<SDA_LICENSE>();
                    result = PackResult<SDA_LICENSE>(resultData);
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
        [ActionName("Decode")]
        public ApiResult Decode(ApiParam<string> param)
        {
            try
            {
                ApiResultObject<SdaLicenseSDO> result = new ApiResultObject<SdaLicenseSDO>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(SdaLicenseManager), "Decode", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    SdaLicenseSDO resultData = managerContainer.Run<SdaLicenseSDO>();
                    result = PackResult<SdaLicenseSDO>(resultData);
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
