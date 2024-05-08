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
using SAR.MANAGER.Base;
using SAR.MANAGER.Core.Check;
using Inventec.Core;
using System;
using System.Collections.Generic;

namespace SAR.MANAGER.Core.SdaTrouble.CreateByMessege
{
    class SdaTroubleCreateByMessegeBehavior : BeanObjectBase, ISdaTroubleCreateByMessege
    {
        List<string> entities;

        internal SdaTroubleCreateByMessegeBehavior(CommonParam param, List<string> datas)
            : base(param)
        {
            entities = datas;
        }

        bool ISdaTroubleCreateByMessege.Run()
        {
            bool result = false;
            try
            {
                if (entities != null && entities.Count > 0)
                {
                    List<SDA_TROUBLE> datas = new List<SDA_TROUBLE>();
                    foreach (var message in entities)
                    {
                        if (!String.IsNullOrEmpty(message))
                        {
                            SDA_TROUBLE data = new SDA_TROUBLE();
                            data.MESSAGE = message;
                            datas.Add(data);
                        }
                    }
                    Inventec.Core.ApiResultObject<bool> aro = ApiConsumerStore.SdaConsumer.Post<Inventec.Core.ApiResultObject<bool>>("/api/SdaTrouble/Create", param, datas);
                    if (!(aro != null && aro.Success))
                    {
                        result = aro.Success;
                        Logging("Khong insert duoc du lieu trouble.", LogType.Error);
                        Inventec.Common.Logging.LogSystem.Info(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => aro), aro));
                    }
                }
                else
                {
                    result = true;
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
    }
}
