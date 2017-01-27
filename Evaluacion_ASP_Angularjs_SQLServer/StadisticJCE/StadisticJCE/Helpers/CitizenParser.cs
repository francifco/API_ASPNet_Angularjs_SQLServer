using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StadisticJCE.Entities;
using StadisticJCE.Models;

namespace StadisticJCE.Helpers
{
    /// <summary>
    /// Helper para el parseo de la data de la BD a la entidad ciudadano.
    /// </summary>
    static class CitizenParser
    {
        /// <summary>
        /// Parsea el listado de los modelo de la capa de la base de datos a el listado
        /// de la entidad Citizen
        /// </summary>
        /// <param name="list">List: listado de del modelo de ciudadano</param>
        /// <returns>listado de la entidad ciudadano</returns>
        static public List<Citizen> toListCitizen(List<TBM_Ciudadanos> list)
        {
            List<Citizen> listCitizen = new List<Citizen>();

            for (int i = 0; i < list.Count; i++)
            {
                Citizen citizen = new Citizen();

                citizen.id = list[i].idCiudadano;
                citizen.name = list[i].nombres;
                citizen.lastName1 = list[i].apellido1;
                citizen.lastName2 = list[i].appellido2;
                citizen.idProfession = list[i].idProfesion;
                citizen.idProvince = list[i].idProvincia;
                citizen.idGender = list[i].idSexo;
                citizen.identify = list[i].cedula;
                citizen.idStatus = list[i].idEstatus;
                citizen.sector = list[i].sector;
                citizen.birthDate = list[i].fechaNac.ToString();

                listCitizen.Add(citizen);
            }

            return listCitizen;
        }

        static public TBM_Ciudadanos toModelCitizen(Citizen citizenParams)
        {
            TBM_Ciudadanos mCitizen = new TBM_Ciudadanos();

            mCitizen.cedula = citizenParams.identify;
            mCitizen.nombres = citizenParams.name;
            mCitizen.apellido1 = citizenParams.lastName1;
            mCitizen.apellido1 = citizenParams.lastName2;
            mCitizen.calle = citizenParams.street;
            mCitizen.fechaNac = Convert.ToDateTime(citizenParams.birthDate);
            mCitizen.idEstatus = citizenParams.idStatus;
            mCitizen.idProvincia = citizenParams.idProvince;
            mCitizen.idProfesion = citizenParams.idProfession;
            mCitizen.idSexo = citizenParams.idGender;
            mCitizen.numero = Convert.ToInt32(citizenParams.houseNumber);

            return mCitizen;

        }

    }
}
