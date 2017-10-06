using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        private static readonly Stack<int>[] piles = new Stack<int>[4] { new Stack<int>(), new Stack<int>(), new Stack<int>(), new Stack<int>() };

        static void Main(string[] args)
        {
            var order = args.Select(arg => int.Parse(arg));
            Console.WriteLine("Please put all cards in pile 0");
            var piler = new InstrumentedPiler<int>(new MemoryPiler<int>(new[] { order, Enumerable.Empty<int>(), Enumerable.Empty<int>(), Enumerable.Empty<int>() }));
            var sorter = new Sorter<int>(piler, Comparer<int>.Default);
            sorter.Sort();

            /*piles[0] = new Stack<int>(order.Reverse());
            Console.WriteLine("Please put all cards in pile 0");
            Sort(piles[0].Count, 0, 1, 2);*/
        }

        private static void Sort(int size, int unsorted, int lessThanOrEqual, int greaterThan)
        {
            if (size == 0)
            {
                return;
            }

            if (size == 1)
            {
                Move(unsorted, 3);
                return;
            }

            var gt = 0;
            var ltoe = 1;
            var pivot = ReadTopCard(unsorted);
            Move(unsorted, lessThanOrEqual);
            for (int i = 0; i < size - 1; ++i)
            {
                if (ReadTopCard(unsorted) > pivot)
                {
                    ++gt;
                    Move(unsorted, greaterThan);
                }
                else
                {
                    ++ltoe;
                    Move(unsorted, lessThanOrEqual);
                }
            }

            Sort(gt, greaterThan, unsorted, lessThanOrEqual);
            Sort(ltoe, lessThanOrEqual, greaterThan, unsorted);
        }

        private static void Move(int startPile, int endPile)
        {
            var value = piles[startPile].Pop();
            piles[endPile].Push(value);
            Console.Write($"Move {value} from pile {startPile} to pile {endPile}");
            Console.ReadLine();
        }

        private static int ReadTopCard(int pile)
        {
            return piles[pile].Peek();
        }
    }
}
