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

namespace ACS.MANAGER.Core.AcsActivityType.Update
{
    class AcsActivityTypeUpdateBehaviorEv : BeanObjectBase, IAcsActivityTypeUpdate
    {
        ACS_ACTIVITY_TYPE current;
        ACS_ACTIVITY_TYPE entity;

        internal AcsActivityTypeUpdateBehaviorEv(CommonParam param, ACS_ACTIVITY_TYPE data)
            : base(param)
        {
            entity = data;
        }

        bool IAcsActivityTypeUpdate.Run()
        {
            bool result = false;
            try
            {
                result = Check() && DAOWorker.AcsActivityTypeDAO.Update(entity);
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
                result = result && AcsActivityTypeCheckVerifyValidData.Verify(param, entity);
                result = result && AcsActivityTypeCheckVerifyIsUnlock.Verify(param, entity.ID, ref current);
                result = result && AcsActivityTypeCheckVerifyExistsCode.Verify(param, entity.ACTIVITY_TYPE_CODE, entity.ID);
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
