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
using SAR.EFMODEL.DataModels;
using SAR.MANAGER.Base;
using SAR.MANAGER.Core.SdaConfig;
using SAR.MANAGER.Core.SdaConfig.Get;
using SDA.EFMODEL.DataModels;
using System;
using System.Collections.Generic;

namespace SAR.MANAGER.Config
{
    public class Loader : BusinessBase
    {
        public static Dictionary<string, SDA_CONFIG> dictionaryConfig = new Dictionary<string, SDA_CONFIG>();
        public static bool Refresh()
        {
            bool result = false;
            try
            {
                CommonParam paramGet = new CommonParam();
                //Cac backend khac thi se goi thong qua API
                //Nho su dung param de kiem tra exception
                List<SDA_CONFIG> listConfig = new SdaConfigBO().Get<List<SDA_CONFIG>>(new SdaConfigFilterQuery());
                if (listConfig != null && listConfig.Count > 0)
                {
                    foreach (var config in listConfig)
                    {
                        if (!String.IsNullOrWhiteSpace(config.KEY))
                        {
                            dictionaryConfig[config.KEY] = config; //Ghi de du lieu cu ==> luu y tinh huong neu 2 config trung key thi config sau se de len config truoc. Loi nay thuoc ve constraint du lieu ko thuoc trach nhiem cua Loader.
                        }
                        else
                        {
                            LogSystem.Error("Key null." + Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => config), config));
                        }
                    }
                    result = true;
                }
                else if (paramGet.HasException)
                {
                    LogSystem.Error("Query sdaconfig co exception.");
                }
                else
                {
                    LogSystem.Warn("Khong co du lieu sdaconfig & khong co exception.");
                    result = true;
                }
                if (result)
                {
                    LogSystem.Info("Load du lieu cau hinh sdaconfig thanh cong.");
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                result = false;
            }
            return result;
        }
    }
}
