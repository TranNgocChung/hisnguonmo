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
using System.Reflection;

namespace SAR.EFMODEL.Decorator
{
    public partial class DummyDecorator
    {
        private static Dictionary<Type, List<PropertyInfo>> properties = new Dictionary<Type, List<PropertyInfo>>();
        private static bool isLoaded = false;
        private static void Load()
        {
            try
            {
                if (!isLoaded)
                {
                    LoadSarReport();
                    LoadSarReportCalendar();

                    isLoaded = true;
                }
            }
            catch (Exception)
            {

            }
        }

        public static void Set<RAW>(RAW raw)
        {
            try
            {
                Load();
                if (properties.ContainsKey(typeof(RAW)))
                {
                    List<PropertyInfo> values = properties[typeof(RAW)];
                    if (values != null && values.Count > 0)
                    {
                        foreach (var property in values)
                        {
                            property.SetValue(raw, "");
                        }
                    }
                }
            }
            catch (Exception)
            {
                
            }
        }
    }
}
