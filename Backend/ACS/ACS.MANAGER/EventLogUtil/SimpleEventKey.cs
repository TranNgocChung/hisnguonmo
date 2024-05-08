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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.MANAGER.EventLogUtil
{
    [AttributeUsage(AttributeTargets.Field)]
    public class SimpleEventKey : Attribute
    {
        public const string APPLICATION_CODE = "APPLICATION_CODE";
        public const string ROLE_CODE = "ROLE_CODE";
        public const string ROLE_BASE_CODE = "ROLE_BASE_CODE";
        public const string MODULE_LINK = "MODULE_LINK";

        public string Value { get; set; }

        public SimpleEventKey(string value)
        {
            this.Value = value;
        }
    } 
}
