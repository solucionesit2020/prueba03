using Core.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapeo
{
    public class EstudianteMap:EntityTypeConfiguration<Estudiante>
    {

        public EstudianteMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.PrimerNombre).IsRequired();
            Property(t => t.PrimerApellido).IsRequired();
            Property(t => t.Email).IsRequired();
            Property(t => t.NoIdentificacion).IsRequired();
            ToTable("TB_Estudiante");



    }


    }
}
