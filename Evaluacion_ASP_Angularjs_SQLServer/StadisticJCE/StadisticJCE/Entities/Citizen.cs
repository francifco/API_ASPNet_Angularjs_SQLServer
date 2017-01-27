using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadisticJCE.Entities
{
     /// <summary>
        /// clase representante e la entidad ciudadano.
        /// </summary>
        public class Citizen
        {
            public int id { get; set; }
            public string name { get; set; }
            public string identify { get; set; }
            public string lastName { get; set; }
            public string gender { get; set; }
            public string birthDate { get; set; }
            public int idProfession { get; set; }
            public int idProvince { get; set; }
            public int idStatus { get; set; }
            public string sector { get; set; }
            public int houseNumber { get; set; }
            public string street { get; set; }


    }

}

