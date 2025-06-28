using System;

public class StackToQueue<T>
{
    Stack<T> queue = new Stack<T>();
    Stack<T> temp = new Stack<T>();    

    public void Enqueue(T item)
    {
        queue.Push(item);
    }

    public T Dequeue()
    {
        temp = new Stack<T>();
        T data = default!;
        int n = queue.Size();

        for (int i = 0; i < n - 1; i++)
        {
            data = queue.Pop();

            temp.Push(data);
        }

        data = queue.Pop();

        for (int i = 0; i < temp.Size(); i++)
        {
            queue.Push(temp.Pop());
        }
        
        return data;
    }

    public T Peek()
    {
        temp = new Stack<T>();
        T data = default!;
        int n = queue.Size();

        for (int i = 0; i < n; i++)
        {
            data = queue.Pop();

            temp.Push(data);
        }

        for (int i = 0; i < temp.Size(); i++)
        {
            queue.Push(temp.Pop());
        }
        
        return data;
    }

    public bool IsEmpty()
    {
        return queue.IsEmpty();
    }

    public int Size()
    {
        return queue.Size();
    }
}