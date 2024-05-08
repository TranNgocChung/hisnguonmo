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

namespace ACS.MANAGER.AcsAuthenRequest
{
    partial class AcsAuthenRequestCreate : BusinessBase
    {
		private List<ACS_AUTHEN_REQUEST> recentAcsAuthenRequests = new List<ACS_AUTHEN_REQUEST>();
		
        internal AcsAuthenRequestCreate()
            : base()
        {

        }

        internal AcsAuthenRequestCreate(CommonParam paramCreate)
            : base(paramCreate)
        {

        }

        internal bool Create(ACS_AUTHEN_REQUEST data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                AcsAuthenRequestCheck checker = new AcsAuthenRequestCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                valid = valid && checker.ExistsCode(data.AUTHEN_REQUEST_CODE, null);
                if (valid)
                {
					if (!DAOWorker.AcsAuthenRequestDAO.Create(data))
                    {
                        ACS.MANAGER.Base.BugUtil.SetBugCode(param, ACS.LibraryBug.Bug.Enum.AcsAuthenRequest_ThemMoiThatBai);
                        throw new Exception("Them moi thong tin AcsAuthenRequest that bai." + LogUtil.TraceData("data", data));
                    }
                    this.recentAcsAuthenRequests.Add(data);
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
            if (IsNotNullOrEmpty(this.recentAcsAuthenRequests))
            {
                if (!DAOWorker.AcsAuthenRequestDAO.TruncateList(this.recentAcsAuthenRequests))
                {
                    LogSystem.Warn("Rollback du lieu AcsAuthenRequest that bai, can kiem tra lai." + LogUtil.TraceData("recentAcsAuthenRequests", this.recentAcsAuthenRequests));
                }
				this.recentAcsAuthenRequests = null;
            }
        }
    }
}
