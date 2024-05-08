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
namespace SAR.LibraryMessage
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
                    case Enum.SarReportType_BaoCaoChuaCoDuLieuThietLap: message = MessageViResource.SarReportType_BaoCaoChuaCoDuLieuThietLap; break;
                    case Enum.SarReportType_NguoiDungChuaCoDuLieuThietLap: message = MessageViResource.SarReportType_NguoiDungChuaCoDuLieuThietLap; break;

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
