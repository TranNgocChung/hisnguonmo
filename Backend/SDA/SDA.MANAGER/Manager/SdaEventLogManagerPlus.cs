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
using SDA.MANAGER.Core.SdaEventLog;
using Inventec.Core;
using System;
using SDA.SDO;
using System.Collections.Generic;

namespace SDA.MANAGER.Manager
{
    public partial class SdaEventLogManager : ManagerBase
    {    
        public object Create(SdaEventLogSDO data)
        {
            object result = false;
            try
            {
                if (!IsNotNull(data)) throw new ArgumentNullException("data");
                SdaEventLogBO bo = new SdaEventLogBO();
                if (bo.CreateSDO(data))
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

        public object CreateList(List<SDA.SDO.SdaEventLogSDO> data)
        {
            object result = false;
            try
            {
                Inventec.Common.Logging.LogSystem.Debug("Begin process method CreateList");
                if (!IsNotNull(data)) throw new ArgumentNullException("data");
                SdaEventLogBO bo = new SdaEventLogBO();
                if (bo.CreateListSDO(data))
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
    }
}
