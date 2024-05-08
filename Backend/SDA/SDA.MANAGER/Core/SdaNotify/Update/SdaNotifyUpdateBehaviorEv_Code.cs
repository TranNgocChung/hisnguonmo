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
using SDA.MANAGER.Core.SdaNotify.EventLog;
using Inventec.Core;
using System;

namespace SDA.MANAGER.Core.SdaNotify.Update
{
    class SdaNotifyUpdateBehaviorEv : BeanObjectBase, ISdaNotifyUpdate
    {
        SDA_NOTIFY current;
        SDA_NOTIFY entity;

        internal SdaNotifyUpdateBehaviorEv(CommonParam param, SDA_NOTIFY data)
            : base(param)
        {
            entity = data;
        }

        bool ISdaNotifyUpdate.Run()
        {
            bool result = false;
            try
            {
                result = Check() && DAOWorker.SdaNotifyDAO.Update(entity);
                if (result) { SdaNotifyEventLogUpdate.Log(current, entity); }
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
                result = result && SdaNotifyCheckVerifyValidData.Verify(param, entity);
                result = result && SdaNotifyCheckVerifyIsUnlock.Verify(param, entity.ID, ref current);
                result = result && SdaNotifyCheckVerifyExistsCode.Verify(param, entity.NOTIFY_CODE, entity.ID);
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
