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
        public List<RoomSummaryInfo> listRoomSummary { get; set; }
        public void GetInterestRoomById(string userId)
        {
            var connect = new DataProvider().GetSqlConnectionProvider(); // get connect

            using (var objConnect = connect)
            {
                var objCmd = new SqlCommand
                {
                    Connection = objConnect,
                    CommandText = "sp_GetRoomInterest", // name stored procedure
                    CommandType = CommandType.StoredProcedure
                };

                try
                {
                    objCmd.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = userId;
                    // Open connection
                    objConnect.Open();
                    //Get data from database
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = objCmd;
                    da.Fill(ds); // fill dataset by adapter
                    if (ds.Tables.Count > 0)
                    {
                        this.listRoomSummary = BaseModel.ConvertDataTable<RoomSummaryInfo>(ds.Tables[0]);
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    objConnect.Close();
                }
            }
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
