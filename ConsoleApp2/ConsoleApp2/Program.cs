using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int io = 0; io < 1;)
            {
                Console.WriteLine("Pilih Menu (1.Read data | 2.Input | 3.Delete | 4.Update | 0. Exit)");
                var x = Console.ReadLine();
                switch (x)
                {
                    case "0":
                        io++;
                        Console.WriteLine("bye Thanos");
                        Environment.Exit(0);
                        break;

                    case "1":
                        //Console.Clear();
                        Console.WriteLine("List Data :");
                        read();
                        break;

                    case "2":
                        Console.WriteLine("Input Data :");
                        add();
                        break;

                    case "3":
                        Console.WriteLine("Delete Data :");
                        Console.WriteLine("*Pilih ID yang akan di hapus");
                        Console.WriteLine("Id : ");
                        string delid = Console.ReadLine();
                        delete(delid);
                        break;

                    case "4":
                        Console.WriteLine("Update Data :");
                        Console.WriteLine("*Pilih ID yang akan di update");
                        Console.WriteLine("Id :");
                        string updid = Console.ReadLine();
                        search(updid);
                        Console.WriteLine("Update Nama : ");
                        var updnama = Console.ReadLine();
                        //dbcon.update(updidnya, updnama);
                        break;
                }
            }

            Console.ReadKey();

        }

        static void read()
        {
            int counter = 0;
            string line1;

            List<string> list = new List<string>();

            System.IO.StreamReader readfile =
                new System.IO.StreamReader(@"C:\TestString\DbString.txt");
            while ((line1 = readfile.ReadLine()) != null)
            {
                Console.WriteLine(line1);
                list.Add(line1); // add to array
                counter++;
            }

            readfile.Close();
            Console.WriteLine("Ada {0} data.", counter);
        }

        static void delete(string id)
        {
            string line1;
            string datadel;

            List<string> list = new List<string>();

            System.IO.StreamReader readfile =
                new System.IO.StreamReader(@"C:\TestString\DbString.txt");
            while ((line1 = readfile.ReadLine()) != null)
            {
                if (line1.Contains(id+"|"))
                {
                    datadel = line1;
                }
                else
                {
                    list.Add(line1); // add to array
                }
            }
            readfile.Close();

            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\TestString\DbString.txt"))
            {
                foreach (string line in list)
                {

                    file.WriteLine(line);

                }
            }
        }

        static void search( string id)
        {
            int counter = 0;
            string line1;
            
            System.IO.StreamReader readfile =
                new System.IO.StreamReader(@"C:\TestString\DbString.txt");
            while ((line1 = readfile.ReadLine()) != null)
            {
                if (line1.Contains(id+"|"))
                {
                    Console.WriteLine(line1);
                    counter++;
                }
            }

            readfile.Close();
            Console.WriteLine("Ada {0} data.", counter);
        }

        static void add()
        {
            Console.WriteLine("Id : ");
            var id = Console.ReadLine();
            Console.WriteLine("Nama : ");
            var nama = Console.ReadLine();
            Console.WriteLine("Alamat : ");
            var alamat = Console.ReadLine();

            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\TestString\DbString.txt", true))
            {
                file.WriteLine(id + "|" + nama + "|" + alamat);
                //foreach (string line in list)
                //{

                //    file.WriteLine(line);

                //}

            }
        }

        static void edit()
        {
            //list.Clear();
            int counter = 0;
            string line1;
            System.IO.StreamReader readfile1 =
                new System.IO.StreamReader(@"C:\TestString\DbString.txt");
            while ((line1 = readfile1.ReadLine()) != null)
            {

                if (line1.Contains("bgr"))
                {
                    string line2 = line1.Replace("bgr", "bogor");
                    Console.WriteLine(line2);

                }
                else
                {
                    Console.WriteLine(line1);

                }
                counter++;
            }

            readfile1.Close();
            Console.WriteLine("Ada {0} data.", counter);
        }
    }
}
