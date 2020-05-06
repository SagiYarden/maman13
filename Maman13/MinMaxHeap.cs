using System;
using System.Collections.Generic;
using System.Text;

namespace Maman13
{
    public class MinMaxHeap
    {
        public int Size;
        public int[] Heap;
        public int Position;
        MySorts merge;
        public MinMaxHeap(int _size)
        {
            Size = _size;
            Heap = new int[Size];
            merge = new MySorts();
        }
        public void BuildHeap(int[] A)
        {
          

            for (int i = A.Length - 1; i >= 0; i--)
            {
                Heapify(A, i);
            }
            Heap = A;
        }
        public void BuildWithSort(int[] A) // using mergesort to build max-min heap hopefully in nlogn
        {
            merge.mergeSort(A, 0, A.Length - 1);

            int i = 0;
            int endSorted = A.Length -1;
            int startSorted = 0;
            int currentDepth = 0; // 1 level before the last level
            int logIndex = 1;
            while (currentDepth <= (int)Math.Log2((double)(A.Length))  )  
            {
                if (currentDepth % 2 == 0)
                {
                    Heap[i] = A[endSorted];     // A[end] == current maximum number position
                    endSorted--;                // to keep tracking of current maximum 
                    i++;                        // current first index
                    logIndex++;
                }
                else
                {
                    Heap[i] = A[startSorted]; //start sorted is the tracker of the sorted array position
                    i++;
                    startSorted++;
                    logIndex++;
                }
                currentDepth = (int)Math.Log2((double)(logIndex)); // 1 level before the last level
                if (i == A.Length )
                {
                    break;
                }
            }
        }                    

        #region Test
        // public void Heapify(int[] A, int i)
        // {
        //     int currentDepth = (int)Math.Log2((double)i + 1);
        //     if (currentDepth % 2 == 0)
        //     {
        //         MaxHeapify(A, i);
        //         ReCalculateUpMax(A, i);
        //     }
        //     else
        //     {
        //         MinHeapify(A, i);
        //         ReCalculateUpMin(A, i);
        //     }
        // }

        #endregion
        public void Heapify(int[] A, int i)
        {
            int currentDepth = (int)Math.Log2((double)i + 1);
            int start = 0;
            int end = A.Length;
            if (currentDepth % 2 == 0)
            {
               
            }
            else
            {
               
            }
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



        // heapifies functions
        //max heapify
        private void MaxHeapify(int[] A,int index)
        {
            while (HasLeftChild(index))
            {
                var biggerIndex = LeftChildIndex(index);  //choose the bigger index as the left child index
                if (HasRightChild(index) && GetRightChild( A ,index) > GetLeftChild(A,index))
                {
                    biggerIndex = RightChildIndex(index); //changes the bigger index to the right child index if the right child is bigger
                }

                if (A[biggerIndex] < A[index])
                {
                    break;
                }

                Exchange(A, biggerIndex, index);
                index = biggerIndex;
            }
        }

        private void MinHeapify(int[] A , int index)
        {
            while (HasLeftChild(index))
            {
                var smallerIndex = LeftChildIndex(index);
                if (HasRightChild(index) && GetRightChild(A,index) < GetLeftChild(A, index))
                {
                    smallerIndex = RightChildIndex(index);
                }

                if (A[smallerIndex] >= A[index])
                {
                    break;
                }

                Exchange(A, smallerIndex, index);
                index = smallerIndex;
            }
        }
        private void ReCalculateUpMax(int[] A , int i)
        {
            var index = i;
            while (!IsRoot(index) && A[index] > GetParent(A,index))
            {
                var parentIndex = ParentIndex(index);
                Exchange(A, parentIndex, index);
                index = parentIndex;
            }
        }
        private void ReCalculateUpMin(int[] A, int i)
        {
            var index = i;
            while (!IsRoot(index) && A[index] < GetParent(A,index))
            {
                var parentIndex = ParentIndex(index);
                Exchange(A,parentIndex, index);
                index = parentIndex;
            }
        }
        //helpers
        private bool IsEmpty()
        {
            return Size == 0;
        }
        private int LeftChildIndex(int i)
        {
            return 2 * i + 1;
        }
        private int RightChildIndex(int i)
        {
            return 2 * i + 2;
        }
        private int ParentIndex(int i)
        {
            return (i -1) /2;
        }
        private bool HasLeftChild(int elementIndex) => LeftChildIndex(elementIndex) < Size;
        private bool HasRightChild(int elementIndex) => RightChildIndex(elementIndex) < Size;
        private bool IsRoot(int elementIndex) => elementIndex == 0;

        public int[] GetSubTree( int[] a, int side)
        {
            int[] tmp = new int[a.Length];
            tmp[0] = a[side];
            int j = 1;
            int i = side; //index of the original array
            bool goleft = true;
            while(HasLeftChild(i) || HasRightChild(i))
            {                
                if (goleft && HasLeftChild(i)) //go left and put the left child inside the sub temp array 
                {
                    tmp[j] = GetLeftChild(a, i);
                    i = LeftChildIndex(i); // we need to change the index to the currect index - stuck
                    goleft = false;
                    j++;
                }
                else if(HasRightChild(i))
                {
                    tmp[j] = GetRightChild(a, i);
                    i = RightChildIndex(i);
                    goleft = true;
                    j++;
                }               
            }
            return tmp;
        }

        private bool Exist(int i , int size)
        {
            return i < size && i >= 0 ? true : false;
        }
       
        private int GetLeftChild(int[] A ,int elementIndex) => A[LeftChildIndex(elementIndex)];
        private int GetRightChild(int[] A ,int elementIndex) => A[RightChildIndex(elementIndex)];
        private int GetParent(int[] A ,int elementIndex) => A[ParentIndex(elementIndex)];

        private int HeapSize(int[] A)
        {
            return A.Length; //for now!!!! TODO check for whatsapp group if this is ok
        }
       // private void HeapSort(int[] A)
       // {
       //     BuildHeap(A);
       //     int size = 0;
       //     for (int i = A.Length; i > 1; i--)
       //     {
       //         A = Exchange(0, i);
       //         size = HeapSize(A) - 1;
       //         Heapify(A, i);
       //     }
       // }

        private void Exchange(int[] A ,int firstIndex, int secondIndex)
        {
            var temp = A[firstIndex];
            A[firstIndex] = A[secondIndex];
            A[secondIndex] = temp;
        }
    }
}
