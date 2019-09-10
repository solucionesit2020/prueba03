using Core.Generico;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Estructura
{
   public class Repository<T> where T:BaseEntity
    {
        private readonly AxDbContext context;
        private IDbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(AxDbContext context)
        {
            this.context = context;

        }

        private IDbSet<T> Entities
        {
            get
            {
                if (entities == null)
                {
                    entities = context.Set<T>();
                }
                return entities;
            }
        }

        public T GetById(object id)
        {
            return Entities.Find(id);
        }

        public void Insert(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("Insert Null");
                }
                this.Entities.Add(entity);
                this.context.SaveChanges();
                
            }catch(DbEntityValidationException ex)
            {
                foreach(var err in ex.EntityValidationErrors)
                {
                    foreach(var errMsg in err.ValidationErrors)
                    {
                        errorMessage += string.Format("property: {0} Error: {1}", errMsg.PropertyName, errMsg.ErrorMessage);
                    }

                }

                throw new Exception(errorMessage, ex);

            }
        }

        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("Insert Null");
                }
               
                this.context.SaveChanges();

            }
            catch (DbEntityValidationException ex)
            {
                foreach (var err in ex.EntityValidationErrors)
                {
                    foreach (var errMsg in err.ValidationErrors)
                    {
                        errorMessage += string.Format("property: {0} Error: {1}", errMsg.PropertyName, errMsg.ErrorMessage);
                    }

                }

                throw new Exception(errorMessage, ex);

            }
        }

        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("Insert Null");
                }

                this.Entities.Remove(entity);
                this.context.SaveChanges();

            }
            catch (DbEntityValidationException ex)
            {
                foreach (var err in ex.EntityValidationErrors)
                {
                    foreach (var errMsg in err.ValidationErrors)
                    {
                        errorMessage += string.Format("property: {0} Error: {1}", errMsg.PropertyName, errMsg.ErrorMessage);
                    }

                }

                throw new Exception(errorMessage, ex);

            }

           
        }

        public virtual IEnumerable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }



    }
}
