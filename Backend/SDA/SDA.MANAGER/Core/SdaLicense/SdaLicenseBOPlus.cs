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

namespace SDA.MANAGER.Core.SdaLicense
{
    partial class SdaLicenseBO : BusinessObjectBase
    {
        internal T GetLast<T>(object data)
        {
            T result = default(T);
            try
            {
                IDelegacyT delegacy = new SdaLicenseGetLast(param, data);
                result = delegacy.Execute<T>();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = default(T);
            }
            return result;
        }

        internal T Decode<T>(object data)
        {
            T result = default(T);
            try
            {
                IDelegacyT delegacy = new SdaLicenseDecode(param, data);
                result = delegacy.Execute<T>();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = default(T);
            }
            return result;
        }

        internal T CreateT<T>(object data)
        {
            T result = default(T);
            try
            {
                IDelegacyT delegacy = new SdaLicenseCreateT(param, data);
                result = delegacy.Execute<T>();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = default(T);
            }
            return result;
        }

        internal T UpdateT<T>(object data)
        {
            T result = default(T);
            try
            {
                IDelegacyT delegacy = new SdaLicenseUpdateT(param, data);
                result = delegacy.Execute<T>();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = default(T);
            }
            return result;
        }
    }
}
