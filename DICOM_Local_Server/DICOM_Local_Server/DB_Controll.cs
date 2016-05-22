using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace DICOM_Local_Server
{
    class DB_Controll
    {
        /*
        using (var conn = new NpgsqlConnection("Host=localhost;Username=postgres;Password=DICOM;Database=DICOM_DB"))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    // Insert some data
                    //cmd.CommandText = "SELECT * FROM files";
                    //cmd.ExecuteNonQuery();

                    // Retrieve all rows
                    cmd.CommandText = "SELECT * FROM authentication";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.GetString(0) + ' ' + reader.GetString(1) + ' ' + reader.GetString(2) + ' ' + reader.GetString(3));
                        }
                    }
                }
            }
            Console.ReadKey();*/
    }
}
