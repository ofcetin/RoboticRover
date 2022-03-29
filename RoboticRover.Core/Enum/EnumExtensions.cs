using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RoboticRover.Core.Enum
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Using Key collection to hold an array by child type (full name of enum).
        /// This way the Keys only need to load once.
        /// Each enum will have its own array in the dictionary
        /// </summary>
        private static readonly Dictionary<Type, object> keys = new Dictionary<Type, object>();

        /// <summary>
        /// Gets the <see cref="EnumKeyAttribute" /> of an <see cref="Enum" />
        /// type value.
        /// </summary>
        /// <param name="value">The <see cref="Enum" /> type value.</param>
        /// <returns>A string containing the text of the
        /// <see cref="EnumKeyAttribute"/>.</returns>
        public static string GetKey<T>(this T value) where T : struct
        {
            Dictionary<string, MappedEnum<T>> enumDict = GetKeyDictionary<T>();

            if (enumDict == null)
            {
                return null;
            }

            return enumDict[value.ToString()].Key;

        }

        /// <summary>
        /// For an enum, retrieve its Dictionary of Key's
        /// Uses full name of the enum.
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, MappedEnum<T>> GetKeyDictionary<T>() where T : struct
        {
            Type enumType = typeof(T);
            if (!keys.TryGetValue(enumType, out object enumKeys))
            {
                if (!keys.TryGetValue(enumType, out enumKeys))
                {
                    enumKeys = GenerateEnumDictionary<T>(enumType);
                    keys.Add(enumType, enumKeys);
                }
            }

            return (Dictionary<string, MappedEnum<T>>)enumKeys;
        }

        private static Dictionary<string, MappedEnum<T>> GenerateEnumDictionary<T>(Type enumType) where T : struct
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException($"Type provided must be an Enum: {enumType.FullName}", "enumType");
            }

            Dictionary<string, MappedEnum<T>> enumDict = new Dictionary<string, MappedEnum<T>>();

            const string fieldValueName = "value__";
            foreach (FieldInfo field in enumType.GetFields())
            {
                if (field.Name == fieldValueName)
                {
                    continue;
                }

                MappedEnum<T> mappedEnumByKey = new MappedEnum<T>();

                var attributes = (EnumKeyAttribute[])
                                            field.GetCustomAttributes(typeof(EnumKeyAttribute), false);

                if (attributes != null && attributes.Length > 0)
                {
                    mappedEnumByKey.Key = attributes[0].Key;
                    mappedEnumByKey.Value = System.Enum.Parse<T>(field.Name);
                }
                else
                {
                    mappedEnumByKey.Key = field.Name;
                    mappedEnumByKey.Value = System.Enum.Parse<T>(field.Name);
                }

                enumDict[field.Name] = mappedEnumByKey;
                enumDict[mappedEnumByKey.Key] = mappedEnumByKey;
            }

            return enumDict;
        }


        /// <summary>
        /// Returns an enum using stringName to make the enum.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stringName"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static T EnumParse<T>(this string stringName, bool ignoreCase = true) where T : struct
        {
            if (string.IsNullOrEmpty(stringName))
            {
                throw new ArgumentNullException("stringName", $"Enum: {typeof(T).FullName} stringName is null or empty");
            }

            stringName = stringName.Trim();

            if (stringName.Length == 0)
            {
                throw new ArgumentException($"Must specify valid information for parsing Enum: { typeof(T).FullName } in the string", "stringName");
            }

            return System.Enum.Parse<T>(stringName, ignoreCase);
        }

        /// <summary>
        /// Uses the Key to return an enum.
        /// Key should not have a space in the front or back
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="ignoreLeadingTrailingSpaces"></param>
        /// <returns></returns>
        public static T EnumParseKey<T>(this string key, bool ignoreLeadingTrailingSpaces = false) where T : struct
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key", $"Enum: {typeof(T).FullName} key is null or empty");
            }

            if (!ignoreLeadingTrailingSpaces)
            {
                key = key.Trim();

                if (key.Length == 0)
                {
                    throw new ArgumentException($"Must specify valid information for parsing the key to the Enum: {typeof(T).FullName}'s value", "key");
                }
            }

            Dictionary<string, MappedEnum<T>> enumDict = GetKeyDictionary<T>();

            try
            {
                return enumDict[key].Value;
            }
            catch
            {
                throw new Exception($"Key:{key} not found in {typeof(T)}");
            }
        }
    }
}
