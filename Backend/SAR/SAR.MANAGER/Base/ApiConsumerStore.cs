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
using System;
namespace SAR.MANAGER.Base
{
    class ApiConsumerStore
    {
        static string uriMrs = System.Configuration.ConfigurationManager.AppSettings["MANAGER.Base.ApiConsumerStore.Mrs"];

        private static Inventec.Common.WebApiClient.ApiConsumer sdaConsumer;
        internal static Inventec.Common.WebApiClient.ApiConsumer SdaConsumer
        {
            get
            {
                if (sdaConsumer == null)
                {
                    sdaConsumer = new Inventec.Common.WebApiClient.ApiConsumer(System.Configuration.ConfigurationManager.AppSettings["MANAGER.Base.ApiConsumerStore.Sda"], ApplicationConfig.APPLICATION_CODE);
                }
                return sdaConsumer;
            }
        }

        internal static Inventec.Common.WebApiClient.ApiConsumer MrsConsumer
        {
            get
            {
                return new Inventec.Common.WebApiClient.ApiConsumer(uriMrs, ApplicationConfig.APPLICATION_CODE);
            }
        }
    }
}
