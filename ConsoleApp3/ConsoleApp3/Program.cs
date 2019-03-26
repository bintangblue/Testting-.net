using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            while (!DrawMenu())
            {

            }
        }

        static bool DrawMenu()
        {
            var retval = false;
            try
            {
                Console.WriteLine("1. Tambah Data");
                Console.WriteLine("2. Hapus Orang");
                Console.WriteLine("3. Ubah Data Orang");
                Console.WriteLine("4. Daftar Orang");
                Console.WriteLine("5. Keluar");
                Console.Write("Silahkan Masukkan Angka Pilihan Anda ?");
                // Baca Input
                var input = Console.ReadLine();
                var angka = Convert.ToInt32(input);

                if ((angka < 1) || (angka > 5))
                {
                    Console.WriteLine("Terjadi Kesalahan : {0}", "Anda harus memasukkan angka 1 sampai 4");
                }
                else
                {
                    switch (angka)
                    {
                        case 1:
                            //
                            TambahData();
                            break;
                        case 2:
                            //
                            DrawMenu2();
                            break;
                        case 3:
                            //
                            DrawMenu3();
                            break;
                        case 4:
                            //
                            DrawList();
                            break;
                        case 5:
                            retval = true;
                            break;
                    }
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Terjadi Kesalahan : {0}", error.Message);
                retval = false;
            }
            return retval;
        }

        public static void DrawMenu2()
        {
            Console.Write("Masukkan Id Orang : ");
            var id = Console.ReadLine();
            var list = System.IO.File.ReadAllLines("./orang.txt");
            var lst = new Dictionary<string, string>();
            foreach (var item in list)
            {
                var key = item.Split(';')[0];
                if (key != id)
                {
                    lst.Add(key, item);
                }
                Console.WriteLine(item);
            }
            System.IO.File.Delete("./orang.txt");
            foreach (var item in lst)
            {
                System.IO.File.AppendAllLines("./orang.txt", new string[] { item.Value });
            }
        }

        public static void DrawMenu3()
        {
            Console.Write("Masukkan Id Orang : ");
            var id = Console.ReadLine();
            var list = System.IO.File.ReadAllLines("./orang.txt");
            var lst = new Dictionary<string, string>();
            foreach (var item in list)
            {
                var key = item.Split(';')[0];
                if (key == id)
                {
                    var orang = InputOrang();
                    lst.Add(orang.Id, string.Format("{0};{1};{2}", orang.Id, orang.Nama, orang.Alamat));
                }
                else
                {
                    lst.Add(key, item);
                }
                Console.WriteLine(item);
            }
            System.IO.File.Delete("./orang.txt");
            foreach (var item in lst)
            {
                System.IO.File.AppendAllLines("./orang.txt", new string[] { item.Value });
            }
        }

        public static void DrawList()
        {
            var list = System.IO.File.ReadAllLines("./orang.txt");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        public static Orang InputOrang()
        {
            var orang = new Orang();
            Console.Write("Masukkan ID : ");
            orang.Id = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Masukkan Nama : ");
            orang.Nama = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Masukkan Alamat : ");
            orang.Alamat = Console.ReadLine();
            Console.WriteLine();
            return orang;
        }

        public static void TambahData()
        {
            var orang = InputOrang();
            System.IO.File.AppendAllLines("./orang.txt", new string[] { string.Format("{0};{1};{2}", orang.Id, orang.Nama, orang.Alamat) });
        }
    }

    public struct Orang
    {
        public string Id { get; set; }
        public string Nama { get; set; }
        public string Alamat { get; set; }
    }


    //public class ClassA
    //{
    //    public string Id { get; set; }
    //    public string Nama { get; set; }
    //    public string Alamat { get; set; }

    //}


}