namespace HarryPotterKataTests;

public class PromotionCalculatorShould
{
    [Fact]
    public void ComputeBasketPrice()
    {
        //ForABasketWithSingleBook()
        //WhenComputingBaskingPrice()
        //ShouldGetExpectedBasketPriceWithPromotion()
        var basket = new Basket();
        var promotionCalculator = new PromotionCalculator();
        var price = promotionCalculator.ComputeBasket(basket);
        price.Should();
    }
}

public class PromotionCalculator
{
    public int ComputeBasket(Basket basket)
    {
        return 0;
    }
}

public class Basket
{

}