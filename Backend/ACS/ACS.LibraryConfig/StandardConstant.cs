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
namespace ACS.LibraryConfig
{
    public class StandardConstant
    {
        public const short IS_ACTIVE = (short)1;
        public const short IS_INACTIVE = (short)0;
        public const string COMBO_ALL = "Tất cả";
        public const long COMBO_ALL_VALUE = -1;
        public const char DELIMITER = ';';
        /// <summary>
        /// 1:kích hoạt
        /// </summary>
        public const short OTP_TYPE_ACTIVE = (short)1;
        /// <summary>
        /// 2:đổi mật khẩu
        /// </summary>
        public const short OTP_TYPE_CHANGEPASS = (short)2;

        public const short OTP_TYPE_OTHER = (short)3;
    }
}
