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

namespace SDA.MANAGER.Core.SdaEventLog.CreateForLog
{
    class SdaEventLogCreateBehaviorEv_ForLog : BeanObjectBase, ISdaEventLogCreateForLog
    {
        string description;

        internal SdaEventLogCreateBehaviorEv_ForLog(CommonParam param, string _description)
            : base(param)
        {
            description = _description;
        }

        bool ISdaEventLogCreateForLog.Run()
        {
            bool result = false;
            try
            {
                if (Check())
                {
                    SDA_EVENT_LOG data = new SDA_EVENT_LOG();
                    try
                    {
                        data.CREATOR = Inventec.Token.ResourceSystem.ResourceTokenManager.GetLoginName();
                        data.LOGIN_NAME = data.CREATOR;
                        //data.IP = GetIpAddress();
                    }
                    catch (Exception ex)
                    {
                        Inventec.Common.Logging.LogSystem.Error(ex);
                    }
                    data.DESCRIPTION = description;
                    result = DAOWorker.SdaEventLogDAO.Create(data);
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
                //result = result && SdaEventLogCheckVerifyValidData.Verify(param, entity);
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
