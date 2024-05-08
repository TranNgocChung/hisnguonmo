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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAR.MANAGER.Core.SarPrintLog.Create
{
    class SarPrintLogCreateBehaviorSDO : BeanObjectBase, ISarPrintLogCreate
    {
        SDO.SarPrintLogSDO entity;
        SAR_PRINT_LOG raw;

        public SarPrintLogCreateBehaviorSDO(Inventec.Core.CommonParam param, SDO.SarPrintLogSDO data)
            : base(param)
        {
            this.entity = data;
        }

        bool ISarPrintLogCreate.Run()
        {
            bool result = false;
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(entity.PrintTypeCode);
                valid = valid && IsNotNull(entity.LogginName);
                valid = valid && IsNotNull(entity.UniqueCode);

                if (valid)
                {
                    raw = new SAR_PRINT_LOG();
                    raw.DATA_CONTENT = Inventec.Common.String.CountVi.SubStringVi(entity.DataContent, 2000);
                    if (String.IsNullOrEmpty(entity.LogginName))
                    {
                        raw.LOGINNAME = Inventec.Token.ResourceSystem.ResourceTokenManager.GetLoginName();
                        raw.CREATOR = Inventec.Token.ResourceSystem.ResourceTokenManager.GetLoginName();
                    }
                    else
                    {
                        raw.CREATOR = entity.LogginName;
                        raw.LOGINNAME = entity.LogginName;
                    }
                    raw.PRINT_TIME = entity.PrintTime;
                    raw.PRINT_TYPE_CODE = entity.PrintTypeCode;
                    raw.PRINT_TYPE_NAME = entity.PrintTypeName;
                    raw.MODIFIER = raw.CREATOR;
                    raw.UNIQUE_CODE = entity.UniqueCode;
                    raw.IP = entity.Ip;
                    raw.NUM_ORDER = entity.NumOrder;
                    raw.PRINT_REASON = entity.PrintReason;

                    result = Check() && DAOWorker.SarPrintLogDAO.Create(raw);
                }
                else
                {
                    SAR.MANAGER.Base.MessageUtil.SetMessage(param, LibraryMessage.Message.Enum.Common__ThieuThongTinBatBuoc);
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
                result = result && SarPrintLogCheckVerifyValidData.Verify(param, raw);
            }
            catch (Exception ex)
            {
                param.HasException = true;
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }
    }
}
