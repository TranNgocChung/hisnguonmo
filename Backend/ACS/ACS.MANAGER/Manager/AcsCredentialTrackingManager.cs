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
using ACS.MANAGER.Core.AcsUser;
using ACS.SDO;
using Inventec.Core;
using System;
using System.Collections.Generic;

namespace ACS.MANAGER.Manager
{
    public partial class AcsCredentialTrackingManager : Inventec.Backend.MANAGER.ManagerBase
    {
        public AcsCredentialTrackingManager()
            : base(new CommonParam())
        {
        }

        /// <summary>
        /// Phần mềm cần chức năng để kiểm soát số lượng máy/ tài khoản/ phiên bản phần mềm đang kết nối với hệ thống HIS
        /// để đánh giá hiệu năng, kiểm soát lỗi.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public object Get(object data)
        {
            object result = null;
            try
            {
                if (!IsNotNull(data)) throw new ArgumentNullException("data");

                List<AcsCredentialTrackingSDO> credentialTrackingSDOs = new List<AcsCredentialTrackingSDO>();

                AcsCredentialTrackingSDO itemTracking = new AcsCredentialTrackingSDO();

                credentialTrackingSDOs.Add(itemTracking);

                result = credentialTrackingSDOs;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = null;
            }
            return result;
        }

    }
}
