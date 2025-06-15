using System;
using Singly;

public class HashTable
{
    int n;
    SinglyList<int>[] table;

    public HashTable(int size)
    {
        n = size;
        table = new SinglyList<int>[n];

        for (int i = 0; i < n; i++)
        {
            table[i] = new SinglyList<int>();
        }
    }

    public void Add(int key)
    {
        int idx = key % n;

        table[idx].Add(key);
    }

    public void Print()
    {
        for (int i = 0; i < n; i++)
        {
            Console.Write($"[{i}]");

            for (int j = 0; j < table[i].count; j++)
            {
                Console.Write($" -> {table[i].Get(j)}");
            }
            Console.Write($" -> null\n");
        }
        Console.WriteLine();
    }
}