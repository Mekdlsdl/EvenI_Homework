using System;

public class Run_Tree
{
    static void Main(string[] args)
    {
        Tree tree = new Tree();

        List<int> nodes = new List<int> { 5, 3, 7, 2, 8, 1, 4, 6 };


        Console.WriteLine("* Empty Tree Print");
        tree.Print();

        Console.WriteLine("* Add");
        foreach (int n in nodes)
        {
            tree.Add(n);
        }

        tree.Print();

        Console.WriteLine($"\nContains(0) - {tree.Contains(0)}");
        Console.WriteLine($"Contains(5) - {tree.Contains(5)}");

        Console.WriteLine($"Find(0) - {tree.Find(0)}");
        Console.WriteLine($"Find(5) - {tree.Find(5)}");

        Console.WriteLine("\n* Remove(2 - left or right X)");
        tree.Remove(2);
        tree.Print();

        Console.WriteLine("\n* Remove(1 - left & right X)");
        tree.Remove(1);
        tree.Print();

        Console.WriteLine("\n* Remove(7 - left & right O)");
        tree.Remove(7);
        tree.Print();

        Console.WriteLine("\n* Remove(5 - root)");
        tree.Remove(5);
        tree.Print();
    }
}