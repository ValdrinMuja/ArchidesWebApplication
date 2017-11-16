using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using ArchidesArchitectureWeb.Models;

namespace ArchidesArchitectureWeb.DataAcc
{
    public class AccKategoria
    {

        public static bool ShtoKategori(Kategoria kategoria)
        {
            bool uRegjistrua = false;
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblKategoria_Insert", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@prmKategoria", kategoria.EmriKategoria);             
                conn.Open();

                cmd.ExecuteNonQuery();
                uRegjistrua = true;
            }
            return uRegjistrua;
        }

        public static bool UpdateKategori(Kategoria kategoria)
        {
            bool uUpdate = false;
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblKategoria_Update", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@prmKategoria", kategoria.EmriKategoria);
                conn.Open();

                cmd.ExecuteNonQuery();
                uUpdate = true;
            }
            return uUpdate;
        }

        public static bool FshijKategori(Kategoria kategoria)
        {
            bool uFshij = false;
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblKategoria_Delete", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@prmKategoria", kategoria.EmriKategoria);
                conn.Open();

                cmd.ExecuteNonQuery();
                uFshij = true;
            }
            return uFshij;
        }

        public static List<Kategoria> ShfaqKategori()
        {
            List<Kategoria> listaKategoria = new List<Kategoria>();
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblKategoria_Select", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Kategoria kategoria = new Kategoria();
                    kategoria.KategoriaID = int.Parse(reader["@prmKategoriaID"].ToString());
                    kategoria.EmriKategoria = reader["@prmKategoria"].ToString();

                    listaKategoria.Add(kategoria);
                    listaKategoria.Add(kategoria);
                }
                return listaKategoria;
            }
        }
    }

}