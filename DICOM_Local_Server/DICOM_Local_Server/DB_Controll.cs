using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace DICOM_Local_Server
{
    static class DB_Controll
    {
        static NpgsqlConnection database;
        static Dictionary<string, string> queryTemplates;
        static bool dbIsOpened;
        static DB_Controll()
        {
            database = new NpgsqlConnection("Host=localhost;Username=postgres;Password=DICOM;Database=DICOM_DB");
            queryTemplates = new Dictionary<string, string>()
            {
                    {"check_device","SELECT ID FROM Authentication WHERE Login='<DeviceUsername>' AND Password='<DevicePassword>'"},
                    {"add_file", "INSERT INTO files (name, path, date) VALUES ('<FileName>', '<FilePath>', '<FileDate>') RETURNING ID"},
                    {"connect_file_patient", "INSERT INTO file_patients (id_file, id_patient) VALUES ('<fileId>', '<patienId>') RETURNING ID"},
                    {"get_patienId", "SELECT ID FROM patients WHERE name='<Name>' AND surname='<Surname>' AND username='<UserName>'"}
            };
            dbIsOpened = false;
        }

        public static void openConnection() 
        {
            dbIsOpened = true;
            database.Open();

        }

        public static bool isOpened()
        {
            return dbIsOpened;
        }

        public static Dictionary<int, Dictionary<string, dynamic>> SendRequest(string request, Dictionary<string, dynamic> data)
        {
            Dictionary<int, Dictionary<string, dynamic>> response = new Dictionary<int, Dictionary<string, dynamic>>();
            string query = queryTemplates[request];
            if (data != null)
            {
                foreach (var pair in data)
                {
                    query = query.Replace("<" + pair.Key + ">", pair.Value);
                }
            }
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = database;
            cmd.CommandText = query;
            using (var reader = cmd.ExecuteReader())
            {
                int rowNumber = 0;
                while (reader.Read())
                {
                    Dictionary<string, dynamic> row = new Dictionary<string, dynamic>();
                    int columnCount = reader.FieldCount;
                    for(int i = 0; i < columnCount; i++)
                    {
                        row.Add(reader.GetName(i), reader.GetString(i));
                    }
                    response.Add(rowNumber, row);
                }
            }
            return response;
        }

        public static void closeConnection()
        {
            dbIsOpened = false;
            database.Close();
        }
    }
}
