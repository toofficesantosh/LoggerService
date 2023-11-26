using LoggerLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerLibrary.Utility
{
    public class UtilityManager
    {

        /// <summary>
        /// Convert the string list to enum List
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="stringList"></param>
        /// <returns></returns>
        public static List<TEnum> ConvertToEnumList<TEnum>(List<string> stringList) where TEnum : struct
        {
            List<TEnum> enumList = new List<TEnum>();

            foreach (var stringValue in stringList)
            {
                if (Enum.TryParse<TEnum>(stringValue, out var enumValue))
                {
                    enumList.Add(enumValue);
                }
                
            }

            return enumList;
        }
        
        /// <summary>
        /// Get the LogType for the string log type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static LogType GetLogType(string type)
        {
            LogType level = (LogType)Enum.Parse(typeof(LogType), type);
            return level;
        }
    }
}

