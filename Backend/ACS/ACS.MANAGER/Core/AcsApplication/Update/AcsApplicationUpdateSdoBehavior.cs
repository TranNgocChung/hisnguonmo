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
using ACS.EFMODEL.DataModels;
using ACS.MANAGER.Base;
using ACS.MANAGER.Core.Check;
using ACS.SDO;
using AutoMapper;
using Inventec.Core;
using System;
using System.Collections.Generic;

namespace ACS.MANAGER.Core.AcsApplication.Update
{
    class AcsApplicationUpdateSdoBehavior : BeanObjectBase, IAcsApplicationUpdate
    {
        AcsApplicationWithDataSDO entity;
        ACS_APPLICATION acsApplicationDTO;
        List<ACS_APP_OTP_TYPE> appOtpTypes;

        internal AcsApplicationUpdateSdoBehavior(CommonParam param, AcsApplicationWithDataSDO data)
            : base(param)
        {
            entity = data;
        }

        bool IAcsApplicationUpdate.Run()
        {
            bool result = false;
            try
            {
                if (Check())
                {
                    if (DAOWorker.AcsApplicationDAO.Update(acsApplicationDTO))
                    {
                        result = true;
                        try
                        {
                            if (this.appOtpTypes != null && appOtpTypes.Count > 0)
                            {
                                if (DAOWorker.AcsAppOtpTypeDAO.TruncateList(appOtpTypes))
                                {
                                    appOtpTypes.ForEach(o => o.ID = 0);
                                    if (!DAOWorker.AcsAppOtpTypeDAO.CreateList(appOtpTypes))
                                    {
                                        param.Messages.Add("Tạo danh sách dữ liệu AcsAppOtpType theo ứng dụng thất bại");
                                    }
                                    else
                                    {
                                        entity.AppOtpTypes = appOtpTypes;
                                    }
                                }
                                else
                                    param.Messages.Add("Xoa danh sách dữ liệu AcsAppOtpType theo ứng dụng de khoi tao lai thất bại");
                            }
                        }
                        catch (Exception exx)
                        {
                            Inventec.Common.Logging.LogSystem.Warn(exx);
                        }
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
                acsApplicationDTO = new ACS_APPLICATION();
                result = result && AcsApplicationCheckVerifyValidData.Verify(param, entity, ref acsApplicationDTO);
                this.appOtpTypes = entity != null ? entity.AppOtpTypes : null;
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
