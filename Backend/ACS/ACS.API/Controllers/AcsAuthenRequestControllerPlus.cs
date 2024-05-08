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
using ACS.EFMODEL.DataModels;
using ACS.MANAGER.AcsAuthenRequest;
using System;
using System.Collections.Generic;
using System.Web.Http;
using ACS.SDO;

namespace ACS.API.Controllers
{
    public partial class AcsAuthenRequestController : BaseApiController
    {
        [AllowAnonymous]
        [HttpPost]
        [ActionName("AuthenRequest")]
        public ApiResult AuthenRequest(ApiParam<AuthenRequestTDO> param)
        {
            try
            {
                ApiResultObject<bool> result = new ApiResultObject<bool>(false);
                if (param != null)
                {
                    AcsAuthenRequestManager mng = new AcsAuthenRequestManager(param.CommonParam);
                    result = mng.AuthenRequest(param.ApiData, this.ActionContext);
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
