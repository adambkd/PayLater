using PayLater.Api.Domain.Entities;
using PayLater.Api.Domain.Enums;

namespace PayLater.Tests;

public class PurchaseTests
{
    [Fact]
    public void Constructor_WithValidPurchase_CreatesFourInstallments()
    {
        // Arrange + Act
        var purchase = new Purchase(
            customerId: 1,
            amount: 8000m
        );

        // Assert
        Assert.Equal(8000m, purchase.Amount);
        Assert.Equal(PurchaseStatus.Active, purchase.Status);

        Assert.Equal(4, purchase.Installments.Count);

        foreach (var installment in purchase.Installments)
        {
            Assert.Equal(2000m, installment.Amount);
            Assert.Equal(0m, installment.PaidAmount);
            Assert.Equal(InstallmentStatus.Pending, installment.Status);
        }
    }
}