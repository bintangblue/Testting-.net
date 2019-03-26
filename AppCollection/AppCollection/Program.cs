using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCollection
{
    class Program
    {
        static void Main(string[] args) 
        {
            var g = new TestGeneric<int, string>();
            var g1 = new TestGeneric<int, int>();
            //g1.Nur(9, 4);
            //g.Nur(9, "angka");

            int[] arr = { 0, 1, 2, 3, 4 };
            var list = new List<int>();

            for (int x = 5; x < 10; x++)
            {
                list.Add(x);
            }

            ProcessItems<int>(arr);
            ProcessItems<int>(list);

            Console.ReadKey();
        }

        static void ProcessItems<T>(IList<T> coll)
        {
            // IsReadOnly returns True for the array and False for the List.
            Console.WriteLine
                ("IsReadOnly returns {0} for this collection.", coll.IsReadOnly);

            // The following statement causes a run-time exception for the 
            // array, but not for the List.
            //coll.RemoveAt(4);

            foreach (T item in coll)
            {
                Console.Write(item.ToString() + " ");
            }
            Console.WriteLine();
        }
    }

    public class TestGeneric<T, T1>
    {
        private T _value;
        private T1 _valuet1;

        public T NilaiT { get; set; }
        public T1 NilaiT1 { get; set; }


        public void Nur(T input1, T1 input2)
        {
            //Type t1 = typeof(input1);
            if ((input1 is int) && (input2 is int))
            {
                //Console.WriteLine(Convert.ToInt32(input1) + Convert.ToInt32(input2));
                Console.WriteLine(input1);

                Console.WriteLine("int");
            }
            else
                if (input2 is string)
            {


                Console.WriteLine(input2+" string");
                //Console.WriteLine(input1.ToString() + input2.ToString());
            }
            else
            {
                Console.WriteLine("gagal");
            }
            //return input2.GetType().FullName;
        }
    }

    public class A
    {

    }
    public class TestG1<T, T1>
        where T : A
    {

    }
}
