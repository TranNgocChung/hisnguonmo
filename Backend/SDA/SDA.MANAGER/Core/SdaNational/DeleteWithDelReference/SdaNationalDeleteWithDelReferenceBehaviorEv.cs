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
using SDA.MANAGER.Core.SdaProvince;

namespace SDA.MANAGER.Core.SdaNational.DeleteWithDelReference
{
    class SdaNationalDeleteWithDelReferenceBehaviorEv : BeanObjectBase, ISdaNationalDeleteWithDelReference
    {
        SDA_NATIONAL entity;

        internal SdaNationalDeleteWithDelReferenceBehaviorEv(CommonParam param, SDA_NATIONAL data)
            : base(param)
        {
            entity = data;
        }

        bool ISdaNationalDeleteWithDelReference.Run()
        {
            bool result = false;
            try
            {
                if (Check())
                {
                    result = DAOWorker.SdaNationalDAO.Truncate(entity);
                    if (result)
                    {
                        List<long> listId = new List<long>();
                        listId.Add(entity.ID);
                        DeleteProvince(listId);
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

        private void DeleteProvince(List<long> nationalIds)
        {
            try
            {
                if (!new SdaProvinceBO().DeleteWithDelReference(nationalIds))
                {
                    Logging("Khong xoa duoc cac tinh thanh thuoc quoc gia da xoa." + Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => nationalIds), nationalIds), LogType.Error);
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error("Khong xoa duoc cac tinh thanh thuoc quoc gia da xoa." + Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => nationalIds), nationalIds), ex);
            }
        }

        bool Check()
        {
            bool result = true;
            try
            {
                result = result && SdaNationalCheckVerifyIsUnlock.Verify(param, entity.ID);
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
