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
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace SAR.API.Base
{
    public class ApiResult : IHttpActionResult
    {
        private object resultValue;
        private HttpActionContext actionContext;

        public ApiResult(object value, HttpActionContext context)
        {
            resultValue = value;
            actionContext = context;
        }

        /// <summary>
        /// Xu ly ket qua truoc khi tra ve client
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            string temp = "";
            try
            {
                HttpContent content = null;
                if (resultValue != null)
                {
                    if (resultValue.GetType() == typeof(bool) || resultValue.GetType() == typeof(Boolean))
                    {
                        temp = resultValue.ToString().ToLower();
                        content = new StringContent(temp);
                    }
                    else if (resultValue.GetType().IsPrimitive || resultValue.GetType() == typeof(string))
                    {
                        temp = resultValue + "";
                        content = new StringContent(temp);
                    }
                    else if (resultValue.GetType() == typeof(FileHolder))
                    {
                        FileHolder sr = (FileHolder)resultValue;
                        if (sr != null)
                        {
                            content = new StreamContent(sr.Content);
                            content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                            content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                            content.Headers.ContentDisposition.FileName = sr.FileName;
                        }
                    }
                    else
                    {
                        temp = JsonConvert.SerializeObject(resultValue);
                        content = new StringContent(temp);
                    }
                }

                var response = new HttpResponseMessage()
                {
                    Content = content,
                    RequestMessage = actionContext.Request
                };
                return Task.FromResult(response);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
            return null;
        }
    }
}
