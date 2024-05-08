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
using ACS.MANAGER.AcsOtp;
using ACS.MANAGER.Base;
using Inventec.Core;
using System;
using System.Collections.Generic;

namespace ACS.MANAGER.Core.Check
{
    class AcsOtpCheckVerifyValidData
    {
        internal static bool Verify(CommonParam param, AcsOtpFilterQuery data)
        {
            bool result = true;
            try
            {
                if (data == null) throw new ArgumentNullException("data");
                if (data.MOBILE__EXACT == null) throw new ArgumentNullException("MOBILE__EXACT");
            }
            catch (ArgumentNullException ex)
            {
                ACS.MANAGER.Base.BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.Common__ThieuThongTinBatBuoc);
                param.Messages.Add(MessageUtil.GetMessage(LibraryMessage.Message.Enum.Common__ThieuThongTinBatBuoc));
                Inventec.Common.Logging.LogSystem.Warn(ex);
                result = false;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
                param.HasException = true;
            }
            return result;
        }
    }
}
