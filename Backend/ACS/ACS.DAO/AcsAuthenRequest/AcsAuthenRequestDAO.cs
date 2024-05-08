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
using ACS.DAO.StagingObject;
using ACS.EFMODEL.DataModels;
using Inventec.Common.Repository;
using Inventec.Core;
using System;
using System.Collections.Generic;

namespace ACS.DAO.AcsAuthenRequest
{
    public partial class AcsAuthenRequestDAO : EntityBase
    {
        private AcsAuthenRequestCreate CreateWorker
        {
            get
            {
                return (AcsAuthenRequestCreate)Worker.Get<AcsAuthenRequestCreate>();
            }
        }
        private AcsAuthenRequestUpdate UpdateWorker
        {
            get
            {
                return (AcsAuthenRequestUpdate)Worker.Get<AcsAuthenRequestUpdate>();
            }
        }
        private AcsAuthenRequestDelete DeleteWorker
        {
            get
            {
                return (AcsAuthenRequestDelete)Worker.Get<AcsAuthenRequestDelete>();
            }
        }
        private AcsAuthenRequestTruncate TruncateWorker
        {
            get
            {
                return (AcsAuthenRequestTruncate)Worker.Get<AcsAuthenRequestTruncate>();
            }
        }
        private AcsAuthenRequestGet GetWorker
        {
            get
            {
                return (AcsAuthenRequestGet)Worker.Get<AcsAuthenRequestGet>();
            }
        }
        private AcsAuthenRequestCheck CheckWorker
        {
            get
            {
                return (AcsAuthenRequestCheck)Worker.Get<AcsAuthenRequestCheck>();
            }
        }

        public bool Create(ACS_AUTHEN_REQUEST data)
        {
            bool result = false;
            try
            {
                result = CreateWorker.Create(data);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public bool CreateList(List<ACS_AUTHEN_REQUEST> listData)
        {
            bool result = false;
            try
            {
                result = CreateWorker.CreateList(listData);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public bool Update(ACS_AUTHEN_REQUEST data)
        {
            bool result = false;
            try
            {
                result = UpdateWorker.Update(data);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public bool UpdateList(List<ACS_AUTHEN_REQUEST> listData)
        {
            bool result = false;
            try
            {
                result = UpdateWorker.UpdateList(listData);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public bool Delete(ACS_AUTHEN_REQUEST data)
        {
            bool result = false;
            try
            {
                result = DeleteWorker.Delete(data);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public bool DeleteList(List<ACS_AUTHEN_REQUEST> listData)
        {
            bool result = false;

            try
            {
                result = DeleteWorker.DeleteList(listData);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public bool Truncate(ACS_AUTHEN_REQUEST data)
        {
            bool result = false;
            try
            {
                result = TruncateWorker.Truncate(data);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public bool TruncateList(List<ACS_AUTHEN_REQUEST> listData)
        {
            bool result = false;
            try
            {
                result = TruncateWorker.TruncateList(listData);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public List<ACS_AUTHEN_REQUEST> Get(AcsAuthenRequestSO search, CommonParam param)
        {
            List<ACS_AUTHEN_REQUEST> result = new List<ACS_AUTHEN_REQUEST>();
            try
            {
                result = GetWorker.Get(search, param);
            }
            catch (Exception ex)
            {
                param.HasException = true;
                Inventec.Common.Logging.LogSystem.Error(ex);
                result.Clear();
            }
            return result;
        }

        public ACS_AUTHEN_REQUEST GetById(long id, AcsAuthenRequestSO search)
        {
            ACS_AUTHEN_REQUEST result = null;
            try
            {
                result = GetWorker.GetById(id, search);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = null;
            }

            return result;
        }

        public bool IsUnLock(long id)
        {
            try
            {
                return CheckWorker.IsUnLock(id);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                throw;
            }
        }
    }
}
