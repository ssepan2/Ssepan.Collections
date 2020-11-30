using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ssepan.Utility;
using System.Diagnostics;
using System.Reflection;

namespace Ssepan.Collections
{
    /// <summary>
    /// Extension to BindingList.
    /// Implements Find(Of T).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable()]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public static class BindingListOfTExtension
    {
        #region BindingList Members

        /// <summary>
        /// Implements missing Find(Predicate(Of T)), like List(Of T).Find(Predicate(Of T))
        /// </summary>
        /// <param name="itemMatch"></param>
        /// <returns></returns>
        public static T Find<T>(this BindingList<T> list, Predicate<T> match)
        {
            T returnValue = default(T);
            try
            {   //TODO: implement FindCore instead?
                returnValue = list.ToList<T>().Find(match);
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                        
            }
            return returnValue;
        }

        #endregion BindingList<T>
    }
}
