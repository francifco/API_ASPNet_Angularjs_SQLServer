using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StadisticJCE.Models;
using StadisticJCE.Entities;
using StadisticJCE.Helpers;


namespace StadisticJCE.Controllers
{
    /// <summary>
    /// Contoller responsable del manejo del ciudadano.
    /// </summary>
    public class CitizenController : Controller
    {

        /// <summary>
        /// Obtiene el listado de ciudadanos deacierdo a la paginacion
        /// </summary>
        /// <param name="page"></param>
        /// <param name="perPage"></param>
        /// <returns></returns>
        // GET: Citizen/getCitizens/pageNumber/pageSize
        [HttpGet]
        public JsonResult fetchCitizens(int pageNumber, int pageSize)
        {
            using (JCEEntities db = new JCEEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
/*
                var objectCitizens = from citizen in db.TBM_Ciudadanos
                                     select citizen;


               /* List<TBM_Ciudadanos> list = objectCitizens.OrderBy(s => s.nombres)
                    .Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
*/
                List<Citizen> listCitizen = CitizenParser.toListCitizen(db.TBM_Ciudadanos.ToList());

                return Json(listCitizen, JsonRequestBehavior.AllowGet);
            }
        }


        /// <summary>
        /// Devuelve la estadistica actual del recibido 
        /// </summary>
        /// <param name="citizens">List<object>: listado de ciudadanos encontrados</param>
        /// <returns>object: el listado de la estadistica</returns>
        private object getStadistic(List<Citizen> citizens)
        {
            //debuguear esta parte
            int totalCitizen = citizens.Count;
            int male = 0, female = 0, voteAvailable = 0;
            object stadisticResult = new object();

            for (int i = 0; i < citizens.Count; i++)
            {
                if (citizens[i].idGender == 2)
                {
                    male++;
                }

                else
                {
                    female++;
                }

                if (isAliveAndNoMilitar(citizens[i]))
                {
                    voteAvailable++;
                }

            }

            male = (male / totalCitizen) * 100;
            female = (female / totalCitizen) * 100;
            voteAvailable = (voteAvailable / totalCitizen) * 100;

            stadisticResult = (
                new
                {
                    total = totalCitizen,
                    porcentMale = male,
                    porcentFemale = female,
                    porcentAvailable = voteAvailable
                });

            return stadisticResult;
        }

        /// <summary>
        /// Agrega a un ciudadano en la BD.
        /// </summary>
        /// <param name="citizenParams">Citizen: objeto representante del ciudadano.</param>
        /// <returns>JsonObject: Si fue agregado con exito.</returns>
        [HttpPost]
        public string addCitizen(Citizen citizenParams)
        {
            
            if (citizenParams != null)
            {
                if (validateIdenty(citizenParams.identify))
                {
                    if (notExist(citizenParams.identify))
                    {
                        /// se parcea por el tipo de datos de la fecha de nacimiento y seperacion
                        /// del full lastname a apellido1 y apellido2.
                        /// cambio de tipologia hacia los foreingkey (string) a (int)
                        TBM_Ciudadanos mCitizen = CitizenParser.toModelCitizen(citizenParams);

                        using (JCEEntities db = new JCEEntities())
                        {
                            TBM_Ciudadanos _citizen = new TBM_Ciudadanos();
                            db.TBM_Ciudadanos.Add(mCitizen);
                            db.SaveChanges();
                            return "El ciudadano fue agregado exitosamente.";
                        }
                    }
                    else
                    {
                        return "El ciudadano no fue gragado. Ya Existe en la base de datos.";
                    }
                    
                }
                else
                {
                    return "Cedula invalida. Verifique el numero de cedula.";
                }
            }
            
            return "No se permiten campos vacios."; 
        }


        /// <summary>
        /// veriica si existe un ciudadano en la BD.
        /// </summary>
        /// <param name="identy">string: cedula del ciudadano.</param>
        /// <returns>true: si no existe, false: si existe</returns>
        private bool notExist(string identy)
        {
            using (JCEEntities db = new JCEEntities())
            {
                var objectCitizen = from c in db.TBM_Ciudadanos
                                    where c.cedula == identy
                                    select c;
                if (objectCitizen != null || objectCitizen.Count() == 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determina si el ciudadano esta vivo.
        /// </summary>
        /// <param name="citizen">Object: objeto respresente del ciudadano</param>
        /// <returns>true: si esta vivo, false: si no</returns>
        private bool isAliveAndNoMilitar(object citizen)
        {
            string status = citizen.GetType().GetProperty("estatus").ToString().ToLower();
            string profession = citizen.GetType().GetProperty("profession").ToString().ToLower();

            if (status.Equals("fallecido"))
            {
                return false;
            }

            if (profession.Equals("militar"))
            {
                return false;
            }

            return true;
        }



        /// <summary>
        /// Valida si un cedula esta correcta o no.
        /// </summary>
        /// <param name="identy">string: numero de cedula</param>
        /// <returns>true: si es valida, false: si no es correcta.</returns>
        private bool validateIdenty(string identy)
        {
            int sum = 0;

            if (identy == null || identy.Length != 11)
            {
                return false;
            }
            else
            {

                for (int i = 0; i < 10; i++)
                {
                    int mul = (identy[i] - '0') * (i % 2 + 1);
                    {
                        while (mul > 0)
                        {
                            sum += mul % 10;
                            mul /= 10;
                        }
                    }
                }

                int div = (sum + 9) / 10 * 10;
                int digit = div - sum;

                return (digit == identy[10] - '0');
            }
        }


    }
}