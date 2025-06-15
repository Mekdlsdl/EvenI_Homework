using System;

public class Run_HashTable
{
    public static void Main(string[] args)
    {
        HashTable hashTable = new HashTable(17);

        for (int i = 0; i < 10; i++)
        {
            hashTable.Add(i);
        }

        for (int i = 17; i < 27; i++)
        {
            hashTable.Add(i);
        }

        hashTable.Print();
    }
}