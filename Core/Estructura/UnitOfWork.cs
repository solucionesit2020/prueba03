using Core.Generico;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Estructura
{
    public class UnitOfWork : IUnitOfWork
    {
        private AxDbContext context;
        private Dictionary<string, object> repositorio;


        public UnitOfWork(AxDbContext context)
        {
            this.context = context;
        }

        public UnitOfWork()
        {
            context = new AxDbContext();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Repository<T> Repository<T>() where T : BaseEntity
        {

            if (repositorio == null)
            {
                repositorio = new Dictionary<string, object>();
            }
            var type = typeof(T).Name;

            if (!repositorio.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), context);
                repositorio.Add(type, repositoryInstance);
            }
            return (Repository<T>)repositorio[type];


        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
