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
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.QuartzScheduler.Credentials
{
    internal class ScanTimeOutJob : IJob
    {
        void IJob.Execute(IJobExecutionContext context)
        {
            try
            {
                LogSystem.Info("ScanTimeOutCredentialsJob running. Hour=" + DateTime.Now.Hour);

                try
                {
                    ResourceTokenManager.ScanTimeOutCredentials();
                }
                catch (Exception ex)
                {
                    Inventec.Common.Logging.LogSystem.Error(ex);
                }

                if (DateTime.Now.Hour == 1)
                {
                    LogSystem.Info("ScanTimeOutCredentialsJob run in (1h) starting...");
                    //Scan remove token timeout from resource server (backend)

                    new ACS.MANAGER.AcsToken.AcsTokenManager().ScanToken();

                    LogSystem.Info("ScanTimeOutCredentialsJob run in (1h) finished. Time=" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                }

                LogSystem.Info("ScanTimeOutCredentialsJob Finish. Hour=" + DateTime.Now.Hour);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }
    }
}
