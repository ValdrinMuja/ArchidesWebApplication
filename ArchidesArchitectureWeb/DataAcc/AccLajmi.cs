using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using ArchidesArchitectureWeb.Models;

namespace ArchidesArchitectureWeb.DataAcc
{
    public class AccLajmi
    {
        public static bool ShtoLajm(Lajmi lajm)
        {
            bool uRegjistrua = false;
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblLajmi_Insert", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //foreign keys
                cmd.Parameters.AddWithValue("@prmFotoPath",lajm.FotoPath);
                cmd.Parameters.AddWithValue("@prmUploadTime",lajm.UploadTime);
                cmd.Parameters.AddWithValue("@prmTitulli", lajm.Titulli);
                cmd.Parameters.AddWithValue("@prmPershkrimi", lajm.Pershkrimi);
                cmd.Parameters.AddWithValue("@prmUserID", lajm.UserID);
                conn.Open();

                cmd.ExecuteNonQuery();
                uRegjistrua = true;
            }
            return uRegjistrua;
        }

        public static bool UpdateLajm(Lajmi lajm)
        {
            bool uUpdate = false;
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblLajmi_Update", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //foreign keys
                cmd.Parameters.AddWithValue("@prmFotoPath", lajm.FotoPath);
                cmd.Parameters.AddWithValue("@prmUploadTime", lajm.UploadTime);
                cmd.Parameters.AddWithValue("@prmTitulli", lajm.Titulli);
                cmd.Parameters.AddWithValue("@prmPershkrimi", lajm.Pershkrimi);
                cmd.Parameters.AddWithValue("@prmUserID", lajm.UserID);
                conn.Open();

                cmd.ExecuteNonQuery();
                uUpdate = true;
            }
            return uUpdate;
        }

        public static bool FshijLajm(Lajmi lajm)
        {
            bool uFshij = false;
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblLajmi_Delete", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //foreign keys
                cmd.Parameters.AddWithValue("@prmFotoPath", lajm.FotoPath);
                cmd.Parameters.AddWithValue("@prmUploadTime", lajm.UploadTime);
                cmd.Parameters.AddWithValue("@prmTitulli", lajm.Titulli);
                cmd.Parameters.AddWithValue("@prmPershkrimi", lajm.Pershkrimi);
                cmd.Parameters.AddWithValue("@prmUserID", lajm.UserID);
                conn.Open();

                cmd.ExecuteNonQuery();
                uFshij = true;
            }
            return uFshij;
        }

        public static List<Lajmi> ShfaqLajm()
        {
            List<Lajmi> listaLajmet = new List<Lajmi>();
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblLajmi_Select", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   Lajmi lajmi = new Lajmi();
                    lajmi.LajmiID = int.Parse(reader["@prmLajmiID"].ToString());
                    lajmi.UserID = int.Parse(reader["@prmUserID"].ToString());
                    lajmi.FotoPath = reader["@prmFotoPath"].ToString();
                    lajmi.UploadTime = DateTime.Parse(reader["@prmUploadTime"].ToString());
                    lajmi.Titulli = reader["@prmTitulli"].ToString();
                    lajmi.Pershkrimi = reader["@prmPershkrimi"].ToString();

                    listaLajmet.Add(lajmi);
                }

                return listaLajmet;
            }
        }

    }
}