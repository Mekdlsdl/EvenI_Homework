using System;


internal class Run_Homework1
{
    static void Main(string[] args)
    {

        DynamicArray da = new DynamicArray();

        Console.Write("Add - ");
        for (int i = 1; i < 5; i++)
        {
            da.Add(i);
        }
        da.Add(2);
        da.Print();


        Console.Write("Remove(있는 요소) - ");
        da.Remove(2);
        da.Print();

        Console.Write("Remove(없는 요소) - ");
        da.Remove(7);
        da.Print();


        Console.Write("Insert(있는 요소) - ");
        da.Insert(2, 5);
        da.Print();

        Console.Write("Insert(없는 요소) - ");
        da.Insert(8, 5);
        da.Print();


        Console.Write("Find(있는 요소) - ");
        Console.WriteLine(da.Find(2));

        Console.Write("Find(없는 요소) - ");
        Console.WriteLine(da.Find(6));


        Console.Write("Size - ");
        Console.WriteLine(da.Size());


        Console.Write("Capacity - ");
        Console.WriteLine(da.Capacity());
    }
}