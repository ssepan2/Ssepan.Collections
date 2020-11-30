using System;
using System.Collections.Generic;
using System.Text;
using Ssepan.Utility;
using System.Diagnostics;
using System.Reflection;

namespace Ssepan.Collections
{
    public class KeyedStringComparer : IComparer<String>
    {
        // Create a field for the desired sort option
        private Int32 _keyIndex = 0;
        private Int32 _keyLength = -1;
        private Boolean _descending = false;

        /// <summary>
        /// Create a constructor that uses the default sort key instantiated in the comparer
        /// </summary>
        public KeyedStringComparer()
        {
        }
        /// <summary>
        /// Create a constructor that uses the default sort key instantiated in the comparer, and does a reverseable sort
        /// </summary>
        /// <param name="descending"></param>
        public KeyedStringComparer(Boolean descending)
        {
            _descending = descending;
        }
        /// <summary>
        /// Create a constructor that uses the passed sort key for the comparer
        /// </summary>
        /// <param name="keyIndex"></param>
        /// <param name="keyLength"></param>
        public KeyedStringComparer(Int32 keyIndex, Int32 keyLength)
        {
            _keyIndex = keyIndex;
            _keyLength = keyLength;
        }
        /// <summary>
        /// Create a constructor that uses the passed sort key for the comparer, and does a reverseable sort
        /// </summary>
        /// <param name="keyIndex"></param>
        /// <param name="keyLength"></param>
        /// <param name="descending"></param>
        public KeyedStringComparer(Int32 keyIndex, Int32 keyLength, Boolean descending)
        {
            _keyIndex = keyIndex;
            _keyLength = keyLength;
            _descending = descending;
        }
        #region IComparer<String> Members

        public Int32 Compare(String x, String y)
        {
            Int32 returnValue = default(Int32);
            try
            {

                if (_keyLength == -1)
                {
                    //TODO:implement default String comparison
                    throw new ArgumentException(String.Format("Invalid KeyLength: '{0}'\r\nDefault String comparison not implemented.", _keyLength));
                }
                else if (_keyLength > 0)
                {
                    returnValue = x.Substring(_keyIndex, _keyLength).CompareTo(y.Substring(_keyIndex, _keyLength));
                }
                else
                {
                    throw new ArgumentException(String.Format("Invalid KeyLength: '{0}'", _keyLength));
                }

                if (_descending)   
                {
                    returnValue = returnValue * -1;
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                        
            }
            return returnValue;
        }

        #endregion
    }
}
