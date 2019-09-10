using Core.Mapeo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Generico
{
    public class AxDbContext:DbContext
    {

        public AxDbContext():base("name=AxDbContext")
        {

        }

        public new IDbSet<T> Set<T>() where T : BaseEntity
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EstudianteMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
