using System;

public class QueueToStack<T>
{
    Queue<T> stack = new Queue<T>();
    Queue<T> temp = new Queue<T>();

    public void Push(T item)
    {
        stack.Enqueue(item);
    }

    public T Pop()
    {
        T data = default!;
        temp = new Queue<T>();

        while (stack.Size() > 1)
        {
            temp.Enqueue(stack.Dequeue());
        }

        data = stack.Dequeue();

        while (!temp.IsEmpty())
        {
            stack.Enqueue(temp.Dequeue());
        }

        return data;
    }

    public T Peek()
    {
        T data = default!;
        temp = new Queue<T>();

        while (stack.Size() > 1)
        {
            temp.Enqueue(stack.Dequeue());
        }

        data = stack.Dequeue();

        while (!temp.IsEmpty())
        {
            stack.Enqueue(temp.Dequeue());
        }

        stack.Enqueue(data);

        return data;
    }

    public bool IsEmpty()
    {
        return stack.IsEmpty();
    }

    public int Size()
    {
        return stack.Size();
    }
}