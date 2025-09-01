namespace ItemFlow.Domain.Checkouts;
public interface ICheckoutRepository
{
    Task<int> GetTotalQuantityCheckedOut(Guid itemId);
}
