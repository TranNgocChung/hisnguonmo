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
using DevExpress.XtraBars;
using HIS.Desktop.Common;
using MOS.EFMODEL.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.Desktop.Plugins.VaccinationExam.Processors
{
    delegate void MouseRightClick(object sender, ItemClickEventArgs e);

    class PopupMenuProcessor
    {
        BarManager _BarManager = null;
        internal PopupMenu _Menu = null;
        MouseRightClick _MouseRightClick;
        V_HIS_VACCINATION_EXAM _VaccinationExamPoppup;
        RefeshReference BtnRefreshPhimTat;
        internal enum ItemType
        {
            HuyKetThuc,
            ThanhToan
        }
        internal PopupMenuProcessor(V_HIS_VACCINATION_EXAM currentVaccinationExam, BarManager barManager, MouseRightClick mouseRightClick, RefeshReference _BtnRefreshPhimTat)
        {
            this._BarManager = barManager;
            this._MouseRightClick = mouseRightClick;
            this._VaccinationExamPoppup = currentVaccinationExam;
            this.BtnRefreshPhimTat = _BtnRefreshPhimTat;
        }

        internal void InitMenu(System.Drawing.Point point)
        {
            try
            {
                if (this._BarManager == null || this._MouseRightClick == null)
                    return;
                if (this._Menu == null)
                    this._Menu = new PopupMenu(this._BarManager);
                this._Menu.ItemLinks.Clear();

                if (this._VaccinationExamPoppup == null)
                    return;

                if (this._VaccinationExamPoppup.VACCINATION_EXAM_STT_ID == 3)   // Đã kết thúc
                {
                    //Hủy kết thúc
                    BarButtonItem bbtnHuyKetThuc = new BarButtonItem(this._BarManager, "Hủy kết thúc", 4);
                    bbtnHuyKetThuc.Tag = ItemType.HuyKetThuc;
                    bbtnHuyKetThuc.ItemClick += new ItemClickEventHandler(this._MouseRightClick);
                    this._Menu.AddItems(new BarItem[] { bbtnHuyKetThuc });
                }

                //Thanh toán
                BarButtonItem bbtnThanhToan = new BarButtonItem(this._BarManager, "Thanh toán", 1);
                bbtnThanhToan.Tag = ItemType.ThanhToan;
                bbtnThanhToan.ItemClick += new ItemClickEventHandler(this._MouseRightClick);
                this._Menu.AddItems(new BarItem[] { bbtnThanhToan });

                this._Menu.ShowPopup(point);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }
    }
}
