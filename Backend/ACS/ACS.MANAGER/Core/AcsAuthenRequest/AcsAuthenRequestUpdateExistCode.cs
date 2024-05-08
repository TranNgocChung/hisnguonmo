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

namespace ACS.MANAGER.AcsAuthenRequest
{
    partial class AcsAuthenRequestUpdate : BusinessBase
    {
		private List<ACS_AUTHEN_REQUEST> beforeUpdateAcsAuthenRequests = new List<ACS_AUTHEN_REQUEST>();
		
        internal AcsAuthenRequestUpdate()
            : base()
        {

        }

        internal AcsAuthenRequestUpdate(CommonParam paramUpdate)
            : base(paramUpdate)
        {

        }

        internal bool Update(ACS_AUTHEN_REQUEST data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                AcsAuthenRequestCheck checker = new AcsAuthenRequestCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                ACS_AUTHEN_REQUEST raw = null;
                valid = valid && checker.VerifyId(data.ID, ref raw);
                valid = valid && checker.IsUnLock(raw);
                valid = valid && checker.ExistsCode(data.AUTHEN_REQUEST_CODE, data.ID);
                if (valid)
                {
					if (!DAOWorker.AcsAuthenRequestDAO.Update(data))
                    {
                        ACS.MANAGER.Base.BugUtil.SetBugCode(param, ACS.LibraryBug.Bug.Enum.AcsAuthenRequest_CapNhatThatBai);
                        throw new Exception("Cap nhat thong tin AcsAuthenRequest that bai." + LogUtil.TraceData("data", data));
                    }
					
					this.beforeUpdateAcsAuthenRequests.Add(raw);
                    
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

        internal bool UpdateList(List<ACS_AUTHEN_REQUEST> listData)
        {
            bool result = false;
            try
            {
                bool valid = true;
                valid = IsNotNullOrEmpty(listData);
                AcsAuthenRequestCheck checker = new AcsAuthenRequestCheck(param);
                List<ACS_AUTHEN_REQUEST> listRaw = new List<ACS_AUTHEN_REQUEST>();
                List<long> listId = listData.Select(o => o.ID).ToList();
                valid = valid && checker.VerifyIds(listId, listRaw);
                valid = valid && checker.IsUnLock(listRaw);
                foreach (var data in listData)
                {
                    valid = valid && checker.VerifyRequireField(data);
                    valid = valid && checker.ExistsCode(data.AUTHEN_REQUEST_CODE, data.ID);
                }
                if (valid)
                {
					if (!DAOWorker.AcsAuthenRequestDAO.UpdateList(listData))
                    {
                        ACS.MANAGER.Base.BugUtil.SetBugCode(param, ACS.LibraryBug.Bug.Enum.AcsAuthenRequest_CapNhatThatBai);
                        throw new Exception("Cap nhat thong tin AcsAuthenRequest that bai." + LogUtil.TraceData("listData", listData));
                    }
					this.beforeUpdateAcsAuthenRequests.AddRange(listRaw);
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
            if (IsNotNullOrEmpty(this.beforeUpdateAcsAuthenRequests))
            {
                if (!DAOWorker.AcsAuthenRequestDAO.UpdateList(this.beforeUpdateAcsAuthenRequests))
                {
                    LogSystem.Warn("Rollback du lieu AcsAuthenRequest that bai, can kiem tra lai." + LogUtil.TraceData("AcsAuthenRequests", this.beforeUpdateAcsAuthenRequests));
                }
				this.beforeUpdateAcsAuthenRequests = null;
            }
        }
    }
}
