using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
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

        public static bool FshijUserNeProjekt(ProjektiUser projektiUser)
        {
            bool uFshij = false;
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblProjektiUser_Delete", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //foreign keys
                cmd.Parameters.AddWithValue("@prmProjektiID", projektiUser.ProjektiID);
                cmd.Parameters.AddWithValue("@prmUserID", projektiUser.UserID);

                conn.Open();
                cmd.ExecuteNonQuery();
                uFshij = true;
            }
            return uFshij;
        }

        public static List<ProjektiUser> ShfaqProjektiMedia()
        {
            List<ProjektiUser> listaProjektiUser = new List<ProjektiUser>();
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblProjektiUser_Select", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProjektiUser projektiUser = new ProjektiUser();
                    projektiUser.ProjektiID = int.Parse(reader["@prmProjektiID"].ToString());
                    projektiUser.UserID = int.Parse(reader["@prmUserID"].ToString());
                }
                return listaProjektiUser;
            }
        }
    }
}