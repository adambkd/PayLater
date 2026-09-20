using PayLater.Api.Domain.Enums;

namespace PayLater.Api.Domain.Entities;

public class Installment
{
    public int Id { get; set; }
    public int PurchaseId { get; set; }
    public decimal Amount { get; set; }
    public decimal PaidAmount { get; set; }
    public DateOnly DueDate { get; set; }
    public DateTime? PaidAt { get; set; }
    public InstallmentStatus Status { get; set; }
}