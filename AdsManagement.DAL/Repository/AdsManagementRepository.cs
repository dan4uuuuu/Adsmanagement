using AdsManagement.DAL.Models;
using AdsManagement.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace AdsManagement.DAL.Context
{
    public abstract class AdsManagementRepository<EntityType> : IAdsManagementRepository <EntityType>
        where EntityType : ModelBase, new()
    {
        public AdsManagementContext DbContext { get; set; }

        public AdsManagementRepository(AdsManagementContext context)
        {
            DbContext = context;
        }

     
        protected DbSet<EntityType> EntitySet
        {
            get
            {
                return DbContext.Set<EntityType>();
            }
        }

        //Consider introducing a string version for the object graph:
        //http://stackoverflow.com/questions/38312437/can-a-string-based-include-alternative-be-created-in-entity-framework-core
        public EntityType Load(int Id, params Expression<Func<EntityType, object>>[] includeGraph)
        {
            IQueryable<EntityType> query = EntitySet;
            foreach (var includeGraphItem in includeGraph)
            {
                query = query.Include(includeGraphItem);
            }
            try
            {
                return query.First(u => u.Id == Id);

            }
            catch (InvalidOperationException ex)
            {
                var exception = ex;
                return new EntityType();
            }

        }

        public IList<EntityType> LoadList(Expression<Func<EntityType, bool>> predicate)
        {
            return LoadList(null, null, predicate);
        }

        public IList<EntityType> LoadList(Expression<Func<EntityType, bool>> predicate, params Expression<Func<EntityType, object>>[] includeGraph)
        {
            return LoadList(null, null, predicate, includeGraph);
        }

        public IList<EntityType> LoadList(int? rows, int? page, Expression<Func<EntityType, bool>> predicate = null,
            params Expression<Func<EntityType, object>>[] includeGraph)
        {
            IQueryable<EntityType> query = EntitySet;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return LoadList(rows, page, query, includeGraph);
        }

        protected IList<EntityType> LoadList(int? rows, int? page, IQueryable<EntityType> query,
            params Expression<Func<EntityType, object>>[] includeGraph)
        {
            foreach (var includeGraphItem in includeGraph)
            {
                query = query.Include(includeGraphItem);
            }

            query = query.OrderBy(e => e.Id);

            if (rows.HasValue && page.HasValue)
            {
                query = query.
                    Skip((page.Value - 1) * rows.Value)
                    .Take(rows.Value);
            }

            return query.ToList<EntityType>();
        }

        public IList<EntityType> LoadAll()
        {
            return EntitySet
                .OrderBy(e => e.Id)
                .ToList<EntityType>();
        }

        public int RowsCount(Expression<Func<EntityType, bool>> predicate = null)
        {
            IQueryable<EntityType> query = EntitySet;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return RowsCount(query);
        }

        public int RowsCount(IQueryable<EntityType> query)
        {
            return query.Count();
        }

        protected virtual void ValidateInsert(EntityType entity)
        {
            //Empty - the logic will be provided in the subclass (child class)
        }

        public void Insert(EntityType entity)
        {
            ValidateInsert(entity);

            EntitySet.Add(entity);
            DbContext.SaveChanges();
        }

        protected virtual void ValidateSave(EntityType entity)
        {
            //Empty - the logic will be provided in the subclass (child class)
        }

        public void Save(EntityType entity)
        {
            ValidateSave(entity);

            EntitySet.Attach(entity);
            DbContext.SaveChanges();
        }

        protected virtual void ValidateDelete(int entityId)
        {
            //Empty - the logic will be provided in the subclass (child class)
            //Should throw BusinessLogicException upon violation of a delete rule
        }

        public void Delete(int entityId)
        {
            ValidateDelete(entityId);

            var entity = new EntityType { Id = entityId };

            EntitySet.Attach(entity);
            EntitySet.Remove(entity);

            DbContext.SaveChanges();
        }

        public void Delete(EntityType entity)
        {
            //ValidateDelete(entityId);

            EntitySet.Remove(entity);

            DbContext.SaveChanges();
        }

        public void DeleteAll(List<EntityType> entities)
        {
            //ValidateDelete(entityId);

            foreach (var entity in entities)
            {
                EntitySet.Remove(entity);
            }
            DbContext.SaveChanges();
        }


        public void SaveAll(List<EntityType> entities)
        {
            foreach (var entity in entities)
            {
                EntitySet.Attach(entity);
            }
            DbContext.SaveChanges();
        }
    }
}
