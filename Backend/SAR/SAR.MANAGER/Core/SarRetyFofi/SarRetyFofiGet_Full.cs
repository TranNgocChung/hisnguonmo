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
using SAR.EFMODEL.DataModels;
using SAR.MANAGER.Core.SarRetyFofi.Get.Ev;
using SAR.MANAGER.Core.SarRetyFofi.Get.ListEv;
using SAR.MANAGER.Core.SarRetyFofi.Get.ListV;
using SAR.MANAGER.Core.SarRetyFofi.Get.V;
using Inventec.Core;
using System;
using System.Collections.Generic;

namespace SAR.MANAGER.Core.SarRetyFofi
{
    partial class SarRetyFofiGet : BeanObjectBase, IDelegacyT
    {
        object entity;

        internal SarRetyFofiGet(CommonParam param, object data)
            : base(param)
        {
            entity = data;
        }

        T IDelegacyT.Execute<T>()
        {
            T result = default(T);
            try
            {
                if (typeof(T) == typeof(List<SAR_RETY_FOFI>))
                {
                    ISarRetyFofiGetListEv behavior = SarRetyFofiGetListEvBehaviorFactory.MakeISarRetyFofiGetListEv(param, entity);
                    result = behavior != null ? (T)System.Convert.ChangeType(behavior.Run(), typeof(T)) : default(T);
                }
                else if (typeof(T) == typeof(SAR_RETY_FOFI))
                {
                    ISarRetyFofiGetEv behavior = SarRetyFofiGetEvBehaviorFactory.MakeISarRetyFofiGetEv(param, entity);
                    result = behavior != null ? (T)System.Convert.ChangeType(behavior.Run(), typeof(T)) : default(T);
                }
                else if (typeof(T) == typeof(List<V_SAR_RETY_FOFI>))
                {
                    ISarRetyFofiGetListV behavior = SarRetyFofiGetListVBehaviorFactory.MakeISarRetyFofiGetListV(param, entity);
                    result = behavior != null ? (T)System.Convert.ChangeType(behavior.Run(), typeof(T)) : default(T);
                }
                else if (typeof(T) == typeof(V_SAR_RETY_FOFI))
                {
                    ISarRetyFofiGetV behavior = SarRetyFofiGetVBehaviorFactory.MakeISarRetyFofiGetV(param, entity);
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
