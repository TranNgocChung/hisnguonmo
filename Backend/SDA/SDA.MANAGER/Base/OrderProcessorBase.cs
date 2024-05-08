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
using System.Reflection;

namespace SDA.MANAGER.Base
{
    public class OrderProcessorBase
    {
        protected string defaultField = "MODIFY_TIME";
        protected string defaultDirection = "DESC";
        protected static List<String> listDirection = new List<string>(new string[] { "DESC", "ASC" });

        public string GetOrderDirection(string direction)
        {
            string result = defaultDirection;
            if (!string.IsNullOrWhiteSpace(direction))
            {
                try
                {
                    if (listDirection.Contains(direction))
                    {
                        result = direction;
                    }
                }
                catch (Exception ex)
                {
                    LogSystem.Error(ex);
                }
            }
            return result;
        }

        public string GetOrderField<T>(string orderField)
        {
            string result = defaultField;
            if (!string.IsNullOrWhiteSpace(orderField))
            {
                try
                {
                    PropertyInfo property = typeof(T).GetProperty(orderField);
                    if (property != null)
                    {
                        result = orderField;
                    }
                }
                catch (Exception ex)
                {
                    LogSystem.Error(ex);
                }
            }
            return result;
        }
    }
}
