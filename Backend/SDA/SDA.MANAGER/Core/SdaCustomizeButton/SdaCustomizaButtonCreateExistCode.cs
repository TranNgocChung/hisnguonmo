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

namespace SDA.MANAGER.SdaCustomizaButton
{
    partial class SdaCustomizaButtonCreate : BusinessBase
    {
		private List<SDA_CUSTOMIZA_BUTTON> recentSdaCustomizaButtons = new List<SDA_CUSTOMIZA_BUTTON>();
		
        internal SdaCustomizaButtonCreate()
            : base()
        {

        }

        internal SdaCustomizaButtonCreate(CommonParam paramCreate)
            : base(paramCreate)
        {

        }

        internal bool Create(SDA_CUSTOMIZA_BUTTON data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                SdaCustomizaButtonCheck checker = new SdaCustomizaButtonCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                valid = valid && checker.ExistsCode(data.CUSTOMIZA_BUTTON_CODE, null);
                if (valid)
                {
					if (!DAOWorker.SdaCustomizaButtonDAO.Create(data))
                    {
                        SDA.MANAGER.Base.BugUtil.SetBugCode(param, SDA.LibraryBug.Bug.Enum.SdaCustomizaButton_ThemMoiThatBai);
                        throw new Exception("Them moi thong tin SdaCustomizaButton that bai." + LogUtil.TraceData("data", data));
                    }
                    this.recentSdaCustomizaButtons.Add(data);
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
            if (IsNotNullOrEmpty(this.recentSdaCustomizaButtons))
            {
                if (!DAOWorker.SdaCustomizaButtonDAO.TruncateList(this.recentSdaCustomizaButtons))
                {
                    LogSystem.Warn("Rollback du lieu SdaCustomizaButton that bai, can kiem tra lai." + LogUtil.TraceData("recentSdaCustomizaButtons", this.recentSdaCustomizaButtons));
                }
				this.recentSdaCustomizaButtons = null;
            }
        }
    }
}
