﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArchidesArchitectureWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult UserIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(ArchidesArchitectureWeb.Useri usermodel)
        {
            using (DBArchidesArchitetureEntities dbArchides = new DBArchidesArchitetureEntities())
            {
                var userDetails = dbArchides.Useris.Where(x => x.Username == usermodel.Username && x.Password == usermodel.Password).FirstOrDefault();
                if(userDetails == null)
                {
                    usermodel.LoginErrorMessage = "Invalid username or password.";
                    return View("UserIndex", usermodel);
                }
                else
                {
                    Session["userID"] = userDetails.UserID;
                    Session["username"] = userDetails.Username;
                    Session["userRol"] = userDetails.Roli.Roli1;
                    Session["foto"] = userDetails.Foto;
                    return RedirectToAction("Index", "Home");
                }          
            }               
        }

        public ActionResult UserDetail()
        {
            int userID = (int)Session["userID"];
            return RedirectToAction("Details/"+userID, "Useri");
        }

        public ActionResult UserEdit()
        {
            int userID = (int)Session["userID"];
            return RedirectToAction("Edit/" + userID, "Useri");
        }

        public ActionResult Logout()
        {
            //int userId = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("UserIndex", "Login");
        }
    }
}