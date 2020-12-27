using Microsoft.Data.SqlClient;
using MotelRoom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MotelRoom.Models
{
    public class HostScreenModel:BaseModel
    {
        public List<Message> listMessage { get; set; }
        public List<RoomSummaryInfo> listPostChecked { get; set; }
        public List<RoomSummaryInfo> listPostNotChecked { get; set; }
        public List<RoomSummaryInfo> listPostDenied { get; set; }
        public HostScreenModel()
        {
            this.listMessage = new List<Message>();
            this.listPostChecked = new List<RoomSummaryInfo>();
            this.listPostNotChecked = new List<RoomSummaryInfo>();
            this.listPostDenied = new List<RoomSummaryInfo>();
        }
        public void GetListPostCheckedOwner(string userId)
        {
            var connect = new DataProvider().GetSqlConnectionProvider(); // get connect
            using (var objConnect = connect)
            {
                var objCmd = new SqlCommand
                {
                    Connection = objConnect,
                    CommandText = "sp_GetPostCheckedOwner", // name stored procedure
                    CommandType = CommandType.StoredProcedure
                };

                try
                {
                    objCmd.Parameters.AddWithValue("@userId", SqlDbType.NVarChar).Value = userId;
                    // Open connection
                    objConnect.Open();
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = objCmd;
                    da.Fill(ds); // fill dataset by adapter
                    if (ds.Tables.Count > 0)
                    {
                        this.listPostChecked = BaseModel.ConvertDataTable<RoomSummaryInfo>(ds.Tables[0]);
                    }
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
        public void GetListPostNotCheckedOwner(string userId)
        {
            var connect = new DataProvider().GetSqlConnectionProvider(); // get connect
            using (var objConnect = connect)
            {
                var objCmd = new SqlCommand
                {
                    Connection = objConnect,
                    CommandText = "sp_GetPostNotCheckedOwner", // name stored procedure
                    CommandType = CommandType.StoredProcedure
                };

                try
                {
                    objCmd.Parameters.AddWithValue("@userId", SqlDbType.NVarChar).Value = userId;
                    // Open connection
                    objConnect.Open();
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = objCmd;
                    da.Fill(ds); // fill dataset by adapter
                    if (ds.Tables.Count > 0)
                    {
                        this.listPostNotChecked = BaseModel.ConvertDataTable<RoomSummaryInfo>(ds.Tables[0]);
                    }
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
        public void GetListPostDeniedOwner(string userId)
        {
            var connect = new DataProvider().GetSqlConnectionProvider(); // get connect
            using (var objConnect = connect)
            {
                var objCmd = new SqlCommand
                {
                    Connection = objConnect,
                    CommandText = "sp_GetPostDeniedOwner", // name stored procedure
                    CommandType = CommandType.StoredProcedure
                };

                try
                {
                    objCmd.Parameters.AddWithValue("@userId", SqlDbType.NVarChar).Value = userId;
                    // Open connection
                    objConnect.Open();
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = objCmd;
                    da.Fill(ds); // fill dataset by adapter
                    if (ds.Tables.Count > 0)
                    {
                        this.listPostDenied = BaseModel.ConvertDataTable<RoomSummaryInfo>(ds.Tables[0]);
                    }
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
