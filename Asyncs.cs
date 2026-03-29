using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParralelProg
{
    public class Asyncs
    {
            
         public async Task<int[]> InsertSortAsync(int[]mas,SortMethod sm )
         {
            return await Task.Run(() =>  sm.InsertsSort(mas));
         }
            
    }
}
