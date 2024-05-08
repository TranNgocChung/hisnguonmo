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
using Inventec.Common.Repository;
using SDA.DTO.Base;
using SDA.EFMODEL.DataModels;
using System;
using System.Reflection;

namespace SDA.DTO.TransferObject
{
    public class EvSdaMessageBroadcastDTO : SDA_EV_SDA_MESSAGE_BROADCAST, IDTO<EvSdaMessageBroadcastDTO, SDA_EV_SDA_MESSAGE_BROADCAST>
    {
        public EvSdaMessageBroadcastDTO()
        {
            IS_ACTIVE = ((IS_ACTIVE == null) ? (short)1 : IS_ACTIVE);
            IS_DELETE = ((IS_DELETE == null) ? (short)0 : IS_DELETE);
        }
        
        public void ProcessNullActiveDelete(EvSdaMessageBroadcastDTO data)
        {
            try
            {
                if (data != null)
                {
                    data.IS_ACTIVE = ((data.IS_ACTIVE == null) ? (short)1 : data.IS_ACTIVE);
                    data.IS_DELETE = ((data.IS_DELETE == null) ? (short)0 : data.IS_DELETE);
                }
            }
            catch (Exception)
            {
                
            }
        }

        public EvSdaMessageBroadcastDTO CreateDTO(SDA_EV_SDA_MESSAGE_BROADCAST raw)
        {
            try
            {
                if (raw != null)
                {
                    EvSdaMessageBroadcastDTO dto = new EvSdaMessageBroadcastDTO();
                    PropertyInfo[] pi = Properties.Get<SDA_EV_SDA_MESSAGE_BROADCAST>();
                    foreach (var item in pi)
                    {
                        item.SetValue(dto, (item.GetValue(raw)));
                    }
                    return dto;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public SDA_EV_SDA_MESSAGE_BROADCAST CreateRaw(EvSdaMessageBroadcastDTO data)
        {
            try
            {
                if (data != null)
                {
                    SDA_EV_SDA_MESSAGE_BROADCAST raw = new SDA_EV_SDA_MESSAGE_BROADCAST();
                    PropertyInfo[] pi = Properties.Get<SDA_EV_SDA_MESSAGE_BROADCAST>();
                    foreach (var item in pi)
                    {
                        item.SetValue(raw, (item.GetValue(data)));
                    }
                    raw.APP_CREATOR = DTOConstant.APP_NAME;
                    raw.APP_MODIFIER = raw.APP_CREATOR;
                    raw.CREATOR = Inventec.Token.Manager.GetLoginname();
                    raw.MODIFIER = Inventec.Token.Manager.GetLoginname();
                    raw.GROUP_CODE = Inventec.Token.Manager.GetGroupCode();
                    return raw;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateDTO(SDA_EV_SDA_MESSAGE_BROADCAST raw, EvSdaMessageBroadcastDTO data)
        {
            try
            {
                #region validate param
                if (raw == null) throw new ArgumentNullException("raw");
                if (data == null) throw new ArgumentNullException("data");
                #endregion

                PropertyInfo[] pi = Properties.Get<SDA_EV_SDA_MESSAGE_BROADCAST>();
                foreach (var item in pi)
                {
                    item.SetValue(data, (item.GetValue(raw)));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateRaw(EvSdaMessageBroadcastDTO data, SDA_EV_SDA_MESSAGE_BROADCAST raw)
        {
            try
            {
                #region validate param
                if (raw == null) throw new ArgumentNullException("raw");
                if (data == null) throw new ArgumentNullException("data");
                #endregion
                
                if (data != null)
                {
                    SetNotChangeField(data, raw);
                    PropertyInfo[] pi = Properties.Get<SDA_EV_SDA_MESSAGE_BROADCAST>();
                    foreach (var item in pi)
                    {
                        item.SetValue(raw, (item.GetValue(data)));
                    }
                    raw.APP_MODIFIER = DTOConstant.APP_NAME;
                    raw.MODIFIER = Inventec.Token.Manager.GetLoginname();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        private void SetNotChangeField(EvSdaMessageBroadcastDTO data, SDA_EV_SDA_MESSAGE_BROADCAST raw)
        {
            try
            {
                #region validate param
                if (data == null) throw new ArgumentNullException("data");
                if (raw == null) throw new ArgumentNullException("raw");
                #endregion

                data.CREATOR = raw.CREATOR;
                data.APP_CREATOR = raw.APP_CREATOR;
                data.CREATE_TIME = raw.CREATE_TIME;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
