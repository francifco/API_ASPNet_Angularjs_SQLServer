﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StadisticJCE.Models;

namespace StadisticJCE.Controllers
{
    // <summary>
    /// Controller responsable de la gestion de la profesion. 
    /// </summary>
    public class ProfessionController : Controller
    {

        /// <summary>
        /// Obtiene todas las profesiones existentes en la BD.
        /// </summary>
        /// <returns>JSONArray: La lista de las profesiones.</returns>
        [HttpGet]
        public JsonResult getAllProfession()
        {
            using (JCEEntities db = new JCEEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return Json(db.TBM_Profesion.ToList(), JsonRequestBehavior.AllowGet);
            }
        }
    }
}