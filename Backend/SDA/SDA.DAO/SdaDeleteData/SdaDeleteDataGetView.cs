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
using SDA.DAO.Base;
using SDA.DAO.StagingObject;
using SDA.EFMODEL.DataModels;
using Inventec.Common.Logging;
using Inventec.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SDA.DAO.SdaDeleteData
{
    partial class SdaDeleteDataGet : EntityBase
    {
        public List<V_SDA_DELETE_DATA> GetView(SdaDeleteDataSO search, CommonParam param)
        {
            List<V_SDA_DELETE_DATA> list = new List<V_SDA_DELETE_DATA>();
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                if (valid)
                {
                    using (var ctx = new AppContext())
                    {
                        var query = ctx.V_SDA_DELETE_DATA.AsQueryable();
                        if (search.listVSdaDeleteDataExpression != null && search.listVSdaDeleteDataExpression.Count > 0)
                        {
                            foreach (var item in search.listVSdaDeleteDataExpression)
                            {
                                query = query.Where(item);
                            }
                        }
                        int start = param.Start.HasValue ? param.Start.Value : 0;
                        int limit = param.Limit.HasValue ? param.Limit.Value : Int32.MaxValue;
                        list = query.OrderByProperty(search.OrderField, search.OrderDirection).Skip(start).Take(limit).ToList();
                        param.Count = (from r in query select r).Count();
                    }
                }
            }
            catch (Exception ex)
            {
                Logging(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => search), search) + Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => param), param), LogType.Error);
                LogSystem.Error(ex);
                list.Clear();
            }
            return list;
        }
    }
}
