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
using SAR.EFMODEL.DataModels;
using SAR.MANAGER.Base;
using SAR.MANAGER.Core.Check;
using Inventec.Core;
using System;
using SAR.SDO;
using System.Collections.Generic;
using Inventec.Fss.Utility;
using Inventec.Fss.Client;
using AutoMapper;
using SAR.MANAGER.Core.SarReportType;

namespace SAR.MANAGER.Core.SarReportTemplate.Upload
{
    class SarReportTemplateUploadBehaviorSDO : BeanObjectBase, ISarReportTemplateUpload
    {
        SarReportTemplateSDO entity;
        List<FileUploadInfo> fileUploadInfos;
        SAR_REPORT_TYPE reportType = null;

        internal SarReportTemplateUploadBehaviorSDO(CommonParam param, SarReportTemplateSDO data)
            : base(param)
        {
            entity = data;
        }

        bool ISarReportTemplateUpload.Run()
        {
            bool result = false;
            try
            {
                if (Check())
                {
                    if (UploadFile(entity))
                    {
                        //entity.REPORT_TEMPLATE_URL = string.Format("{\"FILE_NAME\":\"{0}\",\"URL\":\"{1}\",\"EXTENSION\":\"{2}\"}", fileUploadInfos[0].OriginalName, fileUploadInfos[0].Url, entity.EXTENSION_RECEIVE);
                        string extension = System.IO.Path.GetExtension(fileUploadInfos[0].OriginalName);
                        string originalName = reportType.REPORT_TYPE_CODE + "_" + reportType.REPORT_TYPE_NAME + "_" + entity.REPORT_TEMPLATE_CODE + "_" + entity.REPORT_TEMPLATE_NAME + extension;
                        entity.REPORT_TEMPLATE_URL = "{\"FILE_NAME\":\"" + originalName + "\",\"URL\":\"" + fileUploadInfos[0].Url.Replace("\\", "\\\\") + "\",\"EXTENSION\":\"" + entity.EXTENSION_RECEIVE + "\"}";
                        entity.REPORT_TEMPLATE_URL = entity.REPORT_TEMPLATE_URL.Replace("\\", "\\\\");
                        Mapper.CreateMap<SarReportTemplateSDO, SAR.EFMODEL.DataModels.SAR_REPORT_TEMPLATE>();
                        var raw = Mapper.Map<SarReportTemplateSDO, SAR.EFMODEL.DataModels.SAR_REPORT_TEMPLATE>(entity);
                        result = DAOWorker.SarReportTemplateDAO.Update(raw);
                        Mapper.CreateMap<SAR.EFMODEL.DataModels.SAR_REPORT_TEMPLATE, SarReportTemplateSDO>();
                        entity = Mapper.Map<SAR.EFMODEL.DataModels.SAR_REPORT_TEMPLATE, SarReportTemplateSDO>(raw);
                    }
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                result = false;
            }
            return result;
        }

        bool Check()
        {
            bool result = true;
            try
            {
                result = result && SarReportTemplateCheckVerifyValidData.Verify(param, entity);
                result = result && SarReportTemplateCheckVerifyIsUnlock.Verify(param, entity.ID);
                result = result && SarReportTypeCheckVerifyId.Verify(param, entity.REPORT_TYPE_ID, ref reportType);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                result = false;
            }
            return result;
        }

        bool UploadFile(SarReportTemplateSDO entity)
        {
            bool success = false;
            try
            {
                List<FileHolder> fileHolders = new List<FileHolder>();
                if (entity.FileUpload != null && entity.FileUpload.Count > 0)
                {
                    for (int i = 0; i < entity.FileUpload.Count; i++)
                    {
                        FileHolder file = new FileHolder();
                        string extension = System.IO.Path.GetExtension(entity.FileUpload[i].FileName);
                        file.FileName = reportType.REPORT_TYPE_CODE + "_" + reportType.REPORT_TYPE_NAME + "_" + entity.REPORT_TEMPLATE_CODE + "_" + entity.REPORT_TEMPLATE_NAME + extension;
                        file.Content = new System.IO.MemoryStream();
                        entity.FileUpload[i].InputStream.CopyTo(file.Content);
                        file.Content.Position = 0;
                        fileHolders.Add(file);
                    }

                    fileUploadInfos = FileUpload.UploadFile(ManagerConstant.DSS_CLIENT_CODE, FileStoreLocation.REPORT_TEMPLATE, fileHolders, true);
                    if (fileUploadInfos != null && fileUploadInfos.Count > 0)
                    {
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }

            return success;
        }
    }
}
