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
using ACS.ApiConsumerManager;
using ACS.MANAGER.Base;
using Inventec.Common.Logging;
using Inventec.Core;
using System;
using System.Collections.Generic;

namespace ACS.MANAGER.SdaTrouble
{
    class SdaTroubleScan  : Inventec.Backend.MANAGER.BusinessBase
    {
        internal SdaTroubleScan()
            : base()
        {

        }

        internal SdaTroubleScan(CommonParam paramScan)
            : base(paramScan)
        {

        }

        internal void Execute()
        {
            try
            {
                List<string> listTrouble = TroubleCache.GetAndClear();
                Inventec.Core.ApiResultObject<bool> aro = ApiConsumerStore.SdaConsumer.Post<Inventec.Core.ApiResultObject<bool>>("/api/SdaTrouble/Create", param, listTrouble);
                if (!(aro != null && aro.Success))
                {
                    Logging("Khong insert duoc du lieu trouble.", LogType.Error);
                    Inventec.Common.Logging.LogSystem.Info(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => aro), aro));
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }
    }
}
