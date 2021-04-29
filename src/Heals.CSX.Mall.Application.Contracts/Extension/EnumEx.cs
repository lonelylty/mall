using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Heals.CSX.Mall
{
    public static class EnumEx
    {
        public static string GetDescription(this Enum item)
        {
            string empty = string.Empty;
            Type type = item.GetType();
            FieldInfo field = type.GetField(item.ToString());
            IEnumerable<DescriptionAttribute> source = from a in field.GetCustomAttributes(typeof(DescriptionAttribute), false)
                                                       where a is DescriptionAttribute
                                                       select a as DescriptionAttribute;
            if (source.Any())
            {
                return source.First().Description;
            }
            return field.Name;
        }


        public static T GetAttribute<T>(this Enum item) where T : class
        {
            string empty = string.Empty;
            Type type = item.GetType();
            FieldInfo field = type.GetField(item.ToString());
            IEnumerable<T> source = from a in field.GetCustomAttributes(typeof(T), false)
                                    where a is T
                                    select a as T;
            return source.FirstOrDefault();
        }


        public static T GetEnumByEnumString<T>(string enumSr) where T : class
        {
            object enumItem = null;
            foreach (var item in Enum.GetValues(typeof(T)))
            {
                if (item.ToString().ToLower().Equals(enumSr.ToLower()))
                {
                    enumItem = item;
                    break;
                }

            }
            var tTypeValue = (T)Enum.Parse(typeof(T), enumItem?.ToString());
            return tTypeValue;
        }

        public static T GetEnumValueForString<T>(string eumStr)
        {
            object obj = null;
            foreach (var item in Enum.GetValues(typeof(T)))
            {
                if (!item.ToString().ToLower().Equals(eumStr.ToLower())) continue;
                obj = item;
                break;
            }
            var tTypeValue = (T)Enum.Parse(typeof(T), obj?.ToString());
            return tTypeValue;
        }
    }
}
