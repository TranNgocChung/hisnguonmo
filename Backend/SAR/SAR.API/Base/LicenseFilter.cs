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
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SAR.API.Base
{
    public class LicenseFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            if (!SAR.MANAGER.Config.License.ValidLicense)
            {
                Inventec.Common.Logging.LogSystem.Error("License khong hop le.");
                var response = new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.Forbidden,
                    Content = new StringContent("Invalid license."),
                    RequestMessage = filterContext.Request
                };
                filterContext.Response = response;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
