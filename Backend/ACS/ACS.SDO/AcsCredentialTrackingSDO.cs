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
using AutoMapper;
using Inventec.Token.AuthSystem;
using System;

namespace ACS.SDO
{
    public class AcsCredentialTrackingSDO
    {
        public AcsCredentialTrackingSDO() { }
       
        public string ValidAddress { get; set; }
        public DateTime ExpireTime { get; set; }
        public string LoginAddress { get; set; }
        public DateTime LoginTime { get; set; }
        public string RenewCode { get; set; }
        public string TokenCode { get; set; }
        public string ApplicationCode { get; set; }
        public string Email { get; set; }
        public string GCode { get; set; }
        public string LoginName { get; set; }
        public string Mobile { get; set; }
        public string UserName { get; set; }

        public string VersionApp { get; set; }
        public string MachineName { get; set; }
        public DateTime LastAccessTime { get; set; }

        public string AuthenticationCode { get; set; }
        public string AuthorSystemCode { get; set; }
    }
}
