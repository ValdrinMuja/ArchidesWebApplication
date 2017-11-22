using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using ArchidesArchitectureWeb.Models;

namespace ArchidesArchitectureWeb.DataAcc
{
    public class AccUser
    {
        public static bool ShtoUser(User user)
        {
            bool uRegjistrua = false;
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblUseri_Insert", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@prmEmri", user.Emri);
                cmd.Parameters.AddWithValue("@prmMbiemri", user.Mbiemri);
                cmd.Parameters.AddWithValue("@prmGjinia", user.Gjinia);
                cmd.Parameters.AddWithValue("@prmVendlindja", user.Vendlindja);
                cmd.Parameters.AddWithValue("@prmDatelindja", user.Datelindja);
                cmd.Parameters.AddWithValue("@prmEmail", user.Email);
                cmd.Parameters.AddWithValue("@prmTelefoni", user.Telefoni);
                cmd.Parameters.AddWithValue("@prmUsername", user.Username);
                cmd.Parameters.AddWithValue("@prmPassword", user.Password);
                cmd.Parameters.AddWithValue("@prmPershkrimi", user.PershkrimiPerUser);
                cmd.Parameters.AddWithValue("@prmShkollimi", user.Shkollimi);
                cmd.Parameters.AddWithValue("@prmPergaditjaProfesionale", user.PergaditjaProfesionale);
                cmd.Parameters.AddWithValue("@prmFoto", user.FotoPath);

                //foreign key
                cmd.Parameters.AddWithValue("@prmRoliID", user.RoliID);

                conn.Open();
                cmd.ExecuteNonQuery();
                uRegjistrua = true;
            }
            return uRegjistrua;
        }

        public static bool UpdateUser(User user)
        {
            bool uUpdate = false;
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblUseri_Update", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@prmEmri", user.Emri);
                cmd.Parameters.AddWithValue("@prmMbiemri", user.Mbiemri);
                cmd.Parameters.AddWithValue("@prmGjinia", user.Gjinia);
                cmd.Parameters.AddWithValue("@prmVendlindja", user.Vendlindja);
                cmd.Parameters.AddWithValue("@prmDatelindja", user.Datelindja);
                cmd.Parameters.AddWithValue("@prmEmail", user.Email);
                cmd.Parameters.AddWithValue("@prmTelefoni", user.Telefoni);
                cmd.Parameters.AddWithValue("@prmUsername", user.Username);
                cmd.Parameters.AddWithValue("@prmPassword", user.Password);
                cmd.Parameters.AddWithValue("@prmPershkrimi", user.PershkrimiPerUser);
                cmd.Parameters.AddWithValue("@prmShkollimi", user.Shkollimi);
                cmd.Parameters.AddWithValue("@prmPergaditjaProfesionale", user.PergaditjaProfesionale);
                cmd.Parameters.AddWithValue("@prmFoto", user.FotoPath);

                //foreign key
                cmd.Parameters.AddWithValue("@prmRoliID", user.RoliID);

                conn.Open();
                cmd.ExecuteNonQuery();
                uUpdate = true;
            }
            return uUpdate;
        }

        public static void FshijUser(User user)
        {
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblUseri_Delete", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmUserID", user.UserID);
                //Bla Bla
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

     


        public static DataTable ShfaqUser()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("usp_tblUseri_Select", conn);
                sda.Fill(dataTable);
            }
            return dataTable;
        }
    }
}