namespace ConsoleApplication1
{
    using System;

    /// <summary>
    /// A <see cref="IPiler{T}"/> that writes to the console the different movements as they happen, and waits for user input before letting the movements happen
    /// </summary>
    /// <typeparam name="T">The type of the items that are in the different piles</typeparam>
    /// <threadsafety static="true" instance="true"/>
    public sealed class InstrumentedPiler<T> : IPiler<T>
    {
        /// <summary>
        /// The <see cref="IPiler{T}"/> that will do the actual pile interactions
        /// </summary>
        private readonly IPiler<T> piler;

        public InstrumentedPiler(IPiler<T> piler)
        {
            this.piler = piler;
        }

        public void Move(int from, int to)
        {
            Console.Write($"Move item from pile {from} to pile {to}");
            Console.ReadLine();
            this.piler.Move(from, to);
        }

        public T ReadTop(int pile)
        {
            return this.piler.ReadTop(pile);
        }
    }
}
