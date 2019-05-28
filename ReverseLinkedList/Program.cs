using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ReverseLinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Node> list = new List<Node>();
            var now = new Node(1, null);
            list.Add(now);
            for (int i = 2; i < 6; i++)
            {
                var soon = new Node(i, null);
                now.Next = soon;
                now = soon;
                list.Add(now);
            }
            Console.WriteLine("Traverse the new list --");
            Node current = list[0];
            do
            {
                Console.WriteLine($"current: {current.Val}");
                current = current.Next;
            } while (current != null);
            Console.Write("Press the AnyKey....");
            Console.ReadKey();
            Console.WriteLine("....");

            Console.WriteLine("Reverse it");
            Node newHead = ReverseIt(list[0]);
            Debug.Assert(newHead != null);

            Console.WriteLine("Traverse the list from the new head --");
            current = newHead;
            do
            {
                Console.WriteLine($"current: {current.Val}");
                current = current.Next;
            } while (current != null);

            Console.Write("Press the AnyKey....");
            Console.ReadKey();

        }

        public static Node ReverseIt(Node startNode)
        {
            Node newHead = startNode;
            if (newHead == null) { return newHead; }

            Node a = startNode;
            Node b = a.Next;
            Node c;
            // Make the start node the end of the list.
            a.Next = null;
            if (b != null)
            {
                do
                {
                    // Console.WriteLine($"a: {a.Val}  b: {b.Val}");
                    c = b.Next;
                    b.Next = a;

                    a = b;
                    b = c;
                    // Console.WriteLine($"a: {a.Val}  b: {b?.Val}");
                    // Console.WriteLine("");
                } while (b != null);

                newHead = a;
            }

            return newHead;
        }
    }

    public class Node
    {
        public Node(int val, Node next)
        {
            Val = val;
            Next = next;
        }
        public int Val;
        public Node Next;
    }

}
