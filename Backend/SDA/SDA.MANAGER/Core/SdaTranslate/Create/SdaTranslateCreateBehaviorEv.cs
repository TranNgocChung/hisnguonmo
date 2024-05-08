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
using SDA.MANAGER.Core.SdaTranslate.EventLog;
using Inventec.Core;
using System;

namespace SDA.MANAGER.Core.SdaTranslate.Create
{
    class SdaTranslateCreateBehaviorEv : BeanObjectBase, ISdaTranslateCreate
    {
        SDA_TRANSLATE entity;

        internal SdaTranslateCreateBehaviorEv(CommonParam param, SDA_TRANSLATE data)
            : base(param)
        {
            entity = data;
        }

        bool ISdaTranslateCreate.Run()
        {
            bool result = false;
            try
            {
                result = Check() && DAOWorker.SdaTranslateDAO.Create(entity);
                if (result) { SdaTranslateEventLogCreate.Log(entity); }
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
                result = result && SdaTranslateCheckVerifyValidData.Verify(param, entity);
                result = result && SdaTranslateCheckVerifyValidData.VerifyIsExistsCreate(param, entity);
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
