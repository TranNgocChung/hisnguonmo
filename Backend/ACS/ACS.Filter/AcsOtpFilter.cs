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
    public class AcsOtpFilter : FilterBase
    {
        public string OTP_CODE__EXACT { get; set; }
        public short? OTP_TYPE { get; set; }
        public string LOGINNAME__EXACT { get; set; }
        public string MOBILE__EXACT { get; set; }
        public long? OTP_TYPE_ID { get; set; }

        public bool? IS_HAS_EXPIRE { get; set; }
        public long? EXPIRE_DATE__EXACT { get; set; }

        public string LOGINNAME_OR_MOBILE__EXACT { get; set; }

        public List<short> OTP_TYPEs { get; set; }
        public List<long> OTP_TYPE_IDs { get; set; }

        public AcsOtpFilter()
            : base()
        {
        }
    }
}
