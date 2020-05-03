using System;
using System.Collections.Generic;
using System.Text;

namespace Maman13
{
    public class MinMaxHeap
    {
        public int Size ;
        public int[] Heap ;
        public int Position;
        public MinMaxHeap(int _size)
        {
            Size = _size;
        }
        public void BuildHeap(int[] A)
        {

        }

        public void Heapify(int[] A, int i)
        {
            int l = Left(i);
            int r = Right(i);
            //        if (l <= ){
            //
            //        }
        }

        public void HeapInsert(int[] A, int key)
        {

        }

        public int[] HeapExtractMin(int[] A)
        {
            int[] tempArray = new int[A.Length];


            return tempArray;
        }
        public int[] HeapExtractMax(int[] A)
        {
            int[] tempArray = new int[A.Length];


            return tempArray;
        }
        public void HeapDelete(int[] A, int i)
        {

        }

        //helpers
        private int Left(int i)
        {
            return 2 * i;
        }
        private int Right(int i)
        {
            return 2 * i + 1;
        }
        private int Parent(int i)
        {
            return i/2;
        }
        private int HeapSize(int[] A)
        {
            return A.Length; //for now!!!! TODO check for whatsapp group if this is ok
        }
        private void HeapSort(int[] A)
        {
            BuildHeap(A);
            int size = 0;
            for (int i = A.Length; i > 1; i--)
            {
                A = Exchange(A, 0, i);
                size = HeapSize(A) - 1;
                Heapify(A, i);
            }
        }

        private int[] Exchange(int[] A, int first, int second)
        {
            int temp = first; //remember first index as temp
            A[first] = A[second];
            A[second] = A[temp];
            return A;
        }


    }
}
