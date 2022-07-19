using HospitalControl.Exceptions;

namespace HospitalControl.Tests;

public class HiredTests
{
    [Test]
    public void CalculatePayment_Amount1UnitPrice1000_Payment1000()
    {
        //Arrange
        Hired diarist = new Hired();
        diarist.Amount = 1;
        diarist.UnitPrice = 1000;

        //Action
        var result = diarist.CalculatePayment();

        //Assert
        Assert.AreEqual(1000, result);
    }

    [Test]
    public void CalculatePayment_NegativeAmount_ThrowNegativeHoursException()
    {
        //Arrange
        Hired diarist = new Hired();
        diarist.Amount = 1;
        diarist.UnitPrice = 1000;

        //Action
        NegativeHoursException ex = Assert.Throws<NegativeHoursException>(() => diarist.CalculatePayment());

        //Assert
        Assert.That(ex.Message, Is.EqualTo("A quantidade de serviço deve ser maior que 0!"));
    }

        [Test]
    public void CalculatePayment_NegativeUnitPrice_ThrowNegativeHoursException()
    {
        //Arrange
        Hired diarist = new Hired();
        diarist.Amount = 1;
        diarist.UnitPrice = 1000;

        //Action
        InvalidValueException ex = Assert.Throws<InvalidValueException>(() => diarist.CalculatePayment());

        //Assert
        Assert.That(ex.Message, Is.EqualTo("O valor do serviço deve ser maior que 0!"));
    }


}