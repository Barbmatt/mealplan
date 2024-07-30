using Microsoft.EntityFrameworkCore;
using TableRecipes;

namespace RecipesDbContext
{
    class RecipesDb : DbContext
    {
        public RecipesDb(DbContextOptions<RecipesDb> options)
            : base(options) { }

        public DbSet<Recipes> Recipes => Set<Recipes>();
    }
}