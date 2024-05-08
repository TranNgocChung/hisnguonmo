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
using ACS.EFMODEL.DataModels;
using Inventec.Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.MANAGER.ActivityProcessor
{
    class ActivityLogCache
    {
        private static List<ACS_ACTIVITY_LOG> activityLogs = new List<ACS_ACTIVITY_LOG>();


        public static bool Push(ACS_ACTIVITY_LOG eventLog)
        {
            bool result = false;
            try
            {
                activityLogs.Add(eventLog);
                result = true;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        public static bool Push(List<ACS_ACTIVITY_LOG> eventLogs)
        {
            bool result = false;
            try
            {
                activityLogs.AddRange(eventLogs);
                result = true;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        public static List<ACS_ACTIVITY_LOG> Pop()
        {
            List<ACS_ACTIVITY_LOG> result = new List<ACS_ACTIVITY_LOG>();
            try
            {
                result.AddRange(activityLogs);
                activityLogs.Clear();
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
            return result;
        }
    }
}
