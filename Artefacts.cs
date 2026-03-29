using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParralelProg
{
    internal class Artefacts
    {
        // гонка данных
        public int[] InsertsSortRace(int[] mas)
        {
            int[] masAll = new int[mas.Length];

            Parallel.For(1, mas.Length,
                i =>
                {
                    int bigger = mas[i];
                    int lessNumber = i - 1;
                    while (lessNumber >= 0 && mas[lessNumber] > bigger)
                    {
                        mas[lessNumber + 1] = mas[lessNumber];
                        mas[lessNumber] = bigger;
                        lessNumber--;
                    }
                });
            return mas;
        }
        //Голодание
         public int[] InsertsSortHungry(int[] mas)
        {

            int mid = mas.Length / 2;

            Parallel.Invoke(
                () => SortRange(mas, 1, mid),
                () => SortRange(mas, mid + 1, mas.Length - 1)
            );


            return MergeSortedParts(mas, mid);
        }

        static void SortRange(int[] mas, int start, int end)
        {
            Thread.Sleep(10000);
            for (int i = start; i <= end; i++)
            {
                int bigger = mas[i];
                int lessNumber = i - 1;
                while (lessNumber >= 0 && mas[lessNumber] > bigger)
                {
                    mas[lessNumber + 1] = mas[lessNumber];
                    mas[lessNumber] = bigger;
                    lessNumber--;
                }
            }
            Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} отсортировал диапазон {start}-{end}");
            
        }

        static int[] MergeSortedParts(int[] mas, int mid)
        {
            int[] result = new int[mas.Length];
            int left = 0;
            int right = mid + 1;
            int index = 0;


            while (left <= mid && right < mas.Length)
            {
                if (mas[left] < mas[right])
                    result[index++] = mas[left++];
                else
                    result[index++] = mas[right++];
            }

            while (left <= mid)
                result[index++] = mas[left++];

            while (right < mas.Length)
                result[index++] = mas[right++];

            return result;
        }
        static public int[] InsertsSortDeadLock(int[] mas)
        {
            object lockerA = new object();
            object lockerB = new object();
            Parallel.For(1, mas.Length,
                i =>
                {
                    int bigger = mas[i];
                    int lessNumber = i - 1;

                    // Четные индексы захватывают locker A потом locker B
                    if (i % 2 == 0)
                    {
                        lock (lockerA)// захват первого потока
                        {
                            Console.WriteLine($"[Поток {Thread.CurrentThread.ManagedThreadId}] Захватил lockerA для i={i}");
                            Thread.Sleep(10);

                            lock (lockerB)// попытка захвата второго потока
                            {
                                Console.WriteLine($"[Поток {Thread.CurrentThread.ManagedThreadId}] Захватил lockerB для i={i}");


                                while (lessNumber >= 0 && mas[lessNumber] > bigger)
                                {
                                    mas[lessNumber + 1] = mas[lessNumber];
                                    mas[lessNumber] = bigger;
                                    lessNumber--;
                                }
                            }
                        }
                    }
                    // Нечетные индексы захватывают lockerB потом lockerA
                    else
                    {
                        lock (lockerB)// захват второго потока
                        {
                            Console.WriteLine($"[Поток {Thread.CurrentThread.ManagedThreadId}] Захватил lockerB для i={i}");
                            Thread.Sleep(10);

                            // Этот lock никогда не получится, если lockerA занят четными потоками
                            lock (lockerA)// попытка захвата второго потока
                            {
                                Console.WriteLine($"[Поток {Thread.CurrentThread.ManagedThreadId}] Захватил lockerA для i={i}");


                                while (lessNumber >= 0 && mas[lessNumber] > bigger)
                                {
                                    mas[lessNumber + 1] = mas[lessNumber];
                                    mas[lessNumber] = bigger;
                                    lessNumber--;
                                }
                            }
                        }
                    }
                });

            return mas;
        }
    }
}
