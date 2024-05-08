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

namespace ACS.QuartzScheduler.TokenUnAvailable
{
    internal class ScanTokenUnAvailableJob : IJob
    {
        void IJob.Execute(IJobExecutionContext context)
        {
            try
            {
                if (DateTime.Now.Hour > 23 && DateTime.Now.Hour < 2)
                {
                    //Scan remove token timeout and credential data reference from acs DB
                    new ACS.MANAGER.AcsToken.AcsTokenManager().ScanToken();

                    LogSystem.Info("ScanTokenUnAvailable thanh cong. (De khong anh huong den hieu nang, job nay chi chay trong khoang tu (23h - 2h), chu ky 1 gio chay 1 lan de phong truong hop bi restart lien tuc dan den khong chay duoc job). Time=" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }
    }
}
