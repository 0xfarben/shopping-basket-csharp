namespace ShoppingBasketNameSpace;
public class ShoppingBasket {
    private static readonly Dictionary<string, int> Prices = new(StringComparer.OrdinalIgnoreCase)
    {
        { "apple", 35 },
        { "banana", 20 },
        { "melon", 50 },
        { "lime", 15 }
    };

     // Validate the basket before calculations.
    private static void ValidateBasket(List<string> basket)
    {
        ArgumentNullException.ThrowIfNull(basket);

        foreach (string? item in basket)
        {
            if (item is null)
            {
                throw new ArgumentException(
                    "Every basket item must be a string.");
            }

            if (!Prices.ContainsKey(item))
            {
                throw new ArgumentException(
                    $"Unknown product: {item}");
            }
        }
    }

    public static int CalculateMelonPrice(int quantity)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(quantity);

        int priceOfMelon = Prices["melon"];

        // Grouping is done of 2, and 
        // leftovers are calculated with their individual prices. 
        // (or use Math.Ceiling --> to get round off to (+1) of the quotient)

        // int totalMelons = (int)Math.Ceiling( quantity / 2 );
        int totalMelons = (quantity + 1) / 2;

        return priceOfMelon * totalMelons;
    }
    public static int CalculateLimePrice(int quantity)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(quantity);
        
        int priceOfLime = Prices["lime"];

        // Find the "total groups(a group of 3)" possible with the given quantity.
        // int totalGroups = Math.Floor(quantity / 3);
        int totalGroups = quantity / 3;

        // Find the index number of the last element of the group
        // say e.g if 2 groups, then there are (2*3 = 6) elements
        int indexOfLastElementInGroup = totalGroups * 3;

        // find the number of leftover "Limes" after the grouping
        // total quantity minus the index of the last element of the group
        int leftOvers = quantity - indexOfLastElementInGroup;

        int pricePerGroup = 30;

        // Now calculations of prices.
        int total = ( pricePerGroup * totalGroups ) + ( priceOfLime* leftOvers);

        return total;
    }


    public static int CalculateBasketPrice(List<string> basket)
    {
        // Step 1: Validate the basket.
        ValidateBasket(basket);

        int total = 0;

        // before starting the calulations, validate the basket to remove unwanted items and also raise Errors.

        // Calculate the quantity of each individual item.
        Dictionary<string, int> quantities = new(StringComparer.OrdinalIgnoreCase);

        foreach (string item in basket)
        {   
            quantities.TryGetValue(item, out int count);
            quantities[item] = count + 1;
        }

        foreach (var item in quantities)
        {
            switch(item.Key)
            {
                case "melon":
                    total += CalculateMelonPrice(item.Value);
                    break;

                case "lime":
                    total += CalculateLimePrice(item.Value);
                    break;

                default:
                    total += item.Value * Prices[item.Key];
                    break;
            }
        }

        // return 0;
        return total;
    }

}