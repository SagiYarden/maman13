using System;

namespace Maman13
{
    class Program
    {
        public static void Main(String[] args)
        {
            int[] a = { 1, 5, 3, 9, 12, 4, 8, 33, 22, 13 ,32,54, };
            int[] b = { 76, 89, 23, 1, 55, 78, 99, 12, 65, 100, 5, 3, 9, 12, 4, 8, 33, 22, 13, 94, 60, 120, 128, 45, 79, 222, 60, 55, 240, 91, 13 };
            Console.WriteLine("original array Unsorted");
            for (int i = 0; i < b.Length; i++)
            {
                Console.Write(b[i] + " ");
            }
            Console.WriteLine();
            MinMaxHeap mnh = new MinMaxHeap(b.Length);
            mnh.BuildWithSort(b);
            Console.WriteLine("original array sorted");
            for (int i = 0; i < b.Length; i++)
            {
                Console.Write(b[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("max min heap:");
            for (int i = 0; i < mnh.Heap.Length; i++)
            {
                Console.Write(mnh.Heap[i] + " ");
            }

            Console.Read();
        }
    }
    

}
