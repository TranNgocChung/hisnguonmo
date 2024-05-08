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
using System.Collections.Generic;

namespace SDA.MANAGER.Core.SdaTrouble.CreateByMessege
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
                //result = Check() && DAOWorker.SdaTroubleDAO.CreateByMessegeList(entities);
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
                    result = DAOWorker.SdaTroubleDAO.CreateList(datas);
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
