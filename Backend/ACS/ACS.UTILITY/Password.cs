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
using Inventec.Common.Logging;
using System;
using System.Collections.Generic;

namespace ACS.UTILITY
{
    public class Password
    {
        public static string GeneratePasswordTemp()
        {
            try
            {
                return System.Web.Security.Membership.GeneratePassword(16, 0);
            }
            catch (Exception ex)
            {
                LogSystem.Error("Co exception khi generate pin_temp cho khach hang ca nhan. Tam thoi tra ve chuoi mac dinh Acs123456@.");
                LogSystem.Error(ex);
                return "Acs123456@";
            }
        }

        private readonly static Random _rng = new Random();
        private const string _chars = "1234567890";//"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
        public static string GeneratePassword()
        {
            try
            {
                return RandomString(16);
            }
            catch (Exception ex)
            {
                LogSystem.Error("Co exception khi generate pin_temp cho khach hang ca nhan. Tam thoi tra ve chuoi mac dinh Acs123456@.");
                LogSystem.Error(ex);
                return "Acs123456@";
            }
        }

        public static string RandomString(int size)
        {
            char[] buffer = new char[size];

            for (int i = 0; i < size; i++)
            {
                buffer[i] = _chars[_rng.Next(_chars.Length)];
            }
            return new string(buffer);
        }
    }
}
