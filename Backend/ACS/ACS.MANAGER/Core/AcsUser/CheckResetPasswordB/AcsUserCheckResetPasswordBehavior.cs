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
using ACS.MANAGER.Core.AcsUser.Get;
using ACS.MANAGER.Core.Check;
using ACS.SDO;
using Inventec.Common.Mail;
using Inventec.Core;
using System;

namespace ACS.MANAGER.Core.AcsUser.CheckResetPasswordB
{
    class AcsUserCheckResetPasswordBBehaviorEv : BeanObjectBase, IAcsUserCheckResetPasswordB
    {
        AcsUserCheckResetPasswordTDO entity;

        internal AcsUserCheckResetPasswordBBehaviorEv(CommonParam param, AcsUserCheckResetPasswordTDO data)
            : base(param)
        {
            entity = data;
        }

        AcsCheckResetPasswordResultTDO IAcsUserCheckResetPasswordB.Run()
        {
            AcsCheckResetPasswordResultTDO result = null;
            try
            {
                ACS_USER user = new AcsUserBO().Get<ACS_USER>(entity.LoginName.Trim().ToLower());
                if (user == null)
                {
                    MessageUtil.SetMessage(param, LibraryMessage.Message.Enum.Core_AcsUser_TenDangNhapKhongChinhXac);
                    ACS.MANAGER.Base.BugUtil.SetBugCode(param, ACS.LibraryBug.Bug.Enum.Common__ThieuThongTinBatBuoc);
                    Inventec.Common.Logging.LogSystem.Warn("Kiem tra du lieu user khong hop le. Doi mat khau that bai. Can kiem tra lai. " + Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => entity), entity));
                    result = null;
                }
                else
                {
                    result = new AcsCheckResetPasswordResultTDO();
                    result.Email = user.EMAIL;
                    //result.Phone = user.MOBILE;
                    //result.UserName = user.USERNAME;
                    if (String.IsNullOrEmpty(user.EMAIL))
                    {
                        //MessageUtil.SetMessage(param, LibraryMessage.Message.Enum.Core_AcsUser_EmailKhongHopLe);
                        MessageUtil.SetMessage(param, LibraryMessage.Message.Enum.Core_AcsUser_YeuCauCapNhatThongTinTaiKhoanDayDuTruocKhiResetMatKhauHoacGoiTongDaiCHKHDeDuocHoTro);
                        Inventec.Common.Logging.LogSystem.Warn("Kiem tra thong tin tai khoan khong co email, yeu cau nguoi dung nhap day du thong tin truoc khi tien hanh reset mat khau. Du lieu dau vao: " + Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => entity), entity) + "__Ket qua tra ve: " + Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => result), result));
                        result = null;
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
