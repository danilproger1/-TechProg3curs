using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ParralelProg
{
    public class Program
    {
        static public void Main(string[] args)
        {
            //SortMethod sortMethod = new SortMethod();
            //int[] mas = sortMethod.RandomGenerator(100000, 2000);
            //int []sirtMas = sortMethod.InsertsSort(mas);
            //foreach(int i in sirtMas)
            //    Console.WriteLine(i);
            //RightParallel rightParallel = new RightParallel();
            //SortMethod sortMethod = new SortMethod();

            // последователльная
            //int[] mas = sortMethod.RandomGenerator(10);
            //int[] sortMas = sortMethod.InsertsSort(mas);
            //PrintDifference(mas, sortMas);

            //Паралельная сротировка
            //int[] mas = sortMethod.RandomGenerator(10);
            //int[] sortMas = rightParallel.ParallelInsertionSort(mas);
            //PrintDifference(mas, sortMas);
            // время

            //int[] masForSequlintial = sortMethod.RandomGenerator(100000);
            //int[] masForParallel = sortMethod.RandomGenerator(100000);


            //Stopwatch sw = new Stopwatch();

            //sw.Start();
            //int[] sortSequantialMas = sortMethod.InsertsSort(masForParallel);
            //sw.Stop();
            //Console.WriteLine($"Время последовательного алгоритма: {sw.ElapsedMilliseconds} мс");

            //sw.Restart();

            //sw.Start();
            //int[] sortParallel = rightParallel.ParallelInsertionSort(masForParallel);
            //sw.Stop();
            //Console.WriteLine($"Время парралельного алгоритма: {sw.ElapsedMilliseconds} мс");


        }




        static public void PrintDifference(int[] mas, int[] sortMas)
        {
            Console.WriteLine("Изначальный массив:");
            foreach (int i in mas)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
            Console.WriteLine("Массив отсортированный методом вставок:");
            foreach (int i in sortMas)
            {
                Console.Write($"{i} ");
            }


        }
    }
}