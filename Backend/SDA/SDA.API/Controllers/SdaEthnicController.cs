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
    public partial class SdaEthnicController : BaseApiController
    {
        [HttpGet]
        [ApiParamFilter(typeof(ApiParam<SDA.MANAGER.Core.SdaEthnic.Get.SdaEthnicFilterQuery>), "param")]
        [ActionName("Get")]
        [AllowAnonymous]
        public ApiResult Get(ApiParam<SDA.MANAGER.Core.SdaEthnic.Get.SdaEthnicFilterQuery> param)
        {
            try
            {
                ApiResultObject<List<SDA_ETHNIC>> result = new ApiResultObject<List<SDA_ETHNIC>>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(SdaEthnicManager), "Get", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    List<SDA_ETHNIC> resultData = managerContainer.Run<List<SDA_ETHNIC>>();
                    result = PackResult<List<SDA_ETHNIC>>(resultData);
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
        [ActionName("Create")]
        public ApiResult Create(ApiParam<SDA_ETHNIC> param)
        {
            try
            {
                ApiResultObject<SDA_ETHNIC> result = new ApiResultObject<SDA_ETHNIC>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(SdaEthnicManager), "Create", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    SDA_ETHNIC resultData = managerContainer.Run<SDA_ETHNIC>();
                    result = PackResult<SDA_ETHNIC>(resultData);
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
        [ActionName("Update")]
        public ApiResult Update(ApiParam<SDA_ETHNIC> param)
        {
            try
            {
                ApiResultObject<SDA_ETHNIC> result = new ApiResultObject<SDA_ETHNIC>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(SdaEthnicManager), "Update", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    SDA_ETHNIC resultData = managerContainer.Run<SDA_ETHNIC>();
                    result = PackResult<SDA_ETHNIC>(resultData);
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
        [ActionName("ChangeLock")]
        public ApiResult ChangeLock(ApiParam<SDA_ETHNIC> param)
        {
            try
            {
                ApiResultObject<SDA_ETHNIC> result = new ApiResultObject<SDA_ETHNIC>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(SdaEthnicManager), "ChangeLock", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    SDA_ETHNIC resultData = managerContainer.Run<SDA_ETHNIC>();
                    result = PackResult<SDA_ETHNIC>(resultData);
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
        [ActionName("Delete")]
        public ApiResult Delete(ApiParam<SDA_ETHNIC> param)
        {
            try
            {
                ApiResultObject<bool> result = new ApiResultObject<bool>(false, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(SdaEthnicManager), "Delete", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    bool resultData = managerContainer.Run<bool>();
                    result = PackResult<bool>(resultData);
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
        [ApiParamFilter(typeof(ApiParam<SDA.MANAGER.Core.SdaEthnic.Get.SdaEthnicFilterQuery>), "param")]
        [ActionName("GetDynamic")]
        [AllowAnonymous]
        public ApiResult GetDynamic(ApiParam<SDA.MANAGER.Core.SdaEthnic.Get.SdaEthnicFilterQuery> param)
        {
            try
            {
                ApiResultObject<List<object>> result = new ApiResultObject<List<object>>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(SdaEthnicManager), "GetDynamic", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    List<object> resultData = managerContainer.Run<List<object>>();
                    result = PackResult<List<object>>(resultData);
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
