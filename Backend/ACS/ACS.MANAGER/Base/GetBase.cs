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
using Inventec.Backend.MANAGER;
using Inventec.Core;
using System.Collections.Generic;

namespace ACS.MANAGER.Base
{
    public abstract class GetBase : BusinessBase
    {
        protected const int MAX_IN_CLAUSE_SIZE = 1000;
        protected const string IN_ANCHOR = "{IN_CLAUSE}";

        protected GetBase()
            : base()
        {

        }

        protected GetBase(CommonParam paramGet)
            : base(paramGet)
        {

        }

        /// <summary>
        /// Tra ve chuoi string co dang: IN (id1, id2, ...) or IN (id1001, id1002, ...)
        /// Luu y: trong menh de IN ko qua 1000 phan tu
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        protected string AddInClause(List<long> elements, string query, string property)
        {
            string inClause;
            if (IsNotNullOrEmpty(elements))
            {
                inClause = "(" + property + " IN (";
                int size = elements.Count;
                int i = 0;
                do
                {
                    size--;
                    if (++i == MAX_IN_CLAUSE_SIZE)
                    {
                        inClause += elements[size] + ")";
                        if (size > 0)
                        {
                            inClause += " OR " + property + " IN (";
                        }
                        i = 0;
                    }
                    else
                    {
                        inClause += elements[size] + ",";
                    }
                } while (size > 0);
                inClause = inClause.Substring(0, inClause.Length - 1) + "))";
            }
            else
            {
                inClause = " 1 = 0 ";
            }
            return query.Replace(IN_ANCHOR, inClause);
        }

        /**
         * Bo sung menh de NOT IN trong cau truy van
         */
        protected string AddNotInClause(List<long> elements, string query, string property)
        {
            string notInClause;

            if (IsNotNullOrEmpty(elements))
            {
                notInClause = "(" + property + " NOT IN (";
                int size = elements.Count;
                int i = 0;
                do
                {
                    size--;
                    if (++i == MAX_IN_CLAUSE_SIZE)
                    {
                        notInClause = elements[size] + ")";
                        if (size > 0)
                        {
                            notInClause += " AND " + property + " NOT IN (";
                        }
                        i = 0;
                    }
                    else
                    {
                        notInClause += elements[size] + ",";
                    }
                } while (size > 0);
                notInClause = notInClause.Substring(0, notInClause.Length - 1) + "))";
            }
            else
            {
                notInClause = " 1 = 1 ";
            }
            return query.Replace(IN_ANCHOR, notInClause);
        }
    }
}
