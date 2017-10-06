using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = args.Select(arg => int.Parse(arg));
            Console.WriteLine("Please put all cards in pile 0");
            Sort(order.ToList(), 0, 1, 2);
        }

        private static void Sort(List<int> cards, int unsorted, int lessThanOrEqual, int greaterThan)
        {
            if (cards.Count == 1)
            {
                Move(new List<int>(), cards[0], unsorted, 4);
                return;
            }

            var ltoe = new List<int>();
            var gt = new List<int>();
            using (var enumerator = cards.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    ////throw new InvalidOperationException("Nothing in the pile! Something is wrong!");
                    return;
                }

                var pivot = enumerator.Current;
                Move(ltoe, pivot, unsorted, lessThanOrEqual);
                while (enumerator.MoveNext())
                {
                    if (enumerator.Current > pivot)
                    {
                        Move(gt, enumerator.Current, unsorted, greaterThan);
                    }
                    else
                    {
                        Move(ltoe, enumerator.Current, unsorted, lessThanOrEqual);
                    }
                }
            }

            Sort(Enumerable.Reverse(gt).ToList(), greaterThan, unsorted, lessThanOrEqual);
            Sort(Enumerable.Reverse(ltoe).ToList(), lessThanOrEqual, greaterThan, unsorted);
        }

        private static void Move(List<int> collection, int value, int startPile, int endPile)
        {
            collection.Add(value);
            Console.Write($"Move {value} from pile {startPile} to pile {endPile}");
            Console.ReadLine();
        }
    }
}
