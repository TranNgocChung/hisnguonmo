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
using SAR.MANAGER.Token;
using Inventec.Common.Logging;
using Inventec.Core;
using Inventec.Token;
using System;
using System.Web.Http;

namespace SAR.API.Controllers
{
    public class TokenController : BaseApiController
    {
        [HttpGet]
        [ApiParamFilter(typeof(ApiParam<string>), "param")]
        [ActionName("UpdateLanguage")]
        public ApiResult UpdateLanguage(ApiParam<string> param)
        {
            try
            {
                TokenManager mng = new TokenManager();
                ApiResultObject<bool> result = mng.UpdateLanguage(param.ApiData);
                return new ApiResult(result, this.ActionContext);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                return null;
            }
        }

        [HttpGet]
        [ApiParamFilter(typeof(ApiParam<string>), "param")]
        [ActionName("GetLanguage")]
        public ApiResult GetLanguage(ApiParam<string> param)
        {
            try
            {
                TokenManager mng = new TokenManager();
                ApiResultObject<string> result = mng.GetLanguage();
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
