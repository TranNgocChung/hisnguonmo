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
    partial class AcsAuthenRequestDelete : BusinessBase
    {
        internal AcsAuthenRequestDelete()
            : base()
        {

        }

        internal AcsAuthenRequestDelete(CommonParam paramDelete)
            : base(paramDelete)
        {

        }

        internal bool Delete(ACS_AUTHEN_REQUEST data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                AcsAuthenRequestCheck checker = new AcsAuthenRequestCheck(param);
                valid = valid && IsNotNull(data);
                ACS_AUTHEN_REQUEST raw = null;
                valid = valid && checker.VerifyId(data.ID, ref raw);
                valid = valid && checker.IsUnLock(raw);
                if (valid)
                {
                    result = DAOWorker.AcsAuthenRequestDAO.Delete(data);
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

        internal bool DeleteList(List<ACS_AUTHEN_REQUEST> listData)
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
                if (valid)
                {
                    result = DAOWorker.AcsAuthenRequestDAO.DeleteList(listData);
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
