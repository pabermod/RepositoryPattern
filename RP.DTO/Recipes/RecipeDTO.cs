namespace RP.DTO.Recipes
{
    public class RecipeDTO
    {
        private string name = string.Empty;
        private string description = string.Empty;
        private string imagePath = string.Empty;

        /// <summary>
        /// Name of the recipe
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value.Trim(); }
        }

        /// <summary>
        /// Description of the recipe
        /// </summary>
        public string Description
        {
            get { return description.Trim(); }
            set { description = value; }
        }

        /// <summary>
        /// Image path of the recipe
        /// </summary>
        public string ImagePath
        {
            get { return imagePath.Trim(); }
            set { imagePath = value; }
        }
    }
}