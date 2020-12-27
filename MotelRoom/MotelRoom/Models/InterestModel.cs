using Microsoft.Data.SqlClient;
using MotelRoom.Controllers;
using MotelRoom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MotelRoom.Models
{
    public class InterestModel : BaseModel
    {
        Interest objInterest = new Interest();
        public string GetInterestRoomById()
        {
            return "";
        }
        public void PostInterestRoom(int roomId, string userId)
        {
            var connect = new DataProvider().GetSqlConnectionProvider(); // get connect
            using (var objConnect = connect)
            {
                var objCmd = new SqlCommand
                {
                    Connection = objConnect,
                    CommandText = "sp_PostInterestRoom", // name stored procedure
                    CommandType = CommandType.StoredProcedure
                };
                try
                {
                    objCmd.Parameters.AddWithValue("@roomId", SqlDbType.Int).Value = roomId;
                    objCmd.Parameters.AddWithValue("@userId", SqlDbType.NVarChar).Value = userId;
                    objConnect.Open();
                    objCmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error ");
                }
                finally
                {
                    objConnect.Close();
                }
            }
        }
    }
}
