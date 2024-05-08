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
using SAR.MANAGER.Base;
using SAR.MANAGER.Core.Check;
using Inventec.Core;
using System;

namespace SAR.MANAGER.Core.SarReport.UpdateStt
{
    class SarReportUpdateSttBehavior : BeanObjectBase, ISarReportUpdateStt
    {
        SAR_REPORT entity;
        SAR_REPORT raw;

        internal SarReportUpdateSttBehavior(CommonParam param, SAR_REPORT data)
            : base(param)
        {
            entity = data;
        }

        bool ISarReportUpdateStt.Run()
        {
            bool result = false;
            try
            {
                if (Check())
                {
                    if (DAOWorker.SarReportDAO.Update(entity))
                    {
                        result = true;
                    }
                    else
                    {
                        Logging("DAO update report that bai." + Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => entity), entity), LogType.Error);
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.SarReport_DAOUpdateSttReportThatBai);
                    }
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
                result = result && SarReportCheckVerifyValidData.Verify(param, entity);
                //result = result && SarReportCheckVerifyId.Verify(param, entity.ID, ref raw);
                //result = result && SarReportCheckVerifyIsUnlock.Verify(param, entity.ID);
                result = result && SarReportCheckVerifyExistsCode.Verify(param, entity.REPORT_CODE, entity.ID);
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
