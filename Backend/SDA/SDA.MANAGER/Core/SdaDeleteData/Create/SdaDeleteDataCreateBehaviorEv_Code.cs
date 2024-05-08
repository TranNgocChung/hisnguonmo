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
using SDA.MANAGER.Core.SdaDeleteData.EventLog;
using Inventec.Core;
using System;

namespace SDA.MANAGER.Core.SdaDeleteData.Create
{
    class SdaDeleteDataCreateBehaviorEv : BeanObjectBase, ISdaDeleteDataCreate
    {
        SDA_DELETE_DATA entity;

        internal SdaDeleteDataCreateBehaviorEv(CommonParam param, SDA_DELETE_DATA data)
            : base(param)
        {
            entity = data;
        }

        bool ISdaDeleteDataCreate.Run()
        {
            bool result = false;
            try
            {
                result = Check() && DAOWorker.SdaDeleteDataDAO.Create(entity);
                if (result) { SdaDeleteDataEventLogCreate.Log(entity); }
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
                result = result && SdaDeleteDataCheckVerifyValidData.Verify(param, entity);
                result = result && SdaDeleteDataCheckVerifyExistsCode.Verify(param, entity.DELETE_DATA_CODE, null);
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
