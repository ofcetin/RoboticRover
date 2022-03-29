using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticRover.Core.Enum
{
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = false)]
    public class EnumKeyAttribute : Attribute
    {
        /// <summary>
        /// Key part of enum field
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="EnumKeyAttribute"/> class.
        /// </summary>
        /// <param name="key">The key to store in this attribute.
        /// </param>
        public EnumKeyAttribute(string key)
        {
            Key = key;
        }
    }
}
