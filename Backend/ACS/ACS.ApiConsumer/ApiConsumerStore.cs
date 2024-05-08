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
using Inventec.Common.WebApiClient;
using Inventec.Token.ResourceSystem;
using System.Configuration;

namespace ACS.ApiConsumerManager
{
    public class ApiConsumerStore
    {
        private static ApiConsumer sdaConsumer;
        public static ApiConsumer SdaConsumer
        {
            get
            {
                if (sdaConsumer == null)
                {
                    sdaConsumer = new ApiConsumer(ACS.LibraryConfig.WebConfig.URI_API_SDA, ACS.UTILITY.Constant.APPLICATION_CODE);
                }
                return sdaConsumer;
            }
        }

        public static ApiConsumer AcsConsumer
        {
            get
            {
                string tokenCode = ResourceTokenManager.GetTokenCode();
                return new ApiConsumer(ACS.LibraryConfig.WebConfig.URI_API_ACS, tokenCode, ACS.UTILITY.Constant.APPLICATION_CODE);
            }
        }

        public static ApiConsumer SmsConsumer
        {
            get
            {
                string tokenCode = ResourceTokenManager.GetTokenCode();
                return new ApiConsumer(ACS.LibraryConfig.WebConfig.URI_API_SMS, tokenCode, ACS.UTILITY.Constant.APPLICATION_CODE);
            }
        }
      
    }
}
