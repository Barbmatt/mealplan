using IngredientsManagement;
using Microsoft.EntityFrameworkCore;
using RecipesManagement;

// service init
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
  options.AddDefaultPolicy(policy =>
  {
    policy
      .WithOrigins("http://localhost:3000", "http://localhost:5000")
      .AllowAnyHeader()
      .AllowAnyMethod();
    ;
  });
});

// db init
var mealplanDBSettings = builder.Configuration.GetSection(MealplanDBSettings.MealplanDB);

builder.Services.Configure<MealplanDBSettings>(mealplanDBSettings);

var settings = mealplanDBSettings.Get<MealplanDBSettings>();

if (settings == null)
{
  throw new NullReferenceException("No configuration for database connection.");
}

var serverVersion = new MariaDbServerVersion(new Version(8, 0, 36));

var connectionString =
  $"server={settings.Server};user={settings.Username};password={settings.Password};database={settings.Database}";

var recipesServices = new RecipesServices(builder, connectionString, serverVersion);
var IngredientsServices = new IngredientsServices(builder, connectionString, serverVersion);

var app = builder.Build();

recipesServices.getRecipes(app);
recipesServices.getRecipeById(app);
recipesServices.addNewRecipe(app);
recipesServices.modifyRecipe(app);
recipesServices.deleteRecipe(app);

IngredientsServices.getIngredients(app);
IngredientsServices.getIngredientById(app);
IngredientsServices.addNewIngredient(app);
IngredientsServices.modifyIngredient(app);
IngredientsServices.deleteIngredientById(app);

app.UseCors();

app.Run();
