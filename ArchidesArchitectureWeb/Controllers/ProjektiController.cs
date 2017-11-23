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
    public class ProjektiController : Controller
    {

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
        // GET: Projekti
        public ActionResult Index()
        {
            return View();
        }

        // GET: Projekti/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

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
                cmd.Parameters.AddWithValue("@prmKategoriaID", projekt.KategoriaID);
                cmd.Parameters.AddWithValue("@prmUserID", projekt.UserID);
                conn.Open();

                cmd.ExecuteNonQuery();
                uRegjistrua = true;
            }
            return uRegjistrua;
        }

        // GET: Projekti/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projekti/Create
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

        // GET: Projekti/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Projekti/Edit/5
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


        public static void FshijProjekt(Projekti projekt)
        {
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblProjekti_Delete", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@prmProjektiID", projekt.ProjektiID);
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        // GET: Projekti/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Projekti/Delete/5
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
