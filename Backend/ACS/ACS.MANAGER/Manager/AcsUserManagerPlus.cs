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
using ACS.EFMODEL.DataModels;
using ACS.MANAGER.Core.AcsUser;
using Inventec.Core;
using System;
using System.Collections.Generic;

namespace ACS.MANAGER.Manager
{
    public partial class AcsUserManager : Inventec.Backend.MANAGER.ManagerBase
    {
        public List<object> GetDynamic(object data)
        {
            List<object> result = default(List<object>);
            try
            {
                if (!IsNotNull(data)) throw new ArgumentNullException("data");
                AcsUserBO bo = new AcsUserBO();
                bo.CopyCommonParamInfoGet(param);
                result = bo.GetDynamic(data);
                CopyCommonParamInfo(bo);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                result = default(List<object>);
            }
            return result;
        }

        public object ChangePassword(object data)
        {
            object result = false;
            try
            {
                if (!IsNotNull(data)) throw new ArgumentNullException("data");
                AcsUserBO bo = new AcsUserBO();
                if (bo.ChangePassword(data))
                {
                    result = true;
                }
                CopyCommonParamInfo(bo);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                result = false;
            }
            return result;
        }

        public object ChangePasswordWithOtp(object data)
        {
            object result = false;
            try
            {
                if (!IsNotNull(data)) throw new ArgumentNullException("data");
                AcsUserBO bo = new AcsUserBO();
                if (bo.ChangePasswordWithOtp(data))
                {
                    result = true;
                }
                CopyCommonParamInfo(bo);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                result = false;
            }
            return result;
        }

        public object ResetPassword(object data)
        {
            object result = false;
            try
            {
                if (!IsNotNull(data)) throw new ArgumentNullException("data");
                AcsUserBO bo = new AcsUserBO();
                if (bo.ResetPassword(data))
                {
                    result = true;
                }
                CopyCommonParamInfo(bo);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                result = false;
            }
            return result;
        }

        public object ResetPasswordB(object data)
        {
            object result = null;
            try
            {
                if (!IsNotNull(data)) throw new ArgumentNullException("data");
                AcsUserBO bo = new AcsUserBO();
                result = (bo.ResetPasswordB(data));
                CopyCommonParamInfo(bo);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }

        public object CheckResetPassword(object data)
        {
            object result = null;
            try
            {
                if (!IsNotNull(data)) throw new ArgumentNullException("data");
                AcsUserBO bo = new AcsUserBO();
                result = (bo.CheckResetPasswordB(data));
                CopyCommonParamInfo(bo);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }

        public object CreateSdo(object data)
        {
            object result = false;
            try
            {
                if (!IsNotNull(data)) throw new ArgumentNullException("data");
                AcsUserBO bo = new AcsUserBO();
                if (bo.Create(data))
                {
                    result = true;
                }
                CopyCommonParamInfo(bo);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                result = false;
            }
            return result;
        }

        public object CopyRole(object data)
        {
            object result = null;
            try
            {
                if (!IsNotNull(data)) throw new ArgumentNullException("data");
                AcsUserBO bo = new AcsUserBO();
                result = (bo.CopyRole(data));               
                CopyCommonParamInfo(bo);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                result = false;
            }
            return result;
        }

        public object CheckActive(object data)
        {
            object result = false;
            try
            {
                if (!IsNotNull(data)) throw new ArgumentNullException("data");
                AcsUserBO bo = new AcsUserBO();
                if (bo.CheckActive(data))
                {
                    result = true;
                }
                CopyCommonParamInfo(bo);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                result = false;
            }
            return result;
        }

        public object ActivationRequired(object data)
        {
            object result = false;
            try
            {
                if (!IsNotNull(data)) throw new ArgumentNullException("data");
                AcsUserBO bo = new AcsUserBO();
                if (bo.ActivationRequired(data))
                {
                    result = true;
                }
                CopyCommonParamInfo(bo);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                result = false;
            }
            return result;
        }

        public object ActivationRequiredWithMessage(object data)
        {
            object result = false;
            try
            {
                if (!IsNotNull(data)) throw new ArgumentNullException("data");
                AcsUserBO bo = new AcsUserBO();
                if (bo.ActivationRequiredWithMessage(data))
                {
                    result = true;
                }
                CopyCommonParamInfo(bo);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                result = false;
            }
            return result;
        }

        public object Activate(object data)
        {
            object result = false;
            try
            {
                if (!IsNotNull(data)) throw new ArgumentNullException("data");
                AcsUserBO bo = new AcsUserBO();
                if (bo.Activate(data))
                {
                    result = true;
                }
                CopyCommonParamInfo(bo);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                result = false;
            }
            return result;
        }

        public object InActive(object data)
        {
            object result = false;
            try
            {
                if (!IsNotNull(data)) throw new ArgumentNullException("data");
                AcsUserBO bo = new AcsUserBO();
                if (bo.InActive(data))
                {
                    result = true;
                }
                CopyCommonParamInfo(bo);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                result = false;
            }
            return result;
        }

        public object UpdateListInfo(object data)
        {
            object result = false;
            try
            {
                if (!IsNotNull(data)) throw new ArgumentNullException("data");
                AcsUserBO bo = new AcsUserBO();
                if (bo.UpdateListInfo(data))
                {
                    result = true;
                }
                CopyCommonParamInfo(bo);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                result = false;
            }
            return result;
        }
    }
}
