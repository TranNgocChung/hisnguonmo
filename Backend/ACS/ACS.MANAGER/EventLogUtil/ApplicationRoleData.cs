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
    class ApplicationRoleData
    {
        public string ApplicationCode { get; set; }
        public string ApplicationName { get; set; }

        public List<string> RoleNames { get; set; }

        public ApplicationRoleData()
        {
        }

        public ApplicationRoleData(string applicationCode, string applicationName, List<string> roleNames)
        {
            this.ApplicationCode = applicationCode;
            this.ApplicationName = applicationName;
            this.RoleNames = roleNames;
        }

        public ApplicationRoleData(string applicationCode, List<string> roleNames)
        {
            this.ApplicationCode = applicationCode;
            this.RoleNames = roleNames;
        }

        public override string ToString()
        {
            string roleName = RoleNames != null ?
                string.Join(",", RoleNames) : "";
            string srCode = string.IsNullOrWhiteSpace(this.ApplicationCode) ?
                "" : string.Format("{0}: {1}", SimpleEventKey.APPLICATION_CODE, this.ApplicationCode);
            string vaitro = LogCommonUtil.GetEventLogContent(EventLog.Enum.VaiTro);
            return string.Format("{0} ({1}: {2})", srCode, vaitro, roleName);
        }
    }
}
