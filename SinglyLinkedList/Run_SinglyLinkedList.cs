using System;
using Singly;

internal class Run_Singly
{
    static void Main(string[] args)
    {
        SinglyList<int> singlyList = new SinglyList<int>();

        for (int i = 1; i <= 10; i++)
        {
            singlyList.Add(new SinglyNode<int>(i, null));
        }


        Console.Write("Add - ");
        singlyList.Print();

        Console.Write("Insert - ");
        singlyList.Insert(5, new SinglyNode<int>(11, null));
        singlyList.Print();

        Console.Write("Insert(0) - ");
        singlyList.Insert(0, new SinglyNode<int>(15, null));
        singlyList.Print();

        Console.Write("Remove(6) - ");
        singlyList.Remove(6);
        singlyList.Print();

        Console.Write("RemoveAt(9) - ");
        singlyList.RemoveAt(9);
        singlyList.Print();

        Console.Write("RemoveAt(-1) - ");
        singlyList.RemoveAt(singlyList.count - 1);
        singlyList.Print();
        Console.WriteLine($"Tail: {(singlyList.tail != null ? singlyList.tail.data.ToString() : "null")}");

        SinglyNode<int>? node = singlyList.Find(1);
        if (node != null) Console.WriteLine($"Find(1) - {node.data}");

        Console.WriteLine($"FindIdx(6) - {singlyList.FindIdx(6)}");
        Console.WriteLine($"Get(6) - {singlyList.Get(6)}");

        int n = singlyList.count;
        for (int i = n - 1; i >= 0; i--)
        {
            singlyList.RemoveAt(i);
            Console.Write($"RemoveAt({i}) - ");
            singlyList.Print();
        }
    }
}