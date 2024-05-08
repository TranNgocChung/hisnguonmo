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
using SDA.SDO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDA.UTILITY
{
    public class RsaHash
    {
        public static string PublicKey
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCBdRGp9rFsCmx18c");
                sb.Append("Co8N+XSu/4vyFZ9FkobcB9WS7PiHhnBCotuN3rUMoj1iXJuZ1Tqkw7");
                sb.Append("AGjPJ1hBAa6cCMfSQlQX8FVDb+4136eJZp6M7AaNprd/KtnzLB3uIc");
                sb.Append("DAPsjhYKxMcWWY/ov7JqhRSePU7X7NZFCiMA6M+DGsQB3BPQIDAQAB");
                return sb.ToString();
            }
        }

        public static SdaLicenseSDO GetLicense(string license)
        {
            SdaLicenseSDO result = null;

            string decode = new Inventec.Common.HashUtil.RsaHashProcessor().Decrypt(license, PublicKey);
            decode = decode.Substring(decode.IndexOf('{'));
            if (!String.IsNullOrWhiteSpace(decode))
            {
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<SdaLicenseSDO>(decode);
                result.License = license;
            }

            return result;
        }
    }
}
