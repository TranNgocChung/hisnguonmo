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
using ACS.EFMODEL.DataModels;
using Inventec.Token.AuthSystem;
using Inventec.Token.Core;
using System;
using System.Collections.Generic;

namespace ACS.SDO
{
    public class AcsTokenSyncInsertSDO
    {
        public AcsTokenSyncInsertSDO() { }
                
        public string AuthenticationCode { get; set; }
        public string AuthorSystemCode { get; set; }
        public DateTime ExpireTime { get; set; }
        public DateTime LastAccessTime { get; set; }
        public string LoginAddress { get; set; }
        public DateTime LoginTime { get; set; }
        public string MachineName { get; set; }
        public string RenewCode { get; set; }
        public List<RoleData> RoleDatas { get; set; }
        public string ValidAddress { get; set; }
        public string TokenCode { get; set; }
        public UserData User { get; set; }
        public string VersionApp { get; set; }
        public int TokenCount { get; set; }
    }
}
