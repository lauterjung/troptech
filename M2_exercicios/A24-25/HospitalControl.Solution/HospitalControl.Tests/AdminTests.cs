using HospitalControl.Exceptions;

namespace HospitalControl.Tests;

public class AdminTests
{
    [Test]
    public void CalculateSalary_WorkOneHundredHours_Payment11000()
    {
        //Arrange
        Admin admin = new Admin("12345678900");
        admin.WorkHours = 100;

        //Action
        var result = admin.CalculatePayment();

        //Assert
        Assert.AreEqual(11000, result);
    }

    [Test]
    public void CalculateSalary_WorkTwentyExtraHours_Payment24200()
    {
        //Arrange
        Admin admin = new Admin("12345678900");
        admin.WorkHours = 200;       

        //Action
        var result = admin.CalculatePayment();

        //Assert
        Assert.AreEqual(24200, result);
    }

    [Test]
    public void CalculateSalary_MaximumWorkHours_ThrowMaximumWorkHoursException()
    {
        //Arrange
        Admin admin = new Admin("12345678900");
        admin.WorkHours = 210;

        //Action
        LimitHoursException ex = Assert.Throws<LimitHoursException>(() => admin.CalculatePayment());

        //Assert
        Assert.That(ex.Message, Is.EqualTo("O número máximo de horas foi ultrapassado!"));
    }

    [Test]
    public void CalculateSalary_NegativeWorkHours_ThrowNegativeWorkHoursException()
    {
        //Arrange
        Admin admin = new Admin("12345678900");
        admin.WorkHours = -1;

        //Action
        NegativeHoursException ex = Assert.Throws<NegativeHoursException>(() => admin.CalculatePayment());

        //Assert
        Assert.That(ex.Message, Is.EqualTo("O número mínimo de horas é inválido!"));
    }
}