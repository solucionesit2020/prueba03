using Core.Interfaces;
using Modelo;
using Servicio.Generico;
using Servicio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Clases
{
    public class EstudianteService : Service, IEstudianteService
    {

        public EstudianteService(IUnitOfWork uow):base(uow)
        {

        }
        public void AddEdditEstudiante(bool id, EstudianteModelo estudiante)
        {
            _IEstud.AddEditEstudiante(id, estudiante);
        }

        public void EliminarEstudiante(int id)
        {
            _IEstud.EliminarEstudiante(id);
        }

        public IEnumerable<EstudianteModelo> GeAllEstudiante()
        {
            return _IEstud.GetAllEstudiante();
        }

        public EstudianteModelo GetByIdEstudiante(int id)
        {
            return _IEstud.GetById(id);
        }
    }
}
