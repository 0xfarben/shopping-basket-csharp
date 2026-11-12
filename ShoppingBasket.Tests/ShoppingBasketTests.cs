using Basket = ShoppingBasketNameSpace.ShoppingBasket;

namespace ShoppingBasket.Tests;
public class ShoppingBasketTests
{
    // 1. Test normal product pricing.
    [Fact]
    public void CalculateBasketPrice_WithRegularItems_ReturnsCorrectTotal()
    {
        // Arrange
        List<string> basket = new()
        {
            "apple",
            "apple",
            "banana"
        };

        // Act
        int result = Basket.CalculateBasketPrice(basket);

        // Assert
        Assert.Equal(90, result);
    }

    // 2. Test melon offer.
    [Theory]
    [InlineData(1, 50)]
    [InlineData(2, 50)]
    [InlineData(3, 100)]
    [InlineData(4, 100)]
    [InlineData(5, 150)]
    public void CalculateMelonPrice_ReturnsCorrectPrice(
        int quantity, int expected)
    {
        int result = Basket.CalculateMelonPrice(quantity);

        Assert.Equal(expected, result);
    }

    // 3. Test lime offer.
    [Theory]
    [InlineData(1, 15)]
    [InlineData(2, 30)]
    [InlineData(3, 30)]
    [InlineData(4, 45)]
    [InlineData(5, 60)]
    [InlineData(6, 60)]
    public void CalculateLimePrice_ReturnsCorrectPrice(
        int quantity, int expected)
    {
        int result = Basket.CalculateLimePrice(quantity);

        Assert.Equal(expected, result);
    }

    // 4. Test empty basket.
    [Fact]
    public void CalculateBasketPrice_WithEmptyBasket_ReturnsZero()
    {
        List<string> basket = new();

        int result = Basket.CalculateBasketPrice(basket);

        Assert.Equal(0, result);
    }

    // 5. Test case-insensitive product names.
    [Fact]
    public void CalculateBasketPrice_WithDifferentCases_ReturnsCorrectTotal()
    {
        List<string> basket = new()
        {
            "Apple",
            "APPLE",
            "apple"
        };

        int result = Basket.CalculateBasketPrice(basket);

        Assert.Equal(105, result);
    }

    // 6. Test unknown product.
    [Fact]
    public void CalculateBasketPrice_WithUnknownProduct_ThrowsException()
    {
        List<string> basket = new()
        {
            "apple",
            "orange"
        };

        Assert.Throws<ArgumentException>(
            () => Basket.CalculateBasketPrice(basket));
    }

    // 7. Test null basket.
    [Fact]
    public void CalculateBasketPrice_WithNullBasket_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(
            () => Basket.CalculateBasketPrice(null!));
    }

    // 8. Test null item inside basket.
    [Fact]
    public void CalculateBasketPrice_WithNullItem_ThrowsException()
    {
        List<string> basket = new()
        {
            "apple",
            null!
        };

        Assert.Throws<ArgumentException>(
            () => Basket.CalculateBasketPrice(basket));
    }

    [Fact]
    public void CalculateBasketPrice_WithSpecialOffers_ReturnsCorrectTotal()
    {
        List<string> basket = new()
        {
            "Apple",
            "Apple",
            "banana",
            "melon",
            "lime"
        };

        int result = Basket.CalculateBasketPrice(basket);

        Assert.Equal(155, result);
    }


    [Theory]
    [InlineData(-1)]
    [InlineData(-2)]
    [InlineData(-10)]
    public void CalculateMelonPrice_WithNegativeQuantity_ThrowsException(
        int quantity)
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => Basket.CalculateMelonPrice(quantity));
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-2)]
    [InlineData(-10)]
    public void CalculateLimePrice_WithNegativeQuantity_ThrowsException(
        int quantity)
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => Basket.CalculateLimePrice(quantity));
    }

}
