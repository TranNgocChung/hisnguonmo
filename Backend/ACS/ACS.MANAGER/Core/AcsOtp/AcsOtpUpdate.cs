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
using ACS.EFMODEL.DataModels;
using ACS.MANAGER.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACS.MANAGER.AcsOtp
{
    partial class AcsOtpUpdate : BusinessBase
    {
		private List<ACS_OTP> beforeUpdateAcsOtps = new List<ACS_OTP>();
		
        internal AcsOtpUpdate()
            : base()
        {

        }

        internal AcsOtpUpdate(CommonParam paramUpdate)
            : base(paramUpdate)
        {

        }

        internal bool Update(ACS_OTP data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                AcsOtpCheck checker = new AcsOtpCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                ACS_OTP raw = null;
                valid = valid && checker.VerifyId(data.ID, ref raw);
                valid = valid && checker.IsUnLock(raw);
                if (valid)
                {                    
					if (!DAOWorker.AcsOtpDAO.Update(data))
                    {
                        ACS.MANAGER.Base.BugUtil.SetBugCode(param, ACS.LibraryBug.Bug.Enum.AcsOtp_CapNhatThatBai);
                        throw new Exception("Cap nhat thong tin AcsOtp that bai." + LogUtil.TraceData("data", data));
                    }
					this.beforeUpdateAcsOtps.Add(raw);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = false;
            }
            return result;
        }

        internal bool UpdateList(List<ACS_OTP> listData)
        {
            bool result = false;
            try
            {
                bool valid = true;
                valid = IsNotNullOrEmpty(listData);
                AcsOtpCheck checker = new AcsOtpCheck(param);
                List<ACS_OTP> listRaw = new List<ACS_OTP>();
                List<long> listId = listData.Select(o => o.ID).ToList();
                valid = valid && checker.VerifyIds(listId, listRaw);
                valid = valid && checker.IsUnLock(listRaw);
                foreach (var data in listData)
                {
                    valid = valid && checker.VerifyRequireField(data);
                }
                if (valid)
                {
					if (!DAOWorker.AcsOtpDAO.UpdateList(listData))
                    {
                        ACS.MANAGER.Base.BugUtil.SetBugCode(param, ACS.LibraryBug.Bug.Enum.AcsOtp_CapNhatThatBai);
                        throw new Exception("Cap nhat thong tin AcsOtp that bai." + LogUtil.TraceData("listData", listData));
                    }
					
					this.beforeUpdateAcsOtps.AddRange(listRaw);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = false;
            }
            return result;
        }
		
		internal void RollbackData()
        {
            if (IsNotNullOrEmpty(this.beforeUpdateAcsOtps))
            {
                if (!DAOWorker.AcsOtpDAO.UpdateList(this.beforeUpdateAcsOtps))
                {
                    LogSystem.Warn("Rollback du lieu AcsOtp that bai, can kiem tra lai." + LogUtil.TraceData("AcsOtps", this.beforeUpdateAcsOtps));
                }
				this.beforeUpdateAcsOtps = null;
            }
        }
    }
}
