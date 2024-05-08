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
    class ModuleRoleData
    {
        public string RoleCode { get; set; }
        public string RoleName { get; set; }

        public List<string> ModuleLinks { get; set; }

        public ModuleRoleData()
        {
        }

        public ModuleRoleData(string roleCode, string roleName, List<string> moduleLinks)
        {
            this.RoleCode = roleCode;
            this.RoleName = roleName;
            this.ModuleLinks = moduleLinks;
        }

        public override string ToString()
        {
            string children = this.ModuleLinks != null ?
                string.Join(",", this.ModuleLinks) : "";

            string chucnang = LogCommonUtil.GetEventLogContent(EventLog.Enum.ChucNang);
            string aggrImpCode = string.IsNullOrWhiteSpace(this.RoleCode) ?
                "" : string.Format("{0}: {1} - {2}", SimpleEventKey.ROLE_CODE, this.RoleCode, this.RoleName);
            return string.Format("{0} ({1}: {2})", aggrImpCode, chucnang, children);
        }
    }
}
