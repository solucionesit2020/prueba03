using Core.Entidades;
using Core.Estructura;
using Core.Interfaces;
using Modelo;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Clases
{
    public class EstudianteRep : IEstudianteRep
    {
        private IUnitOfWork _uow;
        private Repository<Estudiante> _estRepo;
        public EstudianteRep(IUnitOfWork uow)
        {
            _uow = uow;
            _estRepo = _uow.Repository<Estudiante>();
        }



        public void AddEditEstudiante(bool isNew, EstudianteModelo estudiante)
        {
            var estModel = new Estudiante {
              PrimerNombre = estudiante.PrimerNombre,
              PrimerApellido = estudiante.PrimerApellido,
              Email = estudiante.Email,
              NoIdentificacion = estudiante.NoIdentificacion
            };

            if (isNew)
            {
                estModel.FechaInsert = DateTime.UtcNow;
                estModel.FechaModificacion = DateTime.UtcNow;
                _estRepo.Insert(estModel);

            }
            else
            {

                var updateModel = _estRepo.GetById((int)estudiante.Id);

                updateModel.FechaModificacion = DateTime.UtcNow;
                updateModel.PrimerNombre = estudiante.PrimerNombre;
                updateModel.PrimerApellido = estudiante.PrimerApellido;
                updateModel.Email = estudiante.Email;
                updateModel.NoIdentificacion = estudiante.NoIdentificacion;
                _estRepo.Update(updateModel);


            }




        }

        public void EliminarEstudiante(int id)
        {
            var estudianteDel = _estRepo.GetById(id);
            _estRepo.Delete(estudianteDel);
        }

        public IEnumerable<EstudianteModelo> GetAllEstudiante()
        {
            var estudiantes = _estRepo.Table.AsEnumerable().Select(x => new EstudianteModelo {
                Id = x.Id,
                NombreCompleto = $"{x.PrimerNombre} {x.PrimerApellido}",
                   Email = x.Email,
                   NoIdentificacion = x.NoIdentificacion
            
            });
            return estudiantes;
        }

        public EstudianteModelo GetById(int id)
        {

            var estudiante = _estRepo.GetById(id);

            var model = new EstudianteModelo
            {
                PrimerNombre = estudiante.PrimerNombre,
                PrimerApellido = estudiante.PrimerApellido,
                Email = estudiante.Email,
                NoIdentificacion = estudiante.NoIdentificacion
                
            };

            return model;


        }
    }
}
