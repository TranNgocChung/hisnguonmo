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

namespace SAR.Filter
{
    public class SarPrintTypeFilter : FilterBase
    {
        public string PRINT_TYPE_CODE { get; set; }
        public string FILE_PATTERN { get; set; }
        public short? HAS_PRINT_EXCEL { get; set; }
        public short? HAS_PRINT_WORD { get; set; }
        public string EMR_DOCUMENT_TYPE_CODE__EXACT { get; set; }

        public SarPrintTypeFilter()
            : base()
        {
        }
    }
}
