using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using ArchidesArchitectureWeb.Models;

namespace ArchidesArchitectureWeb.DataAcc
{
    public class AccRoli
    {
        public static void ShtoRol(Roli roli)
        {
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblRoli_Insert", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@prmRoli", roli.LlojiIRolit);        
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateRol(Roli roli)
        {
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblRoli_Update", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmRoliID", roli.RoliID);
                cmd.Parameters.AddWithValue("@prmRoli", roli.LlojiIRolit);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static bool FshijRol(Roli roli)
        {
            bool uFshij = false;
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblRoli_Fshij", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmLlojiIRolit", roli.LlojiIRolit);
                conn.Open();
                cmd.ExecuteNonQuery();
                uFshij = true;
            }
            return uFshij;
        }

        public static DataTable ShfaqRol()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("usp_tblRoli_Select", conn);
                sda.Fill(dataTable);
            }
            return dataTable;
        }

        public static Roli MerrRol(int id)
        {
            Roli roli = new Roli();
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("usp_tblRoli_SelectById", conn);
                sda.SelectCommand.Parameters.AddWithValue("@prmRoliID", id);
                sda.Fill(dataTable);
            }
            if (dataTable.Rows.Count==1)
            {
                roli.RoliID = int.Parse(dataTable.Rows[0][0].ToString());
                roli.LlojiIRolit = dataTable.Rows[0][1].ToString();
                return roli;
            }
            return null;
        }
    }
}