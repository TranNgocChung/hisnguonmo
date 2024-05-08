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

namespace ACS.MANAGER.AcsRoleAuthor
{
    partial class AcsRoleAuthorUpdate : BusinessBase
    {
		private List<ACS_ROLE_AUTHOR> beforeUpdateAcsRoleAuthors = new List<ACS_ROLE_AUTHOR>();
		
        internal AcsRoleAuthorUpdate()
            : base()
        {

        }

        internal AcsRoleAuthorUpdate(CommonParam paramUpdate)
            : base(paramUpdate)
        {

        }

        internal bool Update(ACS_ROLE_AUTHOR data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                AcsRoleAuthorCheck checker = new AcsRoleAuthorCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                ACS_ROLE_AUTHOR raw = null;
                valid = valid && checker.VerifyId(data.ID, ref raw);
                valid = valid && checker.IsUnLock(raw);
                valid = valid && checker.ExistsCode(data.ROLE_AUTHOR_CODE, data.ID);
                if (valid)
                {
					if (!DAOWorker.AcsRoleAuthorDAO.Update(data))
                    {
                        ACS.MANAGER.Base.BugUtil.SetBugCode(param, ACS.LibraryBug.Bug.Enum.AcsRoleAuthor_CapNhatThatBai);
                        throw new Exception("Cap nhat thong tin AcsRoleAuthor that bai." + LogUtil.TraceData("data", data));
                    }
					
					this.beforeUpdateAcsRoleAuthors.Add(raw);
                    
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

        internal bool UpdateList(List<ACS_ROLE_AUTHOR> listData)
        {
            bool result = false;
            try
            {
                bool valid = true;
                valid = IsNotNullOrEmpty(listData);
                AcsRoleAuthorCheck checker = new AcsRoleAuthorCheck(param);
                List<ACS_ROLE_AUTHOR> listRaw = new List<ACS_ROLE_AUTHOR>();
                List<long> listId = listData.Select(o => o.ID).ToList();
                valid = valid && checker.VerifyIds(listId, listRaw);
                valid = valid && checker.IsUnLock(listRaw);
                foreach (var data in listData)
                {
                    valid = valid && checker.VerifyRequireField(data);
                    valid = valid && checker.ExistsCode(data.ROLE_AUTHOR_CODE, data.ID);
                }
                if (valid)
                {
					if (!DAOWorker.AcsRoleAuthorDAO.UpdateList(listData))
                    {
                        ACS.MANAGER.Base.BugUtil.SetBugCode(param, ACS.LibraryBug.Bug.Enum.AcsRoleAuthor_CapNhatThatBai);
                        throw new Exception("Cap nhat thong tin AcsRoleAuthor that bai." + LogUtil.TraceData("listData", listData));
                    }
					this.beforeUpdateAcsRoleAuthors.AddRange(listRaw);
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
            if (IsNotNullOrEmpty(this.beforeUpdateAcsRoleAuthors))
            {
                if (!DAOWorker.AcsRoleAuthorDAO.UpdateList(this.beforeUpdateAcsRoleAuthors))
                {
                    LogSystem.Warn("Rollback du lieu AcsRoleAuthor that bai, can kiem tra lai." + LogUtil.TraceData("AcsRoleAuthors", this.beforeUpdateAcsRoleAuthors));
                }
				this.beforeUpdateAcsRoleAuthors = null;
            }
        }
    }
}
