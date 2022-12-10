using System.Collections.Generic;
using System.Text;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;

namespace ChristmasPastryShop.Repositories
{
    public class DelicacyRepository : IRepository<IDelicacy>
    {
        private readonly List<IDelicacy> models;

        public DelicacyRepository()
        {
            models = new List<IDelicacy>();
        }

        public IReadOnlyCollection<IDelicacy> Models => models;

        public void AddModel(IDelicacy model)
        {
            models.Add(model);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var delicacy in Models)
            {
                sb.AppendLine(delicacy.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}