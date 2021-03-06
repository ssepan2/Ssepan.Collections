﻿using System;
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
    /// This class checks the content and arrangement of the list.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable()]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class OrderedEquatableBindingList<T> :
        BindingList<T>,                         //start with BindingList Of T
        IEquatable<OrderedEquatableBindingList<T>>     //implements IEquatable
        where T : IEquatable<T> 
    {
        #region IEquatable<T> Members

        /// <summary>
        /// Test for equality of contents *and arrangement* of this list versus another OrderedEquatableBindingList Of T.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Boolean Equals(OrderedEquatableBindingList<T> other)  
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
