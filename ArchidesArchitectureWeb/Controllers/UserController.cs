using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using ArchidesArchitectureWeb.Models;

namespace ArchidesArchitectureWeb.Controllers
{
    public class UserController : Controller
    {

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
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


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
        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public static void FshijUser(User user)
        {
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblUseri_Delete", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmUserID", user.UserID);
                conn.Open();
                cmd.ExecuteNonQuery();
                //Valdrin tu e testu jom
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
