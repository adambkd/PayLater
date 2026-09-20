using PayLater.Api.Domain.Enums;

namespace PayLater.Api.Domain.Entities;

public class Installment
{
    public int Id { get; set; }
    public int PurchaseId { get; set; }
    public decimal Amount { get; private set; }
    public decimal PaidAmount { get; private set; }
    public DateOnly DueDate { get; private set; }
    public DateTime? PaidAt { get; private set; }
    public InstallmentStatus Status { get; private set; }

    public Installment(int purchaseId, decimal amount, DateOnly dueDate)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(Amount),
                "Installment amount must be greater than zero."
            );
        }

        PurchaseId = purchaseId;
        Amount = amount;
        DueDate = dueDate;

        PaidAmount = 0;
        Status = InstallmentStatus.Pending;
    }

    public bool RegisterPayment(decimal amount)
    {
        if (amount <= 0)
        {
            return false;
        }

        if (Status == InstallmentStatus.Paid)
        {
            return false;
        }

        decimal remainingAmount = Amount - PaidAmount;

        if (amount > remainingAmount)
        {
            return false;
        }

        PaidAmount += amount;

        if (PaidAmount == Amount)
        {
            Status = InstallmentStatus.Paid;
            PaidAt = DateTime.UtcNow;
        }

        return true;
    }
}