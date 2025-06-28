using System;
using Doubly;

public class Stack<T>
{
    DoublyList<T> stack = new DoublyList<T>();
    // DoublyNode<T>? top;

    public void Push(T item)
    {
        stack.Add(item);
    }

    public T Pop()
    {
        T data = Peek();

        stack.RemoveAt(stack.count - 1);
        
        return data;
    }

    public T Peek()
    {
        T data = default!;

        if (stack.tail != null)
        {
            data = stack.tail.data;
        }
        
        return data;
    }

    public bool IsEmpty()
    {
        if (stack.count == 0) return true;
        return false;
    }

    public int Size()
    {
        return stack.count;
    }
}