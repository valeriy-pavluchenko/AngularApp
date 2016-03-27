using AngularApp.DAL.Entities;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AngularApp.DAL.Interfaces
{
    public interface IShopContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }

        EntityEntry Entry(object entry);
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
