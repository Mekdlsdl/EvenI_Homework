using System;
using Doubly;

public class Queue<T>
{
    DoublyList<T> queue = new DoublyList<T>();
    // DoublyNode<T>? front;
    // DoublyNode<T>? rear;
    

    public void Enqueue(T item)
    {
        queue.Add(item);
    }

    public T Dequeue()
    {
        T data = Peek();

        queue.RemoveAt(0);
        
        return data;
    }

    public T Peek()
    {
        T data = default!;

        if (queue.head != null)
        {
            data = queue.head.data;
        }
        
        return data;
    }

    public bool IsEmpty()
    {
        if (queue.count == 0) return true;
        return false;
    }

    public int Size()
    {
        return queue.count;
    }
}