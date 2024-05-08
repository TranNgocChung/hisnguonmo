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

using Inventec.Common.Logging;
using Inventec.A2Manager;
using System.Collections.Generic;
using ACS.LDP.Base;
using ACS.EFMODEL.DataModels;
using Inventec.Common.Auth;

namespace ACS.LDP.DataPriv
{
    public class AcsRoleApprDataPriv : BaseDataPriv<ACS_EV_ACS_ROLE_APPR>
    {
        public AcsRoleApprDataPriv()
            : base(DataCodeConstant.ACS_ROLE_APPR)
        {
        }

        public void VerifyGet(string moduleCode, List<System.Linq.Expressions.Expression<Func<ACS_EV_ACS_ROLE_APPR, bool>>> query)
        {
            string dataGrant = "";
            try
            {
                dataGrant = A2.DetermineDataGrant(moduleCode, DataType, DataGrantTypeCodeConstant.GET);
                UserData user = A2.GetUserData();
                if (user != null)
                {
                    switch (dataGrant)
                    {
                        case DataGrantCodeConstant.GET_ALL:
                            break;
                        case DataGrantCodeConstant.GET_CHILD:
                            query.Add(o => user.LIST_GROUP_CODE.Contains(o.GROUP_CODE));
                            break;
                        case DataGrantCodeConstant.GET_GROUP:
                            query.Add(o => user.GROUP_CODE == o.GROUP_CODE);
                            break;
                        case DataGrantCodeConstant.GET_MINE:
                            query.Add(o => user.USER_NAME == o.CREATOR);
                            break;
                        default:
                            query.Add(o => o.ID == NEGATIVE_ID);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error("Kiem tra phan quyen VerifyGet co exception." + LogUtil.TraceData(LogUtil.GetMemberName(() => moduleCode), moduleCode) + LogUtil.TraceData(LogUtil.GetMemberName(() => dataGrant), dataGrant), ex);
                query.Add(o => o.ID == NEGATIVE_ID);
            }
        }
    }
}
