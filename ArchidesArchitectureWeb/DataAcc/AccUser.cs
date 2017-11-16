using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
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

        public static bool FshijUser(User user)
        {
            bool uFshij = false;
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblUseri_Delete", conn);
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
                uFshij = true;
            }
            return uFshij;
        }

        public static List<User> ShfaqUser()
        {
            List<User> listaUsers = new List<User>();
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblUseri_Select", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User();                
                    user.UserID = int.Parse(reader["@prmUserID"].ToString());
                    user.Emri = reader["@prmEmri"].ToString();
                    user.Mbiemri = reader["@prmMbiemri"].ToString();
                    user.Gjinia = reader["@prmGjinia"].ToString();
                    user.Vendlindja = reader["@prmVendlindja"].ToString();
                    user.Datelindja = DateTime.Parse(reader["@prmDatelindja"].ToString());
                    user.Email = reader["@prmEmail"].ToString();
                    user.Telefoni = reader["@prmTelefoni"].ToString();
                    user.Username = reader["@prmUsername"].ToString();
                    user.Password = reader["@prmPassword"].ToString();
                    user.PershkrimiPerUser = reader["@prmPershkrimi"].ToString();
                    user.Shkollimi = reader["@prmShkollimi"].ToString();
                    user.PergaditjaProfesionale = reader["@prmPergaditjaProfesionale"].ToString();
                    user.FotoPath = reader["@prmFoto"].ToString();
                    user.RoliID = int.Parse(reader["@prmRoliID"].ToString());
                    user.Aktiv = bool.Parse(reader["@prmAktiv"].ToString());
                    
                }
                return listaUsers;
            }
        }
    }
}