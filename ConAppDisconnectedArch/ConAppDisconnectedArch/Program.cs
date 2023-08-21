//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConAppDisconnectedArch
//{
// internal class Program
// {
//     static SqlConnection con;
//     static SqlCommand cmd;
//    static SqlDataAdapter adapter;
//    static DataSet ds;
//     static string conString = "server=DESKTOP-IU21EKM;database=Day7Db;trusted_connection=true;";
//     static void Main(string[] args)
//   {
//       try
//       {
//          con = new SqlConnection(conString);
//       cmd = new SqlCommand("select * from Customers", con);
//       adapter = new SqlDataAdapter(cmd);
//       con.Open();
//       ds = new DataSet();
//       adapter.Fill(ds);
//       con.Close();
//       for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
//      {
//          Console.WriteLine("ID :" + ds.Tables[0].Rows[i]["Id"]);
//         Console.WriteLine("Name :" + ds.Tables[0].Rows[i]["Name"]);
//        Console.WriteLine("ODLimit :" + ds.Tables[0].Rows[i]["ODLimit"]);
//       Console.WriteLine("Start Date :" + ds.Tables[0].Rows[i]["SStartDate"]);
//       Console.WriteLine("End Date :" + ds.Tables[0].Rows[i]["SEndDate"]);
//    }
//   }
//    catch (Exception ex)
//    {
//        Console.WriteLine("Error!!!" + ex.Message);
//    }
//    finally
//    {
//        Console.WriteLine("End of the Program!!!");
//         Console.ReadKey();
//     }
//  }
//   }
//}

//with data reader


//namespace ConAppDisconnectedArch
//{
// internal class Programm
//  {
//      static SqlCommand cmd;
//static SqlConnection con;
//     static SqlDataReader reader;
//    static string conStr = "server=DESKTOP-IU21EKM;database=Day7Db;trusted_connection=true;";

//    static void Main(string[] args)
//    {
//       try
//       {
//           con = new SqlConnection(conStr);
//           cmd = new SqlCommand("select * from Customer", con);
//           con.Open();
//          reader = cmd.ExecuteReader();

//         while (reader.Read())
//        {
//           Console.WriteLine(reader["Id"]);
//           Console.WriteLine(reader["Name"]);
//           Console.WriteLine(reader["ODLimit"]);
//           Console.WriteLine(reader["SStartDate"]);
//          Console.WriteLine(reader["SEndDate"]);

//          Console.WriteLine("-----------------------------------------");
//      }
//      con.Close();

//  }
//   catch (Exception ex) { Console.WriteLine(ex.Message); }
//     finally
//       {
//           Console.WriteLine("End of Program");
//            Console.ReadKey();
//        }
//    }
//}
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;


//namespace ConAppDisconnectedArch
//{
//  internal class Programm
//  {
//     static SqlConnection con;
//     static SqlCommand cmd;
//   static SqlDataAdapter adapter;
//   static DataSet ds;
//   static string conString = "server = DESKTOP-IU21EKM;database = Day7Db;trusted_Connection = true;";

//    static void Main(string[] args)
//     {
//        try
//     {
//        con = new SqlConnection(conString);
//        con.Open();
//        cmd = new SqlCommand();
//       cmd.CommandText = "insert into Customer (IDataAdapter,namespace,ODLimit,SStartDate,SEndDate)values(IDataAdapter,@name,@odLimit,SortedDictionary,@nd)";
//       cmd.Connection = con;
//      Console.WriteLine("Enter ID");
//      cmd.Parameters.AddWithValue(@"@id", int.Parse(Console.ReadLine()));
//       Console.WriteLine("Enter Name");
//       cmd.Parameters.AddWithValue("@name", Console.ReadLine());
//       Console.WriteLine("Enter ODLimit");
//       cmd.Parameters.AddWithValue("@odLimit", double.Parse(Console.ReadLine()));
//       Console.WriteLine("Enter StartDate");
//      cmd.Parameters.AddWithValue("@sd", DateTime.Parse(Console.ReadLine()));
//      Console.WriteLine("Enter EndDate");
//     cmd.Parameters.AddWithValue("@nd", DateTime.Parse(Console.ReadLine()));
//     cmd.ExecuteNonQuery();
//     Console.WriteLine("Addedd!!!");
//   }
//   catch (Exception ex)
//    {
//        Console.WriteLine("Error!!" + ex.Message);

//    }
//     finally
//     {
//        Console.WriteLine("End Of the Program!!");
//        con.Close();
//        Console.ReadKey();
//    }
//  }
//  }
//}
//insert using index
using System;
using System.Data.SqlClient;
using System.Data;

namespace ConAppDisconnectedArch
{
    internal class Program
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataAdapter adapter;
        static DataSet ds;
        static string conString = "server=;database=Day7Db;trusted_connection=true;";
        static void Main(string[] args)
        {
            try
            {
                con = new SqlConnection(conString);
                cmd = new SqlCommand("select * from Customers", con);
                adapter = new SqlDataAdapter(cmd);  //fetch the data from the table
                con.Open();
                ds = new DataSet();   //collection of tables  
                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataRow dr = dt.NewRow();
                Console.WriteLine("Enter Id");
                dr["Id"] = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Name");
                dr["Name"] = Console.ReadLine();
                Console.WriteLine("Enter OD Limit");
                dr["ODLimit"] = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter Subscription Start Date");
                dr["SStartDate"] = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter Subscription End Date");
                dr["SEndDate"] = DateTime.Parse(Console.ReadLine());

                dt.Rows.Add(dr);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.Update(ds);
                Console.WriteLine("Inserted!!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }
            finally
            {
                con.Close();
                Console.ReadKey();
            }
        }
    }
}