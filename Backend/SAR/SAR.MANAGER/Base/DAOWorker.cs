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
using Inventec.Common.Repository;

namespace SAR.MANAGER.Base
{
    static class DAOWorker
    {
        internal static SAR.DAO.SarFormField.SarFormFieldDAO SarFormFieldDAO { get { return (SAR.DAO.SarFormField.SarFormFieldDAO)Worker.Get<SAR.DAO.SarFormField.SarFormFieldDAO>(); } }
        internal static SAR.DAO.SarPrint.SarPrintDAO SarPrintDAO { get { return (SAR.DAO.SarPrint.SarPrintDAO)Worker.Get<SAR.DAO.SarPrint.SarPrintDAO>(); } }
        internal static SAR.DAO.SarPrintType.SarPrintTypeDAO SarPrintTypeDAO { get { return (SAR.DAO.SarPrintType.SarPrintTypeDAO)Worker.Get<SAR.DAO.SarPrintType.SarPrintTypeDAO>(); } }
        internal static SAR.DAO.SarReport.SarReportDAO SarReportDAO { get { return (SAR.DAO.SarReport.SarReportDAO)Worker.Get<SAR.DAO.SarReport.SarReportDAO>(); } }
        internal static SAR.DAO.SarReportCalendar.SarReportCalendarDAO SarReportCalendarDAO { get { return (SAR.DAO.SarReportCalendar.SarReportCalendarDAO)Worker.Get<SAR.DAO.SarReportCalendar.SarReportCalendarDAO>(); } }
        internal static SAR.DAO.SarReportStt.SarReportSttDAO SarReportSttDAO { get { return (SAR.DAO.SarReportStt.SarReportSttDAO)Worker.Get<SAR.DAO.SarReportStt.SarReportSttDAO>(); } }
        internal static SAR.DAO.SarReportTemplate.SarReportTemplateDAO SarReportTemplateDAO { get { return (SAR.DAO.SarReportTemplate.SarReportTemplateDAO)Worker.Get<SAR.DAO.SarReportTemplate.SarReportTemplateDAO>(); } }
        internal static SAR.DAO.SarReportType.SarReportTypeDAO SarReportTypeDAO { get { return (SAR.DAO.SarReportType.SarReportTypeDAO)Worker.Get<SAR.DAO.SarReportType.SarReportTypeDAO>(); } }
        internal static SAR.DAO.SarRetyFofi.SarRetyFofiDAO SarRetyFofiDAO { get { return (SAR.DAO.SarRetyFofi.SarRetyFofiDAO)Worker.Get<SAR.DAO.SarRetyFofi.SarRetyFofiDAO>(); } }
        internal static SAR.DAO.SarUserReportType.SarUserReportTypeDAO SarUserReportTypeDAO { get { return (SAR.DAO.SarUserReportType.SarUserReportTypeDAO)Worker.Get<SAR.DAO.SarUserReportType.SarUserReportTypeDAO>(); } }
        internal static SAR.DAO.SarFormType.SarFormTypeDAO SarFormTypeDAO { get { return (SAR.DAO.SarFormType.SarFormTypeDAO)Worker.Get<SAR.DAO.SarFormType.SarFormTypeDAO>(); } }
        internal static SAR.DAO.SarForm.SarFormDAO SarFormDAO { get { return (SAR.DAO.SarForm.SarFormDAO)Worker.Get<SAR.DAO.SarForm.SarFormDAO>(); } }
        internal static SAR.DAO.SarFormData.SarFormDataDAO SarFormDataDAO { get { return (SAR.DAO.SarFormData.SarFormDataDAO)Worker.Get<SAR.DAO.SarFormData.SarFormDataDAO>(); } }

        internal static SAR.DAO.Sql.SqlDAO SqlDAO { get { return (SAR.DAO.Sql.SqlDAO)Worker.Get<SAR.DAO.Sql.SqlDAO>(); } }
        internal static SAR.DAO.SarPrintLog.SarPrintLogDAO SarPrintLogDAO { get { return (SAR.DAO.SarPrintLog.SarPrintLogDAO)Worker.Get<SAR.DAO.SarPrintLog.SarPrintLogDAO>(); } }
        internal static SAR.DAO.SarReportTypeGroup.SarReportTypeGroupDAO SarReportTypeGroupDAO { get { return (SAR.DAO.SarReportTypeGroup.SarReportTypeGroupDAO)Worker.Get<SAR.DAO.SarReportTypeGroup.SarReportTypeGroupDAO>(); } }
        internal static SAR.DAO.SarPrintTypeCfg.SarPrintTypeCfgDAO SarPrintTypeCfgDAO { get { return (SAR.DAO.SarPrintTypeCfg.SarPrintTypeCfgDAO)Worker.Get<SAR.DAO.SarPrintTypeCfg.SarPrintTypeCfgDAO>(); } }
    }
}
