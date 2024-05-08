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
using SDA.LibraryBug;
using Inventec.Common.Logging;
using Inventec.Core;
using System;

namespace SDA.MANAGER.Base
{
    public class BugUtil
    {
        public static void SetBugCode(CommonParam param, Bug.Enum bugCaseEnum)
        {
            try
            {
                Bug bug = SDA.LibraryBug.DatabaseBug.Get(bugCaseEnum);
                if (bug != null)
                {
                    param.BugCodes.Add(bug.code);
                }
                else
                {
                    LogSystem.Error("Thu vien chua khai bao key.");
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
        }
    }
}
