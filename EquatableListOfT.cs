using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ssepan.Utility;
using System.Diagnostics;
using System.Reflection;

namespace Ssepan.Collections
{
    /// <summary>
    /// Subclass of List Of T that implements IEquatable, and contains items that implement IEquatable.
    /// This class checks only the content of the list, not the arrangement.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EquatableList<T> :
        List<T>,                        //start with List Of T
        IEquatable<EquatableList<T>>    //implements IEquatable
        where T : IEquatable<T>         //list contains items that implement IEquatable
    {
        #region IEquatable<T> Members

        /// <summary>
        /// Test for equality of contents of this list versus another EquatableList Of T, but not the arrangement.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Boolean Equals(EquatableList<T> other)  
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
