using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
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

        public static bool FshijMediaNeProjekt(ProjektiMedia projektiMedia)
        {
            bool uFshij = false;
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblProjektiMedia_Fshij", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //foreign keys
                cmd.Parameters.AddWithValue("@prmProjektiID", projektiMedia.ProjektiID);
                cmd.Parameters.AddWithValue("@prmMediaID", projektiMedia.MediaID);
                conn.Open();

                cmd.ExecuteNonQuery();
                uFshij = true;
            }
            return uFshij;
        }

        public static List<ProjektiMedia> ShfaqProjektiMedia()
        {
            List<ProjektiMedia> listaProjektiMedia = new List<ProjektiMedia>();
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblProjektiMedia_Select", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProjektiMedia projektiMedia = new ProjektiMedia();
                    projektiMedia.MediaID = int.Parse(reader["@prmMediaID"].ToString());
                    projektiMedia.ProjektiID = int.Parse(reader["@prmProjektiID"].ToString());
                }
                return listaProjektiMedia;
            }
        }
    }
}