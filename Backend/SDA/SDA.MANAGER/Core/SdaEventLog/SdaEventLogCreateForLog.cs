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
using SDA.MANAGER.Core.SdaEventLog.CreateForLog;
using Inventec.Core;
using System;

namespace SDA.MANAGER.Core.SdaEventLog
{
    partial class SdaEventLogCreateForLog : BeanObjectBase, IDelegacy
    {
        string description;

        internal SdaEventLogCreateForLog(CommonParam param, string _description)
            : base(param)
        {
            description = _description;
        }

        bool IDelegacy.Execute()
        {
            bool result = false;
            try
            {
                ISdaEventLogCreateForLog behavior = SdaEventLogCreateForLogBehaviorFactory.MakeISdaEventLogCreateForLog(param, description);
                result = behavior != null ? behavior.Run() : false;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }
    }
}
