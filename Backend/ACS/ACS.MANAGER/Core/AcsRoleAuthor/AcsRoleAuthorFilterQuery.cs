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
using ACS.DAO.StagingObject;
using ACS.EFMODEL.DataModels;
using ACS.Filter;
using ACS.MANAGER.Base;
using System;
using System.Collections.Generic;

namespace ACS.MANAGER.AcsRoleAuthor
{
    public class AcsRoleAuthorFilterQuery : AcsRoleAuthorFilter
    {
        public AcsRoleAuthorFilterQuery()
            : base()
        {

        }

        internal List<System.Linq.Expressions.Expression<Func<ACS_ROLE_AUTHOR, bool>>> listAcsRoleAuthorExpression = new List<System.Linq.Expressions.Expression<Func<ACS_ROLE_AUTHOR, bool>>>();

        

        internal AcsRoleAuthorSO Query()
        {
            AcsRoleAuthorSO search = new AcsRoleAuthorSO();
            try
            {
                #region Abstract Base
                if (this.ID.HasValue)
                {
                    listAcsRoleAuthorExpression.Add(o => o.ID == this.ID.Value);
                }
				if (this.IDs != null)
                {
                    listAcsRoleAuthorExpression.Add(o => this.IDs.Contains(o.ID));
                }
                if (this.IS_ACTIVE.HasValue)
                {
                    listAcsRoleAuthorExpression.Add(o => o.IS_ACTIVE == this.IS_ACTIVE.Value);
                }
                if (this.CREATE_TIME_FROM.HasValue)
                {
                    listAcsRoleAuthorExpression.Add(o => o.CREATE_TIME.Value >= this.CREATE_TIME_FROM.Value);
                }
                if (this.CREATE_TIME_TO.HasValue)
                {
                    listAcsRoleAuthorExpression.Add(o => o.CREATE_TIME.Value <= this.CREATE_TIME_TO.Value);
                }
                if (this.MODIFY_TIME_FROM.HasValue)
                {
                    listAcsRoleAuthorExpression.Add(o => o.MODIFY_TIME.Value >= this.MODIFY_TIME_FROM.Value);
                }
                if (this.MODIFY_TIME_TO.HasValue)
                {
                    listAcsRoleAuthorExpression.Add(o => o.MODIFY_TIME.Value <= this.MODIFY_TIME_TO.Value);
                }
                if (!String.IsNullOrEmpty(this.CREATOR))
                {
                    listAcsRoleAuthorExpression.Add(o => o.CREATOR == this.CREATOR);
                }
                if (!String.IsNullOrEmpty(this.MODIFIER))
                {
                    listAcsRoleAuthorExpression.Add(o => o.MODIFIER == this.MODIFIER);
                }
                if (!String.IsNullOrEmpty(this.GROUP_CODE))
                {
                    listAcsRoleAuthorExpression.Add(o => o.GROUP_CODE == this.GROUP_CODE);
                }

                if (this.ROLE_ID.HasValue)
                {
                    listAcsRoleAuthorExpression.Add(o => o.ROLE_ID == this.ROLE_ID.Value);
                }
                if (this.AUTHOR_SYSTEM_ID.HasValue)
                {
                    listAcsRoleAuthorExpression.Add(o => o.AUTHOR_SYSTEM_ID == this.AUTHOR_SYSTEM_ID.Value);
                }
                #endregion
                
                search.listAcsRoleAuthorExpression.AddRange(listAcsRoleAuthorExpression);
                search.OrderField = ORDER_FIELD;
                search.OrderDirection = ORDER_DIRECTION;
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                search.listAcsRoleAuthorExpression.Clear();
                search.listAcsRoleAuthorExpression.Add(o => o.ID == NEGATIVE_ID);
            }
            return search;
        }
    }
}
