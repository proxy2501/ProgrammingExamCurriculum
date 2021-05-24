using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPoolPattern
{
    public class BlockPool : ObjectPool<Block>
    {
        private Random rnd = new Random();

        /// <summary>
        /// Creates a BlockPool of the specified size.
        /// </summary>
        /// <param name="size">Max number of inactive pool objects at a given time.</param>
        public BlockPool(int size) : base(size)
        {
        }

        /// <summary>
        /// Gets the current number of objects in the pool.
        /// </summary>
        /// <returns>The number of objects in the pool.</returns>
        public int InactiveCount()
        {
            return inactive.Count;
        }

        /// <summary>
        /// Releases the pool object back into the pool.
        /// </summary>
        /// <param name="item">A pool object to be released back into the pool.</param>
        public override void Release(Block item)
        {
            base.Release(item);
            Program.DestroyedBlocks.Add(item);
        }


        /// <summary>
        /// Creates a new Block object.
        /// </summary>
        /// <returns>A new Block object.</returns>
        protected override Block Create()
        {
            return new Block(rnd.Next(0, Program.PlayFieldWidth - 1), 0);
        }

        /// <summary>
        /// Resets Block object's data and clears all references.
        /// </summary>
        /// <param name="item">The Block object to be reset.</param>
        protected override void Reset(Block item)
        {
            item.X = rnd.Next(0, Program.PlayFieldWidth - 1);
            item.Y = 0;
        }
    }
}