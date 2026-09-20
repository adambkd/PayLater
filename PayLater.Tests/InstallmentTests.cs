using PayLater.Api.Domain.Entities;
using PayLater.Api.Domain.Enums;

namespace PayLater.Tests;

public class InstallmentTests
{
    [Fact]
    public void RegisterPayment_WithValidPartialPayment_UpdatesPaidAmount()
    {
        // Arrange
        var installment = new Installment(
            purchaseId: 1,
            amount: 2000m,
            dueDate: new DateOnly(2026, 10, 20)
        );

        // Act
        bool result = installment.RegisterPayment(500m);

        // Assert
        Assert.True(result);
        Assert.Equal(500m, installment.PaidAmount);
        Assert.Equal(InstallmentStatus.Pending, installment.Status);
        Assert.Null(installment.PaidAt);
    }
}