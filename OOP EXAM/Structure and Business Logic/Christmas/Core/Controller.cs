using System;
using System.Linq;
using System.Text;
using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IBooth> booths;
        private IRepository<IDelicacy> delicacies;
        private IRepository<ICocktail> cocktails;
        private IBooth booth;

        public Controller()
        {
            booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            booth = new Booth(booths.Models.Count + 1, capacity);
            delicacies = booth.DelicacyMenu;
            cocktails = booth.CocktailMenu;
            booths.AddModel(booth);

            return string.Format(OutputMessages.NewBoothAdded, booths.Models.Count, capacity);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            booth = booths.Models.First(b => b.BoothId == boothId);

            if (delicacies.Models.Any(d => d.Name == delicacyName))
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            IDelicacy delicacy;
            if (delicacyTypeName == "Gingerbread")
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else if (delicacyTypeName == "Stolen")
            {
                delicacy = new Stolen(delicacyName);
            }
            else
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            booth.DelicacyMenu.AddModel(delicacy);

            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            booth = booths.Models.First(b => b.BoothId == boothId);

            if (cocktails.Models.Any(c => c.Name == cocktailName && c.Size == size))
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            if (size != "Middle" && size != "Small" && size != "Large")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }

            ICocktail cocktail;
            if (cocktailTypeName == "Hibernation")
            {
                cocktail = new Hibernation(cocktailName, size);
            }
            else if (cocktailTypeName == "MulledWine")
            {
                cocktail = new MulledWine(cocktailName, size);
            }
            else
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            booth.CocktailMenu.AddModel(cocktail);

            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string ReserveBooth(int countOfPeople)
        {
            var orderedBooths = booths.Models.OrderBy(b => b.Capacity).ThenByDescending(b => b.BoothId).Where(b => b.Capacity >= countOfPeople).ToList();

            foreach (var orderedBooth in orderedBooths)
            {
                if (!orderedBooth.IsReserved)
                {
                    orderedBooth.ChangeStatus();

                    return $"Booth {orderedBooth.BoothId} has been reserved for {countOfPeople} people!";
                }
            }

            return $"No available booth for {countOfPeople} people!";
        }

        public string TryOrder(int boothId, string order)
        {
            string[] orderTokens = order.Split('/', StringSplitOptions.RemoveEmptyEntries);
            string itemTypeName = orderTokens[0];
            int checker = 0;

            if (itemTypeName != "Hibernation" && itemTypeName != "MulledWine" && itemTypeName != "Gingerbread" && itemTypeName != "Stolen")
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            string itemName = orderTokens[1];
            int countOfOrderedPieces = int.Parse(orderTokens[2]);
            string size = null;
            if (itemTypeName == "MulledWine" || itemTypeName == "Hibernation")
            {
                size = orderTokens[3];
            }

            if (delicacies.Models.All(d => d.Name != itemName))
            {
                checker++;
            }
            if (cocktails.Models.All(c => c.Name != itemName))
            {
                checker++;
            }
            if (checker == 2)
            {
                return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
            }

            if (itemTypeName == "MulledWine")
            {
                if (!cocktails.Models.Any(c => c.Name == itemName && c.Size == size))
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, size, itemName);
                }

                var curCocktail = cocktails.Models.First(c => c.Name == itemName && c.Size == size);
                double amount = curCocktail.Price * countOfOrderedPieces;
                booth.UpdateCurrentBill(amount);

                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, countOfOrderedPieces, itemName);

            }

            if (itemTypeName == "Hibernation")
            {
                if (!cocktails.Models.Any(c => c.Name == itemName && c.Size == size))
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, size, itemName);
                }

                var curCocktail = cocktails.Models.First(c => c.Name == itemName && c.Size == size);
                double amount = curCocktail.Price * countOfOrderedPieces;
                booth.UpdateCurrentBill(amount);

                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, countOfOrderedPieces, itemName);

            }

            if (itemTypeName == "Gingerbread")
            {
                if (!delicacies.Models.Any(d => d.Name == itemName && d.GetType().Name == itemTypeName))
                {
                    return string.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName, itemName);
                }

                var curDelicacy = delicacies.Models.First(d => d.Name == itemName && d.GetType().Name == itemTypeName);
                double amount = curDelicacy.Price * countOfOrderedPieces;
                booth.UpdateCurrentBill(amount);

                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, countOfOrderedPieces, itemName);

            }

            if (itemTypeName == "Stolen")
            {
                if (!delicacies.Models.Any(d => d.Name == itemName && d.GetType().Name == itemTypeName))
                {
                    return string.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName, itemName);
                }

                var curDelicacy = delicacies.Models.First(d => d.Name == itemName && d.GetType().Name == itemTypeName);
                double amount = curDelicacy.Price * countOfOrderedPieces;
                booth.UpdateCurrentBill(amount);

                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, countOfOrderedPieces, itemName);
            }

            return "";
        }

        public string LeaveBooth(int boothId)
        {
            var curBooth = booths.Models.First(b => b.BoothId == boothId);
            var bill = $"{curBooth.CurrentBill:f2}";
            curBooth.Charge();
            curBooth.ChangeStatus();

            return string.Format(OutputMessages.GetBill, bill) + Environment.NewLine + string.Format(OutputMessages.BoothIsAvailable, boothId);
        }

        public string BoothReport(int boothId)
        {
            var curBooth = booths.Models.First(b => b.BoothId == boothId);

            return curBooth.ToString();
        }
    }
}