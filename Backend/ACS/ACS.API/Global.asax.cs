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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Inventec.Common.Logging;
using ACS.MANAGER.Base;
using Inventec.Common.Scheduler;
using AutoMapper;
using Newtonsoft.Json;

namespace ACS.API
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

                //Cau hinh JsonConvert
                JsonConvert.DefaultSettings = () => new JsonSerializerSettings
                {
                    Formatting = Newtonsoft.Json.Formatting.None,
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
                };


                AreaRegistration.RegisterAllAreas();
                WebApiConfig.Register(GlobalConfiguration.Configuration);
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);

                //Check mapper
                Mapper.AssertConfigurationIsValid();
                CreateMapType();                              

                //Khoi tao cac job scheduler
                QuartzScheduler.JobProcessor.AddJob();

                new ACS.MANAGER.Token.TokenManager().InitJwtKeyForStartApp();
                //new ACS.MANAGER.Token.TokenManager().InitTokenInActiveRamForStartApp();
                new ACS.MANAGER.Token.TokenManager().InitTokenInRamForStartApp(null);

                LogSystem.Info("Application_Start. Time=" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            }
            catch (Exception ex)
            {
                LogSystem.Info("Application_Start error: " + ex.Message + ". Time=" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            }
        }

        void CreateMapType()
        {
            try
            {
                Mapper.CreateMap<ACS.SDO.AcsRoleSDO, ACS.EFMODEL.DataModels.ACS_ROLE>().ReverseMap();
                Mapper.CreateMap<ACS.EFMODEL.DataModels.ACS_USER, ACS.EFMODEL.DataModels.ACS_USER>().ReverseMap();
                Mapper.CreateMap<ACS.EFMODEL.DataModels.ACS_ROLE_USER, ACS.EFMODEL.DataModels.ACS_ROLE_USER>().ReverseMap();
                Mapper.CreateMap<ACS.EFMODEL.DataModels.ACS_USER, ACS.SDO.AcsTokenAuthenticationSDO>().ReverseMap();
            }
            catch (Exception ex)
            {
                LogSystem.Warn(ex);
            }
        }
    }
}
