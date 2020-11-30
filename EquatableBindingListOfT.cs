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
    /// Subclass of BindingList Of T that implements IEquatable, and contains items that implement IEquatable.
    /// This class checks only the content of the list, not the arrangement.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable()]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class EquatableBindingList<T> :
        BindingList<T>,                         //start with BindingList Of T
        IEquatable<EquatableBindingList<T>>     //implements IEquatable
        where T : IEquatable<T> 
    {
        #region IEquatable<T> Members

        /// <summary>
        /// Test for equality of contents of this list versus another EquatableBindingList Of T, but not the arrangement.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Boolean Equals(EquatableBindingList<T> other)  
        {
            Boolean returnValue = true;
            try
            {
                if (this.Count != other.Count)
                {
                    //different number of items
                    returnValue = false;
                }
                else
                { 
                    foreach (T item in this)
                    {
                        if (!other.Contains(item))
                        {
                            //different items
                            returnValue = false;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                    
                returnValue = false;
            }
            return returnValue;
        }

        #endregion
    }
}
