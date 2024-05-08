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
using ACS.LibraryEventLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.MANAGER.EventLogUtil
{
    class RoleBaseData
    {
        public string RoleCode { get; set; }
        public string RoleName { get; set; }

        public List<string> RoleBaseCodes { get; set; }

        public RoleBaseData()
        {
        }

        public RoleBaseData(string roleCode, string roleName, List<string> roleBaseCodes)
        {
            this.RoleCode = roleCode;
            this.RoleName = roleName;
            this.RoleBaseCodes = roleBaseCodes;
        }

        public override string ToString()
        {
            string children = this.RoleBaseCodes != null ?
                string.Join(",", this.RoleBaseCodes) : "";

            string vaitro = LogCommonUtil.GetEventLogContent(EventLog.Enum.VaiTro);
            string vaitrokethua = LogCommonUtil.GetEventLogContent(EventLog.Enum.VaiTroKeThua);
            string aggrExpCode = string.IsNullOrWhiteSpace(this.RoleCode) ?
                "" : string.Format("{0}: {1} - {2}", vaitro, this.RoleCode, this.RoleName);
            return string.Format("{0} ({1}: {2})", aggrExpCode, vaitrokethua, children);
        }
    }
}
