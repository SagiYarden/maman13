using System;
using System.Collections.Generic;
using System.Text;

namespace maman12
{
    public class minHeap
    {
        public int size;
        public int[] heap;
        public int position;
        public minHeap(int size)
        {
            this.size = size;
            heap = new int[size + 1];
            position = 0;
        }
        public void createHeap(int[] arrA)
        {
            if (arrA.Length > 0)
            {
                for (int i = 0; i < arrA.Length; i++)
                {
                    insert(arrA[i]);
                }
            }
        }
        public void insert(int x)
        {
            if (position == 0)
            {
                heap[position + 1] = x;
                position = 2;
            }
            else
            {
                heap[position++] = x;
                bubbleUp();
            }
        }
        public void bubbleUp()
        {
            int pos = position - 1;
            int currentDepth = (int)Math.Log2((double)pos);

            while (pos > 0 && !IsLeaf(pos) )
            {
                if (currentDepth % 2 == 1) // if the depth is not even do min heap
                {
                    if (heap[Parent(pos)] < heap[Left(Parent(pos))] && heap[Parent(pos)] < heap[Right(Parent(pos))]) 
                    { break; } //this statement is checking if the parent of the current triangle is smaller then both of his sons then do nothing
                    else //else check between his sons who is smaller and swap the smallest with the parent.
                    {
                        if (heap[Left(Parent(pos))] > heap[Right(Parent(pos))]) 
                        {
                            Exchange(Right(Parent(pos)), pos);
                        }
                        else
                        {
                            Exchange(Left(Parent(pos)), pos);
                        }
                    }                    
                }
                else //if the depth its even do max heap
                {
                    if (heap[Parent(pos)] > heap[Left(Parent(pos))] && heap[Parent(pos)] > heap[Right(Parent(pos))])
                    { break; } //this statement is checking if the parent of the current triangle is highest then both of his sons then do nothing
                    else //else check between his sons who is highest and swap the highest with the parent.
                    {
                        if (heap[Left(Parent(pos))] > heap[Right(Parent(pos))])
                        {
                            Exchange(Left(Parent(pos)), pos);
                        }
                        else
                        {
                            Exchange(Right(Parent(pos)), pos);
                        }
                    }
                }
                pos = Parent(pos);
            }

        }
        private void Exchange(int first, int second)
        {
          
             int temp = heap[first]; //remember first index as temp
             heap[first] = heap[second];
             heap[second] = temp;
        }
        private bool IsLeaf(int i)
        {
            return (size / 2) < i ? true : false;
        }
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
            return (int)Math.Floor((double)(i/2));
        }

        public void display()
        {
            for (int i = 1; i < heap.Length; i++)
            {
                Console.Write(" " + heap[i]);
            }
            Console.Write("");
        }
      
       
        public int extractMin()
        {
            int min = heap[1];
            heap[1] = heap[position - 1];
            heap[position - 1] = 0;
            position--;
            heapify(1);
            return min;
        }

        public void heapify(int k)
        {
            int a = heap[k];
            int smallest = k;
            if (2 * k < position && heap[smallest] > heap[2 * k])
            {
                smallest = 2 * k;
            }
            if (2 * k + 1 < position && heap[smallest] > heap[2 * k + 1])
            {
                smallest = 2 * k + 1;
            }
            if (smallest != k)
            {
                swap(k, smallest);
                heapify(smallest);
            }

        }
        public void swap(int a, int b)
        {
            int temp = heap[a];
            heap[a] = heap[b];
            heap[b] = temp;
        }

        public void example()
        {
            int[] arrA = new int[] { 14, 15, 55, 18, 22, 66, 64, 45, 33, 49, 100, 101, 67, 65, 104, 52, 46, 35, 34, 51, 50 };
            Console.WriteLine("Original Array : ");
            for (int i = 0; i < arrA.Length; i++)
            {
                Console.Write("  " + arrA[i]);
            }
            minHeap m = new minHeap(arrA.Length);
            Console.Write("\nMin-Heap : ");
            m.createHeap(arrA);
            m.display();
            Console.WriteLine("\nExtract Min :");

            for (int i = 0; i < 7 ; i++)
            {
                Console.Write("  " + m.extractMin());
            }

        }


    }
}
