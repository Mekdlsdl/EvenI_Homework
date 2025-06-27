using System;
using System.Formats.Asn1;

namespace Doubly
{
    public class DoublyNode<T>
    {
        public T data;
        public DoublyNode<T>? prev;
        public DoublyNode<T>? next;

        public DoublyNode(T d, DoublyNode<T>? p, DoublyNode<T>? n)
        {
            data = d;
            prev = p;
            next = n;
        }
    }

    public class DoublyList<T>
    {
        public int count;
        public DoublyNode<T>? head;
        public DoublyNode<T>? tail;


        public void Add(DoublyNode<T> node)
        {
            if (count == 0)
            {
                head = node;
                tail = node;
            }
            else
            {
                node.prev = tail;
                tail!.next = node;
                tail = node;
            }

            count++;
        }

        public void Insert(int idx, DoublyNode<T> node)
        {
            if (idx <= 0 || head == null)
            {
                if (head == null)
                {
                    head = node;
                    tail = node;
                }
                else
                {
                    node.next = head;
                    head.prev = node;
                    head = node;
                }

                count++;
                return;
            }

            DoublyNode<T>? current = head;
            int cnt = 0;

            while (current != null)
            {
                if (cnt == idx)
                {
                    node.prev = current;
                    node.next = current.next;
                    current.next!.prev = node;
                    current.next = node;

                    count++;

                    return;
                }

                cnt++;
                current = current.next;
            }

            tail!.next = node;
            node.prev = tail;
            tail = node;
            count++;
        }

        public void Remove(T data)
        {
            DoublyNode<T>? prev = null;
            DoublyNode<T>? current = head;

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
            DoublyNode<T>? prev = null;
            DoublyNode<T>? current = head;

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

        public void RemoveNode(DoublyNode<T>? prev, DoublyNode<T>? current)
        {
            if (prev == null)
            {
                head = current!.next;
                if (head != null) head.prev = null;
            }
            else
            {
                prev.next = current!.next;
                if (current.next != null) current.next.prev = prev;
            }

            if (current == tail) tail = prev;

            count--;
        }

        public DoublyNode<T>? Find(T data)
        {
            DoublyNode<T>? current = head;

            while (current != null)
            {
                if (Equals(current.data, data)) return current;
                current = current.next;
            }

            return null;
        }

        public int FindIdx(T data)
        {
            DoublyNode<T>? current = head;
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
            if (idx < 0 || idx >= count)
            {
                Console.WriteLine("유효하지 않은 인덱스입니다.");
                return default!;
            } 
            
            DoublyNode<T>? current = head;

            for (int i = 0; i < idx; i++)
            {
                current = current!.next;
            }

            return current!.data;
        }

        public void Print()
        {
            DoublyNode<T>? current = head;

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