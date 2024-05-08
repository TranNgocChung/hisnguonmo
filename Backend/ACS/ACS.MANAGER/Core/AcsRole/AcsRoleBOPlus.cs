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
using System;

namespace ACS.MANAGER.Core.AcsRole
{
    partial class AcsRoleBO : BusinessObjectBase
    {
        internal T GetRoleBase<T>(object data)
        {
            T result = default(T);
            try
            {
                IDelegacyT delegacy = new AcsRoleRoleBaseGet(param, data);
                result = delegacy.Execute<T>();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = default(T);
            }
            return result;
        }

        internal bool CreateWithRoleBase(object data)
        {
            bool result = false;
            try
            {
                IDelegacy delegacy = new AcsRoleRoleBaseMake(param, data);
                result = delegacy.Execute();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        internal bool UpdateWithRoleBase(object data)
        {
            bool result = false;
            try
            {
                IDelegacy delegacy = new AcsRoleRoleBaseUpdate(param, data);
                result = delegacy.Execute();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        internal bool DeleteWithRoleBase(object data)
        {
            bool result = false;
            try
            {
                IDelegacy delegacy = new AcsRoleRoleBaseDelete(param, data);
                result = delegacy.Execute();
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
