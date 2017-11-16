using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using ArchidesArchitectureWeb.Models;

namespace ArchidesArchitectureWeb.DataAcc
{
    public class AccLlojiArkitektura
    {
        public static bool ShtoLlojArkitekture(LlojiArkitektura llojiArkitektura)
        {
            bool uRegjistrua = false;
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblLlojiArkitektura_Insert", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@prmLlojiArkitektura",llojiArkitektura.LlojiIArkitektures);
                conn.Open();

                cmd.ExecuteNonQuery();
                uRegjistrua = true;
            }
            return uRegjistrua;
        }

        public static bool UpdateLlojArkitekture(LlojiArkitektura llojiArkitektura)
        {
            bool uUpdate = false;
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblLlojiArkitektura_Update", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@prmLlojiArkitektura", llojiArkitektura.LlojiIArkitektures);
                conn.Open();

                cmd.ExecuteNonQuery();
                uUpdate = true;
            }
            return uUpdate;
        }

        public static bool FshijLlojArkitekture(LlojiArkitektura llojiArkitektura)
        {
            bool uFshij = false;
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblLlojiArkitektura_Update", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@prmLlojiArkitektura", llojiArkitektura.LlojiIArkitektures);
                conn.Open();

                cmd.ExecuteNonQuery();
                uFshij = true;
            }
            return uFshij;
        }

        public static List<LlojiArkitektura> ShfaqLlojinArkitektures()
        {
            List<LlojiArkitektura> listaLlojiArkitektura = new List<LlojiArkitektura>();
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblLlojiArkitektura_Select", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LlojiArkitektura llojiArkitekture = new LlojiArkitektura();
                   

                    llojiArkitekture.LlojiArkitekturaID = int.Parse(reader["@prmLlojiArkitekturaID"].ToString());
                    llojiArkitekture.LlojiIArkitektures = reader["@prmLlojiArkitektura"].ToString();
                    listaLlojiArkitektura.Add(llojiArkitekture);
                }
                return listaLlojiArkitektura;
            }
        }
    }
}