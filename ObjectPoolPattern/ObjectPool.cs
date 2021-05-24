using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPoolPattern
{
    public abstract class ObjectPool<T>
    {
        protected Stack<T> inactive = new Stack<T>(); // Stack of inactive pool objects.

        /// <summary>
        /// Max number of inactive pool objects at a given time.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Creates an object pool of the specified size.
        /// </summary>
        /// <param name="size">Max number of inactive pool objects at a given time.</param>
        public ObjectPool(int size)
        {
            Size = size;
        }

        /// <summary>
        /// Gets an inactive pool object from the object pool.
        /// If no inactive objects, returns a new object.
        /// </summary>
        /// <returns>A pool object.</returns>
        public virtual T Get()
        {
            return inactive.Count > 0 ? inactive.Pop() : Create();
        }

        /// <summary>
        /// Releases the pool object back into the pool.
        /// </summary>
        /// <param name="item">A pool object to be released back into the pool.</param>
        public virtual void Release(T item)
        {
            Reset(item);

            if (inactive.Count < Size)
                inactive.Push(item);
        }

        /// <summary>
        /// Creates a new pool object.
        /// </summary>
        /// <returns>A new pool object.</returns>
        protected abstract T Create();

        /// <summary>
        /// Resets item's data and clears all references.
        /// </summary>
        /// <param name="item">The pool object to be reset.</param>
        protected abstract void Reset(T item);
    }
}
