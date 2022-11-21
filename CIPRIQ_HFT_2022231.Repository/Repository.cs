using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPRIQ_HFT_2022231.Repository
{
        public abstract class Repository<T> : IRepository<T> where T : class
        {
            protected PhoneDbContext ptx;

            protected Repository(PhoneDbContext ptx)
            {
                this.ptx = ptx;
            }

            public void Create(T item)
            {
                ptx.Set<T>().Add(item);
                ptx.SaveChanges();
            }

            public void Delete(int id)
            {
                ptx.Set<T>().Remove(Read(id));
                ptx.SaveChanges();
            }

            public IQueryable<T> ReadAll()
            {
                return ptx.Set<T>();
            }
            public abstract T Read(int id);

            public abstract void Update(T item);

        }
    }



