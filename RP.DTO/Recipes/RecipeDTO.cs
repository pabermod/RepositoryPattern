namespace RP.DTO.Recipes
{
    public class RecipeDTO : EntityDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}