using Microsoft.Data.SqlClient;
using MotelRoom.Entity.AddressEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MotelRoom.Models
{
    public class AddressModel:BaseModel
    {
        public int ID { get; set; }
        public string homeNo { get; set; }
        public List<Province> listProvince { get; set; }
        public List<District> listDistrict { get; set; }
        public List<Ward> listWard { get; set; }
        public List<Street> listStreet { get; set; }
        public string province { get; set; }
        public string district { get; set; }
        public string ward { get; set; }
        public string street { get; set; }

        public AddressModel()
        {
            this.homeNo = "";
            this.listProvince = new List<Province>();
            this.listDistrict = new List<District>();
            this.listWard = new List<Ward>();
            this.listStreet = new List<Street>();
            this.province = "consPro";
            this.district = "consdistrict";
            this.ward = "consward";
            this.street = "consstreet";
        }
        public void GetListProvince()
        {
            var connect = new DataProvider().GetSqlConnectionProvider(); // get connect

            using (var objConnect = connect)
            {
                var objCmd = new SqlCommand
                {
                    Connection = objConnect,
                    CommandText = "sp_GetListProvince", // name stored procedure
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
                        this.listProvince = BaseModel.ConvertDataTable<Province>(ds.Tables[0]);
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
        public void GetListDistrict(int idProvince)
        {
            var connect = new DataProvider().GetSqlConnectionProvider(); // get connect

            using (var objConnect = connect)
            {
                var objCmd = new SqlCommand
                {
                    Connection = objConnect,
                    CommandText = "sp_GetListDistrict", // name stored procedure
                    CommandType = CommandType.StoredProcedure
                };

                try
                {
                    objCmd.Parameters.AddWithValue("@idProvince", SqlDbType.Int).Value = idProvince;
                    // Open connection
                    objConnect.Open();
                    //Get data from database
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = objCmd;
                    da.Fill(ds); // fill dataset by adapter
                    if (ds.Tables.Count > 0)
                    {
                        this.listDistrict = BaseModel.ConvertDataTable<District>(ds.Tables[0]);
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
