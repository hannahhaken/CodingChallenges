using System.Collections.Generic;

public class CartService
{
    public decimal GetTotal(List<CartItem> items)
    {
        decimal total = 0;
        foreach (var item in items)
        {
            int payableQty = item.Quantity;
            if (item.Quantity >= 3)
                payableQty -= item.Quantity / 3; // Buy 2 get 1 free
            total += item.Product.Price * payableQty;
        }

        if (total > 100)
            total *= 0.9m; // 10% discount

        return total;
    }
}