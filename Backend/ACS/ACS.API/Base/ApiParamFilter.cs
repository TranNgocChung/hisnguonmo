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
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ACS.API.Base
{
    public class ApiParamFilter : ActionFilterAttribute
    {
        Type _type;
        string _queryStringKey;
        public ApiParamFilter(Type type, string queryStringKey)
        {
            _type = type;
            _queryStringKey = queryStringKey;
        }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            try
            {
                LogSystem.Debug(string.Format("User: {0}, Controller: {1}, Action: {2}", Inventec.Token.ResourceSystem.ResourceTokenManager.GetLoginName(), actionContext.ControllerContext.ControllerDescriptor.ControllerName, actionContext.ActionDescriptor.ActionName));
                var json = HttpUtility.ParseQueryString(actionContext.Request.RequestUri.Query)[_queryStringKey];
                if (json != null)
                {
                    json = json.Replace(' ', '+');
                    json = Encoding.UTF8.GetString(Convert.FromBase64String(json));
                    LogSystem.Debug(string.Format("Input: {0}", json));
                    JsonSerializerSettings setting = new JsonSerializerSettings { Error = HandleDeserializationError };
                    actionContext.ActionArguments[_queryStringKey] = JsonConvert.DeserializeObject(json, _type, setting);
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                throw ex;
            }
        }

        public static void HandleDeserializationError(object sender, ErrorEventArgs errorArgs)
        {
            errorArgs.ErrorContext.Handled = true;
        }
    }
}
