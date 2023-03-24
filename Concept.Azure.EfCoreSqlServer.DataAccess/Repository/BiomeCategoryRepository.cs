using Concept.Azure.EfCoreSqlServer.DataAccess.DataContext;
using Concept.Azure.EfCoreSqlServer.DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Concept.Azure.EfCoreSqlServer.DataAccess.Repository
{
    public class BiomeCategoryRepository : IRepository<BiomeCategory>
    {
        private readonly SafariDataContext context;

        public BiomeCategoryRepository(SafariDataContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<BiomeCategory>> GetItems()
        {
            return await context.BiomeCategory.ToArrayAsync();
        }

        public async Task<BiomeCategory> GetItemsById(object id)
        {
            return await context.BiomeCategory.FirstOrDefaultAsync(p => p.Id == new Guid((string)id));
        }

        public async Task DeleteItem(object id)
        {
            var currentBiome = await context.BiomeCategory.FindAsync(new Guid((string)id));
            if (currentBiome != null)
            {
                context.BiomeCategory.Remove(currentBiome);
            }
        }

        public BiomeCategory InsertItem(BiomeCategory item)
        {
            item.Id = Guid.NewGuid();
            item.CreatedDateUtc = DateTime.UtcNow;
            context.BiomeCategory.Add(item);
            return item;
        }

        public async Task UpdateItem(BiomeCategory item)
        {
            var currentBiome = await context.BiomeCategory.FindAsync(item.Id);
            if (currentBiome != null)
            {
                context.Entry(currentBiome).State = EntityState.Modified;
                item.ModifiedDateUtc = DateTime.UtcNow;
                context.Entry(currentBiome).CurrentValues.SetValues(item);
            } else
            {
                throw new Exception();
            }
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        #region disposal
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
