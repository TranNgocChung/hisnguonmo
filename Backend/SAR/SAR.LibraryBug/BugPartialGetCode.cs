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
namespace SAR.LibraryBug
{
    public partial class Bug
    {
        private string GetCode(Enum enumBC)
        {
            string code = "";
            switch (enumBC)
            {
                case Enum.Common__KXDDDuLieuCanXuLy: code = CodeResource.Common__KXDDDuLieuCanXuLy; break;
                case Enum.Common__ThieuThongTinBatBuoc: code = CodeResource.Common__ThieuThongTinBatBuoc; break;
                case Enum.Common__LoiCauHinhHeThong: code = CodeResource.Common__LoiCauHinhHeThong; break;
                case Enum.Common__FactoryKhoiTaoDoiTuongThatBai: code = CodeResource.Common__FactoryKhoiTaoDoiTuongThatBai; break;
                case Enum.Common__MaDaTonTai: code = CodeResource.Common__MaDaTonTai; break;
                case Enum.Common__DuLieuDangBiKhoa: code = CodeResource.Common__DuLieuDangBiKhoa; break;
                case Enum.Common__CapNhatThatBai: code = CodeResource.Common__CapNhatThatBai; break;
                case Enum.Common__ThemMoiThatBai: code = CodeResource.Common__ThemMoiThatBai; break;
                case Enum.SarReport_DAOUpdateSttReportThatBai: code = CodeResource.SarReport_DAOUpdateSttReportThatBai; break;
                case Enum.SarReport_DAOUpdateNameDescriptionReportThatBai: code = CodeResource.SarReport_DAOUpdateNameDescriptionReportThatBai; break;
                case Enum.SarReport_DAOUpdateJsonReaderReportThatBai: code = CodeResource.SarReport_DAOUpdateJsonReaderReportThatBai; break;
                case Enum.SarReport_DAOUpdatePublicReportThatBai: code = CodeResource.SarReport_DAOUpdatePublicReportThatBai; break;



                default: code = defaultViMessage; break;
            }
            return code;
        }
    }
}
