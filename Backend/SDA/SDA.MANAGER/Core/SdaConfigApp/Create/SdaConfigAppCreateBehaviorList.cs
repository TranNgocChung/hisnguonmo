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

namespace SDA.MANAGER.Core.SdaConfigApp.Create
{
    class SdaConfigAppCreateBehaviorList : BeanObjectBase, ISdaConfigAppCreate
    {
        List<SDA_CONFIG_APP> entity;

        internal SdaConfigAppCreateBehaviorList(CommonParam param, List<SDA_CONFIG_APP> data)
            : base(param)
        {
            entity = data;
        }

        bool ISdaConfigAppCreate.Run()
        {
            bool result = false;
            try
            {
                if (Check())
                {
                    result = DAOWorker.SdaConfigAppDAO.CreateList(entity);
                }

                if (result) { SdaConfigAppEventLogCreate.Log(entity); }
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
                foreach (var data in entity)
                {
                    result = result && SdaConfigAppCheckVerifyExistsCode.Verify(param, data.KEY, null);
                }
            }
            catch (Exception ex)
            {
                param.HasException = true;
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }
    }
}
