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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.MANAGER.ActivityProcessor
{
    public class ActivityLogSave
    {
        private static int countFailed = 0;
        private static bool IsRunning = false;
        public static void Run()
        {
            try
            {
                if (IsRunning)
                {
                    Inventec.Common.Logging.LogSystem.Info("Tien trinh ActivityLogSave dang chay");
                    return;
                }
                IsRunning = true;
                List<ACS_ACTIVITY_LOG> logs = ActivityLogCache.Pop();

                Inventec.Common.Logging.LogSystem.Info("ActivityLogs count: " + (logs != null ? logs.Count : 0));

                if (logs != null && logs.Count > 0)
                {
                    var result = new Core.AcsActivityLog.AcsActivityLogBO().Create(logs);
                    if (!result)
                    {
                        Inventec.Common.Logging.LogSystem.Error("Insert ACS_ACTIVITY_LOG that bai");
                        if (countFailed < 5)
                        {
                            countFailed++;
                            ActivityLogCache.Push(logs);
                        }
                        else
                        {
                            countFailed = 0;
                            Inventec.Common.Logging.LogSystem.Error(Inventec.Common.Logging.LogUtil.TraceData("ActivityLog", logs));
                        }
                    }
                    else
                    {
                        countFailed = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
            IsRunning = false;
        }
    }
}
