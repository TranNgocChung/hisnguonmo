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
using ACS.MANAGER.Core.AcsRole;
using Inventec.Core;
using System;

namespace ACS.MANAGER.Manager
{
    public partial class AcsRoleManager : Inventec.Backend.MANAGER.ManagerBase
    {
        public T GetRoleBase<T>(object data)
        {
            T result = default(T);
            try
            {
                if (!IsNotNull(data)) throw new ArgumentNullException("data");
                AcsRoleBO bo = new AcsRoleBO();
                bo.CopyCommonParamInfoGet(param);
                result = bo.GetRoleBase<T>(data);
                CopyCommonParamInfo(bo);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                result = default(T);
            }
            return result;
        }

        public object CreateWithRoleBase(object data)
        {
            object result = false;
            try
            {
                if (!IsNotNull(data)) throw new ArgumentNullException("data");
                AcsRoleBO bo = new AcsRoleBO();
                if (bo.CreateWithRoleBase(data))
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

        public object UpdateWithRoleBase(object data)
        {
            object result = false;
            try
            {
                if (!IsNotNull(data)) throw new ArgumentNullException("data");
                AcsRoleBO bo = new AcsRoleBO();
                if (bo.UpdateWithRoleBase(data))
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

        public object DeleteWithRoleBase(object data)
        {
            object result = false;
            try
            {
                if (!IsNotNull(data)) throw new ArgumentNullException("data");
                AcsRoleBO bo = new AcsRoleBO();
                if (bo.DeleteWithRoleBase(data))
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
