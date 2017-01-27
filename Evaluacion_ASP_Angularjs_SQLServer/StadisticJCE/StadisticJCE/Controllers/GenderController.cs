using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StadisticJCE.Models;

namespace StadisticJCE.Controllers
{

    /// <summary>
    /// Contoller responsable de la gestion de los sexos.
    /// </summary>
    public class GenderController : Controller
    {
        /// <summary>
        /// Obtiene todos los generos existentes en la BD.
        /// </summary>
        /// <returns>JSONArray: La lista de los generos.</returns>
        [HttpGet]
        public JsonResult getAllGender()
        {
            using (JCEEntities db = new JCEEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return Json(db.TBM_Sexo.ToList(), JsonRequestBehavior.AllowGet);
            }
        }
    }
}