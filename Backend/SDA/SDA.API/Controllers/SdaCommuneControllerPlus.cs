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

namespace SDA.API.Controllers
{
    public partial class SdaCommuneController : BaseApiController
    {
        [HttpGet]
        [ApiParamFilter(typeof(ApiParam<SDA.MANAGER.Core.SdaCommune.Get.SdaCommuneViewFilterQuery>), "param")]
        [ActionName("GetView")]
        [AllowAnonymous]
        public ApiResult GetView(ApiParam<SDA.MANAGER.Core.SdaCommune.Get.SdaCommuneViewFilterQuery> param)
        {
            try
            {
                ApiResultObject<List<V_SDA_COMMUNE>> result = new ApiResultObject<List<V_SDA_COMMUNE>>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(SdaCommuneManager), "Get", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    List<V_SDA_COMMUNE> resultData = managerContainer.Run<List<V_SDA_COMMUNE>>();
                    result = PackResult<List<V_SDA_COMMUNE>>(resultData);
                }
                return new ApiResult(result, this.ActionContext);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                return null;
            }
        }

        [HttpGet]
        [ApiParamFilter(typeof(ApiParam<SDA.MANAGER.Core.SdaCommune.Get.SdaCommuneViewFilterQuery>), "param")]
        [ActionName("GetViewZip")]
        [AllowAnonymous]
        public ApiResultZip GetViewZip(ApiParam<SDA.MANAGER.Core.SdaCommune.Get.SdaCommuneViewFilterQuery> param)
        {
            try
            {
                ApiResultObject<List<V_SDA_COMMUNE>> result = new ApiResultObject<List<V_SDA_COMMUNE>>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(SdaCommuneManager), "Get", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    List<V_SDA_COMMUNE> resultData = managerContainer.Run<List<V_SDA_COMMUNE>>();
                    result = PackResult<List<V_SDA_COMMUNE>>(resultData);
                }
                return new ApiResultZip(result, this.ActionContext);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                return null;
            }
        }

        [HttpGet]
        [ApiParamFilter(typeof(ApiParam<SDA.MANAGER.Core.SdaCommune.Get.SdaCommuneViewFilterQuery>), "param")]
        [ActionName("GetViewDynamic")]
        [AllowAnonymous]
        public ApiResultZip GetViewDynamic(ApiParam<SDA.MANAGER.Core.SdaCommune.Get.SdaCommuneViewFilterQuery> param)
        {
            try
            {
                ApiResultObject<List<object>> result = new ApiResultObject<List<object>>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(SdaCommuneManager), "GetDynamic", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    List<object> resultData = managerContainer.Run<List<object>>();
                    result = PackResult<List<object>>(resultData);
                }
                return new ApiResultZip(result, this.ActionContext);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                return null;
            }
        }
    }
}
