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
    public class LajmiController : Controller
    {
        public static DataTable ShfaqLajm()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("usp_tblLajmi_Select", conn);
                sda.Fill(dataTable);
            }
            return dataTable;
        }
        // GET: Lajmi
        public ActionResult Index()
        {
            return View();
        }

        // GET: Lajmi/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        public static bool ShtoLajm(Lajmi lajm)
        {
            bool uRegjistrua = false;
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblLajmi_Insert", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //foreign keys
                cmd.Parameters.AddWithValue("@prmFotoPath", lajm.FotoPath);
                cmd.Parameters.AddWithValue("@prmUploadTime", lajm.UploadTime);
                cmd.Parameters.AddWithValue("@prmTitulli", lajm.Titulli);
                cmd.Parameters.AddWithValue("@prmPershkrimi", lajm.Pershkrimi);
                cmd.Parameters.AddWithValue("@prmUserID", lajm.UserID);
                conn.Open();

                cmd.ExecuteNonQuery();
                uRegjistrua = true;
            }
            return uRegjistrua;
        }

        // GET: Lajmi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lajmi/Create
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

        // GET: Lajmi/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Lajmi/Edit/5
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
        // GET: Lajmi/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Lajmi/Delete/5
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
