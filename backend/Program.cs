using IngridientManagment;
using Microsoft.EntityFrameworkCore;
using RecipesManagement;

// service init
var builder = WebApplication.CreateBuilder(args);

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
var IngridientsServices = new IngridientsServices(builder, connectionString, serverVersion);

var app = builder.Build();

recipesServices.getRecipes(app);
recipesServices.getRecipeById(app);
recipesServices.addNewRecipe(app);
recipesServices.modifyRecipe(app);
recipesServices.deleteRecipe(app);

IngridientsServices.getIngridients(app);
IngridientsServices.getIngridientById(app);
IngridientsServices.addNewIngridient(app);
IngridientsServices.modifyIngridient(app);
IngridientsServices.deleteIngridientById(app);

app.Run();
