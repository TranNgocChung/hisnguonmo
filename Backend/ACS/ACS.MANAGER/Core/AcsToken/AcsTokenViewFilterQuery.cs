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

namespace ACS.MANAGER.AcsToken
{
    public class AcsTokenViewFilterQuery : AcsTokenViewFilter
    {
        public AcsTokenViewFilterQuery()
            : base()
        {

        }

        internal List<System.Linq.Expressions.Expression<Func<V_ACS_TOKEN, bool>>> listVAcsTokenExpression = new List<System.Linq.Expressions.Expression<Func<V_ACS_TOKEN, bool>>>();

        

        internal AcsTokenSO Query()
        {
            AcsTokenSO search = new AcsTokenSO();
            try
            {
                #region Abstract Base
                if (this.ID.HasValue)
                {
                    listVAcsTokenExpression.Add(o => o.ID == this.ID.Value);
                }
				if (this.IDs != null)
                {
                    listVAcsTokenExpression.Add(o => this.IDs.Contains(o.ID));
                }
                if (this.IS_ACTIVE.HasValue)
                {
                    listVAcsTokenExpression.Add(o => o.IS_ACTIVE == this.IS_ACTIVE.Value);
                }
                if (this.CREATE_TIME_FROM.HasValue)
                {
                    listVAcsTokenExpression.Add(o => o.CREATE_TIME.Value >= this.CREATE_TIME_FROM.Value);
                }
                if (this.CREATE_TIME_TO.HasValue)
                {
                    listVAcsTokenExpression.Add(o => o.CREATE_TIME.Value <= this.CREATE_TIME_TO.Value);
                }
                if (this.MODIFY_TIME_FROM.HasValue)
                {
                    listVAcsTokenExpression.Add(o => o.MODIFY_TIME.Value >= this.MODIFY_TIME_FROM.Value);
                }
                if (this.MODIFY_TIME_TO.HasValue)
                {
                    listVAcsTokenExpression.Add(o => o.MODIFY_TIME.Value <= this.MODIFY_TIME_TO.Value);
                }
                if (!String.IsNullOrEmpty(this.CREATOR))
                {
                    listVAcsTokenExpression.Add(o => o.CREATOR == this.CREATOR);
                }
                if (!String.IsNullOrEmpty(this.MODIFIER))
                {
                    listVAcsTokenExpression.Add(o => o.MODIFIER == this.MODIFIER);
                }
                if (!String.IsNullOrEmpty(this.GROUP_CODE))
                {
                    listVAcsTokenExpression.Add(o => o.GROUP_CODE == this.GROUP_CODE);
                }
                if (this.IDs != null)
                {
                    listVAcsTokenExpression.Add(o => this.IDs.Contains(o.ID));
                }
                #endregion
                
                search.listVAcsTokenExpression.AddRange(listVAcsTokenExpression);
                search.OrderField = ORDER_FIELD;
                search.OrderDirection = ORDER_DIRECTION;
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                search.listVAcsTokenExpression.Clear();
                search.listVAcsTokenExpression.Add(o => o.ID == NEGATIVE_ID);
            }
            return search;
        }
    }
}
