using System;
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

        static void Main(string[] args)
        {

            Console.Write("Введите размерность матрицы:");
            int size = Convert.ToInt32(Console.ReadLine());
            int[,] M = new int[size, size];
            int[] DIST = new int[size];


            Random random = new Random();
            Console.WriteLine();
            Console.WriteLine("Сгененрированная матрица:\t");

            /*for (int i = 1; i < size; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    M[i, j] = random.Next(2);     // не взвешенный не направленный
                    M[j, i] = M[i, j];
                }
            }*/

            /*for (int i = 1; i < size; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    M[i, j] = random.Next(10);     // взвешенный не направленный
                    M[j, i] = M[i, j];
                }
            }*/

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    M[i, j] = random.Next(10);     // взвешенный  направленный
                    M[i, i] = 0;
                }
            }

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
        }
    }
}

