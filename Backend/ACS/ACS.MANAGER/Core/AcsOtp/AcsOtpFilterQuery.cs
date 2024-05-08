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

namespace ACS.MANAGER.AcsOtp
{
    public class AcsOtpFilterQuery : AcsOtpFilter
    {
        public AcsOtpFilterQuery()
            : base()
        {

        }

        internal List<System.Linq.Expressions.Expression<Func<ACS_OTP, bool>>> listAcsOtpExpression = new List<System.Linq.Expressions.Expression<Func<ACS_OTP, bool>>>();



        internal AcsOtpSO Query()
        {
            AcsOtpSO search = new AcsOtpSO();
            try
            {
                #region Abstract Base
                if (this.ID.HasValue)
                {
                    listAcsOtpExpression.Add(o => o.ID == this.ID.Value);
                }
                if (this.IDs != null)
                {
                    listAcsOtpExpression.Add(o => this.IDs.Contains(o.ID));
                }
                if (this.IS_ACTIVE.HasValue)
                {
                    listAcsOtpExpression.Add(o => o.IS_ACTIVE == this.IS_ACTIVE.Value);
                }
                if (this.CREATE_TIME_FROM.HasValue)
                {
                    listAcsOtpExpression.Add(o => o.CREATE_TIME.Value >= this.CREATE_TIME_FROM.Value);
                }
                if (this.CREATE_TIME_TO.HasValue)
                {
                    listAcsOtpExpression.Add(o => o.CREATE_TIME.Value <= this.CREATE_TIME_TO.Value);
                }
                if (this.MODIFY_TIME_FROM.HasValue)
                {
                    listAcsOtpExpression.Add(o => o.MODIFY_TIME.Value >= this.MODIFY_TIME_FROM.Value);
                }
                if (this.MODIFY_TIME_TO.HasValue)
                {
                    listAcsOtpExpression.Add(o => o.MODIFY_TIME.Value <= this.MODIFY_TIME_TO.Value);
                }
                if (!String.IsNullOrEmpty(this.CREATOR))
                {
                    listAcsOtpExpression.Add(o => o.CREATOR == this.CREATOR);
                }
                if (!String.IsNullOrEmpty(this.MODIFIER))
                {
                    listAcsOtpExpression.Add(o => o.MODIFIER == this.MODIFIER);
                }
                if (!String.IsNullOrEmpty(this.GROUP_CODE))
                {
                    listAcsOtpExpression.Add(o => o.GROUP_CODE == this.GROUP_CODE);
                }

                #endregion

                if (!String.IsNullOrEmpty(this.OTP_CODE__EXACT))
                {
                    listAcsOtpExpression.Add(o => o.OTP_CODE == this.OTP_CODE__EXACT);
                }
                if (this.OTP_TYPE.HasValue)
                {
                    listAcsOtpExpression.Add(o => o.OTP_TYPE == this.OTP_TYPE.Value);
                }
                if (this.OTP_TYPEs != null)
                {
                    listAcsOtpExpression.Add(o => this.OTP_TYPEs.Contains(o.OTP_TYPE));
                }
                if (this.OTP_TYPE_ID.HasValue)
                {
                    listAcsOtpExpression.Add(o => o.OTP_TYPE_ID == this.OTP_TYPE_ID.Value);
                }
                if (this.OTP_TYPE_IDs != null)
                {
                    listAcsOtpExpression.Add(o => this.OTP_TYPE_IDs.Contains(o.OTP_TYPE_ID));
                }
                if (!String.IsNullOrEmpty(this.LOGINNAME__EXACT))
                {
                    listAcsOtpExpression.Add(o => o.LOGINAME == this.LOGINNAME__EXACT);
                }
                if (!String.IsNullOrEmpty(this.MOBILE__EXACT))
                {
                    listAcsOtpExpression.Add(o => o.MOBILE == this.MOBILE__EXACT);
                }
                if (!String.IsNullOrEmpty(this.LOGINNAME_OR_MOBILE__EXACT))
                {
                    listAcsOtpExpression.Add(o => o.LOGINAME == this.LOGINNAME_OR_MOBILE__EXACT || o.MOBILE == this.LOGINNAME_OR_MOBILE__EXACT);
                }
                if (this.IS_HAS_EXPIRE.HasValue)
                {
                    long nowTime = Inventec.Common.DateTime.Get.Now().Value;
                    if (this.IS_HAS_EXPIRE.Value)
                    {
                        listAcsOtpExpression.Add(o => o.EXPIRE_TIME.HasValue && o.EXPIRE_TIME.Value >= nowTime);
                    }
                    else
                    {
                        listAcsOtpExpression.Add(o => o.EXPIRE_TIME.HasValue && o.EXPIRE_TIME.Value < nowTime);
                    }
                }

                if (this.EXPIRE_DATE__EXACT.HasValue)
                {
                    listAcsOtpExpression.Add(o => o.VIR_EXPIRE_DATE.HasValue && o.VIR_EXPIRE_DATE.Value == this.EXPIRE_DATE__EXACT.Value);
                }

                search.listAcsOtpExpression.AddRange(listAcsOtpExpression);
                search.OrderField = ORDER_FIELD;
                search.OrderDirection = ORDER_DIRECTION;
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                search.listAcsOtpExpression.Clear();
                search.listAcsOtpExpression.Add(o => o.ID == NEGATIVE_ID);
            }
            return search;
        }
    }
}
