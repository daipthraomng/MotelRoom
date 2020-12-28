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
    public class EditPostModel:BaseModel
    {
        EditPost objPostNews = new EditPost();
        public void CancelPost(string idRoom)

        {
            var connect = new DataProvider().GetSqlConnectionProvider(); // get connect
            using (var objConnect = connect)
            {
                var objCmd = new SqlCommand
                {
                    Connection = objConnect,
                    CommandText = "sp_CancelPost", // name stored procedure
                    CommandType = CommandType.StoredProcedure
                };

                try
                {
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
        public void EditPost(EditPost objPost, string userId)

        {
            var connect = new DataProvider().GetSqlConnectionProvider(); // get connect
            using (var objConnect = connect)
            {
                var objCmd = new SqlCommand
                {
                    Connection = objConnect,
                    CommandText = "sp_EditPost", // name stored procedure
                    CommandType = CommandType.StoredProcedure
                };

                try
                {
                    objCmd.Parameters.AddWithValue("@idRoom", SqlDbType.Int).Value = Int32.Parse(objPost.idRoom);
                    objCmd.Parameters.AddWithValue("@title", SqlDbType.NVarChar).Value = objPost.title; // add
                    objCmd.Parameters.AddWithValue("@price", SqlDbType.Int).Value = Int32.Parse(objPost.price);
                    objCmd.Parameters.AddWithValue("@area", SqlDbType.Int).Value = Int32.Parse(objPost.area);
                    objCmd.Parameters.AddWithValue("@typeRoom", SqlDbType.NVarChar).Value = objPost.typeRoom;
                    objCmd.Parameters.AddWithValue("@roomNo", SqlDbType.Int).Value = Int32.Parse(objPost.roomNo);
                    objCmd.Parameters.AddWithValue("@homeNo", SqlDbType.NVarChar).Value = objPost.homeNo;
                    objCmd.Parameters.AddWithValue("@idProvince", SqlDbType.Int).Value = Int32.Parse(objPost.idProvince);
                    objCmd.Parameters.AddWithValue("@idDistrict", SqlDbType.Int).Value = Int32.Parse(objPost.idDistrict);
                    objCmd.Parameters.AddWithValue("@idWard", SqlDbType.Int).Value = Int32.Parse(objPost.idWard);
                    objCmd.Parameters.AddWithValue("@idStreet", SqlDbType.Int).Value = Int32.Parse(objPost.idStreet);
                    objCmd.Parameters.AddWithValue("@publicPlaceAround", SqlDbType.NVarChar).Value = objPost.publicPlaceAround;
                    objCmd.Parameters.AddWithValue("@bathroom", SqlDbType.NVarChar).Value = objPost.bathroom;
                    objCmd.Parameters.AddWithValue("@heater", SqlDbType.NVarChar).Value = objPost.heater;
                    objCmd.Parameters.AddWithValue("@kitchen", SqlDbType.NVarChar).Value = objPost.kitchen;
                    objCmd.Parameters.AddWithValue("@airCondition", SqlDbType.NVarChar).Value = objPost.airCondition;
                    objCmd.Parameters.AddWithValue("@balcony", SqlDbType.NVarChar).Value = objPost.balcony;
                    objCmd.Parameters.AddWithValue("@electricityPrice", SqlDbType.Int).Value = Int32.Parse(objPost.electricityPrice);
                    objCmd.Parameters.AddWithValue("@waterPrice", SqlDbType.Int).Value = Int32.Parse(objPost.waterPrice);
                    objCmd.Parameters.AddWithValue("@otherUtility", SqlDbType.NVarChar).Value = objPost.otherUtility;
                    objCmd.Parameters.AddWithValue("@description", SqlDbType.NVarChar).Value = objPost.description;
                    objCmd.Parameters.AddWithValue("@timeDisplay", SqlDbType.Int).Value = Int32.Parse(objPost.timeDisplay);
                    objCmd.Parameters.AddWithValue("@unitTimeId", SqlDbType.Int).Value = Int32.Parse(objPost.unitTimeId);// add
                    objCmd.Parameters.AddWithValue("@userId", SqlDbType.NVarChar).Value = userId;
                    // Open connection
                    objConnect.Open();
                    objCmd.ExecuteNonQuery();
                    HomeController.idRoom = Convert.ToInt32(objPost.idRoom);
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
