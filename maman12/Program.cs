using System;

namespace maman12
{
    class Program
    {
        static void Main(string[] args)
        {
           
            int[] a = { 14, 15, 55, 18, 22, 66, 64, 45, 33, 49, 100, 101, 67, 65, 104, 52, 46, 35, 34, 51, 50 };
            minHeap mh = new minHeap(a.Length);
            Console.WriteLine("original Array:");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("  " + a[i]);
            }
            mh.createHeap(a);
            Console.WriteLine();
            Console.WriteLine("after creation: ");
            for (int i = 0; i < mh.size; i++)
            {
                Console.Write(" " + mh.heap[i]);

            } 
            Console.Read();
        }
    }
}
