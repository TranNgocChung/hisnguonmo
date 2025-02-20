﻿using Inventec.Common.Adapter;
using Inventec.Common.Logging;
using Inventec.Core;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Inventec.Common.LocalStorage.SdaConfig
{
    public class ConfigLoader
    {
        static string sdaConfigUri = (ConfigurationManager.AppSettings["Inventec.Common.LocalStorage.SdaConfig.SdaConfigGet.Uri.Base"] ?? "/api/SdaConfig/Get").ToString();
        public static Dictionary<string, SDA.EFMODEL.DataModels.SDA_CONFIG> dictionaryConfig = new Dictionary<string, SDA.EFMODEL.DataModels.SDA_CONFIG>();

        public static bool Refresh()
        {
            bool result = false;
            try
            {
                CommonParam paramGet = new CommonParam();
                var ro = new BackendAdapter(paramGet).Get<List<SDA.EFMODEL.DataModels.SDA_CONFIG>>(sdaConfigUri, ApiConsumerConfig.SdaConsumer, new SDA.Filter.SdaConfigFilter(), paramGet);
                if (ro != null && ro.Count > 0)
                {
                    foreach (var config in ro)
                    {
                        if (!String.IsNullOrWhiteSpace(config.KEY))
                        {
                            dictionaryConfig[config.KEY] = config; //Ghi de du lieu cu ==> luu y tinh huong neu 2 config trung key thi config sau se de len config truoc. Loi nay thuoc ve constraint du lieu ko thuoc trach nhiem cua Loader.
                        }
                        else
                        {
                            LogSystem.Error("Key null." + LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => config), config));
                        }
                    }
                    result = true;
                }
                else if (paramGet.HasException)
                {
                    LogSystem.Error("Query SdaConfig co exception.");
                }
                else
                {
                    LogSystem.Warn("Khong co du lieu SdaConfig & khong co exception.");
                    result = true;
                }
                if (result)
                {
                    LogSystem.Info("Load du lieu cau hinh SdaConfig thanh cong.");
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
