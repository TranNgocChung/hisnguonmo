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
namespace ACS.LibraryEventLog
{
    public partial class EventLog
    {
        public LanguageEnum Language;
        public string message;
        public Enum EnumBC;

        private static string defaultViEventLog = "[].";
        private static string defaultEnEventLog = "[].";

        public EventLog(LanguageEnum language, Enum en)
        {
            Language = language;
            EnumBC = en;
            message = GetEventLog(en);
        }

        public enum LanguageEnum
        {
            VI,
            EN,
        }

        public class LanguageCode
        {
            public const string VI = "VI";
            public const string EN = "EN";
        }

        public static string GetLanguageName(LanguageEnum type)
        {
            string result = LanguageCode.VI;
            switch (type)
            {
                case LanguageEnum.VI:
                    result = LanguageCode.VI;
                    break;
                case LanguageEnum.EN:
                    result = LanguageCode.EN;
                    break;
                default:
                    result = LanguageCode.VI;
                    break;
            }
            return result;
        }

        public static LanguageEnum GetLanguageEnum(string languageName)
        {
            LanguageEnum result = LanguageEnum.VI;
            switch (languageName)
            {
                case LanguageCode.VI:
                    result = LanguageEnum.VI;
                    break;
                case LanguageCode.EN:
                    result = LanguageEnum.EN;
                    break;
                default:
                    result = LanguageEnum.VI;
                    break;
            }
            return result;
        }
    }
}
