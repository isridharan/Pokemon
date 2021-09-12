using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Infrastructure
{
    public abstract class Entity<T>
    {
        public virtual T Id { get; set; }

        // Equals to check object instance is same or not
        public override bool Equals(object obj)
        {
            var x = obj as Entity<T>;
            if (x == null) return false;
            if (IsTransient() && x.IsTransient()) return ReferenceEquals(this, x);
            return (Id.Equals(x.Id));
        }

        public override int GetHashCode()
        {
            if (IsTransient())
            {
                return base.GetHashCode();
            }
            return Id.GetHashCode();
        }

        /// Determines whether this instance is transient.
        /// </summary>
        public virtual bool IsTransient()
        {
            return Id == null || Id.Equals(default(T));
        }

        public abstract bool IsValid();
    }

}

