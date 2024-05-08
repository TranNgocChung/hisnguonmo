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
namespace ACS.Filter
{
    public class AcsCredentialDataFilter : FilterBase
    {
        public string RESOURCE_SYSTEM_CODE { get; set; }
        public string TOKEN_CODE { get; set; }
        public List<string> TOKEN_CODEs { get; set; }
        public List<string> NOT_IN_TOKEN_CODEs { get; set; }
        public string DATA_KEY { get; set; }

        public AcsCredentialDataFilter()
            : base()
        {
        }
    }
}
