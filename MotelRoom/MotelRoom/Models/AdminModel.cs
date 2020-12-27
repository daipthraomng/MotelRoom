using Microsoft.Data.SqlClient;
using MotelRoom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MotelRoom.Models
{
    public class AdminModel : BaseModel
    {
        public List<Owner> listOwnerChecked { get; set; }
        public List<Owner> listOwnerNotChecked { get; set; }
        public List<RoomSummaryInfo> listPostChecked { get; set; }
        public List<RoomSummaryInfo> listPostNotChecked { get; set; }
        public List<RoomSummaryInfo> listPostDenied { get; set; }
        public HostScreenModel objHost { get; set; }

        public AdminModel()
        {
            this.listOwnerChecked = new List<Owner>();
            this.listOwnerNotChecked = new List<Owner>();
            this.listPostChecked = new List<RoomSummaryInfo>();
            this.listPostNotChecked = new List<RoomSummaryInfo>();
            this.listPostDenied = new List<RoomSummaryInfo>();
            this.objHost = new HostScreenModel();
        }
        public void GetListOwnerChecked()
        {
            var connect = new DataProvider().GetSqlConnectionProvider(); // get connect
            using (var objConnect = connect)
            {
                var objCmd = new SqlCommand
                {
                    Connection = objConnect,
                    CommandText = "sp_GetListOwnerChecked", // name stored procedure
                    CommandType = CommandType.StoredProcedure
                };

                try
                {
                    // Open connection
                    objConnect.Open();
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = objCmd;
                    da.Fill(ds); // fill dataset by adapter
                    if (ds.Tables.Count > 0)
                    {
                        this.listOwnerChecked = BaseModel.ConvertDataTable<Owner>(ds.Tables[0]);
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
        public void GetListOwnerNotChecked()
        {
            var connect = new DataProvider().GetSqlConnectionProvider(); // get connect
            using (var objConnect = connect)
            {
                var objCmd = new SqlCommand
                {
                    Connection = objConnect,
                    CommandText = "sp_GetListOwnerNotChecked", // name stored procedure
                    CommandType = CommandType.StoredProcedure
                };

                try
                {
                    // Open connection
                    objConnect.Open();
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = objCmd;
                    da.Fill(ds); // fill dataset by adapter
                    if (ds.Tables.Count > 0)
                    {
                        this.listOwnerNotChecked = BaseModel.ConvertDataTable<Owner>(ds.Tables[0]);
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
        public void GetListPostChecked()
        {
            var connect = new DataProvider().GetSqlConnectionProvider(); // get connect
            using (var objConnect = connect)
            {
                var objCmd = new SqlCommand
                {
                    Connection = objConnect,
                    CommandText = "sp_GetPostChecked", // name stored procedure
                    CommandType = CommandType.StoredProcedure
                };

                try
                {
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
        public void GetListPostNotChecked()
        {
            var connect = new DataProvider().GetSqlConnectionProvider(); // get connect
            using (var objConnect = connect)
            {
                var objCmd = new SqlCommand
                {
                    Connection = objConnect,
                    CommandText = "sp_GetPostNotChecked", // name stored procedure
                    CommandType = CommandType.StoredProcedure
                };

                try
                {
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
        public void GetListPostDenied()
        {
            var connect = new DataProvider().GetSqlConnectionProvider(); // get connect
            using (var objConnect = connect)
            {
                var objCmd = new SqlCommand
                {
                    Connection = objConnect,
                    CommandText = "sp_GetPostDenied", // name stored procedure
                    CommandType = CommandType.StoredProcedure
                };

                try
                {
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
        public void DeleteOwner(string idOwner)
        {
            var connect = new DataProvider().GetSqlConnectionProvider(); // get connect
            using (var objConnect = connect)
            {
                var objCmd = new SqlCommand
                {
                    Connection = objConnect,
                    CommandText = "sp_DeleteOwner", // name stored procedure
                    CommandType = CommandType.StoredProcedure
                };

                try
                {
                    objCmd.Parameters.AddWithValue("@userId", SqlDbType.NVarChar).Value = idOwner;
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
        public void AcceptOwner(string idOwner)
        {
            var connect = new DataProvider().GetSqlConnectionProvider(); // get connect
            using (var objConnect = connect)
            {
                var objCmd = new SqlCommand
                {
                    Connection = objConnect,
                    CommandText = "sp_AcceptOwner", // name stored procedure
                    CommandType = CommandType.StoredProcedure
                };

                try
                {
                    objCmd.Parameters.AddWithValue("@userId", SqlDbType.NVarChar).Value = idOwner;
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
        public void AcceptPost(int idRoom)
        {
            var connect = new DataProvider().GetSqlConnectionProvider(); // get connect
            using (var objConnect = connect)
            {
                var objCmd = new SqlCommand
                {
                    Connection = objConnect,
                    CommandText = "sp_AcceptPost", // name stored procedure
                    CommandType = CommandType.StoredProcedure
                };

                try
                {
                    objCmd.Parameters.AddWithValue("@idRoom", SqlDbType.Int).Value = idRoom;
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
        public void DenyPost(int idRoom)
        {
            var connect = new DataProvider().GetSqlConnectionProvider(); // get connect
            using (var objConnect = connect)
            {
                var objCmd = new SqlCommand
                {
                    Connection = objConnect,
                    CommandText = "sp_DenyPost", // name stored procedure
                    CommandType = CommandType.StoredProcedure
                };

                try
                {
                    objCmd.Parameters.AddWithValue("@idRoom", SqlDbType.Int).Value = idRoom;
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
        public void AddEndTime(string endTime, int idRoom)
        {
            var connect = new DataProvider().GetSqlConnectionProvider(); // get connect
            using (var objConnect = connect)
            {
                var objCmd = new SqlCommand
                {
                    Connection = objConnect,
                    CommandText = "sp_AddEndTime", // name stored procedure
                    CommandType = CommandType.StoredProcedure
                };

                try
                {
                    objCmd.Parameters.AddWithValue("@endTime", SqlDbType.DateTime).Value = endTime;
                    objCmd.Parameters.AddWithValue("@idRoom", SqlDbType.Int).Value = idRoom;
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
