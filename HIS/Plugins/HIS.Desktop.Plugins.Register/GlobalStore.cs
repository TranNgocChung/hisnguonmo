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
using HIS.Desktop.LocalStorage.BackendData;
using Inventec.Common.Logging;
using MOS.EFMODEL.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.Desktop.Plugins.Register
{
    class GlobalStore
    {
        internal static List<long> PatientTypeIdAllows { get; set; }

        //private static Dictionary<long, List<V_HIS_SERVICE_PATY>> dicServicePaty;
        //internal static Dictionary<long, List<V_HIS_SERVICE_PATY>> DicServicePaty
        //{
        //    get
        //    {
        //        try
        //        {
        //            if (dicServicePaty == null || dicServicePaty.Count == 0)
        //            {
        //                dicServicePaty = BackendDataWorker.Get<MOS.EFMODEL.DataModels.V_HIS_SERVICE_PATY>()
        //                    .Where(t => PatientTypeIdAllows != null && PatientTypeIdAllows.Contains(t.PATIENT_TYPE_ID))
        //                    .GroupBy(o => o.SERVICE_ID)
        //                    .ToDictionary(o => o.Key, o => o.ToList());
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            LogSystem.Warn(ex);
        //        }

        //        return dicServicePaty;
        //    }
        //    set
        //    {
        //        dicServicePaty = value;
        //    }
        //}
    }
}
