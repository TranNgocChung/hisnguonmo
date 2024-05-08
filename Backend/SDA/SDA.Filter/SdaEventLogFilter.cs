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

namespace SDA.Filter
{
    public class SdaEventLogFilter : FilterBase
    {
        public string LOGIN_NAME { get; set; }

        public string DESCRIPTION { get; set; }

        public long? EVENT_TIME_FROM { get; set; }
        public long? EVENT_TIME_TO { get; set; }

        public long? EVENT_DATE_FROM { get; set; }
        public long? EVENT_DATE_TO { get; set; }

        public long? EVENT_DATE { get; set; }

        public long? EVENT_MONTH { get; set; }

        public long? CREATE_DATE_FROM { get; set; }
        public long? CREATE_DATE_TO { get; set; }

        public SdaEventLogFilter()
            : base()
        {
        }
    }
}
