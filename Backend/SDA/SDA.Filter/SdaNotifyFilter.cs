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

using System.Collections.Generic;
namespace SDA.Filter
{
    public class SdaNotifyFilter : FilterBase
    {
        public List<string> LOGIN_NAMES { get; set; }

        public long? FROM_TIME { get; set; }
        public long? TO_TIME { get; set; }
        public long? NOW_TIME { get; set; }

        public string RECEIVER_LOGINNAME_EXACT_OR_NULL { get; set; }

        public bool? HAS_RECEIVER_LOGINNAME_OR_NULL { get; set; }
        public bool? WATCHED { get; set; }
        public string RECEIVER_DEPARTMENT_CODES_OR_NULL { get; set; }
        public string RECEIVER_LOGINNAMES_EXACT_OR_NULL { get; set; }

        public SdaNotifyFilter()
            : base()
        {
        }
    }
}
