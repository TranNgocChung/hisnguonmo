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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAR.MANAGER.Core.SarUserReportType.Copy
{
    class SarUserReportTypeCopyByUserBehavior : BeanObjectBase, ISarUserReportTypeCopy
    {
        private SDO.SarUserReportTypeCopyByUserSDO entity;

        public SarUserReportTypeCopyByUserBehavior(Inventec.Core.CommonParam param, SDO.SarUserReportTypeCopyByUserSDO sarUserReportTypeCopyByUserSDO)
            : base(param)
        {
            this.entity = sarUserReportTypeCopyByUserSDO;
        }

        object ISarUserReportTypeCopy.Run()
        {
            List<SAR_USER_REPORT_TYPE> result = null;
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(entity);
                valid = valid && IsNotNull(entity.CopyUserLoginname);
                valid = valid && IsNotNull(entity.PasteUserLoginname);
                if (valid)
                {
                    List<SAR_USER_REPORT_TYPE> newDatas = new List<SAR_USER_REPORT_TYPE>();

                    List<SAR_USER_REPORT_TYPE> copyDatas = Base.DAOWorker.SqlDAO.GetSql<SAR_USER_REPORT_TYPE>("SELECT * FROM SAR_USER_REPORT_TYPE WHERE LOGINNAME = :param1", entity.CopyUserLoginname);
                    List<SAR_USER_REPORT_TYPE> pasteDatas = Base.DAOWorker.SqlDAO.GetSql<SAR_USER_REPORT_TYPE>("SELECT * FROM SAR_USER_REPORT_TYPE WHERE LOGINNAME = :param1", entity.PasteUserLoginname);

                    if (!IsNotNullOrEmpty(copyDatas))
                    {
                        //SAR_REPORT_TYPE report = new Manager.SarReportTypeManager(param).Get<SAR_REPORT_TYPE>(entity.CopyUserLoginname);
                        //string name = report != null ? report.REPORT_TYPE_CODE : null;
                        MANAGER.Base.MessageUtil.SetMessage(param, LibraryMessage.Message.Enum.SarReportType_NguoiDungChuaCoDuLieuThietLap, entity.CopyUserLoginname);
                        throw new Exception("Khong co du lieu copyServiceRooms");
                    }

                    foreach (SAR_USER_REPORT_TYPE copyData in copyDatas)
                    {
                        SAR_USER_REPORT_TYPE data = pasteDatas != null ? pasteDatas.FirstOrDefault(o => o.REPORT_TYPE_ID == copyData.REPORT_TYPE_ID) : null;
                        if (data != null)
                        {
                            continue;
                        }
                        else
                        {
                            data = new SAR_USER_REPORT_TYPE();
                            data.LOGINNAME = entity.PasteUserLoginname;
                            data.REPORT_TYPE_ID = copyData.REPORT_TYPE_ID;
                            newDatas.Add(data);
                        }
                    }
                    if (IsNotNullOrEmpty(newDatas))
                    {
                        if (!Base.DAOWorker.SarUserReportTypeDAO.CreateList(newDatas))
                        {
                            throw new Exception("Khong tao duoc SAR_USER_REPORT_TYPE");
                        }
                    }

                    result = new List<SAR_USER_REPORT_TYPE>();
                    if (IsNotNullOrEmpty(newDatas))
                    {
                        result.AddRange(newDatas);
                    }
                    if (IsNotNullOrEmpty(pasteDatas))
                    {
                        result.AddRange(pasteDatas);
                    }
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }
    }
}
