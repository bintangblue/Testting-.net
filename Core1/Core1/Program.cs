using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;

namespace Core1
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new SqlConnection("Server=DESKTOP-IM658HL;Database=dbtest;Trusted_Connection=True;");
            //x.Open();
            IEnumerable<MTest> y =  x.Query<MTest>(@"SELECT TOP (1000) [id],[name] FROM [dbtest].[dbo].[TbTest1]").ToList();

            var c = y.Where(u => u.id == 1);
            //x.Close();
            foreach(var item in y)
            {
                Console.WriteLine("{0} : {1}", item.id, item.name);
            }
            Console.ReadLine();
        }

        static string input()
        {
            try
            {
                var x = new SqlConnection("Server=DESKTOP-IM658HL;Database=dbtest;Trusted_Connection=True;");
                Console.WriteLine("Id :");
                var id = Console.ReadLine();
                Console.WriteLine(" Nama :");
                string name = Console.ReadLine();
                //SqlCommand cmd = x.CreateCommand();
                x.Execute("INSERT INTO [TbTest1] ([id], [name]) VALUES (@Id ,@Name)", new { Id = id, Name = name });
                return "Success";
            }catch(Exception err)
            {
                return ("info : " + err);
            }
        }

        static string bang()
        {
            var x = new SqlConnection("Server=DESKTOP-IM658HL;Database=dbtest;Trusted_Connection=True;");
            //x.Open();
           var y = x.Query<MTest>(@"SELECT TOP (1000) [id],[name] FROM [dbtest].[dbo].[TbTest1]").ToList();
            return y.ToString();
        }

    }

    public class MTest {
        public int id { get; set; }
        public string name { get; set; }
        
    }

    public static class helper
    {
        public static void Testing(this MTest ob)
        {
            Console.WriteLine("hallo");
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

        public void insert(int id, string name)
        {
            var hola = id.ToString();
            if (string.IsNullOrEmpty(hola) || string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Id atau Nama tidak boleh kosong!");
            }
            else
            {
                con.Open(); //execute db
                //DynamicParameters parameter = new DynamicParameters();
                //parameter.Add("@id", id);
                //parameter.Add("@name", name);
                con.Execute(@"INSERT INTO [TbTest1] (id,name) VALUES (@Id ,@Name)", new { Id = id , Name = name});
                con.Close();
            }
        }

        public void update(int id, string name)
        {
            con.Open(); //execute db
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@id",id);
            parameter.Add("@name", name);
            con.Execute(@"UPDATE [TbTest1] SET name = @name WHERE id = @id");
            con.Close();

        }

        public void delete(int id)
        {
            con.Open(); //execute db
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@id", id);
            con.Query("DELETE FROM TbTest1 WHERE id =@id");
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

            for (int i = 0; i < jum_row; i++)
            {
                Console.WriteLine("Id : " + table.Rows[i]["id"] + ", Name : " + table.Rows[i]["name"]);
            }
            con.Close();
        }

        public void search(int id)
        {
            con.Open();
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@id", id);
            IEnumerable<MTest> sql = con.Query<MTest>("SELECT * FROM TbTest1 WHERE id = @id");
            
            con.Close();
        }

    }
}

