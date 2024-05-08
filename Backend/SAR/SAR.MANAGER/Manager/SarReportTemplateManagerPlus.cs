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
using SAR.MANAGER.Core.SarReportTemplate;
using Inventec.Core;
using System;
using AutoMapper;
using SAR.SDO;

namespace SAR.MANAGER.Manager
{
    public partial class SarReportTemplateManager : ManagerBase
    {
        public object Upload(object data)
        {
            object result = null;
            try
            {
                if (!IsNotNull(data)) throw new ArgumentNullException("data");
                SarReportTemplateBO bo = new SarReportTemplateBO();
                if (bo.Upload(data))
                {
                    Mapper.CreateMap<SAR.EFMODEL.DataModels.SAR_REPORT_TEMPLATE, SAR.EFMODEL.DataModels.SAR_REPORT_TEMPLATE>();
                    result = Mapper.Map<SAR.EFMODEL.DataModels.SAR_REPORT_TEMPLATE, SAR.EFMODEL.DataModels.SAR_REPORT_TEMPLATE>((SAR.EFMODEL.DataModels.SAR_REPORT_TEMPLATE)data);
                }
                CopyCommonParamInfo(bo);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }

        public object Download(object data)
        {
            SarReportTemplateDownloadSDO result = null;
            try
            {
                if (!IsNotNull(data)) throw new ArgumentNullException("data");
                SarReportTemplateBO bo = new SarReportTemplateBO();
                string resultUrl = bo.Download(data);
                if (!String.IsNullOrEmpty(resultUrl))
                {
                    result = new SarReportTemplateDownloadSDO();
                    result.ReportTemplateId = (long)data;
                    result.UrlResult = resultUrl;
                }
                CopyCommonParamInfo(bo);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }
    }
}
