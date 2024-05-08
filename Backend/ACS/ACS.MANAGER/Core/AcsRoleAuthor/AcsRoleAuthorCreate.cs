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

namespace ACS.MANAGER.AcsRoleAuthor
{
    partial class AcsRoleAuthorCreate : BusinessBase
    {
		private List<ACS_ROLE_AUTHOR> recentAcsRoleAuthors = new List<ACS_ROLE_AUTHOR>();
		
        internal AcsRoleAuthorCreate()
            : base()
        {

        }

        internal AcsRoleAuthorCreate(CommonParam paramCreate)
            : base(paramCreate)
        {

        }

        internal bool Create(ACS_ROLE_AUTHOR data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                AcsRoleAuthorCheck checker = new AcsRoleAuthorCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                if (valid)
                {
					if (!DAOWorker.AcsRoleAuthorDAO.Create(data))
                    {
                        ACS.MANAGER.Base.BugUtil.SetBugCode(param, ACS.LibraryBug.Bug.Enum.AcsRoleAuthor_ThemMoiThatBai);
                        throw new Exception("Them moi thong tin AcsRoleAuthor that bai." + LogUtil.TraceData("data", data));
                    }
                    this.recentAcsRoleAuthors.Add(data);
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
		
		internal bool CreateList(List<ACS_ROLE_AUTHOR> listData)
        {
            bool result = false;
            try
            {
                bool valid = true;
                valid = IsNotNullOrEmpty(listData);
                AcsRoleAuthorCheck checker = new AcsRoleAuthorCheck(param);
                foreach (var data in listData)
                {
                    valid = valid && checker.VerifyRequireField(data);
                }
                if (valid)
                {
                    if (!DAOWorker.AcsRoleAuthorDAO.CreateList(listData))
                    {
                        ACS.MANAGER.Base.BugUtil.SetBugCode(param, ACS.LibraryBug.Bug.Enum.AcsRoleAuthor_ThemMoiThatBai);
                        throw new Exception("Them moi thong tin AcsRoleAuthor that bai." + LogUtil.TraceData("listData", listData));
                    }
                    this.recentAcsRoleAuthors.AddRange(listData);
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
            if (IsNotNullOrEmpty(this.recentAcsRoleAuthors))
            {
                if (!DAOWorker.AcsRoleAuthorDAO.TruncateList(this.recentAcsRoleAuthors))
                {
                    LogSystem.Warn("Rollback du lieu AcsRoleAuthor that bai, can kiem tra lai." + LogUtil.TraceData("recentAcsRoleAuthors", this.recentAcsRoleAuthors));
                }
				this.recentAcsRoleAuthors = null;
            }
        }
    }
}
