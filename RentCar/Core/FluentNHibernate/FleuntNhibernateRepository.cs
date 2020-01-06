using NHibernate;
using RentCar.Core.Abstract;
using RentCar.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentCar.Core
{
    public class FleuntNhibernateRepository<TEntity> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
    {
        public void Add(TEntity entity)
        {
            using (ISession _session = NHibernateHelper.OpenSession()) {
                using (var _transaction = _session.BeginTransaction()) {
                    try
                    {
                        _session.Save(entity);
                        _transaction.Commit();
                    }catch(Exception msg)
                    {
                        if(!_transaction.WasCommitted)
                            _transaction.Rollback();
                        throw new Exception("Can not insert data: " + msg);
                    }
                }
            };
        }

        public void Delete(TEntity entity)
        {
            using (ISession _session = NHibernateHelper.OpenSession())
            {
                using (var _transaction = _session.BeginTransaction())
                {

                    try
                    {
                        //_session.Delete(entity);
                        _session.Update(entity);
                        _transaction.Commit();
                    }
                    catch (Exception msg)
                    {
                        if (!_transaction.WasCommitted)
                            _transaction.Rollback();

                        throw new Exception("Can not delete : " + msg);
                    }
                }
            };
        }

        public TEntity Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter)
        {

            using (ISession _session = NHibernateHelper.OpenSession())
            {     
                return _session.Get<TEntity>(filter);
            };
            
        }

        public IList<TEntity> GetList(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null)
        {
            using (ISession _session = NHibernateHelper.OpenSession())
            {
              
                return _session.Query<TEntity>().ToList(); 

            }
        }

        public void Update(TEntity entity)
        {
            using (ISession _session = NHibernateHelper.OpenSession())
            {
                using (var _transaction = _session.BeginTransaction())
                {
                    try { 
                        _session.Update(entity);
                        _transaction.Commit();
                    }catch (Exception msg){

                        if (!_transaction.WasCommitted)
                            _transaction.Rollback();

                        throw new Exception("Can not delete : " + msg);
                    }
                }
            }

        }
    }
}