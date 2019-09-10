using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class EstudianteModelo
    {
        public int Id  { get; set; }
        [Display(Name ="Primer Nombre")]
        public string PrimerNombre { get; set; }
        [Display(Name = "Primer Apellido")]
        public string PrimerApellido { get; set; }
        [Display(Name = "Nombre Completo")]
        public string NombreCompleto { get; set; }
        [Display(Name = "Correo")]
        public string Email { get; set; }
        [Display(Name = "Identificación")]
        public string NoIdentificacion { get; set; }
    }
}
