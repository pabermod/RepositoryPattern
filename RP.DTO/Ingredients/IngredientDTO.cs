namespace RP.DTO.Ingredients
{
    public class IngredientDTO
    {
        private string name = string.Empty;
        private string amount = string.Empty;

        public string Name
        {
            get { return name; }
            set { name = value.Trim(); }
        }

        public string Quantity
        {
            get { return amount; }
            set { amount = value.Trim(); }
        }
    }
}