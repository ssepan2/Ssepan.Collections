using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ssepan.Collections
{
    /// <summary>
    /// Comparer wrapper from lambda that can be used where only delegates are accepted (i.e. .Except(), etc.)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EqualityComparerOfT<T>: IEqualityComparer<T>
    {
        private readonly Func<T, T, Boolean> _comparer;

        public EqualityComparerOfT(Func<T, T, Boolean> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException("comparer");

            _comparer = comparer;
        }

        public Boolean Equals(T x, T y)
        {
            return _comparer(x, y);
        }

        public Int32 GetHashCode(T obj)
        {
            return obj.ToString().ToLower().GetHashCode();
        }
    }
}
