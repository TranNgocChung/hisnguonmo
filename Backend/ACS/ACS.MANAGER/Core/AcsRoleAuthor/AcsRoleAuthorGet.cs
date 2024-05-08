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
using ACS.EFMODEL.DataModels;
using ACS.MANAGER.Base;
using System;
using System.Collections.Generic;

namespace ACS.MANAGER.AcsRoleAuthor
{
    partial class AcsRoleAuthorGet : BusinessBase
    {
        internal AcsRoleAuthorGet()
            : base()
        {

        }

        internal AcsRoleAuthorGet(CommonParam paramGet)
            : base(paramGet)
        {

        }

        internal List<ACS_ROLE_AUTHOR> Get(AcsRoleAuthorFilterQuery filter)
        {
            try
            {
                return DAOWorker.AcsRoleAuthorDAO.Get(filter.Query(), param);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal ACS_ROLE_AUTHOR GetById(long id)
        {
            try
            {
                return GetById(id, new AcsRoleAuthorFilterQuery());
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal ACS_ROLE_AUTHOR GetById(long id, AcsRoleAuthorFilterQuery filter)
        {
            try
            {
                return DAOWorker.AcsRoleAuthorDAO.GetById(id, filter.Query());
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }
    }
}
