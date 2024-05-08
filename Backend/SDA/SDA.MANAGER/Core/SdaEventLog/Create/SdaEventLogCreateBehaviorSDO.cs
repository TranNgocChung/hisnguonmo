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

namespace SDA.MANAGER.Core.SdaEventLog.Create
{
    class SdaEventLogCreateBehaviorSDO : BeanObjectBase, ISdaEventLogCreate
    {
        SDA.SDO.SdaEventLogSDO entity;
        SDA_EVENT_LOG raw;
        internal SdaEventLogCreateBehaviorSDO(CommonParam param, SDA.SDO.SdaEventLogSDO data)
            : base(param)
        {
            entity = data;
        }

        bool ISdaEventLogCreate.Run()
        {
            bool result = false;
            try
            {
                raw = new SDA_EVENT_LOG();
                if (Inventec.Common.String.CountVi.Count(entity.Description) > 4000)
                {
                    raw.DESCRIPTION = Inventec.Common.String.CountVi.SubStringVi(entity.Description, 4000 - 4) + "...";
                }
                else
                {
                    raw.DESCRIPTION = entity.Description;
                }
                if (String.IsNullOrEmpty(entity.LogginName))
                {
                    raw.LOGIN_NAME = Inventec.Token.ResourceSystem.ResourceTokenManager.GetLoginName();
                    raw.CREATOR = Inventec.Token.ResourceSystem.ResourceTokenManager.GetLoginName();
                }
                else
                {
                    raw.CREATOR = entity.LogginName;
                    raw.LOGIN_NAME = entity.LogginName;
                }
                raw.APP_CODE = entity.AppCode;
                raw.EVENT_TIME = entity.EventTime;
                raw.MODIFIER = raw.CREATOR;
                raw.IP = entity.Ip;

                result = Check() && DAOWorker.SdaEventLogDAO.Create(raw);
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
                result = result && SdaEventLogCheckVerifyValidData.Verify(param, raw);
                //result = result && SdaEventLogCheckVerifyExistsCode.Verify(param, entity.EVENT_LOG_CODE, null);
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
