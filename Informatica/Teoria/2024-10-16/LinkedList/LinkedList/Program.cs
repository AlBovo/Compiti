using System.Diagnostics;

namespace LinkedList
{
    class LinkedList
    {
        private class Node
        {
            public int value;
            public Node? next;
        }

        private int size;
        private Node? head, tail;

        public LinkedList()
        {
            head = tail = null;
            size = 0;
        }

        public int Count { get => size; }
        public int this[int idx]
        {
            get => GetElement(idx).value;
            set => GetElement(idx).value = value;
        }

        private Node GetElement(int idx)
        {
            Node? n = head;
            int index = 0;
            if (n == null)
                throw new IndexOutOfRangeException();
            while (n != null && (index++) != idx)
                n = n.next;

            if (n == null)
                throw new IndexOutOfRangeException();
            return n;
        }

        public void Add(int value)
        {
            Node n = new Node();
            n.value = value;
            n.next = null;

            if (head == null)
            {
                head = n;
                tail = head;
            }
            else
            {
                Debug.Assert(tail != null);

                tail.next = n;
                tail = n;
            }
            size++;
        }

        public void RemoveAt(int idx)
        {
            if (idx == 0)
            {
                if (head == null) throw new IndexOutOfRangeException();
                if (tail == head) tail = null;
                head = head.next;
                size--;
                return;
            }

            Node prev = GetElement(idx - 1);

            if (prev.next == tail) 
            {
                prev.next = null;
                tail = prev;
            }
            else
                prev.next = prev.next?.next;
            size--;
        }

        public void Reset()
        {
            size = 0;
            head = tail = null;
        }

        public void RemoveValue(int value)
        {
            int idx = Search(value);

            if (idx != -1)
                RemoveAt(idx);
        }

        public void RemoveAll(int value)
        {
            if (head == null)
                return;

            for (Node? curr = head; curr != null; curr = curr.next)
            {
                while (curr.next != null && curr.next!.value == value)
                {
                    if (curr.next.next == null)
                        curr.next = null;
                    else
                        curr.next = curr.next.next;

                    size--;
                }
                if (curr.next != null)
                    tail = curr;
            }

            if (head.value == value)
            {
                head = head.next;
                size--;
            }
            if (head == null)
                tail = null;
        }
        public int Search(int value)
        {
            int i = 0;
            for (Node? curr = head; curr != null; curr = curr.next, ++i)
            {
                if (curr.value == value)
                    return i;
            }

            return -1;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // i mean i could have done worse
            LinkedList list = new LinkedList();
            list.Add(32);
            list.Add(32);
            list.Add(31);
            list.Add(32);
            list.RemoveAll(32);
            Console.WriteLine(list[0]);
        }
    }
}
