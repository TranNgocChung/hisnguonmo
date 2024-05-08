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
using SAR.MANAGER.Base;
using Inventec.Core;
using System;
using System.Text;

namespace SAR.MANAGER.Core.SarReport.GetFile
{
    class SarReportGetFileBehavior : BeanObjectBase, ISarReportGetFile
    {
        SAR.EFMODEL.DataModels.SAR_REPORT entity;
        private readonly string folderSeparate = System.Configuration.ConfigurationManager.AppSettings["MRS.MANAGER.Core.MrsReport.Create.MrsReportCreateBase.FolderSeparate"];
        private readonly string templateReportFolder = System.Configuration.ConfigurationManager.AppSettings["MRS.MANAGER.Core.MrsReport.Create.MrsReportCreateBase.TemplateReportFolder"];
        private readonly string downloadReportFolder = System.Configuration.ConfigurationManager.AppSettings["MRS.MANAGER.Core.MrsReport.Create.MrsReportCreateBase.DownloadReportFolder"];

        long reportId;
        internal SarReportGetFileBehavior(CommonParam param, long filter)
            : base(param)
        {
            reportId = filter;
        }

        FileHolder ISarReportGetFile.Run()
        {
            FileHolder result = null;
            try
            {
                if (!IsGreaterThanZero(reportId)) throw new ArgumentNullException("reportId is null");
                entity = new SAR.MANAGER.Core.SarReport.SarReportBO().Get<SAR.EFMODEL.DataModels.SAR_REPORT>(reportId);

                if (!IsNotNull(entity)) throw new ArgumentNullException("entity");
                if (String.IsNullOrEmpty(entity.REPORT_URL)) throw new ArgumentNullException("entity.REPORT_URL");

                System.IO.MemoryStream stream = Inventec.Fss.Client.FileDownload.GetFile(entity.REPORT_URL);
                if (stream != null)
                {
                    result = new FileHolder();
                    result.Content = stream;
                }

                //StringBuilder sbTemplateUriSar = new StringBuilder().Append(BaseUriStore.GetFssUri);
                //StringBuilder sbReport = new StringBuilder().Append(folderSeparate).Append(downloadReportFolder).Append(folderSeparate).Append(entity.REPORT_URL.ToString());
                //string pathFile = System.Web.Hosting.HostingEnvironment.MapPath(sbReport.ToString()).Replace("\\\\", "/");
                //if (System.IO.File.Exists(pathFile))
                //{
                //    result = new FileHolder();
                //    result.FileName = entity.REPORT_NAME;
                //    result.Content = new System.IO.MemoryStream();
                //    System.Net.FileWebRequest fileReq = (System.Net.FileWebRequest)System.Net.HttpWebRequest.Create(pathFile);
                //    //Create a response for this request
                //    System.Net.FileWebResponse fileResp = (System.Net.FileWebResponse)fileReq.GetResponse();
                //    if (fileReq.ContentLength > 0)
                //        fileResp.ContentLength = fileReq.ContentLength;
                //    //Get the Stream returned from the response
                //    System.IO.Stream stream = fileResp.GetResponseStream();
                //    result.Content = new System.IO.MemoryStream();
                //    stream.CopyTo(result.Content);
                //    result.Content.Position = 0;
                //}
                return result;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }
    }
}
