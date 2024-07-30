using Microsoft.EntityFrameworkCore;
using RecipesDbContext;
using TableRecipes;

namespace RecipesManagement
{
  public class RecipesServices
  {
    public RecipesServices(
      WebApplicationBuilder builder,
      string connectionString,
      ServerVersion serverVersion
    )
    {
      builder.Services.AddDbContext<RecipesDb>(dbContextOptions =>
        dbContextOptions
          .UseMySql(connectionString, serverVersion)
          .LogTo(Console.WriteLine, LogLevel.Information)
          .EnableSensitiveDataLogging()
          .EnableDetailedErrors()
      );
    }

    //services

    public void getRecipes(WebApplication app)
    {
      app.MapGet("/Recipesitems", async (RecipesDb db) => await db.Recipes.ToListAsync());
    }

    public void getRecipeById(WebApplication app)
    {
      app.MapGet(
        "/Recipesitems/{id}",
        async (int id, RecipesDb db) =>
          await db.Recipes.FindAsync(id) is Recipes Recipes
            ? Results.Ok(Recipes)
            : Results.NotFound()
      );
    }

    public void addNewRecipe(WebApplication app)
    {
      app.MapPost(
        "/Recipesitems",
        async (Recipes Recipes, RecipesDb db) =>
        {
          db.Recipes.Add(Recipes);
          await db.SaveChangesAsync();

          return Results.Created($"/Recipesitems/{Recipes.Id}", Recipes);
        }
      );
    }

    public void deleteRecipe(WebApplication app)
    {
      app.MapDelete(
        "/Recipesitems/{id}",
        async (int id, RecipesDb db) =>
        {
          if (await db.Recipes.FindAsync(id) is Recipes Recipes)
          {
            db.Recipes.Remove(Recipes);
            await db.SaveChangesAsync();
            return Results.NoContent();
          }

          return Results.NotFound();
        }
      );
    }

    public void modifyRecipe(WebApplication app)
    {
      app.MapPut(
        "/Recipesitems/{id}",
        async (int id, Recipes inputRecipes, RecipesDb db) =>
        {
          var Recipes = await db.Recipes.FindAsync(id);

          if (Recipes is null)
            return Results.NotFound();

          Recipes.Name = inputRecipes.Name;
          Recipes.Category = inputRecipes.Category;
          Recipes.Description = inputRecipes.Description;
          Recipes.Link = inputRecipes.Link;
          Recipes.Picture = inputRecipes.Picture;

          await db.SaveChangesAsync();

          return Results.NoContent();
        }
      );
    }
  }
}
