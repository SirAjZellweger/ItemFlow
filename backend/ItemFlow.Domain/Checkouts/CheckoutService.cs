namespace ItemFlow.Domain.Checkouts;

internal class CheckoutService(ICheckoutRepository checkoutRepository)
{

    public Checkout CreateCheckout(IEnumerable<CheckoutItem> items, DateTime? plannedStartDate = null, DateTime? plannedEndDate = null)
    {
        // Überprüfen des Bestands über alle laufenden Checkouts hinweg
        foreach (CheckoutItem ci in items)
        {
            int available = ci.Item.Quantity - checkoutRepository.GetTotalQuantityCheckedOut(ci.Item.Id);
            if (ci.Quantity > available)
                throw new InvalidOperationException($"Es können maximal {available} Stück von '{ci.Item.Name}' ausgeliehen werden.");
        }

        Checkout checkout = Checkout.Create(items, plannedStartDate, plannedEndDate);
        foreach (CheckoutItem ci in items)
            checkout.AddItem(ci);

        return checkout;
    }
}
