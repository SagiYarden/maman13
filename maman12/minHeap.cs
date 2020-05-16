using System;
using System.Collections.Generic;
using System.Text;

namespace maman12
{
    public class minHeap
    {
        
            public int size;
            public int[] heap;
            public minHeap(int size) // this is a constructor
            {
                this.size = size;
                heap = new int[size];
            }

            public void BuildHeap(int[] Arr)// done
            {
                for (int i = size - 1; i > (int)Math.Floor((double)size / 2) - 1; i--)
                {
                    BubbleUp(Arr, i);
                }
                heap = Arr;
            }



            public void HeapInsert(int value) // done
            {
                if (size == heap.Length)
                {
                    int[] NewHeap = new int[size * 2]; // this is a dynamic heap incase the client wants to add more than the default amount of values in the heap
                    for (int j = 0; j < size; j++)
                    {
                        NewHeap[j] = heap[j];
                    }
                    NewHeap[size] = value;
                    BubbleUp(NewHeap, size);
                    size = size + 1;
                    heap = NewHeap;
                }
                else
                {
                    heap[size] = value;
                    BubbleUp(heap, size);
                    size = size + 1;
                }
            }
            private void Heapify(int i)  // done!
            {
                int succ = Succ(heap, i);
                if (currentLevel(i) % 2 == 0)
                {
                    if (succ != i)
                    {
                        Exchange(heap, succ, i);
                        if (heap[succ] < heap[Parent(succ)])
                        {
                            Exchange(heap, Parent(succ), succ);
                        }
                        if (exist(Left(succ)))
                        {
                            if (heap[Left(succ)] > heap[succ])
                                Exchange(heap, Left(succ), succ);
                        }
                        if (exist(Right(succ)))
                        {
                            if (heap[Right(succ)] > heap[succ])
                                Exchange(heap, Right(succ), succ);
                        }
                        Heapify(succ);
                    }
                }
                else
                {
                    if (succ != i)
                    {
                        Exchange(heap, succ, i);
                        if (heap[succ] > heap[Parent(succ)])
                        {
                            Exchange(heap, Parent(succ), succ);
                        }
                        if (exist(Left(succ)))
                        {
                            if (heap[Left(succ)] < heap[succ])
                                Exchange(heap, Left(succ), succ);
                        }
                        if (exist(Right(succ)))
                        {
                            if (heap[Right(succ)] < heap[succ])
                                Exchange(heap, Right(succ), succ);
                        }
                        Heapify(succ);
                    }
                }
            }

            public int HeapExtractMax() // done!
            {
                if (size < 1)
                    throw new Exception("error: stack underflow");
                int max = heap[0];
                heap[0] = heap[size - 1];
                size = size - 1;
                Heapify(0);
                return max;
            }


            public int HeapExtractMin() // done!
            {
                if (size < 1)
                    throw new Exception("error: stack underflow");
                int min = heap[0];
                if (size == 1)
                {
                    min = heap[0];
                    size = size - 1;
                    return min;

                }
                if (size == 2)
                {
                    min = heap[1];
                    size = size - 1;
                    return min;
                }
                if (size > 2)
                {
                    if (heap[1] > heap[2])
                    {
                        min = heap[2];
                        heap[2] = heap[size - 1];
                        size = size - 1;
                        Heapify(2);
                    }
                    else
                    {
                        min = heap[1];
                        heap[1] = heap[size - 1];
                        size = size - 1;
                        Heapify(1);
                    }
                }

                return min;
            }

            public void HeapDelete(int i)
            {
                if (!exist(i))
                    throw new Exception("the index is outside of the array bounds");
                heap[i] = heap[size - 1];
                size = size - 1;
                Heapify(i);

            }

            public int[] HeapSort()
            {
                int[] Sorted = new int[size];
                for (int i = 0; i < Sorted.Length; i++)
                {
                    Sorted[i] = heap[i];
                }
                Sort.mergeSort(Sorted, 0, Sorted.Length - 1);
                return Sorted;
            }



            public int Succ(int[] Arr, int i)
            {
                int succ = i;
                if (currentLevel(i) % 2 == 0)
                {
                    foreach (var grandChild in GetGrandChildren(Arr, i))
                    {
                        if (grandChild == -1)
                            break;
                        if (Arr[grandChild] > Arr[succ])
                            succ = grandChild;

                    }
                }
                else
                {
                    foreach (var grandChild in GetGrandChildren(Arr, i))
                    {
                        if (grandChild == -1)
                            break;
                        if (Arr[grandChild] < Arr[succ])
                            succ = grandChild;

                    }
                }
                return succ;
            }
            public void Display()
            {
                for (int i = 1; i < size; i++)
                {
                    Console.Write(" " + heap[i]);
                }
                Console.Write("");
            }

            private void BubbleUp(int[] Arr, int leaf)
            {
                if (currentLevel(leaf) % 2 == 0) // we are on a max level
                {
                    if (exist(Parent(leaf))) // this check is necessary because level 0 is also a maximum level
                    {
                        if (Arr[leaf] < Arr[Parent(leaf)])// בדיקה ראשונית בין האבן לבן הכי תחתונים
                            Exchange(Arr, leaf, Parent(leaf));
                        BubbleUpMin(Arr, Parent(leaf));
                        if (Arr[leaf] < Arr[Parent(leaf)]) // בדיקה שנייה בין האב לבן הכי תחתונים לאחר סידור ערכי המינימום 
                            Exchange(Arr, leaf, Parent(leaf));
                        BubbleUpMax(Arr, leaf);
                    }
                }
                else // currentLevel(leaf) % 2 == 1 // we are on a min level
                {
                    BubbleUpMin(Arr, leaf);
                    if (Arr[leaf] > Arr[Parent(leaf)])
                        Exchange(Arr, leaf, Parent(leaf));
                    BubbleUpMax(Arr, Parent(leaf));
                }

            }

            private void BubbleUpMax(int[] Arr, int leaf)
            {
                if (exist(grandpa(leaf)))
                {
                    if (Arr[leaf] > Arr[grandpa(leaf)])
                    {
                        Exchange(Arr, grandpa(leaf), leaf);
                    }
                    BubbleUpMax(Arr, grandpa(leaf));
                }
                return;
            }

            private void BubbleUpMin(int[] Arr, int leaf)
            {
                if (Arr[Parent(leaf)] < Arr[leaf])
                {
                    Exchange(Arr, Parent(leaf), leaf);
                }
                if (exist(grandpa(leaf)))
                {
                    if (Arr[leaf] < Arr[grandpa(leaf)])
                    {
                        Exchange(Arr, grandpa(leaf), leaf);
                    }
                    BubbleUpMin(Arr, grandpa(leaf));
                }
                return;
            }
            private void Exchange(int[] Arr, int first, int second)
            {

                int temp = Arr[first]; //remember first index as temp
                Arr[first] = Arr[second];
                Arr[second] = temp;
            }

            private bool IsLeaf(int i)
            {
                return (size / 2) < i ? true : false;
            }
            private int Left(int i)
            {
                if (2 * i + 1 >= size || i <= -1)
                    return -1;
                return 2 * i + 1;
            }
            private int Right(int i)
            {
                if (2 * i + 2 >= size || i <= -1)
                    return -1;
                return 2 * i + 2;
            }

            public int Parent(int i)
            {
                if (i == 0)
                    return -1;
                return (int)Math.Floor((double)((i - 1) / 2));
            }
            public int grandpa(int i)
            {
                return Parent(Parent(i));
            }
            public bool exist(int i)
            {

                return i >= 0 && i < size;
            }

            public int currentLevel(int i)
            {
                return (int)Math.Floor((double)((int)Math.Log2((double)i + 1)));
            }

            public int[] GetGrandChildren(int[] Arr, int i)
            {
                int[] GrandChilds = new int[4];
                GrandChilds[0] = Left(Left(i));
                GrandChilds[1] = Right(Left(i));
                GrandChilds[2] = Left(Right(i));
                GrandChilds[3] = Right(Right(i));

                return GrandChilds;

            }


            public void TreeView(int[] a, int Count)
            {
                //   Console.WriteLine("                     " + a[0]);
                Console.WriteLine("                  /      \\      ");
                Console.WriteLine("                 /        \\      ");
                Console.WriteLine("                /          \\      ");
                Console.WriteLine("               /            \\      ");
                Console.WriteLine("              /              \\      ");
                Console.WriteLine("             /                \\      ");
                Console.WriteLine("            /                  \\      ");
                //     Console.WriteLine("           " + a[1] + "                  " + a[2] + "               " + Count);
                Console.WriteLine("         /    \\                / \\      ");
                Console.WriteLine("        /      \\              /   \\      ");
                Console.WriteLine("       /        \\            /     \\      ");
                Console.WriteLine("      /          \\          /       \\");
                //   Console.WriteLine("    " + a[3] + "          " + a[4] + "         " + a[5] + "       " + a[6]);
                Console.WriteLine("   / \\          / \\      ");
                Console.WriteLine("  /   \\        /   \\      ");
                //Console.WriteLine(" " + a[7] + "    " + a[8] + "    " + a[9] + "   " );
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
            }



        }
        }
