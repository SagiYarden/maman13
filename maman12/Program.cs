using System;

namespace maman12
{
    class Program
    {
        static void Main(string[] args)
        {
           
            int[] a = { 14, 15, 55, 18, 22, 66, 64, 45, 33, 49, 100, 101, 67, 65, 104, 52, 46, 35, 34, 51, 50 };
          //  minHeap mh = new minHeap(a.Length);
          //  Console.WriteLine("original Array:");
          //  for (int i = 0; i < a.Length; i++)
          //  {
          //      Console.Write("  " + a[i]);
          //  }
          //  mh.createHeap(a);
          //  Console.WriteLine();
          //  Console.WriteLine("after creation: ");
          //  for (int i = 0; i < mh.size; i++)
          //  {
          //      Console.Write(" " + mh.heap[i]);
          //
          //  }

            Console.WriteLine();
            Tree t2 = new Tree();
            int[] arr = { 1, 2, 3, 4, 5, 6, 6, 6, 6 };
            t2.root = t2.insertLevelOrder(arr, t2.root, 0);
            t2.inOrder(t2.root);
            Console.Read();
        }
    }
    public class Tree
    {
        public Node root;

        // Tree Node 
        public class Node
        {
            public int data;
            public Node left, right;
            public Node(int data)
            {
                this.data = data;
                this.left = null;
                this.right = null;
            }
        }

        // Function to insert nodes in level order 
        public Node insertLevelOrder(int[] arr,
                                Node root, int i)
        {
            // Base case for recursion 
            if (i < arr.Length)
            {
                Node temp = new Node(arr[i]);
                root = temp;

                // insert left child 
                root.left = insertLevelOrder(arr,
                                root.left, 2 * i + 1);

                // insert right child 
                root.right = insertLevelOrder(arr,
                                root.right, 2 * i + 2);
            }
            return root;
        }

        // Function to print tree 
        // nodes in InOrder fashion 
        public void inOrder(Node root)
        {
            if (root != null)
            {
                inOrder(root.left);
                Console.Write(root.data + " ");
                inOrder(root.right);
            }
        }

        // Driver code 

    }
}
