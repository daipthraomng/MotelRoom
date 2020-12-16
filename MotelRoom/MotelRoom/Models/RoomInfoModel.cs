using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using MotelRoom.Models;

namespace MotelRoom.Models
{
    public class RoomInfoModel : BaseModel
    {
        public Room objRoom { get; set; }
        public List<Room> objListRoom { get; set; }
        public RoomInfoModel() { objListRoom = new List<Room>(); }
        public void GetRoomInfo(int id)
        {
            var connect = new DataProvider().GetSqlConnectionProvider(); // get connect

            using (var objConnect = connect)
            {
                var objCmd = new SqlCommand
                {
                    Connection = objConnect,
                    CommandText = "sp_GetRoomInfo", // name stored procedure
                    CommandType = CommandType.StoredProcedure
                };

                try
                {
                    objCmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                    // Open connection
                    objConnect.Open();
                    //Get data from database
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = objCmd;
                    da.Fill(ds); // fill dataset by adapter
                    if (ds.Tables.Count > 0)
                    {
                        this.objListRoom = BaseModel.ConvertDataTable<Room>(ds.Tables[0]);
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

    }
}
