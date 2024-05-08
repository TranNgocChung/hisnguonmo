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
namespace SDA.LibraryMessage
{
    public partial class Message
    {
        private string GetMessage(Enum enumBC)
        {
            string message = "";
            if (Language == LanguageEnum.Vietnamese)
            {
                switch (enumBC)
                {
                    case Enum.Common__ThieuThongTinBatBuoc: message = MessageViResource.Common__ThieuThongTinBatBuoc; break;
                    case Enum.Common__MaDaTonTaiTrenHeThong: message = MessageViResource.Common__MaDaTonTaiTrenHeThong; break;
                    case Enum.Common__DuLieuDangBiKhoa: message = MessageViResource.Common__DuLieuDangBiKhoa; break;
                    case Enum.Common__LoiCauHinhHeThong: message = MessageViResource.Common__LoiCauHinhHeThong; break;
                    case Enum.SdaGroup_ChaMoiCuaDonViKhongDuocLaConHienTai: message = MessageViResource.SdaGroup_ChaMoiCuaDonViKhongDuocLaConHienTai; break;
                    case Enum.SdaTranslate_DuLieuDaTonTai: message = MessageViResource.SdaTranslate_DuLieuDaTonTai; break;
                    case Enum.SdaLanguage__DuLieuDangDuocSuDung: message = MessageViResource.SdaLanguage__DuLieuDangDuocSuDung; break;
                    case Enum.SdaConfigAppUser_NguoiDungChuaCoDuLieuThietLap: message = MessageViResource.SdaConfigAppUser_NguoiDungChuaCoDuLieuThietLap; break;
                    case Enum.SdaConfigAppUser_CauHinhChuaCoDuLieuThietLap: message = MessageViResource.SdaConfigAppUser_CauHinhChuaCoDuLieuThietLap; break;
                    case Enum.SdaNational_MaDaTonTaiTrenHeThong: message = MessageViResource.SdaNational_MaDaTonTaiTrenHeThong; break;
                    case Enum.SdaLicense_MaKichHoatKhongHopLe: message = MessageViResource.SdaLicense_MaKichHoatKhongHopLe; break;
                    case Enum.Common__DuLieuKhongHopLe: message = MessageViResource.Common__DuLieuKhongHopLe; break;
                    case Enum.Common__DuLieuKhongTonTai: message = MessageViResource.Common__DuLieuKhongTonTai; break;
                    case Enum.SdaLicense_TomTaiMaKichHoat: message = MessageViResource.SdaLicense_TomTaiMaKichHoat; break;

                    default: message = defaultViMessage; break;
                }
            }
            else if (Language == LanguageEnum.English)
            {
                switch (enumBC)
                {

                    default: message = defaultEnMessage; break;
                }
            }
            return message;
        }
    }
}
