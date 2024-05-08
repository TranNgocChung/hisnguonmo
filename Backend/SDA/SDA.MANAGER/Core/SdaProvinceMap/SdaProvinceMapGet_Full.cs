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
using SDA.MANAGER.Core.SdaProvinceMap.Get.Ev;
using SDA.MANAGER.Core.SdaProvinceMap.Get.ListEv;
using SDA.MANAGER.Core.SdaProvinceMap.Get.ListV;
using SDA.MANAGER.Core.SdaProvinceMap.Get.V;
using Inventec.Core;
using System;
using System.Collections.Generic;

namespace SDA.MANAGER.Core.SdaProvinceMap
{
    partial class SdaProvinceMapGet : BeanObjectBase, IDelegacyT
    {
        object entity;

        internal SdaProvinceMapGet(CommonParam param, object data)
            : base(param)
        {
            entity = data;
        }

        T IDelegacyT.Execute<T>()
        {
            T result = default(T);
            try
            {
                if (typeof(T) == typeof(List<SDA_PROVINCE_MAP>))
                {
                    ISdaProvinceMapGetListEv behavior = SdaProvinceMapGetListEvBehaviorFactory.MakeISdaProvinceMapGetListEv(param, entity);
                    result = behavior != null ? (T)System.Convert.ChangeType(behavior.Run(), typeof(T)) : default(T);
                }
                else if (typeof(T) == typeof(SDA_PROVINCE_MAP))
                {
                    ISdaProvinceMapGetEv behavior = SdaProvinceMapGetEvBehaviorFactory.MakeISdaProvinceMapGetEv(param, entity);
                    result = behavior != null ? (T)System.Convert.ChangeType(behavior.Run(), typeof(T)) : default(T);
                }
                else if (typeof(T) == typeof(List<V_SDA_PROVINCE_MAP>))
                {
                    ISdaProvinceMapGetListV behavior = SdaProvinceMapGetListVBehaviorFactory.MakeISdaProvinceMapGetListV(param, entity);
                    result = behavior != null ? (T)System.Convert.ChangeType(behavior.Run(), typeof(T)) : default(T);
                }
                else if (typeof(T) == typeof(V_SDA_PROVINCE_MAP))
                {
                    ISdaProvinceMapGetV behavior = SdaProvinceMapGetVBehaviorFactory.MakeISdaProvinceMapGetV(param, entity);
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
