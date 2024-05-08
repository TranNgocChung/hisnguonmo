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
using Inventec.Token.ResourceSystem;
using ACS.UTILITY;
using SDA.SDO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.LogManager
{
    public class EventLogCache
    {
        private static List<SdaEventLogSDO> eventLogs = new List<SdaEventLogSDO>();

        public static bool Push(string description)
        {
            bool result = false;
            try
            {
                SdaEventLogSDO eventLog = new SdaEventLogSDO();
                eventLog.AppCode = Constant.APPLICATION_CODE;
                try
                {
                    eventLog.Ip = ResourceTokenManager.GetRequestAddress();
                }
                catch (Exception ex)
                {
                    Inventec.Common.Logging.LogSystem.Error(ex);
                }
                eventLog.LogginName = ResourceTokenManager.GetLoginName();
                eventLog.EventTime = Inventec.Common.DateTime.Get.Now().Value; ;
                eventLog.Description = description;
                eventLogs.Add(eventLog);
                result = true;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        public static bool Push(List<SdaEventLogSDO> eventLog)
        {
            bool result = false;
            try
            {
                eventLogs.AddRange(eventLog);
                result = true;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        public static List<SdaEventLogSDO> Pop()
        {
            List<SdaEventLogSDO> result = new List<SdaEventLogSDO>();
            try
            {
                result.AddRange(eventLogs);
                eventLogs.Clear();
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
            return result;
        }
    }
}
