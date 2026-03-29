using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParralelProg
{
    public class RightParallel
    {
        public int[] ParallelInsertionSort(int[] mas)
        {
            SortMethod sortMethod = new SortMethod();
            object lockObject = new object();
            List<int[]> sortedParts = new List<int[]>();

            int partSize = mas.Length / Environment.ProcessorCount;

            Parallel.For(0, Environment.ProcessorCount,
                () => new List<int>(),

                (i, state, localList) =>
                {
                    int start = i * partSize;
                    int end = (i == Environment.ProcessorCount - 1) ? mas.Length : start + partSize;

                    for (int j = start; j < end; j++)
                        localList.Add(mas[j]);

                    return localList;
                },

                localList =>
                {
                    int[] part = localList.ToArray();
                    part = sortMethod.InsertsSort(part);

                    lock (lockObject)
                    {
                        sortedParts.Add(part);
                    }
                }
            );

            int[] result = sortedParts.SelectMany(x => x).ToArray();
            result = sortMethod.InsertsSort(result);

            return result;
        }
        
    }
}
