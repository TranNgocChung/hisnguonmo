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
using ACS.MANAGER.Base;
using Inventec.Core;
using System;
using System.Linq;

namespace ACS.MANAGER.Core.AcsCredentialData.Get.Ev
{
    class AcsCredentialDataGetEvBehaviorByTokenManagerFilter : BeanObjectBase, IAcsCredentialDataGetEv
    {
        AcsCredentialDataFilterForTokenManager entity;

        internal AcsCredentialDataGetEvBehaviorByTokenManagerFilter(CommonParam param, AcsCredentialDataFilterForTokenManager filter)
            : base(param)
        {
            entity = filter;
        }

        ACS_CREDENTIAL_DATA IAcsCredentialDataGetEv.Run()
        {
            try
            {
                AcsCredentialDataFilterQuery filterQuery = new AcsCredentialDataFilterQuery();
                filterQuery.RESOURCE_SYSTEM_CODE = entity.RESOURCE_SYSTEM_CODE;
                filterQuery.TOKEN_CODE = entity.TOKEN_CODE;
                filterQuery.DATA_KEY = entity.DATA_KEY;
                filterQuery.IS_ACTIVE = entity.IS_ACTIVE;

                return DAOWorker.AcsCredentialDataDAO.Get(filterQuery.Query(), param).SingleOrDefault();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }
    }
}
