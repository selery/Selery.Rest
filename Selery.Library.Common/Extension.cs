using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Selery.Library.Common
{
    public static class Extension
    {
        /// <summary>
        /// Si el parametro source es nulo o si es el default de su tipo o si es igua al parametro nullComparisonValue entonces regresa null, sino  regresa el mismo valor de source
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="source"></param>
        /// <param name="nullComparisonValue"></param>
        /// <returns></returns>
        /// <remarks>
        /// Nota: 
        /// El default de un int? no es cero sino NULL int i?=0; i.ToNull(); regresaria 0
        /// Habria que hacer esto para que regrese null i.ToNull((int?)0)        
        /// </remarks>
        public static Object ToNull<T, K>(this T source, K nullComparisonValue)
        {
            Object retVal = source;

            if (source == null)
                retVal = null;
            else
                if (nullComparisonValue != null)
                {
                    if (source.Equals(default(T)) || source.Equals(nullComparisonValue))
                        retVal = null;
                }
                else
                    if (source.Equals(default(T)))
                        retVal = null;
            return retVal;
        }

        /// <summary>
        /// Si el parametro source es nulo o si es el default de su tipo entonces regresa DBNull.Value, sino  regresa el mismo valor de source
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Object ToNull<T>(this T source)
        {
           return ToNull<T,string>(source, null);
        }

              
        public static T ReplaceNull<T>(this Object source)
        {
            Object retValue = source;
            if (source==null)
                retValue = default(T);
            else
                if (source.Equals(null))
                    retValue = default(T);

            return (T)retValue;
        }

        /// <summary>
        /// Regresa cero si la variable evaluada en s es string vacio, sino regrea el string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// <remarks>
        /// </remarks>
        public static Object ReplaceEmptySting(this string s)
        {
            Object retVal;
            if (string.IsNullOrEmpty(s))
                retVal = 0;
            else
                retVal = s;

            return retVal;
        }

        /// <summary>
        /// Regresa string vacio la variable evaluada es el default de su mismo tipo
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// <remarks>
        /// </remarks>
        public static Object ReplaceDefault<T>(this T source)
        {
            Object retVal;

            if (source.Equals(default(T)))
                retVal = string.Empty;
            else
                retVal = source;

            return retVal;
        }

    }
}
