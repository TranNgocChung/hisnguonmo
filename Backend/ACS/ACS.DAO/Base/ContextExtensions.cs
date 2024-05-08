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
using System.Data.Entity;

namespace ACS.DAO.Base
{
    public static class ContextExtensions
    {
        public static string GetTableName<T>(this System.Data.Entity.DbContext context) where T : class
        {
            System.Data.Objects.ObjectContext objectContext = ((System.Data.Entity.Infrastructure.IObjectContextAdapter)context).ObjectContext;

            return objectContext.GetTableName<T>();
        }

        public static string GetTableName<T>(this System.Data.Objects.ObjectContext context) where T : class
        {
            string sql = context.CreateObjectSet<T>().ToTraceString();
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("FROM (?<table>.*) AS");
            System.Text.RegularExpressions.Match match = regex.Match(sql);

            string table = match.Groups["table"].Value;
            return table;
        }
    }
}
