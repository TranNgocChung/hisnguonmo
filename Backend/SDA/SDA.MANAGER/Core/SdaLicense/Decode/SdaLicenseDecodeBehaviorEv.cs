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
using Inventec.Core;
using SDA.LibraryBug;
using SDA.LibraryMessage;
using SDA.MANAGER.Base;
using SDA.SDO;
using SDA.UTILITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDA.MANAGER.Core.SdaLicense.Decode
{
    class SdaLicenseDecodeBehaviorEv : BeanObjectBase, ISdaLicenseDecode
    {
        string entity;

        internal SdaLicenseDecodeBehaviorEv(CommonParam param, string data)
            : base(param)
        {
            entity = data;
        }

        object ISdaLicenseDecode.Run()
        {
            SdaLicenseSDO result = null;
            try
            {
                if (this.Check())
                {
                    result = RsaHash.GetLicense(this.entity);
                }
            }
            catch (Exception ex)
            {
                MessageUtil.SetMessage(param, Message.Enum.SdaLicense_MaKichHoatKhongHopLe);
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }

        bool Check()
        {
            bool valid = true;
            try
            {
                if (entity == null) throw new ArgumentNullException("data");
            }
            catch (ArgumentNullException ex)
            {
                MessageUtil.SetMessage(param, Message.Enum.Common__DuLieuKhongHopLe);
                LogSystem.Warn(ex);
                valid = false;
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                valid = false;
                param.HasException = true;
            }
            return valid;
        }
    }
}
