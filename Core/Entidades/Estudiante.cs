using Core.Generico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entidades
{
   public  class Estudiante:BaseEntity
    {
        public string PrimerNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string Email { get; set; }
        public string NoIdentificacion { get; set; }

    }
}
