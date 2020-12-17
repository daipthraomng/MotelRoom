using Microsoft.Data.SqlClient;
using MotelRoom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MotelRoom.Models
{
    public class ImageRoomModel : BaseModel
    {
        public List<ImageRoom> listObjImageRoom;

        public ImageRoomModel()
        {
            this.listObjImageRoom = new List<ImageRoom>();
        }

        public void GetImageRoom (int idRoom)
        {
            var connect = new DataProvider().GetSqlConnectionProvider(); // get connect

            using (var objConnect = connect)
            {
                var objCmd = new SqlCommand
                {
                    Connection = objConnect,
                    CommandText = "sp_GetImageRoom", // ten thu tuc
                    CommandType = CommandType.StoredProcedure
                };
                try
                {

                    objCmd.Parameters.AddWithValue("@idRoomIn", SqlDbType.Int).Value = idRoom;
                    objConnect.Open();

                    //objCmd.ExecuteNonQuery();
                    //Get data from database
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = objCmd;
                    da.Fill(ds); // fill dataset by adapter
                    if (ds.Tables.Count > 0)
                    {
                        listObjImageRoom = BaseModel.ConvertDataTable<ImageRoom>(ds.Tables[0]);
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
