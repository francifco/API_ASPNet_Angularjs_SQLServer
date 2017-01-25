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
    public class SexController : Controller
    {
        /// <summary>
        /// Obtiene todos los sexos existentes en la BD.
        /// </summary>
        /// <returns>JSONArray: La lista de los sexos.</returns>
        [HttpGet]
        public JsonResult getAllSex()
        {
            using (JCEEntities db = new JCEEntities())
            {
                var objectSex = from p in db.TBM_Sexo
                                orderby p.sexo ascending
                                select p;

                return Json(objectSex, JsonRequestBehavior.AllowGet);
            }
        }
    }
}