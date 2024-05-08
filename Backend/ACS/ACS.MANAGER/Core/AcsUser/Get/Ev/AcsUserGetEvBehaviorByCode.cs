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
using System.Linq;

namespace ACS.MANAGER.Core.AcsUser.Get.Ev
{
    class AcsUserGetEvBehaviorByCode : BeanObjectBase, IAcsUserGetEv
    {
        string code;

        internal AcsUserGetEvBehaviorByCode(CommonParam param, string filter)
            : base(param)
        {
            code = filter;
        }

        ACS_USER IAcsUserGetEv.Run()
        {
            try
            {
                AcsUserFilterQuery filter = new AcsUserFilterQuery();
                filter.LOGINNAME__OR__SUB_LOGINNAME = code;
                var users = DAOWorker.AcsUserDAO.Get(filter.Query(), new CommonParam());
                if (users == null || users.Count == 0)
                {
                    //Inventec.Common.Logging.LogSystem.Debug(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => users), users));
                }
                return users.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }
    }
}
