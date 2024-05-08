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

namespace SAR.MANAGER.Core.SarReportTemplate.Update
{
    class SarReportTemplateUpdateListBehaviorEv : BeanObjectBase, ISarReportTemplateUpdate
    {
        List<SAR_REPORT_TEMPLATE> entity;

        internal SarReportTemplateUpdateListBehaviorEv(CommonParam param, List<SAR_REPORT_TEMPLATE> data)
            : base(param)
        {
            entity = data;
        }

        bool ISarReportTemplateUpdate.Run()
        {
            bool result = false;
            try
            {
                result = Check() && DAOWorker.SarReportTemplateDAO.UpdateList(entity);
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
                    result = result && SarReportTemplateCheckVerifyValidData.Verify(param, data);
                    result = result && SarReportTemplateCheckVerifyIsUnlock.Verify(param, data.ID);
                    result = result && SarReportTemplateCheckVerifyExistsCode.Verify(param, data.REPORT_TEMPLATE_CODE, data.ID);
                    if (!result)
                    {
                        break;
                    }
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
