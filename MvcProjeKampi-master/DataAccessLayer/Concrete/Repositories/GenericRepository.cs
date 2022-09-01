using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        //context sınıfımdan nesne türeterek işlem yapacağım. 
        Context c = new Context();
        // _object t değerine karşılık gelen sınıfı tutuyor.
        DbSet<T> _object;
        //aşağıda yapıcı metot(Constructors) tanımladığım field a değer atıyorum. atamamla
        //artık object isimli field ım dışarıdan gönderilen entity neyse o olacak.
        public GenericRepository()
        {
            _object = c.Set<T>();
        }
        public void Delete(T p)
        {
            var deletedEntity = c.Entry(p);
            deletedEntity.State = EntityState.Deleted;            
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
            //singleordefault bir dizide ya da listede sadece 1 değer göndermek
            //için kullanılan linq'dur. mesela id si 5 olan şeyi döndür dediğimde kullanıyorum.
        }

        public List<T> List()
        {
            return _object.ToList();
        }
        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }
        public void Update(T p)
        {
            var updatedEntity = c.Entry(p);
            updatedEntity.State = EntityState.Modified;
            c.SaveChanges();
        }

        public void İnsert(T p)
        {
            var addedEntity = c.Entry(p);
            addedEntity.State = EntityState.Added;            
            c.SaveChanges();
        }
    }
}
