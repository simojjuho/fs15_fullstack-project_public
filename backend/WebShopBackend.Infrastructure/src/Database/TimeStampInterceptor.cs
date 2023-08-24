using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WebShopBackend.Core.Abstractions.CoreEntities;

namespace WebShopBackend.Infrastructure.Database
{
    public class TimeStampInterceptor : SaveChangesInterceptor
    {
        public TimeStampInterceptor()
        {
        }
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            var addedEntries = eventData.Context?.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added);

            if (addedEntries is not null)
            {
                foreach (var entry in addedEntries)
                {
                    if (entry.Entity is IBaseEntity hasTimestamp)
                    {
                        hasTimestamp.CreatedAt = new DateTimeOffset().ToUniversalTime();
                    }
                }   
            }

            if (eventData.Context is not null)
            {
                var modifiedEntries = eventData.Context.ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Modified);

                foreach (var entry in modifiedEntries)
                {
                    if (entry.Entity is IBaseEntity hasTimestamp)
                    {
                        hasTimestamp.UpdatedAt = new DateTimeOffset().ToUniversalTime();
                    }
                }
            }

            return base.SavingChanges(eventData, result);
        }
    }
}