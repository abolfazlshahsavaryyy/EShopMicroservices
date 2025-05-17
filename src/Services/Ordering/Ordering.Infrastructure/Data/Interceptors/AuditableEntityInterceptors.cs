using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Ordering.Domain.Abstractions;

namespace Ordering.Infrastructure.Data.Interceptors
{
    public class AuditableEntityInterceptors :SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEntity(eventData.Context);
            return base.SavingChanges(eventData, result);
        }

        private void UpdateEntity(DbContext? context)
        {
            if (context == null) return;
            foreach(var entity in context.ChangeTracker.Entries<IEntity>())
            {
                if(entity.State == EntityState.Added)
                {
                    entity.Entity.CreateBy = "abolfazl";
                    entity.Entity.Created = DateTime.UtcNow;
                }
                if(entity.State== EntityState.Added || entity.State == EntityState.Modified || entity.HasChangedOwnedEntity())
                {
                    entity.Entity.LastModifiedBy = "abolfazl";
                    entity.Entity.LastModified = DateTime.UtcNow;
                }
            }

        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateEntity(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }


    }
    public static class ExtensionInterceptor
    {
        public static bool HasChangedOwnedEntity(this EntityEntry entity) =>

            entity.References.Any(r =>

                r.TargetEntry != null && r.TargetEntry.Metadata.IsOwned() &&
                (r.TargetEntry.State == EntityState.Added || r.TargetEntry.State == EntityState.Modified)
            );
        
    }
}
