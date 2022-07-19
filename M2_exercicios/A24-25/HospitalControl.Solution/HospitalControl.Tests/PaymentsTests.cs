namespace HospitalControl.Tests;
using Exceptions;

public class PaymentsTests
{
    [Test]
    public void CreatePayment_ValidPayment_CreatesPayment()
    {
        // Arrange
        int month = 1;
        decimal payment = 1m;

        // Act
        Payments result = new Payments(month, payment);

        // Assert
        Assert.AreEqual(1, result.Month);
        Assert.AreEqual(1m, result.Payment);
    }

    [Test]
    public void CreatePayment_InvalidNegativeMonth_ThrowsException()
    {
        // Arrange
        int month = -1;
        decimal payment = 1m;

        // Act
        InvalidMonthException ex = Assert.Throws<InvalidMonthException>(() => new Payments(month, payment));

        // Assert
        Assert.That(ex.Message, Is.EqualTo("Mês inválido! Deve estar entre 1 e 12!"));
    }

    [Test]
    public void CreatePayment_Invalid13Month_ThrowsException()
    {
        // Arrange
        int month = 13;
        decimal payment = 1m;

        // Act
        InvalidMonthException ex = Assert.Throws<InvalidMonthException>(() => new Payments(month, payment));

        // Assert
        Assert.That(ex.Message, Is.EqualTo("Mês inválido! Deve estar entre 1 e 12!"));
    }

    [Test]
    public void CreatePayment_InvalidNegativePayment_ThrowsException()
    {
        // Arrange
        int month = 1;
        decimal payment = -1m;

        // Act
        InvalidPaymentException ex = Assert.Throws<InvalidPaymentException>(() => new Payments(month, payment));

        // Assert
        Assert.That(ex.Message, Is.EqualTo("Pagamento inválido! Deve ser maior que zero!"));
    }
}