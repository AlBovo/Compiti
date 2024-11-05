using System.Diagnostics;

namespace LinkedList
{
    class LinkedList
    {
        private class Node
        {
            public int index;
            public int value;
            public Node? next;
        }

        private Node? head, tail;

        public LinkedList()
        {
            head = tail = null;
        }

        public int Count { get => (tail == null) ? 0 : tail.index; }
        public int this[int idx]
        {
            get => GetElement(idx).value;
            set => GetElement(idx).value = value;
        }

        private Node GetElement(int idx)
        {
            Node? n = head;
            if (n == null)
                throw new IndexOutOfRangeException();
            while (n != null && n.index != idx)
                n = n.next;

            if (n == null)
                throw new IndexOutOfRangeException();
            return n;
        }

        public void Add(int value)
        {
            // Crea il nuovo nodo
            Node n = new Node();
            n.value = value;
            n.next = null;

            if (head == null)  // lista vuota?
            {
                n.index = 0;
                head = n;
                tail = head;
            }
            else
            {
                Debug.Assert(tail != null);

                n.index = tail.index + 1;
                tail.next = n;
                tail = n;
            }
        }

        public void RemoveAt(int idx)
        {
            Node prev = GetElement(idx - 1);

            if (prev.next == tail) 
            {
                prev.next = null;
                tail = prev;
            }
            else
                prev.next = prev.next?.next;
        }

        public void RemoveValue(int value)
        {
            int idx = Search(value);
            
            if (idx != -1)
                RemoveAt(idx);
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

    class ArrayList
    {
        private int[] data;
        private int count;
        public ArrayList(int capacity)
        {
            data = new int[capacity];
            count = 0;
        }

        public int Count { get { return count; } }
        public int this[int idx]
        {
            get
            {
                if (idx < 0 || count < idx)
                    throw new IndexOutOfRangeException();
                return data[idx];
            }
            set
            {
                if (idx < 0 || count < idx)
                    throw new IndexOutOfRangeException();
                data[idx] = value;
            }
        }
        public void Add(int value)
        {
            if (count == data.Length)
                Realloc(2 * data.Length);

            data[count++] = value;
        }
        public void RemoveAt(int idx)
        {
            if (idx < 0 || count < idx)
                throw new IndexOutOfRangeException();
            ShiftLeft(idx);
        }
        public void RemoveValue(int value)
        {
            int idx = Search(value);
            if (idx >= 0)
                RemoveAt(idx);
        }
        public int Search(int value)
        {
            for (int i = 0; i < count; ++i)
            {
                if (data[i] == value)
                    return i;
            }

            return -1;
        }

        // i metodi che seguono sono stati presi da https://classroom.google.com/c/NjI0MDAwODEyNDMx/m/NjcyOTQ3NjgwMjM5/details
        private void Realloc(int new_capacity)
        {
            int[] new_data = new int[new_capacity];
            int idx_max = Math.Min(data.Length, new_data.Length);
            for (int i = 0; i < idx_max; ++i)
                new_data[i] = data[i];
            data = new_data;
        }
        private void ShiftRight(int idx)
        {
            if (idx < 0 || count < idx)
                throw new IndexOutOfRangeException();
            if (count == data.Length)
                Realloc(2 * data.Length);
            int move_count = count - idx; // numero di elementi da spostare
            for (int k = move_count; k > 0; --k)
                data[idx + k] = data[idx + k - 1];
            ++count;
        }
        private void ShiftLeft(int idx)
        {
            if (idx < 0 || count <= idx)
                throw new IndexOutOfRangeException();
            int move_count = count - idx - 1; // numero di elementi da spostare
            for (int k = 0; k < move_count; ++k)
                data[idx + k] = data[idx + k + 1];
            --count;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
        }
    }
}
