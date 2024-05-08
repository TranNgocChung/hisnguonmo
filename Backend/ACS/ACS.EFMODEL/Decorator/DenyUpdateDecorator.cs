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
using ACS.EFMODEL.DataModels;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ACS.EFMODEL.Decorator
{
    public partial class DenyUpdateDecorator
    {
        private static Dictionary<Type, List<string>> properties = new Dictionary<Type, List<string>>();
        private static bool isLoaded = false;
        private static void Load()
        {
            try
            {
                if (!isLoaded)
                {
                    LoadAcsApplication();
                    LoadAcsApplicationRole();
                    LoadAcsControl();
                    LoadAcsControlRole();
                    LoadAcsCredentialData();
                    LoadAcsModule();
                    LoadAcsModuleGroup();
                    LoadAcsModuleRole();
                    LoadAcsRole();
                    LoadAcsRoleBase();
                    LoadAcsRoleUser();
                    LoadAcsUser();
                    LoadAcsToken();
					LoadAcsOtp();
					LoadAcsAuthenRequest();
					LoadAcsAuthorSystem();
					LoadAcsRoleAuthor();
                    LoadAcsActivityLog();
                    LoadAcsActivityType();
                    LoadAcsOtpType();
                    LoadAcsAppOtpType();
                    isLoaded = true;
                }
            }
            catch (Exception)
            {

            }
        }

        public static List<string> Get<RAW>()
        {
            try
            {
                Load();
                if (properties.ContainsKey(typeof(RAW)))
                {
                    return properties[typeof(RAW)];
                }
            }
            catch (Exception)
            {

            }
            return null;
        }
    }
}
