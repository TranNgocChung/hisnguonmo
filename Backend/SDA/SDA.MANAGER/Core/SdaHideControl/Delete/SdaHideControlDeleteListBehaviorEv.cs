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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDA.MANAGER.Core.SdaHideControl.Delete
{
    class SdaHideControlDeleteListBehaviorEv : BeanObjectBase, ISdaHideControlDelete
    {
        List<SDA_HIDE_CONTROL> processDatas;
        List<long> entity;

        internal SdaHideControlDeleteListBehaviorEv(CommonParam param, List<long> data)
            : base(param)
        {
            entity = data;
        }

        bool ISdaHideControlDelete.Run()
        {
            bool result = false;
            try
            {
                result = Check() && DAOWorker.SdaHideControlDAO.TruncateList(processDatas);
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
                processDatas = new List<SDA_HIDE_CONTROL>();
                foreach (var item in entity)
                {
                    bool valid = true;
                    SDA_HIDE_CONTROL raw = new SDA_HIDE_CONTROL();
                    valid = valid && SdaHideControlCheckVerifyIsUnlock.Verify(param, item, ref raw);
                    if (valid)
                        processDatas.Add(raw);
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
