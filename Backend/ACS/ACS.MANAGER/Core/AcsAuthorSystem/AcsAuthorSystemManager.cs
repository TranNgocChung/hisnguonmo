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

namespace ACS.MANAGER.AcsAuthorSystem
{
    public partial class AcsAuthorSystemManager : BusinessBase
    {
        public AcsAuthorSystemManager()
            : base()
        {

        }

        public AcsAuthorSystemManager(CommonParam param)
            : base(param)
        {

        }

        [Logger]
        public ApiResultObject<List<ACS_AUTHOR_SYSTEM>> Get(AcsAuthorSystemFilterQuery filter)
        {
            ApiResultObject<List<ACS_AUTHOR_SYSTEM>> result = null;
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(filter);
                List<ACS_AUTHOR_SYSTEM> resultData = null;
                if (valid)
                {
                    resultData = new AcsAuthorSystemGet(param).Get(filter);
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
        public ApiResultObject<ACS_AUTHOR_SYSTEM> GetInfoByCode(string code)
        {
            ApiResultObject<ACS_AUTHOR_SYSTEM> result = null;
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(code);
                ACS_AUTHOR_SYSTEM resultData = null;
                if (valid)
                {
                    resultData = new AcsAuthorSystemGet(param).GetByCode(code);
                    if (resultData != null)
                    {
                        resultData.SERCURE_KEY = "";
                        resultData.ID = 0;
                    }
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
        public ApiResultObject<ACS_AUTHOR_SYSTEM> Create(ACS_AUTHOR_SYSTEM data)
        {
            ApiResultObject<ACS_AUTHOR_SYSTEM> result = new ApiResultObject<ACS_AUTHOR_SYSTEM>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                ACS_AUTHOR_SYSTEM resultData = null;
                bool isSuccess = false;
                if (valid)
                {
                    isSuccess = new AcsAuthorSystemCreate(param).Create(data);
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
        public ApiResultObject<ACS_AUTHOR_SYSTEM> Update(ACS_AUTHOR_SYSTEM data)
        {
            ApiResultObject<ACS_AUTHOR_SYSTEM> result = new ApiResultObject<ACS_AUTHOR_SYSTEM>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                ACS_AUTHOR_SYSTEM resultData = null;
                bool isSuccess = false;
                if (valid)
                {
                    isSuccess = new AcsAuthorSystemUpdate(param).Update(data);
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
        public ApiResultObject<ACS_AUTHOR_SYSTEM> ChangeLock(long id)
        {
            ApiResultObject<ACS_AUTHOR_SYSTEM> result = new ApiResultObject<ACS_AUTHOR_SYSTEM>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                ACS_AUTHOR_SYSTEM resultData = null;
                bool isSuccess = false;
                if (valid)
                {
                    isSuccess = new AcsAuthorSystemLock(param).ChangeLock(id, ref resultData);
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
        public ApiResultObject<ACS_AUTHOR_SYSTEM> Lock(long id)
        {
            ApiResultObject<ACS_AUTHOR_SYSTEM> result = null;

            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                ACS_AUTHOR_SYSTEM resultData = null;
                bool isSuccess = false;
                if (valid)
                {
                    isSuccess = new AcsAuthorSystemLock(param).Lock(id, ref resultData);
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
        public ApiResultObject<ACS_AUTHOR_SYSTEM> Unlock(long id)
        {
            ApiResultObject<ACS_AUTHOR_SYSTEM> result = null;

            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                ACS_AUTHOR_SYSTEM resultData = null;
                bool isSuccess = false;
                if (valid)
                {
                    isSuccess = new AcsAuthorSystemLock(param).Unlock(id, ref resultData);
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
                    resultData = new AcsAuthorSystemTruncate(param).Truncate(id);
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
