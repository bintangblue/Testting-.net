using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDB1
{
    class Program : dbtools
    {
        static void Main(string[] args)
        {

            dbtools dbcon = new dbtools();

            for(int io = 0; io < 1;)
            {
                var x = dbcon.menus();

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
                        dbcon.showdata();
                        break;

                    case "2":
                        Console.WriteLine("Input Data :");
                        Console.WriteLine("Id : ");
                        var id = Console.ReadLine();
                        Console.WriteLine("Nama : ");
                        var nama = Console.ReadLine();
                        int idnya = Convert.ToInt16(id);
                        dbcon.insert(idnya, nama);
                        break;

                    case "3":
                        Console.WriteLine("Delete Data :");
                        Console.WriteLine("Id : ");
                        var delid = Console.ReadLine();
                        int delidnya = Convert.ToInt16(delid);
                        dbcon.delete(delidnya);
                        break;

                    case "4":
                        Console.WriteLine("Update Data :");
                        Console.WriteLine("*Pilih ID yang akan di update");
                        Console.WriteLine("Id :");
                        var updid = Console.ReadLine();
                        int updidnya = Convert.ToInt16(updid);
                        dbcon.search(updidnya);
                        Console.WriteLine("Update Nama : ");
                        var updnama = Console.ReadLine();
                        dbcon.update(updidnya, updnama);
                        break;
                }
            }
            Console.ReadKey();
        }
    }

    public class dbtools
    {
        SqlConnection con = new SqlConnection(
               "Server=DESKTOP-IM658HL;Database=dbtest;Trusted_Connection=True;"
               ); // connect to db

        public string menus()
        {
            Console.WriteLine("Pilih Menu (1.Read data | 2.Input | 3.Delete | 4.Update | 0. Exit)");
            var x = Console.ReadLine();
            return x;
        }

        public void insert(int id, string nama)
        {
            var hola = id.ToString();
            if (string.IsNullOrEmpty(hola) || string.IsNullOrEmpty(nama))
            {
                Console.WriteLine("Id atau Nama tidak boleh kosong!");
            }
            else
            {
                con.Open(); //execute db
                SqlCommand cmd = con.CreateCommand();
                cmd.Parameters.Add("@id", id);
                cmd.Parameters.Add("@nama", nama);
                cmd.CommandText = "INSERT INTO TbTest1 (id,name) VALUES (@id ,@nama)";
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void update(int id, string nama)
        {
            con.Open(); //execute db
            SqlCommand cmd = con.CreateCommand();
            cmd.Parameters.Add("@id", id);
            cmd.Parameters.Add("@nama", nama);
            cmd.CommandText = "UPDATE TbTest1 SET name = @nama WHERE id = @id";
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public void delete(int id)
        {
            con.Open(); //execute db
            SqlCommand cmd = con.CreateCommand();
            cmd.Parameters.Add("@id", id);
            cmd.CommandText = "DELETE FROM TbTest1 WHERE id =@id";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void showdata()
        {
            con.Open(); //execute db
            SqlCommand cmd = con.CreateCommand();

            cmd.CommandText = "SELECT * FROM TbTest1 ORDER BY  id ASC";
            var table = new DataTable();
            table.Load(cmd.ExecuteReader());
            var jum_row = table.Rows.Count; // jum row

            for (int i = 0; i < jum_row; i++){
                Console.WriteLine("Id : "+table.Rows[i]["id"]+", Name : "+table.Rows[i]["name"]);
            }
            con.Close();
        }

        public void search(int id)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.Parameters.Add("@id", id);
            cmd.CommandText = "SELECT * FROM TbTest1 WHERE id = @id";
            var table = new DataTable();
            table.Load(cmd.ExecuteReader());
            var jum_row = table.Rows.Count; // jum row

            for (int i = 0; i < jum_row; i++)
            {
                Console.WriteLine("Id : " + table.Rows[i]["id"] + ", Name : " + table.Rows[i]["name"]);
            }
            con.Close();
        }

    }

}
