using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interfaces
{
   public interface IEstudianteRep
    {
        IEnumerable<EstudianteModelo> GetAllEstudiante();
        EstudianteModelo GetById(int id);
        void AddEditEstudiante(bool id, EstudianteModelo estudiante);
        void EliminarEstudiante(int id);
    }
}
