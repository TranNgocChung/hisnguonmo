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

namespace ACS.Filter
{
    public class AcsModuleViewFilter : FilterBase
    {
        public bool? IsTree { get; set; }
        public long? Node { get; set; }
        public long? APPLICATION_ID { get; set; }
        public string APPLICATION_CODE { get; set; }
        public string MODULE_LINK { get; set; }
        public short? IS_LEAF { get; set; }
        public short? IS_VISIBLE { get; set; }
        public bool? IsLeaf { get; set; }
        public bool? IsParent { get; set; }
        public bool? IsAnonymous { get; set; }

        public AcsModuleViewFilter()
            : base()
        {
        }
    }
}
