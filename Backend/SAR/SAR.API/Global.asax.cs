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
using AutoMapper;
using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace SAR.API
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            try
            {
                log4net.Config.XmlConfigurator.Configure();
                Newtonsoft.Json.JsonConvert.DefaultSettings = () => new Newtonsoft.Json.JsonSerializerSettings
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                };
                Inventec.Common.Logging.LogSystem.Info("Bat he thong.");
                new Inventec.Common.Scheduler.JobManager().ExecuteAllJobs();
                //SAR.MANAGER.Config.License.Check();

                AreaRegistration.RegisterAllAreas();

                WebApiConfig.Register(GlobalConfiguration.Configuration);
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);

                //Check mapper
                Mapper.AssertConfigurationIsValid();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error("Bat he thong: co loi xay ra.", ex);
            }
        }

        protected void Application_End()
        {
            Inventec.Common.Logging.LogSystem.Info("Tat he thong.");
        }
    }
}
