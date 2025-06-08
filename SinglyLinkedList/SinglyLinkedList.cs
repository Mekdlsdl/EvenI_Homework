using System;
using System.Formats.Asn1;

namespace Singly
{
    public class SinglyNode<T>
    {
        public T data;
        public SinglyNode<T>? next;


        public SinglyNode(T d, SinglyNode<T>? n)
        {
            data = d;
            next = n;
        }
    }

    public class SinglyList<T>
    {
        public int count;
        public SinglyNode<T>? head;
        public SinglyNode<T>? tail;


        public void Add(SinglyNode<T> node)
        {
            if (count == 0)
            {
                head = node;
                tail = node;
            }
            else
            {
                tail!.next = node;
                tail = node;
            }

            count++;
        }

        public void Insert(int idx, SinglyNode<T> node)
        {
            if (idx <= 0 || head == null)
            {
                node.next = head;
                head = node;
                if (count == 0) tail = node;
                count++;
                return;
            }

            SinglyNode<T>? current = head;
            int cnt = 0;

            while (current != null && cnt < idx - 1)
            {
                current = current.next;
                cnt++;
            }

            if (current != null)
            {
                node.next = current.next;
                current.next = node;
                if (current == tail)
                    tail = node;
                count++;
            }
            else
            {
                tail!.next = node;
                tail = node;
                count++;
            }
        }

        public void Remove(T data)
        {
            SinglyNode<T>? prev = null;
            SinglyNode<T>? current = head;

            while (current != null)
            {
                if (Equals(current.data, data))
                {
                    RemoveNode(prev, current);
                    return;
                }

                prev = current;
                current = current.next;
            }
        }

        public void RemoveAt(int idx)
        {
            SinglyNode<T>? prev = null;
            SinglyNode<T>? current = head;

            for (int i = 0; i < idx; i++)
            {
                if (current == null) return;
                prev = current;
                current = current.next;
            }

            if (current != null)
            {
                RemoveNode(prev, current);
            }
        }

        public void RemoveNode(SinglyNode<T>? prev, SinglyNode<T>? current)
        {
            if (prev == null) head = current!.next;
            else prev.next = current!.next;

            if (current == tail) tail = prev;

            if (head == null) tail = null;

            count--;
        }

        public SinglyNode<T>? Find(T data)
        {
            SinglyNode<T>? current = head;

            while (current != null)
            {
                if (Equals(current.data, data)) return current;
                current = current.next;
            }

            return null;
        }

        public int FindIdx(T data)
        {
            SinglyNode<T>? current = head;
            int idx = 0;

            while (current != null)
            {
                if (Equals(current.data, data)) return idx;

                current = current.next;
                idx++;
            }

            return -1;
        }

        public T? Get(int idx)
        {
            DoublyNode<T>? current = head;

            for (int i = 0; i < idx; i++)
            {
                current = current!.next;
            }

            return current!.data;
        }

        public void Print()
        {
            SinglyNode<T>? current = head;

            if (current == null) Console.Write("null ");

            while (current != null)
            {
                Console.Write($"{current.data} ");
                current = current.next;
            }

            Console.Write($"(count : {count})\n");
        }
    }
}