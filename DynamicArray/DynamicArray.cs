using System;

class DynamicArray
    {
        private int[] arr = new int[2];

        private int size = 0;

        public void Print()
        {
            if (size == 0)
            {
                Console.WriteLine("데이터 없음");
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    Console.Write($"{arr[i]} ");
                }
                Console.WriteLine();
            }
        }

        public void Check()
        {
            if (size >= arr.Length)
            {
                int[] temp = new int[arr.Length + 2];

                for (int i = 0; i < size; i++)
                {
                    temp[i] = arr[i];
                }

                arr = temp;
            }
        }

        public void Add(int data)
        {
            Check();

            arr[size] = data;
            size++;
        }

        public void Remove(int data)
        {
            for (int i = 0; i < size; i++)
            {
                if (arr[i] == data)
                {
                    for (int j = i; j < size - 1; j++)
                    {
                        arr[j] = arr[j + 1];
                    }

                    arr[size - 1] = 0;
                    size--;

                    break;
                }
            }
        }

        public void Insert(int findData, int insertData)
        {
            for (int i = 0; i < size; i++)
            {
                if (arr[i] == findData)
                {
                    Check();

                    for (int j = size; j > i; j--)
                    {
                        arr[j] = arr[j - 1];
                    }

                    arr[i + 1] = insertData;
                    size++;
                    break;
                }


            }
        }

        public int Find(int data)
        {
            for (int i = 0; i < size; i++)
            {
                if (arr[i] == data) return i;
            }

            return -1;
        }

        public int Size()
        {
            return size;
        }

        public int Capacity()
        {
            return arr.Length;
        }
    }

