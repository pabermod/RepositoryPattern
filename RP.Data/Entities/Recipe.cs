using Newtonsoft.Json;
using System.Collections.Generic;

namespace RP.Data
{
    public class Recipe : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }

        public int TotalTime { get; set; }

        public int Servings { get; set; }

        public virtual IList<string> Directions
        {
            get
            {
                return directions;
            }
            set
            {
                directions = value;
            }
        }

        private IList<string> directions;

        public string DirectionsSerialized
        {
            get
            {
                return JsonConvert.SerializeObject(directions);
            }
            set
            {
                directions = JsonConvert.DeserializeObject<IList<string>>(value);
            }
        }
    }
}