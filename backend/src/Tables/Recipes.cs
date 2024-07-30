using System.Reflection.Metadata;
using Microsoft.Net.Http.Headers;


namespace TableRecipes
{
    public class Recipes
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set; }
        public byte[]? Picture { get; set; }
        public string? Link { get; set; }
    }
}