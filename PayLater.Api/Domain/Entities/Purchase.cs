using PayLater.Api.Domain.Enums;

namespace PayLater.Api.Domain.Entities;

public class Purchase
{
    public int Id { get; set; }
    public int CustomerId { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public PurchaseStatus Status { get; private set; }
    private readonly List<Installment> _installments = [];
    public IReadOnlyCollection<Installment> Installments => _installments;

        public Purchase(int customerId, decimal amount)
{
    if (amount <= 0)
    {
        throw new ArgumentOutOfRangeException(
            nameof(amount),
            "Purchase amount must be greater than zero."
        );
    }

    if (customerId <= 0)
{
    throw new ArgumentOutOfRangeException(nameof(customerId));
}

    CustomerId = customerId;
    Amount = amount;
    CreatedAt = DateTime.UtcNow;
    Status = PurchaseStatus.Active;
}

private void CreateInstallments()
{
    decimal installmentAmount = Amount / 4;

    for (int i = 0; i < 4; i++)
    {
        var dueDate = DateOnly.FromDateTime(CreatedAt.AddMonths(i));

        _installments.Add(
            new Installment(
                installmentAmount,
                dueDate
            )
        );
    }
}

}