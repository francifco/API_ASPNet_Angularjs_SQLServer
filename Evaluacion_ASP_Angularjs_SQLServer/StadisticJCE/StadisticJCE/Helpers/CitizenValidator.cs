using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StadisticJCE.Entities;

namespace StadisticJCE.Helpers
{
    /// <summary>
    /// clase responsable de validar las propiedades del ciudadano.
    /// </summary>
    static public class CitizenValidator
    {
        /// <summary>
        /// verifica si alguna propiedad del ciudadanos es nulla o 0.
        /// </summary>
        /// <param name="citizen">objeto: respresntante del ciudadano.</param>
        /// <returns>true: si alguno es nullo o cero, false: si no.</returns>
        static public bool somePropertiesNull(Citizen citizen)
        {
            if (citizen.name == null) { return true; }
            if (citizen.lastName == null) { return true; }
            if (citizen.idProfession == 0) { return true; }
            if(citizen.idProvince == 0) { return true; }
            if (citizen.gender == null) { return true; }
            if(citizen.identify == null) { return true; }
            if(citizen.idStatus == 0) { return true; }
            if (citizen.sector == null) { return true; }
            if (citizen.birthDate == null) { return true; }

            return false;
        }


        /// <summary>
        /// Valida si un cedula esta correcta o no.
        /// </summary>
        /// <param name="identy">string: numero de cedula</param>
        /// <returns>true: si es valida, false: si no es correcta.</returns>
        static public bool validateIdenty(string identy)
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

                bool valid = (digit == Convert.ToInt32((identy[10] - '0')));


                return valid;

            }
        }


    }
}