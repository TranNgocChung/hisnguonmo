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
using SDA.MANAGER.Core.SdaLanguage.EventLog;
using Inventec.Core;
using System;
using System.Collections.Generic;

namespace SDA.MANAGER.Core.SdaLanguage.Update
{
    class SdaLanguageUpdateBehaviorEv : BeanObjectBase, ISdaLanguageUpdate
    {
        SDA_LANGUAGE current;
        SDA_LANGUAGE entity;
        List<SDA_LANGUAGE> list;

        internal SdaLanguageUpdateBehaviorEv(CommonParam param, SDA_LANGUAGE data)
            : base(param)
        {
            entity = data;
        }

        public SdaLanguageUpdateBehaviorEv(CommonParam param, List<SDA_LANGUAGE> data)
            : base(param)
        {
            list = data;
        }

        bool ISdaLanguageUpdate.Run()
        {
            bool result = false;
            try
            {
                if (IsNotNull(entity))
                {
                    result = Check() && DAOWorker.SdaLanguageDAO.Update(entity);
                    if (result)
                    {
                        SdaLanguageEventLogUpdate.Log(current, entity);
                    }
                }
                else if (IsNotNullOrEmpty(list))
                {
                    result = CheckList() && DAOWorker.SdaLanguageDAO.UpdateList(list);
                    if (result)
                    {
                        SdaLanguageEventLogUpdate.Log(current, list);
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

        bool CheckList()
        {
            bool result = true;
            try
            {
                result = result && SdaLanguageCheckVerifyValidData.Verify(param, list);
                result = result && SdaLanguageCheckVerifyIsUnlock.Verify(param, list);
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
                result = result && SdaLanguageCheckVerifyValidData.Verify(param, entity);
                result = result && SdaLanguageCheckVerifyIsUnlock.Verify(param, entity.ID, ref current);
                result = result && SdaLanguageCheckVerifyExistsCode.Verify(param, entity.LANGUAGE_CODE, entity.ID);
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
