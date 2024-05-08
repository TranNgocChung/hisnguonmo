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
using SDA.MANAGER.Core.SdaProvince;
using Inventec.Core;
using System;
using System.Collections.Generic;

namespace SDA.MANAGER.Manager
{
    public partial class SdaProvinceManager : ManagerBase
    {
        public bool Delete(object data)
        {
            bool result = false;
            try
            {
                if (!IsNotNull(data)) throw new ArgumentNullException("data");
                SdaProvinceBO bo = new SdaProvinceBO();
                if (bo.DeleteWithDelReference(data))
                {
                    result = true;
                }
                CopyCommonParamInfo(bo);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                result = false;
            }
            return result;
        }

        public List<object> GetDynamic(object data)
        {
            List<object> result = default(List<object>);
            try
            {
                if (!IsNotNull(data)) throw new ArgumentNullException("data");
                SdaProvinceBO bo = new SdaProvinceBO();
                bo.CopyCommonParamInfoGet(param);
                result = bo.GetDynamic(data);
                CopyCommonParamInfo(bo);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                result = default(List<object>);
            }
            return result;
        }
    }
}
