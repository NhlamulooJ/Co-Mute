using Co_MuteDB.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Co_MuteBL.DbFunctions
{
    public class DbAccess<TEntity> where TEntity : class
    {
        public static DatabaseContext GetContext()
        {
            var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
            try { return new DatabaseContext(DatabaseContext.ops.dbOptions); }
            catch (Exception e) { throw new Exception("Failed to Connect to DB", e); };

        }
        public static async Task<TEntity> Update(TEntity entity)
        {
            using (var context = GetContext())
            {
                //context.Database.GetCommandTimeout = 60 * 1;
                using (var transaction = context.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        context.Set<TEntity>().Attach(entity);
                        var entry = context.Entry(entity);
                        entry.State = EntityState.Modified;
                        await context.SaveChangesAsync();
                        transaction.Commit();
                        return entity;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public static async Task<TEntity> Save(TEntity entity)
        {
            using (var context = GetContext())
            {
                context.Database.SetCommandTimeout(60 * 1);
                using (var transaction = context.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        TEntity returnEntity = entity;
                        context.Set<TEntity>().Add(returnEntity);
                        var entry = context.Entry(returnEntity);
                        entry.State = EntityState.Added;
                        await context.SaveChangesAsync();
                        transaction.Commit();
                        return returnEntity;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public static async Task<IList<TEntity>> GetAll()
        {
            using (var context = GetContext())
            {
                return context.Set<TEntity>().ToList().Select(entity => entity).ToList();
            }
        }
        public static IQueryable<TEntity> GetQueryable()
        {
            return GetContext().Set<TEntity>().Where(e => e != null).Select(e => e);
        }
    }
}
