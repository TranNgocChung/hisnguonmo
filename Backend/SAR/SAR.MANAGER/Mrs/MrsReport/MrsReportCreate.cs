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
using Inventec.Core;
using SDA.SDO;
using System;
using SAR.EFMODEL.DataModels;
using Inventec.Common.WebApiClient;
using SAR.MANAGER.Core;
using SAR.MANAGER.Base;

namespace MRS.MANAGER.Sar.SarReport
{
    class MrsReportCreate : BeanObjectBase
    {
        internal MrsReportCreate(CommonParam paramCreate)
            : base(paramCreate)
        {

        }

        internal SAR.EFMODEL.DataModels.SAR_REPORT Create(MRS.SDO.CreateReportSDO data)
        {
            SAR.EFMODEL.DataModels.SAR_REPORT result = null;
            try
            {
                Inventec.Core.ApiResultObject<SAR.EFMODEL.DataModels.SAR_REPORT> rs = ApiConsumerStore.MrsConsumer.Post<Inventec.Core.ApiResultObject<SAR.EFMODEL.DataModels.SAR_REPORT>>("/api/MrsReport/CreateByCalendar", param, data);
                if (rs != null)
                {
                    if (rs.Param != null)
                    {
                        param.Messages.AddRange(rs.Param.Messages);
                        param.BugCodes.AddRange(rs.Param.BugCodes);
                    }
                    if (rs.Success) result = (rs.Data);
                }
            }
            catch (ApiException ex)
            {
                Inventec.Common.Logging.LogSystem.Info(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => ex.StatusCode), ex.StatusCode));
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }
    }
}
