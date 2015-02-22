using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManagement.Core.DomainEntity;

namespace TaskManagement.Core
{
    public interface IContext
    {
        IDbSet<IterationOrSprint> IterationOrSprints { get; set; }
        IDbSet<LineItem> LineItems { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entry) where TEntity : class;

        Task<int> SaveChangesAsync();
    }
    
    public class TaskManagementContext : DbContext, IContext
    {

        public TaskManagementContext()
            : base("Name = TaskManagementContext")
        {
            //this.Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer<TaskManagementContext>(new TaskManagementDBInitializer());
        }

        public IDbSet<IterationOrSprint> IterationOrSprints { get; set; }
        public IDbSet<LineItem> LineItems { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync()
        {

            var modifiedEntries = ChangeTracker.Entries().Where(x => x.Entity is IAuditableEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                var entity = entry.Entity as IAuditableEntity;
                if (entity != null)
                {
                    var identityName = Thread.CurrentPrincipal.Identity.Name;
                    var now = DateTime.UtcNow;

                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedBy = identityName;
                        entity.CreatedDate = now;
                    }
                    else
                    {
                        base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                        base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                    }

                    entity.ModifiedBy = identityName;
                    entity.ModifiedDate = now;
                }

            }

            return await base.SaveChangesAsync();
        }
    }
}
