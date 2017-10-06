namespace ConsoleApplication1
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed class MemoryPiler<T> : IPiler<T>
    {
        /// <summary>
        /// The different piles that this <see cref="IPiler{T}"/> can move items between
        /// </summary>
        private readonly IReadOnlyList<Stack<T>> piles;

        /// <summary>
        /// Creates a new instance of the <see cref="MemoryPiler{T}"/> class
        /// </summary>
        /// <param name="items">The items that should be initialized into their corresponding piles based on index</param>
        public MemoryPiler(IEnumerable<T>[] items)
        {
            this.piles = items.Select(pile => new Stack<T>(pile.Reverse())).ToList();
        }

        public void Move(int from, int to)
        {
            this.piles[to].Push(piles[from].Pop());
        }

        public T ReadTop(int pile)
        {
            return this.piles[pile].Peek();
        }
    }
}
