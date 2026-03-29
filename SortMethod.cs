using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ParralelProg
{
    public class SortMethod
    {
        int limit;
        int size;
        public  int Size { get { return size; } }
        public int limitRandom {
            get
            { return limit; }
            set { limit = value; } 
        }
        public SortMethod(int size,  int limit)
        {
           this.size = size;
           this.limit = limit;
        }
        public SortMethod()
        {
            
        }
        public int MyProperty { get; set; }
        public int[] InsertsSort(int[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
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
            return mas;
        }
        
        public int[] RandomGenerator()
        {

            Random rnd = new Random();
            int[] mas = new int[size];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = rnd.Next(1, limit); ;
            }
            return mas;
        }

    }
}
