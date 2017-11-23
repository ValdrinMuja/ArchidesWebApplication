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
    public class LlojiArkitekturaController : Controller
    {
        public static DataTable ShfaqLlojinArkitektures()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("usp_tblLlojiArkitektura_Select", conn);
                sda.Fill(dataTable);
            }
            return dataTable;
        }
        // GET: LlojiArkitektura
        public ActionResult Index()
        {
            return View();
        }

        // GET: LlojiArkitektura/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public static bool ShtoLlojArkitekture(LlojiArkitektura llojiArkitektura)
        {
            bool uRegjistrua = false;
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblLlojiArkitektura_Insert", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@prmLlojiArkitektura", llojiArkitektura.LlojiIArkitektures);
                conn.Open();

                cmd.ExecuteNonQuery();
                uRegjistrua = true;
            }
            return uRegjistrua;
        }

        // GET: LlojiArkitektura/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LlojiArkitektura/Create
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
        // GET: LlojiArkitektura/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LlojiArkitektura/Edit/5
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

        // GET: LlojiArkitektura/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LlojiArkitektura/Delete/5
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
