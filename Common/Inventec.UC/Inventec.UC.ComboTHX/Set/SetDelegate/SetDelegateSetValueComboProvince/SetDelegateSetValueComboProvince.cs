﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventec.UC.ComboTHX.Set.SetDelegate.SetDelegateSetValueComboProvince
{
    class SetDelegateSetValueComboProvince : ISetDelegateSetValueComboProvince
    {
        public bool SetDelegateValueProvince(System.Windows.Forms.UserControl UC, SetValueComboProvince ValueTinh)
        {
            bool result = false;
            try
            {
                if (UC.GetType() == typeof(Design.Template1.Template1))
                {
                    Design.Template1.Template1 UCComboTHX = (Design.Template1.Template1)UC;
                    result = UCComboTHX.SetDelegateSetValueProvince(ValueTinh);
                    if (result == false)
                    {
                        Inventec.Common.Logging.LogSystem.Debug(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => UC), UC));
                        Inventec.Common.Logging.LogSystem.Debug(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => UCComboTHX), UCComboTHX));
                        Inventec.Common.Logging.LogSystem.Debug(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => ValueTinh), ValueTinh));
                    }
                }
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
