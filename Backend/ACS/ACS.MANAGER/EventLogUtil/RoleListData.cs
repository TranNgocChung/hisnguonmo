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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.MANAGER.EventLogUtil
{
    class RoleListData
    {
        public string ApplicationCode { get; set; }
        public List<ACS_ROLE> RoleDatas { get; set; }

        public RoleListData()
        {
        }

        public RoleListData(string applicationCode, List<ACS_ROLE> roleDatas)
        {
            this.ApplicationCode = applicationCode;
            this.RoleDatas = roleDatas;
        }

        public override string ToString()
        {
            string children = this.RoleDatas != null ?
              string.Join(",", RoleDatas.Select(o => o.ROLE_CODE + " - " + o.ROLE_NAME).ToList()) : "";

            string aggrImpCode = string.IsNullOrWhiteSpace(this.ApplicationCode) ?
                "" : string.Format("{0}: {1}", SimpleEventKey.APPLICATION_CODE, this.ApplicationCode);
            return string.Format("{0} ({1}: {2})", aggrImpCode, SimpleEventKey.ROLE_CODE, children);
        }
    }
}
