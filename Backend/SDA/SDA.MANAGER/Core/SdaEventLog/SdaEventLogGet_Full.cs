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
using SDA.MANAGER.Core.SdaEventLog.Get.Ev;
using SDA.MANAGER.Core.SdaEventLog.Get.ListEv;
using SDA.MANAGER.Core.SdaEventLog.Get.ListV;
using SDA.MANAGER.Core.SdaEventLog.Get.V;
using Inventec.Core;
using System;
using System.Collections.Generic;

namespace SDA.MANAGER.Core.SdaEventLog
{
    partial class SdaEventLogGet : BeanObjectBase, IDelegacyT
    {
        object entity;

        internal SdaEventLogGet(CommonParam param, object data)
            : base(param)
        {
            entity = data;
        }

        T IDelegacyT.Execute<T>()
        {
            T result = default(T);
            try
            {
                if (typeof(T) == typeof(List<SDA_EVENT_LOG>))
                {
                    ISdaEventLogGetListEv behavior = SdaEventLogGetListEvBehaviorFactory.MakeISdaEventLogGetListEv(param, entity);
                    result = behavior != null ? (T)System.Convert.ChangeType(behavior.Run(), typeof(T)) : default(T);
                }
                else if (typeof(T) == typeof(SDA_EVENT_LOG))
                {
                    ISdaEventLogGetEv behavior = SdaEventLogGetEvBehaviorFactory.MakeISdaEventLogGetEv(param, entity);
                    result = behavior != null ? (T)System.Convert.ChangeType(behavior.Run(), typeof(T)) : default(T);
                }
                else if (typeof(T) == typeof(List<V_SDA_EVENT_LOG>))
                {
                    ISdaEventLogGetListV behavior = SdaEventLogGetListVBehaviorFactory.MakeISdaEventLogGetListV(param, entity);
                    result = behavior != null ? (T)System.Convert.ChangeType(behavior.Run(), typeof(T)) : default(T);
                }
                else if (typeof(T) == typeof(V_SDA_EVENT_LOG))
                {
                    ISdaEventLogGetV behavior = SdaEventLogGetVBehaviorFactory.MakeISdaEventLogGetV(param, entity);
                    result = behavior != null ? (T)System.Convert.ChangeType(behavior.Run(), typeof(T)) : default(T);
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = default(T);
            }
            return result;
        }
    }
}
