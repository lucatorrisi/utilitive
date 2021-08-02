using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utilitive.Internal
{
    internal static class EnumerableInternal
    {
        /// <summary>
        /// Gets a PropertyInfo IEnumerable castable to the given class
        /// </summary>
        /// <param name="propertyInfos"></param>
        /// <param name="sourceObject"></param>
        /// <returns>Collection of PropertyInfo</returns>
        public static IEnumerable<PropertyInfo> ToCastablePropertieInfosArray<T>(this IEnumerable<PropertyInfo> propertyInfos, object sourceObject)
        {
            var castablePropertyInfos = new List<PropertyInfo>();

            if (!propertyInfos.Any() && sourceObject == null)
                return castablePropertyInfos;

            foreach (var propInfo in propertyInfos)
            {
                if (propInfo.GetValueOrNull(sourceObject, null) is T)
                    castablePropertyInfos.Add(propInfo);
            }

            return castablePropertyInfos;
        }
    }
}
