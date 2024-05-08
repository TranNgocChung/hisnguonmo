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
using Inventec.Core;
using Inventec.Token.ResourceSystem;
using SDA.MANAGER.Base;
using System;

namespace SDA.MANAGER.Token
{
    public sealed partial class TokenManager : BusinessBase
    {
        private const string LANGUAGE = "LANGUAGE";

        public ApiResultObject<bool> UpdateLanguage(string language)
        {
            return new ApiResultObject<bool>(ResourceTokenManager.SetCredentialData(LANGUAGE, language), true);
        }

        public ApiResultObject<string> GetLanguage()
        {
            string language = ResourceTokenManager.GetCredentialData<string>(LANGUAGE);
            if (string.IsNullOrWhiteSpace(language))
            {
                Inventec.Common.Logging.LogSystem.Warn("language null or white space");
            }
            return new ApiResultObject<string>(language, true);
        }

        public ApiResultObject<bool> RemoveSession()
        {
            return this.PackSingleResult(ResourceTokenManager.RemoveSession());
        }
    }
}
