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
using Inventec.Common.Logging;
using Inventec.Core;
using SDA.EFMODEL.DataModels;
using SDA.MANAGER.Base;
using System;
using System.Collections.Generic;

namespace SDA.MANAGER.SdaCustomizeButton
{
    partial class SdaCustomizeButtonCreate : BusinessBase
    {
		private List<SDA_CUSTOMIZE_BUTTON> recentSdaCustomizeButtons = new List<SDA_CUSTOMIZE_BUTTON>();
		
        internal SdaCustomizeButtonCreate()
            : base()
        {

        }

        internal SdaCustomizeButtonCreate(CommonParam paramCreate)
            : base(paramCreate)
        {

        }

        internal bool Create(SDA_CUSTOMIZE_BUTTON data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                SdaCustomizeButtonCheck checker = new SdaCustomizeButtonCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                if (valid)
                {
					if (!DAOWorker.SdaCustomizeButtonDAO.Create(data))
                    {
                        SDA.MANAGER.Base.BugUtil.SetBugCode(param, SDA.LibraryBug.Bug.Enum.SdaCustomizeButton_ThemMoiThatBai);
                        throw new Exception("Them moi thong tin SdaCustomizeButton that bai." + LogUtil.TraceData("data", data));
                    }
                    this.recentSdaCustomizeButtons.Add(data);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = false;
            }
            return result;
        }
		
		internal bool CreateList(List<SDA_CUSTOMIZE_BUTTON> listData)
        {
            bool result = false;
            try
            {
                bool valid = true;
                valid = IsNotNullOrEmpty(listData);
                SdaCustomizeButtonCheck checker = new SdaCustomizeButtonCheck(param);
                foreach (var data in listData)
                {
                    valid = valid && checker.VerifyRequireField(data);
                }
                if (valid)
                {
                    if (!DAOWorker.SdaCustomizeButtonDAO.CreateList(listData))
                    {
                        SDA.MANAGER.Base.BugUtil.SetBugCode(param, SDA.LibraryBug.Bug.Enum.SdaCustomizeButton_ThemMoiThatBai);
                        throw new Exception("Them moi thong tin SdaCustomizeButton that bai." + LogUtil.TraceData("listData", listData));
                    }
                    this.recentSdaCustomizeButtons.AddRange(listData);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = false;
            }

            return result;
        }
		
		internal void RollbackData()
        {
            if (IsNotNullOrEmpty(this.recentSdaCustomizeButtons))
            {
                if (!DAOWorker.SdaCustomizeButtonDAO.TruncateList(this.recentSdaCustomizeButtons))
                {
                    LogSystem.Warn("Rollback du lieu SdaCustomizeButton that bai, can kiem tra lai." + LogUtil.TraceData("recentSdaCustomizeButtons", this.recentSdaCustomizeButtons));
                }
				this.recentSdaCustomizeButtons = null;
            }
        }
    }
}
