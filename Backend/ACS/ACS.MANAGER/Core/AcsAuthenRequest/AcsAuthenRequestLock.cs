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

namespace ACS.MANAGER.AcsAuthenRequest
{
    partial class AcsAuthenRequestLock : BusinessBase
    {
        internal AcsAuthenRequestLock()
            : base()
        {

        }

        internal AcsAuthenRequestLock(CommonParam paramLock)
            : base(paramLock)
        {

        }
		
		internal bool Lock(long id, ref ACS_AUTHEN_REQUEST resultData)
        {
            bool result = false;
            try
            {
                bool valid = true;
                valid = valid && IsGreaterThanZero(id);
                if (valid)
                {
                    ACS_AUTHEN_REQUEST data = new AcsAuthenRequestGet().GetById(id);
                    if (data != null)
                    {
                        data.IS_ACTIVE = IMSys.DbConfig.ACS_RS.COMMON.IS_ACTIVE__FALSE;
                        result = DAOWorker.AcsAuthenRequestDAO.Update(data);
                        resultData = result ? data : null;
                    }
                    else
                    {
                        ACS.MANAGER.Base.BugUtil.SetBugCode(param, ACS.LibraryBug.Bug.Enum.Common__KXDDDuLieuCanXuLy);
                    }
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
		
		internal bool Unlock(long id, ref ACS_AUTHEN_REQUEST resultData)
        {
            bool result = false;
            try
            {
                bool valid = true;
                valid = valid && IsGreaterThanZero(id);
                if (valid)
                {
                    ACS_AUTHEN_REQUEST data = new AcsAuthenRequestGet().GetById(id);
                    if (data != null)
                    {
                        data.IS_ACTIVE = IMSys.DbConfig.ACS_RS.COMMON.IS_ACTIVE__TRUE;
                        result = DAOWorker.AcsAuthenRequestDAO.Update(data);
                        resultData = result ? data : null;
                    }
                    else
                    {
                        ACS.MANAGER.Base.BugUtil.SetBugCode(param, ACS.LibraryBug.Bug.Enum.Common__KXDDDuLieuCanXuLy);
                    }
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

        internal bool ChangeLock(long id, ref ACS_AUTHEN_REQUEST resultData)
        {
            bool result = false;
            try
            {
                bool valid = true;
                ACS_AUTHEN_REQUEST raw = null;
                valid = valid && new AcsAuthenRequestCheck().VerifyId(id, ref raw);
                if (valid && raw != null)
                {
                    if (raw.IS_ACTIVE.HasValue && raw.IS_ACTIVE == IMSys.DbConfig.ACS_RS.COMMON.IS_ACTIVE__TRUE)
                    {
                        raw.IS_ACTIVE = IMSys.DbConfig.ACS_RS.COMMON.IS_ACTIVE__FALSE;
                    }
                    else
                    {
                        raw.IS_ACTIVE = IMSys.DbConfig.ACS_RS.COMMON.IS_ACTIVE__TRUE;
                    }
                    result = DAOWorker.AcsAuthenRequestDAO.Update(raw);
                    if (result) resultData = raw;
                }
                else
                {
                    BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.Common__KXDDDuLieuCanXuLy);
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
    }
}
