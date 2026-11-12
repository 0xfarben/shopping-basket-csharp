using ShoppingBasketNameSpace;

List<string> basket = new()
{
    "Apple",
    "Apple",
    "banana",
    "melon",
    "lime"
};

int result = ShoppingBasket.CalculateBasketPrice(basket);

Console.WriteLine(result + "p");