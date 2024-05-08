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
using ACS.SDO;
using Inventec.Core;
using System;

namespace ACS.MANAGER.Core.AcsUser.Update
{
    class AcsUserUpdateBehaviorForSubLogin : BeanObjectBase, IAcsUserUpdate
    {
        AcsUserUpdateLoginNameTDO entity;
        ACS_USER raw;

        internal AcsUserUpdateBehaviorForSubLogin(CommonParam param, AcsUserUpdateLoginNameTDO data)
            : base(param)
        {
            entity = data;
        }

        bool IAcsUserUpdate.Run()
        {
            bool result = false;
            try
            {
                if (Check())
                {
                    //raw.SUB_LOGINNAME = entity.SubLoginName.ToLower();
                    result = DAOWorker.AcsUserDAO.Update(raw);
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

        bool Check()
        {
            bool result = true;
            try
            {
                raw = new ACS_USER();
                result = result && AcsUserCheckVerifyValidData.Verify(param, entity);
                result = result && AcsUserCheckVerifyValidDataForLogin.Verify(param, ref raw, entity.LoginName, entity.Password);
                result = result && AcsUserCheckVerifyIsUnlock.Verify(param, raw);
                result = result && AcsUserCheckVerifyExistsCode.Verify(param, entity.SubLoginName, raw.ID);
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
