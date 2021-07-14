using LossTypeData.App_Data;
using LossTypeData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LossTypeData.Controllers
{
    public class LossTypeController : Controller
    {
        // GET: LossType
        /// <summary>
        /// Get Loss Type
        /// </summary>
        /// <returns>View with Loss Type List</returns>
        public ActionResult Index()
        {
            if(Session["idUser"] == null || Session["UserName"] == null) {
                return RedirectToAction("Login", "Account");
            }

            

            try
            {
               List<LossType> lossType = new List<LossType>();
                using (InterviewEntities db = new InterviewEntities())
                {
                    lossType = (from x in db.dev_LossType                             
                             select new LossType
                             {
                                 LossTypeID = x.LossTypeID,
                                 LossTypeCode = x.LossTypeCode,
                                 LossTypeDescription = x.LossTypeDescription
                             }).ToList();
                }

               
                return View(lossType);

            }
            catch (Exception ex)
            {

                return View("Error: "+ex.Message);
            }
         
        }
    }
}