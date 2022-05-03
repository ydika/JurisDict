using JurisDict.Api.DataBase;
using JurisDict.Api.Repositories.Interfaces;
using Common.Models.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JurisDict.Api.Repositories
{
    public class Repository<TDbModel> : IRepository<TDbModel> where TDbModel : BaseModel
    {
        private readonly ApplicationContext _context;

        public Repository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TDbModel>> GetAllAsync()
        {
            return await _context.Set<TDbModel>().ToListAsync();
        }

        public async Task<IEnumerable<TDbModel>> GetWithInclude(params Expression<Func<TDbModel, object>>[] includeProperties)
        {
            return await Include(includeProperties).ToListAsync();
        }

        private IQueryable<TDbModel> Include(params Expression<Func<TDbModel, object>>[] includeProperties)
        {
            IQueryable<TDbModel> query = _context.Set<TDbModel>();
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public async Task<TDbModel> GetAsync(Guid id)
        {
            var item = await _context.Set<TDbModel>().FirstOrDefaultAsync(m => m.Id == id);
            if (item is null)
            {
                throw new Exception($"Не удалось найти объект с id: {id}");
            }
            return item;
        }

        public async Task<TDbModel> CreateAsync(TDbModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            await _context.Set<TDbModel>().AddRangeAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<IEnumerable<TDbModel>> UpdateAsync(IEnumerable<TDbModel> models)
        {
            if (models is null)
            {
                throw new ArgumentNullException(nameof(models));
            }
            foreach (var model in models)
            {
                _context.Entry(await _context.Set<TDbModel>().FindAsync(model.Id)).CurrentValues.SetValues(model);
            }
            await _context.SaveChangesAsync();
            return models;
        }

        public async Task<IEnumerable<Guid>> DeleteAsync(IEnumerable<Guid> ids)
        {
            var toDelete = await _context.Set<TDbModel>().Where(m => ids.Contains(m.Id)).ToListAsync();
            _context.Set<TDbModel>().RemoveRange(toDelete);
            await _context.SaveChangesAsync();
            return ids;
        }
    }
}
