using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using ArchidesArchitectureWeb.Models;

namespace ArchidesArchitectureWeb.DataAcc
{
    public class AccProjekti
    {
        public static bool ShtoProjekt(Projekti projekt)
        {
            bool uRegjistrua = false;
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblProjekti_Insert", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@prmTitulli", projekt.TitulliProjektit);
                cmd.Parameters.AddWithValue("@prmLokacioni", projekt.Lokacioni);
                cmd.Parameters.AddWithValue("@prmViti", projekt.Viti);
                cmd.Parameters.AddWithValue("@prmMadhesia", projekt.Madhesia);
                cmd.Parameters.AddWithValue("@prmStatusi", projekt.Statusi);
                cmd.Parameters.AddWithValue("@prmPershkrimi", projekt.Pershkrimi);
                cmd.Parameters.AddWithValue("@prmUploadTime", projekt.UploadTime);
                cmd.Parameters.AddWithValue("@prmAktiv", projekt.Aktiv);

                //foreignKeys
                cmd.Parameters.AddWithValue("@prmKategoriaID",projekt.KategoriaID);
                cmd.Parameters.AddWithValue("@prmUserID", projekt.UserID);
                conn.Open();

                cmd.ExecuteNonQuery();
                uRegjistrua = true;
            }
            return uRegjistrua;
        }

        public static bool UpdateProjekt(Projekti projekt)
        {
            bool uUpdate = false;
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblProjekti_Update", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@prmTitulli", projekt.TitulliProjektit);
                cmd.Parameters.AddWithValue("@prmLokacioni", projekt.Lokacioni);
                cmd.Parameters.AddWithValue("@prmViti", projekt.Viti);
                cmd.Parameters.AddWithValue("@prmMadhesia", projekt.Madhesia);
                cmd.Parameters.AddWithValue("@prmStatusi", projekt.Statusi);
                cmd.Parameters.AddWithValue("@prmPershkrimi", projekt.Pershkrimi);
                cmd.Parameters.AddWithValue("@prmUploadTime", projekt.UploadTime);
                cmd.Parameters.AddWithValue("@prmAktiv", projekt.Aktiv);

                //foreignKeys
                cmd.Parameters.AddWithValue("@prmKategoriaID", projekt.KategoriaID);
                cmd.Parameters.AddWithValue("@prmUserID", projekt.UserID);
                conn.Open();

                cmd.ExecuteNonQuery();
                uUpdate = true;
            }
            return uUpdate;
        }

        public static bool FshijProjekt(Projekti projekt)
        {
            bool uFshij = false;
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblProjekti_Delete", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@prmTitulli", projekt.TitulliProjektit);
                cmd.Parameters.AddWithValue("@prmLokacioni", projekt.Lokacioni);
                cmd.Parameters.AddWithValue("@prmViti", projekt.Viti);
                cmd.Parameters.AddWithValue("@prmMadhesia", projekt.Madhesia);
                cmd.Parameters.AddWithValue("@prmStatusi", projekt.Statusi);
                cmd.Parameters.AddWithValue("@prmPershkrimi", projekt.Pershkrimi);
                cmd.Parameters.AddWithValue("@prmUploadTime", projekt.UploadTime);
                cmd.Parameters.AddWithValue("@prmAktiv", projekt.Aktiv);

                //foreignKeys
                cmd.Parameters.AddWithValue("@prmKategoriaID", projekt.KategoriaID);
                cmd.Parameters.AddWithValue("@prmUserID", projekt.UserID);
                conn.Open();

                cmd.ExecuteNonQuery();
                uFshij = true;
            }
            return uFshij;


        }

       
        public static DataTable ShfaqProjekt()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("usp_tblProjekti_Select", conn);
                sda.Fill(dataTable);
            }
            return dataTable;
        }
    }
}