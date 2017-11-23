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
    public class KategoriaController : Controller
    {
        public static DataTable ShfaqKategoria()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("usp_tblKategoria_Select", conn);
                sda.Fill(dataTable);
            }
            return dataTable;
        }
        // GET: Kategoria
        public ActionResult Index()
        {
            return View();
        }

        // GET: Kategoria/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

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
        // GET: Kategoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kategoria/Create
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
        // GET: Kategoria/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Kategoria/Edit/5
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

        // GET: Kategoria/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Kategoria/Delete/5
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
