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
using SDA.EFMODEL.DataModels;
using SDA.MANAGER.Base;
using SDA.MANAGER.Core.Check;
using SDA.MANAGER.Core.SdaConfigAppUser.EventLog;
using Inventec.Core;
using System;
using System.Collections.Generic;

namespace SDA.MANAGER.Core.SdaConfigAppUser.Update
{
    class SdaConfigAppUserUpdateBehaviorList : BeanObjectBase, ISdaConfigAppUserUpdate
    {
        List<SDA_CONFIG_APP_USER> current;
        List<SDA_CONFIG_APP_USER> entity;

        internal SdaConfigAppUserUpdateBehaviorList(CommonParam param, List<SDA_CONFIG_APP_USER> data)
            : base(param)
        {
            entity = data;
        }

        bool ISdaConfigAppUserUpdate.Run()
        {
            bool result = false;
            try
            {
                result = Check() && DAOWorker.SdaConfigAppUserDAO.UpdateList(entity);
                if (result) { SdaConfigAppUserEventLogUpdate.Log(current, entity); }
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
                result = result && SdaConfigAppUserCheckVerifyValidData.Verify(param, entity);
                //result = result && SdaConfigAppUserCheckVerifyIsUnlock.Verify(param, entity.ID, ref current);
                //result = result && SdaConfigAppUserCheckVerifyExistsCode.Verify(param, entity.CONFIG_APP_USER_CODE, entity.ID);
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
