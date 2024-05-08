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
using Inventec.Core;
using SDA.EFMODEL.DataModels;
using SDA.MANAGER.Base;
using SDA.MANAGER.Core.Check;
using SDA.MANAGER.Core.SdaNotify.EventLog;
using SDA.SDO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDA.MANAGER.Core.SdaNotify.Update
{
    class SdaNotifyUpdateLoginNamesBehaviorEv : BeanObjectBase, ISdaNotifyUpdate
    {
        List<SDA_NOTIFY> update;
        List<SDA_NOTIFY> current;
        SdaNotifySeenSDO entity;

        internal SdaNotifyUpdateLoginNamesBehaviorEv(CommonParam param, SdaNotifySeenSDO data)
            : base(param)
        {
            entity = data;
        }

        bool ISdaNotifyUpdate.Run()
        {
            bool result = false;
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(entity);
                valid = valid && IsNotNullOrEmpty(entity.Ids);
                valid = valid && SdaNotifyCheckVerifyIsUnlock.Verify(param, entity.Ids, ref current);
                if (valid)
                {
                    string loginnameSeen = Inventec.Token.ResourceSystem.ResourceTokenManager.GetLoginName();
                    if (!String.IsNullOrWhiteSpace(entity.Loginname))
                    {
                        loginnameSeen = entity.Loginname;
                    }

                    update = new List<SDA_NOTIFY>();
                    foreach (var curr in current)
                    {
                        var data = new SDA_NOTIFY();
                        Inventec.Common.Mapper.DataObjectMapper.Map<SDA_NOTIFY>(data, curr);
                        List<string> loginNames = new List<string>();
                        if (!String.IsNullOrWhiteSpace(curr.LOGIN_NAMES))
                        {
                            loginNames.AddRange(curr.LOGIN_NAMES.Split(',').ToList());
                        }

                        loginNames.Add(loginnameSeen);

                        loginNames = loginNames.Distinct().ToList();
                        data.LOGIN_NAMES = string.Join(",", loginNames);
                        update.Add(data);
                    }

                    result = DAOWorker.SdaNotifyDAO.UpdateList(update);
                }

                if (result) { SdaNotifyEventLogUpdate.Log(current, update); }
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
