using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using Newtonsoft.Json;
using System.Data.SQLite;

namespace MyDistinctionApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Distinction App Running");

            // Print clean formatted time (no JSON, no quotes)
            string formattedTime = DateTime.Now.ToString("'Time and Date': dd/MM/yyyy, hh:mmtt");
            Console.WriteLine(formattedTime);

            using (var conn = new SQLiteConnection("Data Source=:memory:;Version=3;New=True;"))
            {
                conn.Open();

                using (var cmd = new SQLiteCommand("CREATE TABLE Test(Id INTEGER PRIMARY KEY, Name TEXT);", conn))
                    cmd.ExecuteNonQuery();

                using (var cmd = new SQLiteCommand("INSERT INTO Test(Name) VALUES ('Patrick');", conn))
                    cmd.ExecuteNonQuery();

                using (var cmd = new SQLiteCommand("SELECT * FROM Test;", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        Console.WriteLine($"Row: Id-{reader["Id"]}, Name-{reader["Name"]}");
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}



