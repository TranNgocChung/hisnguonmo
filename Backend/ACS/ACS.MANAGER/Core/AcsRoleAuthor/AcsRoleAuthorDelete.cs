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
    partial class AcsRoleAuthorDelete : BusinessBase
    {
        internal AcsRoleAuthorDelete()
            : base()
        {

        }

        internal AcsRoleAuthorDelete(CommonParam paramDelete)
            : base(paramDelete)
        {

        }

        internal bool Delete(ACS_ROLE_AUTHOR data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                AcsRoleAuthorCheck checker = new AcsRoleAuthorCheck(param);
                valid = valid && IsNotNull(data);
                ACS_ROLE_AUTHOR raw = null;
                valid = valid && checker.VerifyId(data.ID, ref raw);
                valid = valid && checker.IsUnLock(raw);
                if (valid)
                {
                    result = DAOWorker.AcsRoleAuthorDAO.Delete(data);
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

        internal bool DeleteList(List<ACS_ROLE_AUTHOR> listData)
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
                if (valid)
                {
                    result = DAOWorker.AcsRoleAuthorDAO.DeleteList(listData);
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
