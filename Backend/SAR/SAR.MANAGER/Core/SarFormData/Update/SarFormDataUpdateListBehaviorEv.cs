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
using SAR.EFMODEL.DataModels;
using SAR.MANAGER.Base;
using SAR.MANAGER.Core.Check;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAR.MANAGER.Core.SarFormData.Update
{
    class SarFormDataUpdateListBehaviorEv : BeanObjectBase, ISarFormDataUpdate
    {
        List<SAR_FORM_DATA> entity;

        internal SarFormDataUpdateListBehaviorEv(CommonParam param, List<SAR_FORM_DATA> data)
            : base(param)
        {
            entity = data;
        }

        bool ISarFormDataUpdate.Run()
        {
            bool result = false;
            try
            {
                result = Check() && DAOWorker.SarFormDataDAO.UpdateList(entity);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                if (param.Messages != null && param.Messages.Count > 0)
                {
                    param.Messages = param.Messages.Distinct().ToList();
                }
                result = false;
            }
            return result;
        }

        bool Check()
        {
            bool result = true;
            try
            {
                foreach (var data in entity)
                {
                    result = result && SarFormDataCheckVerifyValidData.Verify(param, data);
                    result = result && SarFormDataCheckVerifyIsUnlock.Verify(param, data.ID);
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                if (param.Messages != null && param.Messages.Count > 0)
                {
                    param.Messages = param.Messages.Distinct().ToList();
                }
                result = false;
            }
            return result;
        }
    }
}
