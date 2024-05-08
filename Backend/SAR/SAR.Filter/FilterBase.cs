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
namespace SAR.Filter
{
    public class FilterBase
    {
        protected static readonly long NEGATIVE_ID = -1;

        /// <summary>
        /// Truong sap xep (mac dinh: MODIFY_TIME)
        /// </summary>
        public string ORDER_FIELD { get; set; }
        /// <summary>
        /// Chieu sap xep (DESC/ASC, mac dinh DESC)
        /// </summary>
        public string ORDER_DIRECTION { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public long? ID { get; set; }
        /// <summary>
        /// Trang thai kich hoat
        /// </summary>
        public short? IS_ACTIVE { get; set; }
        /// <summary>
        /// Thoi gian tao (tu)
        /// </summary>
        public long? CREATE_TIME_FROM { get; set; }
        public long? CREATE_TIME_FROM__GREATER { get; set; }
        /// <summary>
        /// Thoi gian tao (den)
        /// </summary>
        public long? CREATE_TIME_TO { get; set; }
        public long? CREATE_TIME_TO__LESS { get; set; }
        /// <summary>
        /// Thoi gian sua (tu)
        /// </summary>
        public long? MODIFY_TIME_FROM { get; set; }
        public long? MODIFY_TIME_FROM__GREATER { get; set; }
        /// <summary>
        /// Thoi gian sua (den)
        /// </summary>
        public long? MODIFY_TIME_TO { get; set; }
        public long? MODIFY_TIME_TO__LESS { get; set; }
        /// <summary>
        /// Nguoi tao
        /// </summary>
        public string CREATOR { get; set; }
        /// <summary>
        /// Nguoi sua
        /// </summary>
        public string MODIFIER { get; set; }
        /// <summary>
        /// Don vi quan ly
        /// </summary>
        public string GROUP_CODE { get; set; }
        /// <summary>
        /// Tu khoa tim kiem
        /// </summary>
        public string KEY_WORD { get; set; }
        /// <summary>
        /// Danh sach cac Id
        /// </summary>
        public List<long> IDs { get; set; }
    }
}
