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
    public partial class SarUserReportTypeController : BaseApiController
    {
        [HttpGet]
        [ApiParamFilter(typeof(ApiParam<SAR.MANAGER.Core.SarUserReportType.Get.SarUserReportTypeFilterQuery>), "param")]
        [ActionName("Get")]
        [AllowAnonymous]
        public ApiResult Get(ApiParam<SAR.MANAGER.Core.SarUserReportType.Get.SarUserReportTypeFilterQuery> param)
        {
            try
            {
                ApiResultObject<List<SAR_USER_REPORT_TYPE>> result = new ApiResultObject<List<SAR_USER_REPORT_TYPE>>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(SarUserReportTypeManager), "Get", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    List<SAR_USER_REPORT_TYPE> resultData = managerContainer.Run<List<SAR_USER_REPORT_TYPE>>();
                    result = PackResult<List<SAR_USER_REPORT_TYPE>>(resultData);
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
        [ApiParamFilter(typeof(ApiParam<SAR.MANAGER.Core.SarUserReportType.Get.SarUserReportTypeViewFilterQuery>), "param")]
        [ActionName("GetView")]
        [AllowAnonymous]
        public ApiResult GetView(ApiParam<SAR.MANAGER.Core.SarUserReportType.Get.SarUserReportTypeViewFilterQuery> param)
        {
            try
            {
                ApiResultObject<List<V_SAR_USER_REPORT_TYPE>> result = new ApiResultObject<List<V_SAR_USER_REPORT_TYPE>>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(SarUserReportTypeManager), "Get", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    List<V_SAR_USER_REPORT_TYPE> resultData = managerContainer.Run<List<V_SAR_USER_REPORT_TYPE>>();
                    result = PackResult<List<V_SAR_USER_REPORT_TYPE>>(resultData);
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
        public ApiResult Create(ApiParam<SAR_USER_REPORT_TYPE> param)
        {
            try
            {
                ApiResultObject<SAR_USER_REPORT_TYPE> result = new ApiResultObject<SAR_USER_REPORT_TYPE>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(SarUserReportTypeManager), "Create", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    SAR_USER_REPORT_TYPE resultData = managerContainer.Run<SAR_USER_REPORT_TYPE>();
                    result = PackResult<SAR_USER_REPORT_TYPE>(resultData);
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
        [ActionName("CreateList")]
        public ApiResult CreateList(ApiParam<List<SAR_USER_REPORT_TYPE>> param)
        {
            try
            {
                ApiResultObject<List<SAR_USER_REPORT_TYPE>> result = new ApiResultObject<List<SAR_USER_REPORT_TYPE>>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(SarUserReportTypeManager), "CreateList", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    List<SAR_USER_REPORT_TYPE> resultData = managerContainer.Run<List<SAR_USER_REPORT_TYPE>>();
                    result = PackResult<List<SAR_USER_REPORT_TYPE>>(resultData);
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
        [ActionName("DeleteList")]
        public ApiResult DeleteList(ApiParam<List<long>> param)
        {
            try
            {
                ApiResultObject<bool> result = new ApiResultObject<bool>(false, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(SarUserReportTypeManager), "DeleteList", new object[] { param.CommonParam }, new object[] { param.ApiData });
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

        [HttpPost]
        [ActionName("Update")]
        public ApiResult Update(ApiParam<SAR_USER_REPORT_TYPE> param)
        {
            try
            {
                ApiResultObject<SAR_USER_REPORT_TYPE> result = new ApiResultObject<SAR_USER_REPORT_TYPE>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(SarUserReportTypeManager), "Update", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    SAR_USER_REPORT_TYPE resultData = managerContainer.Run<SAR_USER_REPORT_TYPE>();
                    result = PackResult<SAR_USER_REPORT_TYPE>(resultData);
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
        public ApiResult ChangeLock(ApiParam<SAR_USER_REPORT_TYPE> param)
        {
            try
            {
                ApiResultObject<SAR_USER_REPORT_TYPE> result = new ApiResultObject<SAR_USER_REPORT_TYPE>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(SarUserReportTypeManager), "ChangeLock", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    SAR_USER_REPORT_TYPE resultData = managerContainer.Run<SAR_USER_REPORT_TYPE>();
                    result = PackResult<SAR_USER_REPORT_TYPE>(resultData);
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
        public ApiResult Delete(ApiParam<SAR_USER_REPORT_TYPE> param)
        {
            try
            {
                ApiResultObject<bool> result = new ApiResultObject<bool>(false, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(SarUserReportTypeManager), "Delete", new object[] { param.CommonParam }, new object[] { param.ApiData });
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

        [HttpPost]
        [ActionName("CopyByUser")]
        public ApiResult CopyByUser(ApiParam<SDO.SarUserReportTypeCopyByUserSDO> param)
        {
            try
            {
                ApiResultObject<List<SAR_USER_REPORT_TYPE>> result = new ApiResultObject<List<SAR_USER_REPORT_TYPE>>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(SarUserReportTypeManager), "Copy", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    List<SAR_USER_REPORT_TYPE> resultData = managerContainer.Run<List<SAR_USER_REPORT_TYPE>>();
                    result = PackResult<List<SAR_USER_REPORT_TYPE>>(resultData);
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
        [ActionName("CopyByReportType")]
        public ApiResult CopyByReportType(ApiParam<SDO.SarUserReportTypeCopyByReportTypeSDO> param)
        {
            try
            {
                ApiResultObject<List<SAR_USER_REPORT_TYPE>> result = new ApiResultObject<List<SAR_USER_REPORT_TYPE>>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(SarUserReportTypeManager), "Copy", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    List<SAR_USER_REPORT_TYPE> resultData = managerContainer.Run<List<SAR_USER_REPORT_TYPE>>();
                    result = PackResult<List<SAR_USER_REPORT_TYPE>>(resultData);
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
