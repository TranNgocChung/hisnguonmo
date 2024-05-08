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
    public class SdaGroupFilter : FilterBase
    {
        public string ID_PATH { get; set; }
        public string CODE_PATH { get; set; }

        /// <summary>
        /// Co phai don vi goc hay khong.
        /// TRUE - La don vi goc (PARENT_ID = null).
        /// FALSE - Khong phai don vi goc (PARENT_ID # null)
        /// NULL - Ca 2
        /// </summary>
        public bool? IS_ROOT { get; set; }
        public long? PARENT_ID { get; set; }

        public SdaGroupFilter()
            : base()
        {
        }
    }
}
