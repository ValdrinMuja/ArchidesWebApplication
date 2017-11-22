using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using ArchidesArchitectureWeb.Models;

namespace ArchidesArchitectureWeb.DataAcc
{
    public class AccProjektiUser
    {
        public static bool ShtoUserNeProjekt(ProjektiUser projektiUser)
        {
            bool uRegjistrua = false;
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblProjektiUser_Insert", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //foreign keys
                cmd.Parameters.AddWithValue("@prmProjektiID",projektiUser.ProjektiID);
                cmd.Parameters.AddWithValue("@prmUserID", projektiUser.UserID); 
        
                conn.Open();
                cmd.ExecuteNonQuery();
                uRegjistrua = true;
            }
            return uRegjistrua;
        }

        public static bool UpdateUserNeProjekt(ProjektiUser projektiUser)
        {
            bool uUpdate = false;
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblProjektiUser_Update", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //foreign keys
                cmd.Parameters.AddWithValue("@prmProjektiID", projektiUser.ProjektiID);
                cmd.Parameters.AddWithValue("@prmUserID", projektiUser.UserID);

                conn.Open();
                cmd.ExecuteNonQuery();
                uUpdate = true;
            }
            return uUpdate;
        }

        public static void FshijUserNeProjekt(ProjektiUser projektiUser)
        {
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblProjektiUser_Delete", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmProjektiUserID", projektiUser.ProjektiUserID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        

        public static DataTable ShfaqProjektiUser()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("usp_tblProjektiUser_Select", conn);
                sda.Fill(dataTable);
            }
            return dataTable;
        }
    }
}