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

namespace HIS.Desktop.Plugins.PublicServiceBedRoom.ADO
{
    public class Service_NT_ADO
    {
        public string SERVICE_NAME { get; set; }
        public string SERVICE_CODE { get; set; }
        public long SERVICE_ID { get; set; }
        public string SERVICE_UNIT_NAME { get; set; }
        public string SERVICE_UNIT_CODE { get; set; }
        public long SERVICE_UNIT_ID { get; set; }
        public decimal AMOUNT { get; set; }
        public decimal? PRICE { get; set; }
        public string DESCRIPTION { get; set; }
        public long SERVICE_TYPE_ID { get; set; }
        public long INTRUCTION_DATE { get; set; }
        public string CONCENTRA { get; set; }
        public long TREATMENT_ID { get; set; }
    }
}
