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

namespace ACS.DAO.AcsRole
{
    public partial class AcsRoleDAO : EntityBase
    {
        private AcsRoleCreate CreateWorker
        {
            get
            {
                return (AcsRoleCreate)Worker.Get<AcsRoleCreate>();
            }
        }
        private AcsRoleUpdate UpdateWorker
        {
            get
            {
                return (AcsRoleUpdate)Worker.Get<AcsRoleUpdate>();
            }
        }
        private AcsRoleDelete DeleteWorker
        {
            get
            {
                return (AcsRoleDelete)Worker.Get<AcsRoleDelete>();
            }
        }
        private AcsRoleTruncate TruncateWorker
        {
            get
            {
                return (AcsRoleTruncate)Worker.Get<AcsRoleTruncate>();
            }
        }
        private AcsRoleGet GetWorker
        {
            get
            {
                return (AcsRoleGet)Worker.Get<AcsRoleGet>();
            }
        }
        private AcsRoleCheck CheckWorker
        {
            get
            {
                return (AcsRoleCheck)Worker.Get<AcsRoleCheck>();
            }
        }

        public bool Create(ACS_ROLE data)
        {
            bool result = false;
            
            #region Logging Input Data
            try
            {
                Input = Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => data), data);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
            #endregion

            try
            {
                result = CreateWorker.Create(data);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }

            #region Logging
            if (!result)
            {
                LogInOut(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => result), result) + Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => data), data));
            }
            #endregion

            return result;
        }

        public bool CreateList(List<ACS_ROLE> listData)
        {
            bool result = false;

            #region Logging Input Data
            try
            {
                Input = Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => listData), listData);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
            #endregion

            try
            {
                result = CreateWorker.CreateList(listData);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }

            #region Logging
            if (!result)
            {
                LogInOut(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => result), result) + Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => listData), listData));
            }
            #endregion

            return result;
        }

        public bool Update(ACS_ROLE data)
        {
            bool result = false;
            
            #region Logging Input Data
            try
            {
                Input = Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => data), data);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
            #endregion

            try
            {
                result = UpdateWorker.Update(data);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }

            #region Logging
            if (!result)
            {
                LogInOut(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => result), result) + Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => data), data));
            }
            #endregion

            return result;
        }

        public bool UpdateList(List<ACS_ROLE> listData)
        {
            bool result = false;

            #region Logging Input Data
            try
            {
                Input = Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => listData), listData);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
            #endregion

            try
            {
                result = UpdateWorker.UpdateList(listData);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }

            #region Logging
            if (!result)
            {
                LogInOut(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => result), result) + Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => listData), listData));
            }
            #endregion

            return result;
        }

        public bool Delete(ACS_ROLE data)
        {
            bool result = false;
            
            #region Logging Input Data
            try
            {
                Input = Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => data), data);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
            #endregion

            try
            {
                result = DeleteWorker.Delete(data);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }

            #region Logging
            if (!result)
            {
                LogInOut(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => result), result) + Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => data), data));
            }
            #endregion

            return result;
        }

        public bool DeleteList(List<ACS_ROLE> listData)
        {
            bool result = false;

            #region Logging Input Data
            try
            {
                Input = Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => listData), listData);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
            #endregion

            try
            {
                result = DeleteWorker.DeleteList(listData);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }

            #region Logging
            if (!result)
            {
                LogInOut(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => result), result) + Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => listData), listData));
            }
            #endregion

            return result;
        }

        public bool Truncate(ACS_ROLE data)
        {
            bool result = false;
            
            #region Logging Input Data
            try
            {
                Input = Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => data), data);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
            #endregion

            try
            {
                result = TruncateWorker.Truncate(data);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }

            #region Logging
            if (!result)
            {
                LogInOut(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => result), result) + Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => data), data));
            }
            #endregion

            return result;
        }

        public bool TruncateList(List<ACS_ROLE> listData)
        {
            bool result = false;

            #region Logging Input Data
            try
            {
                Input = Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => listData), listData);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
            #endregion

            try
            {
                result = TruncateWorker.TruncateList(listData);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }

            #region Logging
            if (!result)
            {
                LogInOut(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => result), result) + Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => listData), listData));
            }
            #endregion

            return result;
        }

        public List<ACS_ROLE> Get(AcsRoleSO search, CommonParam param)
        {
            List<ACS_ROLE> result = new List<ACS_ROLE>();

            #region Logging Input Data
            try
            {
                Input = Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => param), param) + Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => search), search);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
            #endregion

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

            #region Logging
            if (param.HasException)
            {
                LogInOut();
            }
            #endregion

            return result;
        }

        public ACS_ROLE GetById(long id, AcsRoleSO search)
        {
            ACS_ROLE result = null;

            #region Logging Input Data
            try
            {
                Input = Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => id), id) + Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => search), search);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
            #endregion

            try
            {
                result = GetWorker.GetById(id, search);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = null;
                LogInOut();
            }

            return result;
        }

        public bool IsUnLock(long id)
        {
            #region Logging Input Data
            try
            {
                Input = Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => id), id);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
            #endregion

            try
            {
                return CheckWorker.IsUnLock(id);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                LogInOut();
                throw;
            }
        }
    }
}
