using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_part_5__buildings_
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = File.OpenText("Test_Part_3.config.json");
            string connection_string = reader.ReadToEnd();
            log4net.ILog my_logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            using (var con = new NpgsqlConnection(connection_string))
            {
                try
                {
                    con.Open();
                    string query = "call add_500_to_salary_in_loop()";
                    NpgsqlCommand command = new NpgsqlCommand(query, con);
                    command.CommandType = System.Data.CommandType.Text;
                    command.ExecuteNonQuery();
                }
                catch(Exception)
                {
                    my_logger.Error("the stored procedure wa call add_500_to_salary_in_loop() was not exacuted");
                }
            }
        }
    }
}
