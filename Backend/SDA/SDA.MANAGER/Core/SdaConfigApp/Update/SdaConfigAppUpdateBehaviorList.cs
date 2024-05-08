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
using SDA.MANAGER.Core.SdaConfigApp.EventLog;
using Inventec.Core;
using System;
using System.Collections.Generic;

namespace SDA.MANAGER.Core.SdaConfigApp.Update
{
    class SdaConfigAppUpdateBehaviorList : BeanObjectBase, ISdaConfigAppUpdate
    {
        List<SDA_CONFIG_APP> current;
        List<SDA_CONFIG_APP> entity;

        internal SdaConfigAppUpdateBehaviorList(CommonParam param, List<SDA_CONFIG_APP> data)
            : base(param)
        {
            entity = data;
        }

        bool ISdaConfigAppUpdate.Run()
        {
            bool result = false;
            try
            {
                result = Check() && DAOWorker.SdaConfigAppDAO.UpdateList(entity);
                if (result) { SdaConfigAppEventLogUpdate.Log(current, entity); }
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
                result = result && SdaConfigAppCheckVerifyValidData.Verify(param, entity);
                foreach (var item in entity)
                {
                    SDA_CONFIG_APP raw = new SDA_CONFIG_APP();
                    result = result && SdaConfigAppCheckVerifyIsUnlock.Verify(param, item.ID, ref raw);
                    result = result && SdaConfigAppCheckVerifyExistsCode.Verify(param, item.KEY, item.ID);
                    if (result)
                    {
                        if (current == null) current = new List<SDA_CONFIG_APP>();
                        current.Add(raw);
                    }
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
