using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticRover.Core.Enum
{
    /// <summary>
    /// Enum mapping for cache class
    /// </summary>
    /// <typeparam name="T">Enum Type</typeparam>
    public class MappedEnum<T> where T : struct
    {
        /// <summary>
        /// Key field of enum if it' present, otherwise enum field name
        /// </summary>
        public string Key { get; internal set; }
        /// <summary>
        /// Enumeration value
        /// </summary>
        public T Value { get; internal set; }

    }
}
