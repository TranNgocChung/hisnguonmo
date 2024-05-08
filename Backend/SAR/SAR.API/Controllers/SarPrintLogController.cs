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
using SAR.API.Base;
using SAR.EFMODEL.DataModels;
using SAR.MANAGER.Manager;
using Inventec.Core;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SAR.API.Controllers
{
    public partial class SarPrintLogController : BaseApiController
    {
        [HttpGet]
        [ApiParamFilter(typeof(ApiParam<SAR.MANAGER.Core.SarPrintLog.Get.SarPrintLogFilterQuery>), "param")]
        [ActionName("Get")]
        [AllowAnonymous]
        public ApiResult Get(ApiParam<SAR.MANAGER.Core.SarPrintLog.Get.SarPrintLogFilterQuery> param)
        {
            try
            {
                ApiResultObject<List<SAR_PRINT_LOG>> result = new ApiResultObject<List<SAR_PRINT_LOG>>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(SarPrintLogManager), "Get", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    List<SAR_PRINT_LOG> resultData = managerContainer.Run<List<SAR_PRINT_LOG>>();
                    result = PackResult<List<SAR_PRINT_LOG>>(resultData);
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
        public ApiResult Create(ApiParam<SDO.SarPrintLogSDO> param)
        {
            try
            {
                ApiResultObject<SDO.SarPrintLogSDO> result = new ApiResultObject<SDO.SarPrintLogSDO>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(SarPrintLogManager), "Create", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    SDO.SarPrintLogSDO resultData = managerContainer.Run<SDO.SarPrintLogSDO>();
                    result = PackResult<SDO.SarPrintLogSDO>(resultData);
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
        public ApiResult Update(ApiParam<SAR_PRINT_LOG> param)
        {
            try
            {
                ApiResultObject<SAR_PRINT_LOG> result = new ApiResultObject<SAR_PRINT_LOG>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(SarPrintLogManager), "Update", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    SAR_PRINT_LOG resultData = managerContainer.Run<SAR_PRINT_LOG>();
                    result = PackResult<SAR_PRINT_LOG>(resultData);
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
        public ApiResult ChangeLock(ApiParam<SAR_PRINT_LOG> param)
        {
            try
            {
                ApiResultObject<SAR_PRINT_LOG> result = new ApiResultObject<SAR_PRINT_LOG>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(SarPrintLogManager), "ChangeLock", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    SAR_PRINT_LOG resultData = managerContainer.Run<SAR_PRINT_LOG>();
                    result = PackResult<SAR_PRINT_LOG>(resultData);
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
        public ApiResult Delete(ApiParam<long> param)
        {
            try
            {
                ApiResultObject<bool> result = new ApiResultObject<bool>(false, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    SAR_PRINT_LOG data = new SAR_PRINT_LOG();
                    data.ID = param.ApiData;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(SarPrintLogManager), "Delete", new object[] { param.CommonParam }, new object[] { data });
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
    }
}
