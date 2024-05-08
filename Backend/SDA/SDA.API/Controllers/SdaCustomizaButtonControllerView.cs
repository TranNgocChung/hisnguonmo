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
using SDA.API.Base;
using SDA.EFMODEL.DataModels;
using SDA.MANAGER.SdaCustomizaButton;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SDA.API.Controllers
{
    public partial class SdaCustomizaButtonController : BaseApiController
    {
        [HttpGet]
        [ApiParamFilter(typeof(ApiParam<SdaCustomizaButtonViewFilterQuery>), "param")]
        [ActionName("GetView")]
        public ApiResult Get(ApiParam<SdaCustomizaButtonViewFilterQuery> param)
        {
            try
            {
                ApiResultObject<List<V_SDA_CUSTOMIZA_BUTTON>> result = new ApiResultObject<List<V_SDA_CUSTOMIZA_BUTTON>>(null);
                if (param != null)
                {
                    SdaCustomizaButtonManager mng = new SdaCustomizaButtonManager(param.CommonParam);
                    result = mng.GetView(param.ApiData);
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
