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
using Inventec.Core;
using Inventec.Common.Logging;
using ACS.EFMODEL.DataModels;
using ACS.MANAGER.Base;
using System;
using System.Collections.Generic;
using ACS.SDO;
using System.Web.Http.Controllers;

namespace ACS.MANAGER.AcsAuthenRequest
{
    public partial class AcsAuthenRequestManager : BusinessBase
    {
        [Logger]
        public ApiResultObject<bool> AuthenRequest(AuthenRequestTDO data, HttpActionContext httpActionContext)
        {
            ApiResultObject<bool> result = new ApiResultObject<bool>(false);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                bool resultData = false;
                bool isSuccess = false;
                if (valid)
                {
                    isSuccess = new AcsAuthenRequestAuthenRequest(param).AuthenRequest(data, httpActionContext);
                    resultData = isSuccess ? true : false;
                }
                result = this.PackResult(resultData, isSuccess);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
            }
            return result;
        }

        [Logger]
        public ApiResultObject<List<ACS_AUTHEN_REQUEST>> UpdateList(List<ACS_AUTHEN_REQUEST> data)
        {
            ApiResultObject<List<ACS_AUTHEN_REQUEST>> result = new ApiResultObject<List<ACS_AUTHEN_REQUEST>>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                List<ACS_AUTHEN_REQUEST> resultData = null;
                bool isSuccess = false;
                if (valid)
                {
                    isSuccess = new AcsAuthenRequestUpdate(param).UpdateList(data);
                    resultData = isSuccess ? data : null;
                }
                result = this.PackResult(resultData, isSuccess);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
            }

            return result;
        }
    }
}
