using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utilitive.Internal
{
    internal static class PropertyInfoInternal
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj">Source object</param>
        /// <param name="index">Index</param>
        /// <returns>The property value or null</returns>
#nullable enable
        public static object? GetValueOrNull(this PropertyInfo propertyInfo, object? obj, object?[]? index)
        {
            try
            {
                return propertyInfo.GetValue(obj, index);
            }
            catch (Exception) { return null; }
        }
#nullable disable
    }
}
