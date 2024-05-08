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
using ACS.MANAGER.Core.AcsModule;
using ACS.MANAGER.EventLogUtil;
using ACS.LibraryEventLog;

namespace ACS.MANAGER.Core.AcsModule.Lock
{
    class AcsModuleChangeLockBehaviorEv : BeanObjectBase, IAcsModuleChangeLock
    {
        ACS_MODULE entity;

        internal AcsModuleChangeLockBehaviorEv(CommonParam param, ACS_MODULE data)
            : base(param)
        {
            entity = data;
        }

        bool IAcsModuleChangeLock.Run()
        {
            bool result = false;
            try
            {
                ACS_MODULE raw = new AcsModuleBO().Get<ACS_MODULE>(entity.ID);
                if (raw != null)
                {
                    if (raw.IS_ACTIVE.HasValue && raw.IS_ACTIVE == IMSys.DbConfig.ACS_RS.COMMON.IS_ACTIVE__TRUE)
                    {
                        raw.IS_ACTIVE = IMSys.DbConfig.ACS_RS.COMMON.IS_ACTIVE__FALSE;
                    }
                    else
                    {
                        raw.IS_ACTIVE = IMSys.DbConfig.ACS_RS.COMMON.IS_ACTIVE__TRUE;
                    }
                    result = DAOWorker.AcsModuleDAO.Update(raw);
                    if (result)
                    {
                        entity.IS_ACTIVE = raw.IS_ACTIVE;
                        CreateEventLog(raw);
                    }
                }
                else
                {
                    BugUtil.SetBugCode(param, ACS.LibraryBug.Bug.Enum.Common__KXDDDuLieuCanXuLy);
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

        private void CreateEventLog(ACS_MODULE raw)
        {
            try
            {
                new EventLogGenerator(raw.IS_ACTIVE == IMSys.DbConfig.ACS_RS.COMMON.IS_ACTIVE__TRUE ? EventLog.Enum.AcsModule_MoKhoaDanhMucChucNang : EventLog.Enum.AcsModule_KhoaDanhMucChucNang, String.Format("MODULE_NAME: {0}", raw.MODULE_NAME))
                          .ModuleLink(raw.MODULE_LINK).Run();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }
    }
}
