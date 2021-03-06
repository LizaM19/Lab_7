﻿using System;
using System.Collections.Generic;


namespace Program
{
    class Program
    {
        static void BFSD(int v, int[,] matrix, int[] DIST, int size)
        {
            Queue<int> queue = new Queue<int>(); //Создаем новую очередь
            queue.Enqueue(v); //Помещаем v в очередь

            DIST[v] = 0;
           
            Console.Write("Результат обхода:  ");
            while (queue.Count != 0)
            {
                v = queue.Dequeue();//Удаляем первый элемент из очереди
                Console.Write(v);
                for (int i = 0; i < size; i++)
                {
                    if (matrix[v, i] != 0 && DIST[i] == -1)
                    {
                        queue.Enqueue(i); //Помещаем i в очередь
                        DIST[i] = DIST[v] + matrix[v,i];
                    }
                }
            }
            Console.Write("      ");   
        }

        static int Main(string[] args)
        {
            Console.Write("Введите размерность матрицы:");  // 1 2  не взвешенный направленный
            int size=3;// = Convert.ToInt32(Console.ReadLine()); // 1 1  не взвешенный не направленный

            for (int i=0; i< args.Length; i++) {
                if (args[i] == "size")
                {
                    size = int.Parse(args[i + 1]);
                }
            }


            int[,] M = new int[size, size];                 // 2 1  взвешенный не направленный
            int[] DIST = new int[size];                     // 2 2  взвешенный  направленный
            Random random = new Random();

            if (args.Length == 0)
            {
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            M[i, j] = random.Next(2);
                            M[i, i] = 0;
                        }
                    }
            }

            if (args.Length != 0)
            {      
                for (int k = 0; k < args.Length; k++)
                {
                    if (args[k] == "v")
                    {
                        for (int i = 0; i < size; i++)
                        {
                            for (int j = 0; j < size; j++)
                            {
                                M[i, j] = random.Next(10);
                                M[i, i] = 0;
                            }
                        }
                    }
  

                    if (args[k] == "n")
                    {
                        for (int i = 1; i < size; i++)
                        {
                            for (int j = 0; j < i; j++)
                            {
                                M[j, i] = M[i, j];

                            }
                        }
                    }
                }

            }

            Console.WriteLine();
            Console.WriteLine("Сгененрированная матрица:\t");
 

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"{M[i, j]}, \t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    DIST[j] = -1;
                }

                BFSD(i, M, DIST, size);
 
                Console.Write("Расстояния от вершины  "+i+":  ");
                for (int t = 0; t < size; t++)
                {
                    Console.Write(DIST[t]+" ");
                }
                Console.WriteLine();
            }

            return 0;
        }
    }
}

