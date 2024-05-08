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
using ACS.EFMODEL.DataModels;
using ACS.LibraryEventLog;
using ACS.LogManager;
using ACS.MANAGER.Base;
using ACS.MANAGER.Config;
using ACS.SDO;
using ACS.UTILITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.MANAGER.EventLogUtil
{
    public class HisAggrExpMestLog
    {
        public static void Run(Dictionary<HIS_EXP_MEST, List<HIS_EXP_MEST>> aggrDic, EventLog.Enum logEnum)
        {
            try
            {
                new EventLogGenerator(logEnum).AggrExpMestList(GetAggrExpMestData(aggrDic)).Run();
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
        }

        private static List<AggrExpMestData> GetAggrExpMestData(Dictionary<HIS_EXP_MEST, List<HIS_EXP_MEST>> aggrDic)
        {
            try
            {
                List<AggrExpMestData> aggrExpMestData = new List<AggrExpMestData>();
                if (aggrDic != null && aggrDic.Count > 0)
                {
                    foreach (HIS_EXP_MEST exp in aggrDic.Keys)
                    {
                        List<HIS_EXP_MEST> children = aggrDic[exp];
                        if (children != null)
                        {
                            aggrExpMestData.Add(new AggrExpMestData(exp.EXP_MEST_CODE, children.Select(o => o.EXP_MEST_CODE).ToList()));
                        }
                    }
                    return aggrExpMestData;
                }
                return null;
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                return null;
            }
        }

    }
}
