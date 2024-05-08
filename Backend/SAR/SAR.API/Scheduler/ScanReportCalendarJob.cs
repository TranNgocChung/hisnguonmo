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
using System;

namespace SAR.API.Scheduler
{
    public class ScanReportCalendarJob : Inventec.Common.Scheduler.Job
    {
        private int repeatTime;
        public int RepeatTime
        {
            get
            {
                if (repeatTime <= 0)
                {
                    try
                    {
                        repeatTime = int.Parse(System.Configuration.ConfigurationManager.AppSettings["API.Scheduler.ScanReportCalendarJob"]);
                        return repeatTime;
                    }
                    catch (Exception ex)
                    {
                        LogSystem.Debug(ex);
                        repeatTime = 0;
                        return 3600000;
                    }
                }
                else
                {
                    return repeatTime;
                }
            }
        }

        public override void DoJob()
        {
            try
            {
                CommonParam param = new CommonParam();
                new SAR.MANAGER.Manager.SarReportCalendarManager(param).Scan();
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
        }

        public override string GetName()
        {
            return this.GetType().Name;
        }

        public override int GetRepetitionIntervalTime()
        {
            return RepeatTime;
        }

        public override bool IsRepeatable()
        {
            return true;
        }
    }
}
