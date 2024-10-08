using IngredientsDbContext;
using Microsoft.EntityFrameworkCore;
using TableIngredients;

namespace IngredientsManagement
{
  public class IngredientsServices
  {
    public IngredientsServices(
      WebApplicationBuilder builder,
      string connectionString,
      ServerVersion serverVersion
    )
    {
      builder.Services.AddDbContext<IngredientsDb>(dbContextOptions =>
        dbContextOptions
          .UseMySql(connectionString, serverVersion)
          // The following three options help with debugging, but should
          // be changed or removed for production.
          .LogTo(Console.WriteLine, LogLevel.Information)
          .EnableSensitiveDataLogging()
          .EnableDetailedErrors()
      );
    }

    public void getIngredients(WebApplication app)
    {
      app.MapGet("/Ingredients", async (IngredientsDb db) => await db.Ingredients.ToListAsync());
    }

    public void getIngredientById(WebApplication app)
    {
      app.MapGet(
        "/Ingredients/{id}",
        async (int id, IngredientsDb db) =>
          await db.Ingredients.FindAsync(id) is Ingredients Ingredients
            ? Results.Ok(Ingredients)
            : Results.NotFound()
      );
    }

    public void addNewIngredient(WebApplication app)
    {
      app.MapPost(
        "/Ingredients",
        async (Ingredients Ingredients, IngredientsDb db) =>
        {
          db.Ingredients.Add(Ingredients);
          await db.SaveChangesAsync();

          return Results.Created($"/Ingredients/{Ingredients.Id}", Ingredients);
        }
      );
    }

    public void modifyIngredient(WebApplication app)
    {
      app.MapPut(
        "/Ingredients/{id}",
        async (int id, Ingredients inputIngredients, IngredientsDb db) =>
        {
          var Ingredients = await db.Ingredients.FindAsync(id);

          if (Ingredients is null)
            return Results.NotFound();

          Ingredients.Name = inputIngredients.Name;
          Ingredients.Unit = inputIngredients.Unit;

          await db.SaveChangesAsync();

          return Results.NoContent();
        }
      );
    }

    public void deleteIngredientById(WebApplication app)
    {
      app.MapDelete(
        "/Ingredients/{id}",
        async (int id, IngredientsDb db) =>
        {
          if (await db.Ingredients.FindAsync(id) is Ingredients Ingredients)
          {
            db.Ingredients.Remove(Ingredients);
            await db.SaveChangesAsync();
            return Results.NoContent();
          }

          return Results.NotFound();
        }
      );
    }
  }
}
