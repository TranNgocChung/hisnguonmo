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
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;
using SDA.PubSub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartup(typeof(SDA.API.Startup))]
namespace SDA.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            try
            {
                LogSystem.Info("Begin Configuration");
                //Install-Package Microsoft.Owin -V 2.1.0
                //Install-Package Microsoft.Owin.Host.SystemWeb -Version 2.1.0
                //Install-Package Microsoft.Owin.Security -Version 2.1.0
                AppDomain.CurrentDomain.Load(typeof(HisProHub).Assembly.FullName);

                var hubConfiguration = new HubConfiguration
                {
                    EnableDetailedErrors = true
                };
                app.MapSignalR(hubConfiguration);
                LogSystem.Info("End Configuration");
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }
    }
}
