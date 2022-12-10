using System.Collections.Generic;
using System.Text;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Repositories.Contracts;

namespace ChristmasPastryShop.Repositories
{
    public class CocktailRepository : IRepository<ICocktail>
    {
        private readonly List<ICocktail> models;

        public CocktailRepository()
        {
            models = new List<ICocktail>();
        }

        public IReadOnlyCollection<ICocktail> Models => models;

        public void AddModel(ICocktail model)
        {
            models.Add(model);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var cocktail in Models)
            {
                sb.AppendLine(cocktail.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}