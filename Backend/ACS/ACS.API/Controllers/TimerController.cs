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
using ACS.API.Base;
using ACS.MANAGER.Token;
using ACS.SDO;
using Inventec.Common.Logging;
using Inventec.Core;
using Inventec.Token;
using System;
using System.Web.Http;

namespace ACS.API.Controllers
{
    public class TimerController : BaseApiController
    {
        [AllowAnonymous]
        [HttpGet]
        [ActionName("Sync")]
        public ApiResult Sync()
        {
            try
            {
                TokenManager mng = new TokenManager();
                DateTime dateTime = DateTime.Now;
                TimeZoneInfo timeZone = TimeZoneInfo.Local;// TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
                TimerSDO timerSDO = new TimerSDO();
                timerSDO.DateNow = dateTime;
                var dateTimeUnspec = DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified);
                DateTime DateUniversalTime = TimeZoneInfo.ConvertTimeToUtc(dateTimeUnspec, timeZone);
                timerSDO.UniversalTime = Inventec.Common.TypeConvert.Parse.ToInt64(DateUniversalTime.ToString("yyyyMMddHHmmss"));
                timerSDO.TimeZoneId = timeZone.Id;
                timerSDO.LocalTime = Inventec.Common.TypeConvert.Parse.ToInt64(TimeZoneInfo.ConvertTime(DateUniversalTime, timeZone).ToString("yyyyMMddHHmmss"));
                timerSDO.TimeZoneId = timeZone.Id;

                ApiResultObject<TimerSDO> result = new ApiResultObject<TimerSDO>(timerSDO, true);
                return new ApiResult(result, this.ActionContext);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                return null;
            }
        }
    }
}
