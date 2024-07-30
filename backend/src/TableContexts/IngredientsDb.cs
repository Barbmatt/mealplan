using Microsoft.EntityFrameworkCore;
using TableIngredients;

namespace IngredientsDbContext
{
    class IngredientsDb : DbContext
    {
        public IngredientsDb(DbContextOptions<IngredientsDb> options)
            : base(options) { }

        public DbSet<Ingredients> Ingredients => Set<Ingredients>();
    }
}