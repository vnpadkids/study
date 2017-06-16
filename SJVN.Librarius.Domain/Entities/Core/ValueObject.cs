using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJVN.Librarius.Domain.Entities
{
    /// <summary>
    /// Represent an object as a value object of Domain-Driven Design.
    /// Several parts of code is from <see cref="http://enterprisecraftsmanship.com/2015/01/03/value-objects-explained/"/> 
    /// </summary>
    public abstract class ValueObject<T>
        where T : ValueObject<T>
    {
        public override bool Equals(object compareTo)
        {
            var valueObject = compareTo as T;

            if (ReferenceEquals(valueObject, null))
                return false;

            return InternalEquals(valueObject);
        }

        protected abstract bool InternalEquals(T compareTo);

        public override int GetHashCode()
        {
            return InternalGetHashCode();
        }

        protected abstract int InternalGetHashCode();

        public static bool operator ==(ValueObject<T> left, ValueObject<T> right)
        {
            if (ReferenceEquals(left, null) && ReferenceEquals(right, null))
                return true;

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                return false;

            return left.Equals(right);
        }

        public static bool operator !=(ValueObject<T> left, ValueObject<T> right)
        {
            return !(left == right);
        }
    }
}
