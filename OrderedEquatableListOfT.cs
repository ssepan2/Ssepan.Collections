﻿using System;
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
    /// This class checks the content and arrangement of the list.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OrderedEquatableList<T> :
        List<T>,                        //start with List Of T
        IEquatable<OrderedEquatableList<T>>    //implements IEquatable
        where T : IEquatable<T>         //list contains items that implement IEquatable
    {
        #region IEquatable<T> Members

        /// <summary>
        /// Test for equality of contents *and arrangement* of this list versus another EquatableList Of T.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Boolean Equals(OrderedEquatableList<T> other)  
        {
            Boolean returnValue = true;
            Int32 thisIndex = default(Int32);
            Int32 otherIndex = default(Int32);

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
                        thisIndex = this.IndexOf(item);
                        otherIndex = other.IndexOf(item);
                        if (thisIndex != otherIndex)
                        {
                            //items missing or in different positions
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
