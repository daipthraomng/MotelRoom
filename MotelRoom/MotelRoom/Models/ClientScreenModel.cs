using Microsoft.Data.SqlClient;
using MotelRoom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MotelRoom.Models
{
    public class ClientScreenModel : BaseModel
    {
        public RoomSummaryInfo objRoomSummary { get; set; }
        public List<RoomSummaryInfo> listRoomSummary { get; set; }
        public AddressModel objAddress { get; set; }

        public ClientScreenModel()
        {
            this.listRoomSummary = new List<RoomSummaryInfo>();
            this.objAddress = new AddressModel();
            this.objRoomSummary = new RoomSummaryInfo();
        }

        public void GetListRoomSummaryInfo()
        {
            var connect = new DataProvider().GetSqlConnectionProvider(); // get connect

            using (var objConnect = connect)
            {
                var objCmd = new SqlCommand
                {
                    Connection = objConnect,
                    CommandText = "sp_GetRoomSummaryInfo", // name stored procedure
                    CommandType = CommandType.StoredProcedure
                };

                try
                {

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
        public void SearchListRoomSummary(SearchRoom objSearchRoom)

        {
            var connect = new DataProvider().GetSqlConnectionProvider(); // get connect
            using (var objConnect = connect)
            {
                var objCmd = new SqlCommand
                {
                    Connection = objConnect,
                    CommandText = "sp_SearchListRoomSummary", // name stored procedure
                    CommandType = CommandType.StoredProcedure
                };

                try
                {
                    objCmd.Parameters.AddWithValue("@publicPlaceAround", SqlDbType.NVarChar).Value = objSearchRoom.publicPlaceAround;
                    if (objSearchRoom.idProvince == "" | objSearchRoom.idProvince == null)
                        objCmd.Parameters.AddWithValue("@idProvince", SqlDbType.Int).Value =  null;
                    else
                        objCmd.Parameters.AddWithValue("@idProvince", SqlDbType.Int).Value =  Int32.Parse(objSearchRoom.idProvince);
                    // iddistrict
                    if (objSearchRoom.idDistrict == "" | objSearchRoom.idDistrict == null)
                        objCmd.Parameters.AddWithValue("@idDistrict", SqlDbType.Int).Value =  null;
                    else
                        objCmd.Parameters.AddWithValue("@idDistrict", SqlDbType.Int).Value = Int32.Parse(objSearchRoom.idDistrict);
                    // idWard
                    if (objSearchRoom.idWard == "" | objSearchRoom.idWard == null)
                        objCmd.Parameters.AddWithValue("@idWard", SqlDbType.Int).Value =  null;
                    else
                        objCmd.Parameters.AddWithValue("@idWard", SqlDbType.Int).Value = Int32.Parse(objSearchRoom.idWard);
                    // idStreet
                    if (objSearchRoom.idStreet == "" | objSearchRoom.idStreet == null)
                        objCmd.Parameters.AddWithValue("@idStreet", SqlDbType.Int).Value =  null;
                    else
                        objCmd.Parameters.AddWithValue("@idStreet", SqlDbType.Int).Value = Int32.Parse(objSearchRoom.idStreet); 
                    // priceMin
                    if (objSearchRoom.priceMin == "")
                        objCmd.Parameters.AddWithValue("@priceMin", SqlDbType.Int).Value =  null;
                    else
                        objCmd.Parameters.AddWithValue("@priceMin", SqlDbType.Int).Value =  Int32.Parse(objSearchRoom.priceMin);
                    // priceMax
                    if (objSearchRoom.priceMax == "")
                        objCmd.Parameters.AddWithValue("@priceMax", SqlDbType.Int).Value =  null;
                    else
                        objCmd.Parameters.AddWithValue("@priceMax", SqlDbType.Int).Value =  Int32.Parse(objSearchRoom.priceMax);
                    // typeRoom
                    objCmd.Parameters.AddWithValue("@typeRoom", SqlDbType.NVarChar).Value = objSearchRoom.typeRoom;
                    // areaMin
                    if (objSearchRoom.areaMin == "")
                        objCmd.Parameters.AddWithValue("@areaMin", SqlDbType.Int).Value = null;
                    else
                        objCmd.Parameters.AddWithValue("@areaMin", SqlDbType.Int).Value = Int32.Parse(objSearchRoom.areaMin);
                    // areaMax
                    if (objSearchRoom.areaMax == "")
                        objCmd.Parameters.AddWithValue("@areaMax", SqlDbType.Int).Value = null;
                    else
                        objCmd.Parameters.AddWithValue("@areaMax", SqlDbType.Int).Value = Int32.Parse(objSearchRoom.areaMax);
                    objCmd.Parameters.AddWithValue("@bathroom", SqlDbType.NVarChar).Value = objSearchRoom.bathroom;
                    objCmd.Parameters.AddWithValue("@heater", SqlDbType.NVarChar).Value = objSearchRoom.heater;
                    objCmd.Parameters.AddWithValue("@kitchen", SqlDbType.NVarChar).Value = objSearchRoom.kitchen;
                    objCmd.Parameters.AddWithValue("@airCondition", SqlDbType.NVarChar).Value = objSearchRoom.airCondition;
                    objCmd.Parameters.AddWithValue("@balcony", SqlDbType.NVarChar).Value = objSearchRoom.balcony;
                    // Open connection
                    objConnect.Open();
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
