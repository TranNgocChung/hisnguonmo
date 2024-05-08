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
using Inventec.Common.Scheduler;
using System;

namespace SDA.API.Scheduler
{
    public class RefreshSystemConfigJob : Job
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
                        repeatTime = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["SDA.API.Scheduler.RefreshSystemConfigJob"] ?? "");
                        return repeatTime;
                    }
                    catch (Exception ex)
                    {
                        LogSystem.Error(ex);
                        repeatTime = 0;
                        return 1800000;
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
                SDA.MANAGER.Config.Loader.Refresh();
                LogSystem.Info("RefreshSystemConfigJob thanh cong. Time=" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
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
