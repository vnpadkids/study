using System;
using System.Data.Entity.Core.Objects;

namespace SJVN.Librarius.Domain.Entities
{
    /// <summary>
    /// Represent object as an entity in Domain-Driven Design.
    /// This can be found originally <see cref="http://enterprisecraftsmanship.com/2014/11/08/domain-object-base-class/">HERE</see>.
    /// </summary>
    public abstract class Entity : IEquatable<object>
    {
        /// <summary>
        /// Identity of entity
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(compareTo, null))
                return false;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (GetRealType() != compareTo.GetRealType())
                return false;

            if (!IsTransient() && !compareTo.IsTransient() && Id == compareTo.Id)
                return true;

            return false;
        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (ReferenceEquals(left, null) && ReferenceEquals(right, null))
                return true;

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                return false;
            return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Return hash code for this string
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (GetRealType().ToString() + Id).GetHashCode();
        }

        /// <summary>
        /// Determines whether this object is transient or not
        /// </summary>
        /// <returns></returns>
        public virtual bool IsTransient()
        {
            return Id == 0;
        }

        /// <summary>
        /// Determines the real type which EntityFramework use Proxy Type for mapping
        /// </summary>
        /// <returns></returns>
        protected virtual Type GetRealType()
        {
            return ObjectContext.GetObjectType(GetType());
        }
    }
}