using Microsoft.Data.SqlClient;
using MotelRoom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MotelRoom.Models
{
    public class UpdateStatusRentModel : BaseModel
    {
        EditPost objPostNews = new EditPost();
        public void UpdateStatusRent(string statusRent, string idRoom)

        {
            var connect = new DataProvider().GetSqlConnectionProvider(); // get connect
            using (var objConnect = connect)
            {
                var objCmd = new SqlCommand
                {
                    Connection = objConnect,
                    CommandText = "sp_UpdateStatusRent", // name stored procedure
                    CommandType = CommandType.StoredProcedure
                };

                try
                {
                    objCmd.Parameters.AddWithValue("@statusRent", SqlDbType.NVarChar).Value = statusRent;
                    objCmd.Parameters.AddWithValue("@idRoom", SqlDbType.Int).Value = Int32.Parse(idRoom);
                    // Open connection
                    objConnect.Open();
                    objCmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error get post news");
                }
                finally
                {
                    objConnect.Close();

                }
            }
        }
    }
}
