using Microsoft.Data.SqlClient;
using MotelRoom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MotelRoom.Models
{
    public class PostNewsModel:BaseModel
    {
        PostNews objPostNews = new PostNews();
        public List<PostNews> objListPostNews { get; set; }
        public string GetPostNewsById(int id)
        {
            var connect = new DataProvider().GetSqlConnectionProvider(); // get connect

            using (var objConnect = connect)
            {
                var objCmd = new SqlCommand
                {
                    Connection = objConnect,
                    CommandText = "sp_GetPostNewsById", // name stored procedure
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
                        this.objPostNews = BaseModel.ConvertDataTable<PostNews>(ds.Tables[0])[0];
                        return "success get";
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
                return "false get";
            }
        }
        /* 
            * int price,decimal area, string typeRoom, int roomNo, string homeNo, 
           // int idProvince, int idDistrict, int idWard ,int idStreet, string publicPlaceAround
           //, string bathroom
           //, string heater
           //, string kitchen
           //, string airCondition
           //, string balcony
           //, int electricityPrice
           //, int waterPrice
           //, string otherUtility
           //, string description
           //, string nameBoss
           //, string phoneBoss
           //, int timeDisplay
           //, string unitTime
           */
        public void PostPostNews(PostNews objPostNews)
           
        {
            var connect = new DataProvider().GetSqlConnectionProvider(); // get connect

            using (var objConnect = connect)
            {
                var objCmd = new SqlCommand
                {
                    Connection = objConnect,
                    CommandText = "sp_PostPostNews", // name stored procedure
                    CommandType = CommandType.StoredProcedure
                };

                try
                {
                    //objCmd.Parameters.Add("@roomID", SqlDbType.Int, 0, "roomID");
                    //objCmd.Parameters["@roomID"].Direction = ParameterDirection.Output;
                    objCmd.Parameters.AddWithValue("@price", SqlDbType.Int).Value = Int32.Parse(objPostNews.price);
                    objCmd.Parameters.AddWithValue("@area", SqlDbType.Int).Value = Int32.Parse(objPostNews.area);
                    objCmd.Parameters.AddWithValue("@typeRoom", SqlDbType.NVarChar).Value = objPostNews.typeRoom;
                    objCmd.Parameters.AddWithValue("@roomNo", SqlDbType.Int).Value = Int32.Parse(objPostNews.roomNo);
                    objCmd.Parameters.AddWithValue("@homeNo", SqlDbType.VarChar).Value = objPostNews.homeNo;
                    objCmd.Parameters.AddWithValue("@idProvince", SqlDbType.Int).Value = Int32.Parse(objPostNews.idProvince);
                    objCmd.Parameters.AddWithValue("@idDistrict", SqlDbType.Int).Value = Int32.Parse(objPostNews.idDistrict);
                    objCmd.Parameters.AddWithValue("@idWard", SqlDbType.Int).Value = Int32.Parse(objPostNews.idWard);
                    objCmd.Parameters.AddWithValue("@idStreet", SqlDbType.Int).Value = Int32.Parse(objPostNews.idStreet);
                    objCmd.Parameters.AddWithValue("@publicPlaceAround", SqlDbType.NVarChar).Value = objPostNews.publicPlaceAround;
                    objCmd.Parameters.AddWithValue("@bathroom", SqlDbType.NVarChar).Value = objPostNews.bathroom;
                    objCmd.Parameters.AddWithValue("@heater", SqlDbType.NVarChar).Value = objPostNews.heater;
                    objCmd.Parameters.AddWithValue("@kitchen", SqlDbType.NVarChar).Value = objPostNews.kitchen;
                    objCmd.Parameters.AddWithValue("@airCondition", SqlDbType.NVarChar).Value = objPostNews.airCondition;
                    objCmd.Parameters.AddWithValue("@balcony", SqlDbType.NVarChar).Value = objPostNews.balcony;
                    objCmd.Parameters.AddWithValue("@electricityPrice", SqlDbType.Int).Value = Int32.Parse(objPostNews.electricityPrice);
                    objCmd.Parameters.AddWithValue("@waterPrice", SqlDbType.Int).Value = Int32.Parse(objPostNews.waterPrice);
                    objCmd.Parameters.AddWithValue("@otherUtility", SqlDbType.NVarChar).Value = objPostNews.otherUtility;
                    objCmd.Parameters.AddWithValue("@description", SqlDbType.NVarChar).Value = objPostNews.description;
                    objCmd.Parameters.AddWithValue("@nameBoss", SqlDbType.NVarChar).Value = objPostNews.nameBoss;
                    objCmd.Parameters.AddWithValue("@phoneBoss", SqlDbType.VarChar).Value = objPostNews.phoneBoss;
                    objCmd.Parameters.AddWithValue("@timeDisplay", SqlDbType.Int).Value = Int32.Parse(objPostNews.timeDisplay);
                    objCmd.Parameters.AddWithValue("@unitTime", SqlDbType.NVarChar).Value = objPostNews.unitTime;
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
