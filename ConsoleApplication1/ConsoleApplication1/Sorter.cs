namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Sorts items using some piles
    /// </summary>
    /// <typeparam name="T">The type of the items to be sorted using piles</typeparam>
    /// <threadsafety static="true" instance="true"/>
    public sealed class Sorter<T>
    {
        /// <summary>
        /// The <see cref="IPiler{T}"/> that we will use to read items from piles and move them around
        /// </summary>
        private readonly IPiler<T> piler;

        /// <summary>
        /// The <see cref="IComparer{T}"/> that we will use to compare items in piles to determine the order they should end up in
        /// </summary>
        private readonly IComparer<T> comparer;

        public Sorter(IPiler<T> piler, IComparer<T> comparer)
        {
            this.piler = piler;
            this.comparer = comparer;
        }

        /// <summary>
        /// Sorts the items
        /// </summary>
        public void Sort()
        {
            Sort(int.MaxValue, 0, 1, 2);
        }

        private void Sort(int size, int unsorted, int lessThanOrEqual, int greaterThan)
        {
            if (size == 0)
            {
                return;
            }

            if (size == 1)
            {
                this.piler.Move(unsorted, 3);
                return;
            }

            var gt = 0;
            var ltoe = 1;
            var pivot = this.piler.ReadTop(unsorted);
            this.piler.Move(unsorted, lessThanOrEqual);
            for (int i = 0; i < size - 1; ++i)
            {
                T current;
                try
                {
                    current = this.piler.ReadTop(unsorted);
                }
                catch (InvalidOperationException)
                {
                    break;
                }

                if (this.comparer.Compare(current, pivot) > 0)
                {
                    ++gt;
                    this.piler.Move(unsorted, greaterThan);
                }
                else
                {
                    ++ltoe;
                    this.piler.Move(unsorted, lessThanOrEqual);
                }
            }

            Sort(gt, greaterThan, unsorted, lessThanOrEqual);
            Sort(ltoe, lessThanOrEqual, greaterThan, unsorted);
        }
    }
}
