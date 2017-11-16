using System;
using System.Collections.Generic;
using ArchidesArchitectureWeb.Models;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ArchidesArchitectureWeb.DataAcc
{
    public class AccMedia
    {
        public static bool ShtoMedia( Media media)
        {
            bool uRegjistrua = false;
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblMedia_Insert", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@prmMedia", media.MediaPath);
                conn.Open();

                cmd.ExecuteNonQuery();
                uRegjistrua = true;
            }
            return uRegjistrua;
        }

        public static bool UpdateMedia(Media media)
        {
            bool uUpdate = false;
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblMedia_Update", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@prmMedia", media.MediaPath);
                conn.Open();

                cmd.ExecuteNonQuery();
                uUpdate = true;
            }
            return uUpdate;
        }

        public static bool FshijMedia(Media media)
        {
            bool uFshij = false;
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblMedia_Fshij", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@prmMedia", media.MediaPath);
                conn.Open();

                cmd.ExecuteNonQuery();
                uFshij = true;
            }
            return uFshij;
        }

        public static List<Media> ShfaqMedia()
        {
            List<Media> listaMedia = new List<Media>();
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblMedia_Select", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Media media = new Media();            
                    media.MediaID = int.Parse(reader["@prmMediaID"].ToString());
                    media.MediaPath = reader["@prmMediaPath"].ToString();
                    media.MediaTypeID = int.Parse(reader["@prmMediaTypeID"].ToString());
                    media.LlojiArkitekturaID = int.Parse(reader["@prmLlojiArkitekturaID"].ToString());
                }
                return listaMedia;
            }
        }
    }
}