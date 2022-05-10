using BookStore.Data.Infrastructure;
using BookStore.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Data.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> GetByAlias(string alias);
    }

    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Category> GetByAlias(string alias)
        {
            return this.DbContext.Categories.Where(x => x.Alias == alias); ;
        }
    }
}