using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Data
{
    /// <summary>
    /// Base class for entities
    /// </summary>
    public abstract partial class BaseEntity<T> : IEquatable<T>
    {
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        public T Id { get; set; }


        public override bool Equals(object obj)
        {
            return Equals(obj as BaseEntity<T>);
        }

        public bool Equals(T other)
        {
            return Equals(Id, other);
        }

        public virtual bool Equals(BaseEntity<T> other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (!IsTransient(this) &&
                !IsTransient(other) &&
                Equals(Id, other.Id))
            {
                var otherType = other.GetUnproxiedType();
                var thisType = GetUnproxiedType();
                return thisType.IsAssignableFrom(otherType) ||
                        otherType.IsAssignableFrom(thisType);
            }

            return false;
        }

        public override int GetHashCode()
        {
            if (Equals(Id, default(int)))
                return base.GetHashCode();
            return Id.GetHashCode();
        }

        public static bool operator ==(BaseEntity<T> x, BaseEntity<T> y)
        {
            return x.Equals(x);
        }

        public static bool operator !=(BaseEntity<T> x, BaseEntity<T> y)
        {
            return !(x == y);
        }

        private static bool IsTransient(BaseEntity<T> obj)
        {
            return obj != null && Equals(obj.Id, default(int));
        }

        private Type GetUnproxiedType()
        {
            return GetType();
        }
    }
}
