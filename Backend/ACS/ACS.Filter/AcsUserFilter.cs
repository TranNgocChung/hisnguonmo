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
using System.Text;

namespace ACS.Filter
{
    public class AcsUserFilter : FilterBase
    {
        public string EMAIL { get; set; }
        public string LOGINNAME { get; set; }
        public string LOGINNAME__OR__SUB_LOGINNAME { get; set; }
        public string CN_WORD { get; set; }
        public string KEY_WORD { get; set; }
        public List<string> LOGINNAMEs { get; set; }
        public List<string> LOGINNAME__OR__SUB_LOGINNAMEs { get; set; }
        public bool? IS_NOT_PEOPLE { get; set; }//For THE
        public AcsUserFilter()
            : base()
        {
        }
    }
}
