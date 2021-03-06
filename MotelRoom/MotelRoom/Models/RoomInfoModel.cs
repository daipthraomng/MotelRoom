﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using MotelRoom.Models;
using MotelRoom.Entity;

namespace MotelRoom.Models
{
    public class RoomInfoModel : BaseModel
    {
        public Room objRoom { get; set; }
        public List<Room> listRoom { get; set; }
        public List<ImageRoom> listImageRoom { get; set; }
        public List<RoomSummaryInfo> listRoomSummary { get; set; }
        public AddressModel address { get; set; }
        public List<User> listOwner { get; set; }
        public Owner owner { get; set; }
        public User user { get; set; }
        public RoomInfoModel() { 
            listRoom = new List<Room>();
            address = new AddressModel();
            listRoomSummary = new List<RoomSummaryInfo>();
            listOwner = new List<User>();
            owner = new Owner();
            user = new User();
        }
        public void GetUserName(int idRoom)
        {
            var connect = new DataProvider().GetSqlConnectionProvider(); // get connect

            using (var objConnect = connect)
            {
                var objCmd = new SqlCommand
                {
                    Connection = objConnect,
                    CommandText = "sp_GetUserName", // name stored procedure
                    CommandType = CommandType.StoredProcedure
                };

                try
                {
                    objCmd.Parameters.AddWithValue("@idRoom", SqlDbType.Int).Value = idRoom;
                    // Open connection
                    objConnect.Open();
                    //Get data from database
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = objCmd;
                    da.Fill(ds); // fill dataset by adapter
                    if (ds.Tables.Count > 0)
                    {
                        this.listOwner = BaseModel.ConvertDataTable<User>(ds.Tables[0]);
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
        //public void GetRoomInfo(int id)
        //{
        //    var connect = new DataProvider().GetSqlConnectionProvider(); // get connect

        //    using (var objConnect = connect)
        //    {
        //        var objCmd = new SqlCommand
        //        {
        //            Connection = objConnect,
        //            CommandText = "sp_GetRoomInfo", // name stored procedure
        //            CommandType = CommandType.StoredProcedure
        //        };

        //        try
        //        {
        //            objCmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
        //            // Open connection
        //            objConnect.Open();
        //            //Get data from database
        //            DataSet ds = new DataSet();
        //            SqlDataAdapter da = new SqlDataAdapter();
        //            da.SelectCommand = objCmd;
        //            da.Fill(ds); // fill dataset by adapter
        //            if (ds.Tables.Count > 0)
        //            {
        //                this.listRoom = BaseModel.ConvertDataTable<Room>(ds.Tables[0]);
        //            }
        //        }
        //        catch (Exception ex)
        //        {


        //        }
        //        finally
        //        {
        //            objConnect.Close();
        //        }
        //    }
        //}

    }
}
