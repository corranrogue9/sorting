namespace ConsoleApplication1
{
    using System;

    /// <summary>
    /// Moves items around different piles
    /// </summary>
    /// <typeparam name="T">The type of items that are in piles</typeparam>
    /// <threadsafety instance="true"/>
    public interface IPiler<T>
    {
        /// <summary>
        /// Moves an item from pile <paramref name="from"/> to pile <paramref name="to"/>
        /// </summary>
        /// <param name="from">The pile to move an item from</param>
        /// <param name="to">The pile to move an item to</param>
        void Move(int from, int to);

        /// <summary>
        /// Gets the top item of <paramref name="pile"/> without moving it
        /// </summary>
        /// <param name="pile">The pile to get the top of</param>
        /// <returns>The item on top of pile <paramref name="pile"/></returns>
        /// <exception cref="InvalidOperationException">Thrown if there are no more items in pile <paramref name="pile"/></exception>
        T ReadTop(int pile);
    }
}
