using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using ArchidesArchitectureWeb.Models;

namespace ArchidesArchitectureWeb.DataAcc
{
    public class AccProjektiMedia
    {
      
        public static bool ShtoMediaNeProjekt(ProjektiMedia projektiMedia)
        {
            bool uRegjistrua = false;
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblProjektiMedia_Insert", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //foreign keys
                cmd.Parameters.AddWithValue("@prmProjektiID", projektiMedia.ProjektiID);
                cmd.Parameters.AddWithValue("@prmMediaID", projektiMedia.MediaID);
                conn.Open();

                cmd.ExecuteNonQuery();
                uRegjistrua = true;
            }
            return uRegjistrua;
        }

        public static bool UpdateMediaNeProjekt(ProjektiMedia projektiMedia)
        {
            bool uUpdate = false;
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblProjektiMedia_Update", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //foreign keys
                cmd.Parameters.AddWithValue("@prmProjektiID", projektiMedia.ProjektiID);
                cmd.Parameters.AddWithValue("@prmMediaID", projektiMedia.MediaID);
                conn.Open();

                cmd.ExecuteNonQuery();
                uUpdate = true;
            }
            return uUpdate;
        }

        public static void FshijMediaNeProjekt(ProjektiMedia projektiMedia)
        {
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblProjektiMedia_Fshij", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //foreign keys
                cmd.Parameters.AddWithValue("@prmProjektiMediaID", projektiMedia.ProjektMediaID);
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        
        public static DataTable ShfaqProjektiMedia()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("usp_tblProjektiMedia_Select", conn);
                sda.Fill(dataTable);
            }
            return dataTable;
        }
    }
}