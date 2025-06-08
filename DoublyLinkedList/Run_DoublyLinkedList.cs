using System;
using Doubly;

internal class Run_Doubly
{
    static void Main(string[] args)
    {
        DoublyList<int> doublyList = new DoublyList<int>();

        for (int i = 1; i <= 10; i++)
        {
            doublyList.Add(new DoublyNode<int>(i, null, null));
        }


        Console.Write("Add - ");
        doublyList.Print();

        Console.Write("Insert(5) - ");
        doublyList.Insert(5, new DoublyNode<int>(11, null, null));
        doublyList.Print();

        Console.Write("Insert(0) - ");
        doublyList.Insert(0, new DoublyNode<int>(15, null, null));
        doublyList.Print();

        Console.Write("Insert(-1) - ");
        doublyList.Insert(doublyList.count, new DoublyNode<int>(20, null, null));
        doublyList.Print();

        Console.Write("Remove(6) - ");
        doublyList.Remove(6);
        doublyList.Print();

        Console.Write("RemoveAt(9) - ");
        doublyList.RemoveAt(9);
        doublyList.Print();

        Console.Write("RemoveAt(-1) - ");
        doublyList.RemoveAt(doublyList.count - 1);
        doublyList.Print();
        Console.WriteLine($"Tail - {(doublyList.tail != null ? doublyList.tail.data.ToString() : "null")}");

        Console.Write("Reverse Print - ");
        DoublyNode<int>? rev = doublyList.tail;
        while (rev != null)
        {
            Console.Write($"{rev.data} ");
            rev = rev.prev;
        }
        Console.WriteLine();

        DoublyNode<int>? node = doublyList.Find(1);
        if (node != null) Console.WriteLine($"Find(1) - {node.data}");

        Console.WriteLine($"FindIdx(11) - {doublyList.FindIdx(11)}");
        Console.WriteLine($"FindIdx(1000) - {doublyList.FindIdx(1000)}");
        Console.WriteLine($"Get(6) - {doublyList.Get(6)}");

        int n = doublyList.count;
        for (int i = n - 1; i >= 0; i--)
        {
            doublyList.RemoveAt(i);
            Console.Write($"RemoveAt({i}) - ");
            doublyList.Print();
        }

        Console.Write("Remove(1) - ");
        doublyList.Remove(1);
        doublyList.Print();

        Console.Write("Insert(0) - ");
        doublyList.Insert(0, new DoublyNode<int>(24, null, null));
        doublyList.Print();
    }
}