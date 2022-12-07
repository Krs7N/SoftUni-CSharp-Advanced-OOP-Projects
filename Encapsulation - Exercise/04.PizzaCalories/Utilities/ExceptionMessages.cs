namespace _04.PizzaCalories.Utilities
{
    public static class ExceptionMessages
    {
        public const string InvalidDoughOrFlourType = "Invalid type of dough.";
        public const string InvalidDoughWeight = "Dough weight should be in the range [{0}..{1}].";

        public const string InvalidToppingType = "Cannot place {0} on top of your pizza.";
        public const string InvalidToppingWeight = "{0} weight should be in the range [{1}..{2}].";

        public const string InvalidPizzaName = "Pizza name should be between {0} and {1} symbols.";
        public const string InvalidCountPizzaToppings = "Number of toppings should be in range [{0}..{1}].";
    }
}