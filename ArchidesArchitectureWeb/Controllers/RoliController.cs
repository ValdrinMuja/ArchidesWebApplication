﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using ArchidesArchitectureWeb.Models;


namespace ArchidesArchitectureWeb.Controllers
{
    public class RoliController : Controller
    {
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
        // GET: Roli
        [HttpGet]
        public ActionResult Index()
        {
            return View(ShfaqRol());
        }

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
        // GET: Roli/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Roli());
        }

        // POST: Roli/Create
        [HttpPost]
        public ActionResult Create(Models.Roli roli)
        {
            try
            {
                // TODO: Add insert logic here
                ShtoRol(roli);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
            if (dataTable.Rows.Count == 1)
            {
                roli.RoliID = int.Parse(dataTable.Rows[0][0].ToString());
                roli.LlojiIRolit = dataTable.Rows[0][1].ToString();
                return roli;
            }
            return null;
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
        // GET: Roli/Edit/5
        public ActionResult Edit(int id)
        {
            if (MerrRol(id)!=null)
            {
                return View(MerrRol(id));
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        // POST: Roli/Edit/5
        [HttpPost]
        public ActionResult Edit(Models.Roli roli)
        {
            try
            {
                // TODO: Add update logic here
                UpdateRol(roli);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public static void FshijRol(Roli roli)
        {
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_tblRoli_Fshij", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmLlojiIRolit", roli.LlojiIRolit);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        // GET: Roli/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Roli/Delete/5
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
