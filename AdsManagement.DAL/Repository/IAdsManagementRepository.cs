using AdsManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdsManagement.DAL.Repository
{
    public interface IAdsManagementRepository<EntityType>
        where EntityType : ModelBase, new()
    {
        EntityType Load(int Id, params Expression<Func<EntityType, object>>[] includeGraph);

        IList<EntityType> LoadList(Expression<Func<EntityType, bool>> predicate);

        IList<EntityType> LoadList(Expression<Func<EntityType, bool>> predicate, params Expression<Func<EntityType, object>>[] includeGraph);

        IList<EntityType> LoadList(int? rows, int? page, Expression<Func<EntityType, bool>> predicate = null,
            params Expression<Func<EntityType, object>>[] includeGraph);

        IList<EntityType> LoadAll();

        int RowsCount(Expression<Func<EntityType, bool>> predicate = null);

        int RowsCount(IQueryable<EntityType> query);

        void Insert(EntityType entity);

        void Save(EntityType entity);

        void Delete(int entityId);

        void Delete(EntityType entity);

        void DeleteAll(List<EntityType> entities);

        void SaveAll(List<EntityType> entities);
    }
}
