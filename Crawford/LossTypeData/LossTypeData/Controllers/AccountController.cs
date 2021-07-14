using LossTypeData.App_Data;
using LossTypeData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LossTypeData.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            if (Session["idUser"] != null && Session["UserName"] != null)
            {
                return RedirectToAction("Index", "LossType");
            }
            return View("Login");
        }
        /// <summary>
        /// Verify credencials
        /// </summary>
        /// <param name="acc">Object from login</param>
        /// <returns>to list view or denied access</returns>
        [HttpPost]
        public ActionResult Verify(Account model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Login",model);

                }
                
                Account login = null;
                using (InterviewEntities db = new InterviewEntities())
                {
                        login = (from x in db.dev_User                              
                               where x.UserName == model.UserName && x.Password == model.Password && x.Active == true
                                     select new Account
                               {
                                   UserName = x.UserName,
                                   DisplayName = x.DisplayName,
                                   Active = x.Active
                               }).SingleOrDefault();
                   
                }  

               if (login != null)
                  {
                    Session["idUser"] = login.Id;
                    Session["UserName"] = login.UserName;
                    return RedirectToAction("Index","LossType");
                }
               
                return View("Login");
               

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


      
        public ActionResult Logout()
        {

            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();

            return RedirectToAction("Login", "Account");
        }
       
    }
}