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

namespace ACS.MANAGER.AcsAuthenRequest
{
    public partial class AcsAuthenRequestManager : BusinessBase
    {
        public AcsAuthenRequestManager()
            : base()
        {

        }
        
        public AcsAuthenRequestManager(CommonParam param)
            : base(param)
        {

        }
		
		[Logger]
        public ApiResultObject<List<ACS_AUTHEN_REQUEST>> Get(AcsAuthenRequestFilterQuery filter)
        {
            ApiResultObject<List<ACS_AUTHEN_REQUEST>> result = null;
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(filter);
                List<ACS_AUTHEN_REQUEST> resultData = null;
                if (valid)
                {
                    resultData = new AcsAuthenRequestGet(param).Get(filter);
                }
                result = this.PackSuccess(resultData);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }

		[Logger]
        public ApiResultObject<ACS_AUTHEN_REQUEST> Create(ACS_AUTHEN_REQUEST data)
        {
            ApiResultObject<ACS_AUTHEN_REQUEST> result = new ApiResultObject<ACS_AUTHEN_REQUEST>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                ACS_AUTHEN_REQUEST resultData = null;
				bool isSuccess = false;
                if (valid)
                {
					isSuccess = new AcsAuthenRequestCreate(param).Create(data);
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

		[Logger]
        public ApiResultObject<ACS_AUTHEN_REQUEST> Update(ACS_AUTHEN_REQUEST data)
        {
            ApiResultObject<ACS_AUTHEN_REQUEST> result = new ApiResultObject<ACS_AUTHEN_REQUEST>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                ACS_AUTHEN_REQUEST resultData = null;
				bool isSuccess = false;
                if (valid)
                {
					isSuccess = new AcsAuthenRequestUpdate(param).Update(data);
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

		[Logger]
        public ApiResultObject<ACS_AUTHEN_REQUEST> ChangeLock(long id)
        {
            ApiResultObject<ACS_AUTHEN_REQUEST> result = new ApiResultObject<ACS_AUTHEN_REQUEST>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                ACS_AUTHEN_REQUEST resultData = null;
				bool isSuccess = false;
                if (valid)
                {
                    isSuccess = new AcsAuthenRequestLock(param).ChangeLock(id, ref resultData);
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
        public ApiResultObject<ACS_AUTHEN_REQUEST> Lock(long id)
        {
            ApiResultObject<ACS_AUTHEN_REQUEST> result = null;
            
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                ACS_AUTHEN_REQUEST resultData = null;
				bool isSuccess = false;
                if (valid)
                {
                    isSuccess = new AcsAuthenRequestLock(param).Lock(id, ref resultData);
                }
                result = this.PackResult(resultData, isSuccess);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
            }

            return result;
        }
		
		[Logger]
        public ApiResultObject<ACS_AUTHEN_REQUEST> Unlock(long id)
        {
            ApiResultObject<ACS_AUTHEN_REQUEST> result = null;
            
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                ACS_AUTHEN_REQUEST resultData = null;
				bool isSuccess = false;
                if (valid)
                {
                    isSuccess = new AcsAuthenRequestLock(param).Unlock(id, ref resultData);
                }
                result = this.PackResult(resultData, isSuccess);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
            }

            return result;
        }

		[Logger]
        public ApiResultObject<bool> Delete(long id)
        {
            ApiResultObject<bool> result = new ApiResultObject<bool>(false);

            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                bool resultData = false;
                if (valid)
                {
                    resultData = new AcsAuthenRequestTruncate(param).Truncate(id);
                }
                result = this.PackSingleResult(resultData);
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
