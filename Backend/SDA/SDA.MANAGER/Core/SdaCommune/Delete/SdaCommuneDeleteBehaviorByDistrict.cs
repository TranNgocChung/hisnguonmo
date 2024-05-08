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
using SDA.EFMODEL.DataModels;
using SDA.MANAGER.Base;
using SDA.MANAGER.Core.Check;
using Inventec.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SDA.MANAGER.Core.SdaCommune.Delete
{
    class SdaCommuneDeleteBehaviorByDistrict : BeanObjectBase, ISdaCommuneDelete
    {
        List<long> entity;

        internal SdaCommuneDeleteBehaviorByDistrict(CommonParam param, List<long> data)
            : base(param)
        {
            entity = data;
        }

        bool ISdaCommuneDelete.Run()
        {
            bool result = false;
            try
            {
                if (Check())
                {
                    List<SDA_COMMUNE> listRaw = new SdaCommuneBO().Get<List<SDA_COMMUNE>>(entity);
                    if (listRaw != null && listRaw.Count > 0)
                    {
                        List<long> ids = listRaw.Select(o => o.ID).ToList();
                        result = DAOWorker.SdaCommuneDAO.TruncateList(listRaw);
                    }
                    else
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                result = false;
            }
            return result;
        }

        bool Check()
        {
            bool result = true;
            try
            {
                if (entity == null || entity.Count == 0)
                {
                    throw new ArgumentNullException("entity is null");
                }
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
