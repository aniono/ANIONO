using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsAndDataStructures.DataStructure
{
    public class MyLinkedList<T> where T: IEquatable<T>
    {
        public MyLinkedList()
        {
            Head = new Node(default);
            Tail = new Node(default);
            Head.Prev = null;
            Head.Next = Tail;
            Tail.Prev = Head;
            Tail.Next = null;
        }

        public int Count { get; private set; }

        public Node Head { get; set; }

        public Node Tail { get; set; }

        public void Add(T key)
        {
            Node item = new Node(key);

            var current = Tail.Prev;
            Tail.Prev = item;
            item.Prev = current;
            current.Next = item;

            Count++;
        }

        public Node Remove(T key)
        {
            var current = Head.Next;
            while (current != null)
            {
                if (current.Key.Equals(key))
                {
                    current.Prev.Next = current.Next;
                    Count--;
                    break;
                }

                current = current.Next;
            }

            return current;
        }

        public class Node
        {
            public Node(T key)
            {
                Key = key;
            }

            public Node Prev { get; set; }
            public Node Next { get; set; }
            public T Key { get; set; }
        }
    }
}