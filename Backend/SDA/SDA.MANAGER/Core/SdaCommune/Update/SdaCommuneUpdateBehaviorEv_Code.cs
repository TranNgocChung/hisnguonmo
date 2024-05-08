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
using Inventec.Core;
using System;

namespace SDA.MANAGER.Core.SdaCommune.Update
{
    class SdaCommuneUpdateBehaviorEv : BeanObjectBase, ISdaCommuneUpdate
    {
        SDA_COMMUNE entity;

        internal SdaCommuneUpdateBehaviorEv(CommonParam param, SDA_COMMUNE data)
            : base(param)
        {
            entity = data;
        }

        bool ISdaCommuneUpdate.Run()
        {
            bool result = false;
            try
            {
                result = Check() && DAOWorker.SdaCommuneDAO.Update(entity);
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
                result = result && SdaCommuneCheckVerifyValidData.Verify(param, entity);
                result = result && SdaCommuneCheckVerifyIsUnlock.Verify(param, entity.ID);
                result = result && SdaCommuneCheckVerifyExistsCode.Verify(param, entity.COMMUNE_CODE, entity.ID);
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
