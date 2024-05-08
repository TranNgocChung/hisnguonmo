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
    public class SdaEventLogViewFilter : FilterBase
    {
        public List<long> EVENT_LOG_TYPE_IDs { get; set; }
        public string LOGIN_NAME { get; set; }

        public long? VIR_CREATE_DATE_FROM { get; set; }
        public long? VIR_CREATE_DATE_TO { get; set; }

        public SdaEventLogViewFilter()
            : base()
        {
        }
    }
}
