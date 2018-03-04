namespace RP.DTO.Ingredients
{
    public class IngredientDTO
    {
        private string name = string.Empty;
        private string amount = string.Empty;

        /// <summary>
        /// Name of the ingredient
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value.Trim(); }
        }

        /// <summary>
        /// Amount of the ingredient
        /// </summary>
        public string Amount
        {
            get { return amount; }
            set { amount = value.Trim(); }
        }
    }
}