using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Ssepan.Utility;
using System.Diagnostics;
using System.Reflection;

namespace Ssepan.Collections
{

    /// <summary>
    /// Extension to List(Of T) />
    /// </summary>
    public static class ListOfTExtension
    {
        public enum ShiftTypes
        {
            Promote,
            Demote
        }

        #region BindingList<T>
        /// <summary>
        /// Shift TItem item in TList list
        /// </summary>
        /// <typeparam name="TList"></typeparam>
        /// <typeparam name="TItem"></typeparam>
        /// <typeparam name="TItemSwap"></typeparam>
        /// <param name="items"></param>
        /// <param name="shiftType"></param>
        /// <param name="itemMatch"></param>
        /// <param name="swapItemMatch"></param>
        public static void ShiftListItem<TList, TItem>
        (
            this TList items, 
            ShiftTypes shiftType, 
            Predicate<TItem> itemMatch,
            Func<TItem, TItem, Boolean> swapItemMatch
        )
            where TList : BindingList<TItem>
        {
            try
            {
                Int32 searchOffset = default(Int32);
                Int32 searchLimit = default(Int32);
                Boolean isFoundSwapItem = default(Boolean);
                Boolean isAtEnd = default(Boolean);
                TItem item = default(TItem);
                TItem tempItem = default(TItem);
                Int32 itemIndex = default(Int32);
                Int32 swapItemIndex = default(Int32);

                //define direction
                if (shiftType == ShiftTypes.Promote)
                {
                    searchOffset = -1;
                    searchLimit = 0;
                }
                else if (shiftType == ShiftTypes.Demote)
                {
                    searchOffset = 1;
                    searchLimit = items.Count - 1;
                }

                //find index with which to swap
                item = items.Find(itemMatch); //item => item.Property == propertyValue
                itemIndex = items.IndexOf(item);
                swapItemIndex = itemIndex;
                isAtEnd = (itemIndex == searchLimit);
                while (!isFoundSwapItem && !isAtEnd)
                {
                    swapItemIndex += searchOffset;
                    
                    isFoundSwapItem = swapItemMatch(item, items[swapItemIndex]); //evaluate lambda, or true (to swap with any item, unconditionally)
                    isAtEnd = (swapItemIndex == searchLimit);
                }

                //swap
                if (isFoundSwapItem)
                {
                    tempItem = items[swapItemIndex];
                    items[swapItemIndex] = items[itemIndex];
                    items[itemIndex] = tempItem;
                    tempItem = default(TItem);
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                    
                throw;
            }
        }
        #endregion BindingList<T>

        #region EquatableList<T>
        /// <summary>
        /// Return EquatableList Of T from supplied List Of T.
        /// </summary>
        public static EquatableList<T> ToEquatableList<T>(this List<T> list) 
            where T : IEquatable<T>
		{
            EquatableList<T> returnValue = new EquatableList<T>();
			foreach (T item in list) 
			{
				returnValue.Add(item);
			}
			return returnValue;
		}
        
        /// <summary>
        /// Return EquatableList Of T from supplied IEnumerable Of T.
        /// </summary>
        public static EquatableList<T> ToEquatableList<T>(this IEnumerable<T> list) 
            where T : IEquatable<T>
		{
            EquatableList<T> returnValue = new EquatableList<T>();
			foreach (T item in list) 
			{
				returnValue.Add(item);
			}
			return returnValue;
        }
        #endregion EquatableList<T>

        #region EquatableBindingList<T>
        /// <summary>
        /// Return EquatableBindingList Of T from supplied List Of T.
        /// </summary>
		public static EquatableBindingList<T> ToEquatableBindingList<T>(this List<T> list) 
            where T : IEquatable<T>
		{ 
			EquatableBindingList<T> returnValue = new EquatableBindingList<T>();
			foreach (T item in list) 
			{
				returnValue.Add(item);
			}
			return returnValue;
		}
        
        /// <summary>
        /// Return EquatableBindingList Of T from supplied IEnumerable Of T.
        /// </summary>
        public static EquatableBindingList<T> ToEquatableBindingList<T>(this IEnumerable<T> list) 
            where T : IEquatable<T>
		{ 
			EquatableBindingList<T> returnValue = new EquatableBindingList<T>();
			foreach (T item in list) 
			{
				returnValue.Add(item);
			}
			return returnValue;
		}
        #endregion EquatableBindingList<T>

        #region OrderedEquatableList<T>
        /// <summary>
        /// Return OrderedEquatableList Of T from supplied List Of T.
        /// </summary>
        public static OrderedEquatableList<T> ToOrderedEquatableList<T>(this List<T> list) 
            where T : IEquatable<T>
		{
            OrderedEquatableList<T> returnValue = new OrderedEquatableList<T>();
			foreach (T item in list) 
			{
				returnValue.Add(item);
			}
			return returnValue;
		}
        
        /// <summary>
        /// Return OrderedEquatableList Of T from supplied IEnumerable Of T.
        /// </summary>
        public static OrderedEquatableList<T> ToOrderedEquatableList<T>(this IEnumerable<T> list) 
            where T : IEquatable<T>
		{
            OrderedEquatableList<T> returnValue = new OrderedEquatableList<T>();
			foreach (T item in list) 
			{
				returnValue.Add(item);
			}
			return returnValue;
        }
        #endregion OrderedEquatableList<T>

        #region OrderedEquatableBindingList<T>
        /// <summary>
        /// Return OrderedEquatableBindingList Of T from supplied List Of T.
        /// </summary>
        public static OrderedEquatableBindingList<T> ToOrderedEquatableBindingList<T>(this List<T> list) 
            where T : IEquatable<T>
		{
            OrderedEquatableBindingList<T> returnValue = new OrderedEquatableBindingList<T>();
			foreach (T item in list) 
			{
				returnValue.Add(item);
			}
			return returnValue;
		}
        
        /// <summary>
        /// Return OrderedEquatableBindingList Of T from supplied IEnumerable Of T.
        /// </summary>
        public static OrderedEquatableBindingList<T> ToOrderedEquatableBindingList<T>(this IEnumerable<T> list) 
            where T : IEquatable<T>
		{
            OrderedEquatableBindingList<T> returnValue = new OrderedEquatableBindingList<T>();
			foreach (T item in list) 
			{
				returnValue.Add(item);
			}
			return returnValue;
        }
        #endregion OrderedEquatableBindingList<T>
    }

}