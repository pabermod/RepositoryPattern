namespace RP.DTO.Recipes
{
    public class RecipeDTO
    {
        private string name = string.Empty;
        private string description = string.Empty;
        private string imagePath = string.Empty;

        public string Name
        {
            get { return name; }
            set { name = value.Trim(); }
        }

        public string Description
        {
            get { return description.Trim(); }
            set { description = value; }
        }

        public string ImagePath
        {
            get { return imagePath.Trim(); }
            set { imagePath = value; }
        }

        public int TotalTime { get; set; }

        public int Servings { get; set; }
    }
}