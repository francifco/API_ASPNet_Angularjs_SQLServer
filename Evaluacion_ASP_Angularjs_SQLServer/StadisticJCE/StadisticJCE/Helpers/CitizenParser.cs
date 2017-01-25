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
                citizen.idSex = list[i].idSexo;
                citizen.identify = list[i].cedula;
                citizen.idStatus = list[i].idEstatus;
                citizen.sector = list[i].sector;
                citizen.birthDate = list[i].fechaNac.ToString();

                listCitizen.Add(citizen);
            }

            return listCitizen;
        }
        
    }
}
