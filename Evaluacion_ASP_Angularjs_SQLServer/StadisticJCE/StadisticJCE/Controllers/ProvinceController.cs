using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StadisticJCE.Models;

namespace StadisticJCE.Controllers
{
    /// <summary>
    /// Contoller responsable de la gestion de las provincias.
    /// </summary>
    public class ProvinceController : Controller
    {
        /// <summary>
        /// Obtiene todas las provincias existentes en la BD.
        /// </summary>
        /// <returns>JSONArray: La lista de las provincias.</returns>
        [HttpGet]
        public JsonResult getAllProvinces()
        {
            using (JCEEntities db = new JCEEntities())
            {
                var objectProvince = from p in db.TBM_Provincia
                                     orderby p.provincia ascending
                                     select p;

                return Json(objectProvince, JsonRequestBehavior.AllowGet);
            }
        }
    }
}