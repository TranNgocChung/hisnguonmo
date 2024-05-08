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
using Inventec.Core;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ACS.API.Controllers
{
    public partial class AcsModuleRoleController : BaseApiController
    {
        [HttpGet]
        [ApiParamFilter(typeof(ApiParam<ACS.MANAGER.Core.AcsModuleRole.Get.AcsModuleRoleFilterQuery>), "param")]
        [ActionName("Get")]
        public ApiResult Get(ApiParam<ACS.MANAGER.Core.AcsModuleRole.Get.AcsModuleRoleFilterQuery> param)
        {
            try
            {
                ApiResultObject<List<ACS_MODULE_ROLE>> result = new ApiResultObject<List<ACS_MODULE_ROLE>>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    Inventec.Backend.MANAGER.ManagerContainer managerContainer = new Inventec.Backend.MANAGER.ManagerContainer(typeof(AcsModuleRoleManager), "Get", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    List<ACS_MODULE_ROLE> resultData = managerContainer.Run<List<ACS_MODULE_ROLE>>();
                    result = PackResult<List<ACS_MODULE_ROLE>>(resultData);
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
        [ApiParamFilter(typeof(ApiParam<ACS.MANAGER.Core.AcsModuleRole.Get.AcsModuleRoleViewFilterQuery>), "param")]
        [ActionName("GetView")]
        public ApiResult GetView(ApiParam<ACS.MANAGER.Core.AcsModuleRole.Get.AcsModuleRoleViewFilterQuery> param)
        {
            try
            {
                ApiResultObject<List<V_ACS_MODULE_ROLE>> result = new ApiResultObject<List<V_ACS_MODULE_ROLE>>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    Inventec.Backend.MANAGER.ManagerContainer managerContainer = new Inventec.Backend.MANAGER.ManagerContainer(typeof(AcsModuleRoleManager), "Get", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    List<V_ACS_MODULE_ROLE> resultData = managerContainer.Run<List<V_ACS_MODULE_ROLE>>();
                    result = PackResult<List<V_ACS_MODULE_ROLE>>(resultData);
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
        public ApiResult Create(ApiParam<ACS_MODULE_ROLE> param)
        {
            try
            {
                ApiResultObject<ACS_MODULE_ROLE> result = new ApiResultObject<ACS_MODULE_ROLE>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    Inventec.Backend.MANAGER.ManagerContainer managerContainer = new Inventec.Backend.MANAGER.ManagerContainer(typeof(AcsModuleRoleManager), "Create", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    ACS_MODULE_ROLE resultData = managerContainer.Run<ACS_MODULE_ROLE>();
                    result = PackResult<ACS_MODULE_ROLE>(resultData);
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
        public ApiResult CreateList(ApiParam<List<ACS_MODULE_ROLE>> param)
        {
            try
            {
                ApiResultObject<List<ACS_MODULE_ROLE>> result = new ApiResultObject<List<ACS_MODULE_ROLE>>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    Inventec.Backend.MANAGER.ManagerContainer managerContainer = new Inventec.Backend.MANAGER.ManagerContainer(typeof(AcsModuleRoleManager), "Create", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    List<ACS_MODULE_ROLE> resultData = managerContainer.Run<List<ACS_MODULE_ROLE>>();
                    result = PackResult<List<ACS_MODULE_ROLE>>(resultData);
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
        public ApiResult Update(ApiParam<ACS_MODULE_ROLE> param)
        {
            try
            {
                ApiResultObject<ACS_MODULE_ROLE> result = new ApiResultObject<ACS_MODULE_ROLE>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    Inventec.Backend.MANAGER.ManagerContainer managerContainer = new Inventec.Backend.MANAGER.ManagerContainer(typeof(AcsModuleRoleManager), "Update", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    ACS_MODULE_ROLE resultData = managerContainer.Run<ACS_MODULE_ROLE>();
                    result = PackResult<ACS_MODULE_ROLE>(resultData);
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
        public ApiResult ChangeLock(ApiParam<ACS_MODULE_ROLE> param)
        {
            try
            {
                ApiResultObject<ACS_MODULE_ROLE> result = new ApiResultObject<ACS_MODULE_ROLE>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    Inventec.Backend.MANAGER.ManagerContainer managerContainer = new Inventec.Backend.MANAGER.ManagerContainer(typeof(AcsModuleRoleManager), "ChangeLock", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    ACS_MODULE_ROLE resultData = managerContainer.Run<ACS_MODULE_ROLE>();
                    result = PackResult<ACS_MODULE_ROLE>(resultData);
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
                    ACS_MODULE_ROLE data = new ACS_MODULE_ROLE();
                    data.ID = param.ApiData;
                    Inventec.Backend.MANAGER.ManagerContainer managerContainer = new Inventec.Backend.MANAGER.ManagerContainer(typeof(AcsModuleRoleManager), "Delete", new object[] { param.CommonParam }, new object[] { data });
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
                    Inventec.Backend.MANAGER.ManagerContainer managerContainer = new Inventec.Backend.MANAGER.ManagerContainer(typeof(AcsModuleRoleManager), "Delete", new object[] { param.CommonParam }, new object[] { param.ApiData });
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
