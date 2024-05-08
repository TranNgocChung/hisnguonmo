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
using System;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SAR.API.Base
{
    public class ApiHeaderParamFilter : ActionFilterAttribute
    {
        Type _type;
        object _data;
        string _queryStringKey;
        public ApiHeaderParamFilter(Type type, string queryStringKey, object data)
        {
            _type = type;
            _queryStringKey = queryStringKey;
            _data = data;
        }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            try
            {
                //LogSystem.Debug(string.Format("User: {0}, Controller: {1}, Action: {2}", Inventec.Token.ResourceSystem.ResourceTokenManager.GetLoginName(), actionContext.ControllerContext.ControllerDescriptor.ControllerName, actionContext.ActionDescriptor.ActionName));

                var json = actionContext.Request.Headers.GetValues(_queryStringKey).FirstOrDefault(); ;
                if (json != null)
                {
                    //LogSystem.Debug(string.Format("Input: {0}", json));
                    this._data = JsonConvert.DeserializeObject(json, _type);
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                throw ex;
            }
        }
    }
}
