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
using ACS.MANAGER.Base;
using Inventec.Core;
using System;
using ACS.MANAGER.Core.AcsCredentialData;
using System.Collections.Generic;

namespace ACS.MANAGER.Core.AcsCredentialData.Lock
{
    class AcsCredentialDataLockBehaviorListEv : BeanObjectBase, IAcsCredentialDataChangeLock
    {
        List<ACS_CREDENTIAL_DATA> entitys;

        internal AcsCredentialDataLockBehaviorListEv(CommonParam param, List<ACS_CREDENTIAL_DATA> data)
            : base(param)
        {
            entitys = data;
        }

        bool IAcsCredentialDataChangeLock.Run()
        {
            bool result = false;
            try
            {
                foreach (var entity in entitys)
                {
                    ACS_CREDENTIAL_DATA raw = new AcsCredentialDataBO().Get<ACS_CREDENTIAL_DATA>(entity.ID);
                    if (raw != null)
                    {
                        raw.IS_ACTIVE = IMSys.DbConfig.ACS_RS.COMMON.IS_ACTIVE__FALSE;
                        result = DAOWorker.AcsCredentialDataDAO.Update(raw);
                    }
                    else
                    {
                        BugUtil.SetBugCode(param, ACS.LibraryBug.Bug.Enum.Common__KXDDDuLieuCanXuLy);
                    }
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                result = false;
            }
            return result;
        }
    }
}
