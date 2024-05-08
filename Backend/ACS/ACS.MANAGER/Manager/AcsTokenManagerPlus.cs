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
using ACS.MANAGER.Core.TokenSys;
using Inventec.Core;
using System;

namespace ACS.MANAGER.Manager
{
    public partial class AcsTokenManagerExtra : Inventec.Backend.MANAGER.ManagerBase
    {
        public AcsTokenManagerExtra(CommonParam param)
            : base(param)
        {

        }

        public object Login(object data)
        {
            object result = null;
            try
            {
                if (!IsNotNull(data)) throw new ArgumentNullException("data");
                AcsTokenBO bo = new AcsTokenBO();
                bo.CopyCommonParamInfoGet(param);
                result = bo.Login(data);
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

        public object LoginBySecretKey(object data)
        {
            object result = null;
            try
            {
                if (!IsNotNull(data)) throw new ArgumentNullException("data");
                AcsTokenBO bo = new AcsTokenBO();
                bo.CopyCommonParamInfoGet(param);
                result = bo.LoginBySecretKey(data);
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

        public object LoginByAuthenRequest(object data)
        {
            object result = null;
            try
            {
                if (!IsNotNull(data)) throw new ArgumentNullException("data");
                AcsTokenBO bo = new AcsTokenBO();
                bo.CopyCommonParamInfoGet(param);
                result = bo.LoginByAuthenRequest(data);
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

        public object LoginByEmail(object data)
        {
            object result = null;
            try
            {
                if (!IsNotNull(data)) throw new ArgumentNullException("data");
                AcsTokenBO bo = new AcsTokenBO();
                bo.CopyCommonParamInfoGet(param);
                result = bo.LoginByEmail(data);
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

        public object Authorize(object data)
        {
            object result = null;
            try
            {
                if (!IsNotNull(data)) throw new ArgumentNullException("data");
                AcsTokenBO bo = new AcsTokenBO();
                bo.CopyCommonParamInfoGet(param);
                result = bo.Authorize(data);
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

        public object SyncToken(object data)
        {
            object result = false;
            try
            {
                if (!IsNotNull(data)) throw new ArgumentNullException("data");
                AcsTokenBO bo = new AcsTokenBO();
                bo.CopyCommonParamInfoGet(param);
                result = bo.SyncToken(data);
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
