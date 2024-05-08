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
using ACS.MANAGER.Core.Check;
using Inventec.Core;
using System;

namespace ACS.MANAGER.Core.AcsUser.Update
{
    class AcsUserUpdateBehaviorEv : BeanObjectBase, IAcsUserUpdate
    {
        ACS_USER entity;
        ACS_USER raw;

        internal AcsUserUpdateBehaviorEv(CommonParam param, ACS_USER data)
            : base(param)
        {
            entity = data;
        }

        bool IAcsUserUpdate.Run()
        {
            bool result = false;
            try
            {
                result = Check() && DAOWorker.AcsUserDAO.Update(entity);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                result = false;
            }
            return result;
        }

        bool Check()
        {
            bool result = true;
            try
            {
                result = result && AcsUserCheckVerifyValidData.Verify(param, entity);
                result = result && AcsUserCheckVerifyIsUnlock.Verify(param, entity.ID, ref raw);
                result = result && AcsUserCheckVerifyExistsCode.Verify(param, entity.LOGINNAME, entity.ID);
                if (result)
                {
                    entity.LOGINNAME = raw.LOGINNAME;
                    entity.PASSWORD = raw.PASSWORD;
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
