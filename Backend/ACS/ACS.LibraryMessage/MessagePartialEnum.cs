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
namespace ACS.LibraryMessage
{
    public partial class Message
    {
        public enum Enum
        {
            Common__ThieuThongTinBatBuoc,
            Common__MaDaTonTaiTrenHeThong,
            Common__LoiCauHinhHeThong,
            Common__DuLieuDangBiKhoa,
            Common__DuLieuTruyenLenKhongHopLe,
            Common__ThemMoiThatBai,
            Common__CapNhatThatBai,
            Core_AcsUser_DangNhapThanhCong,
            Core_AcsRole_VaiTroKeThuaDaDuocKeThuaTuVaiTroDangChon,
            Core_AcsUser_TenDangNhapHoacMatKhauKhongChinhXac,
            Core_AcsUser_TaiKhoanDangBiTamKhoa,
            Core_AcsUser_TaiKhoanChuaDuocThietLapQuyenTruyCapUngDung,
            Core_AcsUser_TaoTaiKhoanThatBai,
            Core_AcsUser_CapNhatThongTinTaiKhoanThatBai,
            Core_AcsUser_TaoTaiKhoanHeThongTichHopThanhCongTuyNhienKhongGanDuocUserRoleDoRoleCodeGuiLenKhongHopLe,
            Core_AcsUser_TaoTaiKhoanHeThongTichHopThanhCongTuyNhienKhongGanDuocUserRole,
            Core_AcsUser_TenDangNhapKhongChinhXac,
            Core_AcsUser_EmailKhongHopLe,
            Core_AcsUser_YeuCauCapNhatThongTinTaiKhoanDayDuTruocKhiResetMatKhauHoacGoiTongDaiCHKHDeDuocHoTro,
            Core_AcsUser_GuiEmailXacNhanResetMatKhauDenNguoiDungThatBai,
            Core_AcsUser_GuiSmsMaKichHoatTaiKhoanDenSDTThatBai,
            Core_AcsUser_DaQuaThoiHanResetMatKhau,
            Core_AcsUser_ChuaThucHienGuiYeuCauGuiOtpDoiMatKhau,
            Core_AcsUser_GuiYeuCauOtpDoiMatKhauTaiKhoanTruyCapGuiLenKhongHopLe,
            Core_AcsUser_GuiYeuCauOtpDoiMatKhauSoDienThoaiGuiLenKhongKhopVoiSoDTDaDangKy,
            Core_AcsUser_MatKhauCuKhongChinhXac,

            Core_AcsApplicationRole_XoaDanhSachQuyenTruyCapThanhCongChiTiet,
            Core_AcsApplicationRole_ThemDanhSachQuyenTruyCapThanhCongChiTiet,
            Core_AcsModuleRole_XoaDanhSachVaiTroChucNangThanhCongChiTiet,
            Core_AcsModuleRole_ThemDanhSachVaiTroChucNangThanhCongChiTiet,
            Core_AcsRole_ThemVaiTroThanhCongChiTiet,
            Core_AcsRole_SuaVaiTroThanhCongChiTiet,
            Core_AcsRole_XoaVaiTroThanhCongChiTiet,
            Core_AcsRole_ThayDoiVaiTroKeThuaCuaVaiTroThanhCongChiTiet,
            Core_AcsToken_PhienBanHienTaiDaCuPhaiNenPhienBanMoiHonDeHeThongTuongThichChayOnDinh,
            Core_AcsUser_YeuCaukichHoatTaiKhoanThatBai,
            Core_AcsOtp_GuiSmsMaDoiMatKhauDenSDTThatBai,
            Core_AcsOtp_GuiYeuCauCapOtpThatBai,
            Core_AcsOtp_VerifyYeuCauCapOtpThatBai,
            Core_AcsOtp_OtpDaHetHan,

            Core_AcsAuthenRequest_AuthenRequest__ThieuMaHeThongUyQuyen,
            Core_AcsAuthenRequest_AuthenRequest__MaHeThongUyQuyenKhongHopLe,
            Core_AcsAuthenRequest_AuthenRequest__ThieuKhoaBaoMat,
            Core_AcsAuthenRequest_AuthenRequest__KhoaBaoMatKhongHopLe,
            Core_AcsAuthenRequest_AuthenRequest__ThieuThongTinNguoiYeuCau,  
            Core_AcsAuthenRequest_AuthenRequest__ThieuThongTinBoSung,
            Core_AcsAuthenRequest_AuthenRequest__ThieuThongTinMaXacThuc,  
            Core_AcsAuthenRequest_AuthenRequest__YeuCauXacThucKhongTonTaiHoacDaHetHan,
            Core_AcsAuthenRequest_AuthenRequest__KhoaCacYeuCauXacThucThatBai,
            Core_AcsAuthenRequest_AuthenRequest__HeThongUyQuyenChuaDuocGanQuyen,

            Core_AcsOtp_OtpReqiure__MaUngDungKhongHopLe,
            Core_AcsOtp_OtpReqiure__ungDungChuaKhaiBaoMauTinNhanKichHoatTaiKhoan,
            Core_AcsOtp_OtpReqiure__ungDungChuaKhaiBaoMauTinNhanDoiMatKhau,
            Core_AcsOtp_OtpReqiure__ungDungChuaKhaiBaoMauTinNhanKhac,
            Core_AcsApplication__TaoUngDungThanhCongTuyNhienKhongTaoDuocDanhSachTemplateCuaUngDung,
            Core_AcsApplication__SuaUngDungThanhCongTuyNhienKhongTaoDuocDanhSachTemplateCuaUngDung,

            Core_AcsOtp_GuiSmsMaVerifyDangNhapDenSDTThatBai,
            Core_AcsOtp_TaiKhoanDangNhapChuaDuocKhaiBaoSoDienThoai,
            Core_AcsOtp_GuiSmsMaOtpVerifyDangNhapAppGuiDenSDTThatBai,
            Core_AcsToken_KhongChoPhepGiaHanThoiGianHieuLucCuaToken,
        }
    }
}
