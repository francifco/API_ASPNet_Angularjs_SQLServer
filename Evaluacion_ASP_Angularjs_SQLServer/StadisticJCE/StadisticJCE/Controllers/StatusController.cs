using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StadisticJCE.Models;

namespace StadisticJCE.Controllers
{/// <summary>
 /// Contoller responsable de la gestion de los estatus.
 /// </summary>
    public class StatusController : Controller
    {
        /// <summary>
        /// Obtiene todos los estatus existentes en la BD.
        /// </summary>
        /// <returns>JSONArray: La lista de los estatus.</returns>
        [HttpGet]
        public JsonResult getAllStatus()
        {
            using (JCEEntities db = new JCEEntities())
            {
                var objectStatus = from p in db.TBM_Estatus
                                   orderby p.Estatus ascending
                                   select p;

                return Json(objectStatus, JsonRequestBehavior.AllowGet);
            }
        }
    }
}


