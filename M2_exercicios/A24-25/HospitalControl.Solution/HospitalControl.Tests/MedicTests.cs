using HospitalControl.Exceptions;

namespace HospitalControl.Tests;

public class MedicTests
{
    [Test]
    public void CalculateSalary_Work100Hours_Payment15000()
    {
        //Arrange
        Medic medic = new Medic("12345678900");
        medic.WorkHours = 100;

        //Action
        var result = medic.CalculatePayment();

        //Assert
        Assert.AreEqual(30000, result);
    }

    [Test]
    public void CalculateSalary_Work200Hours_Payment60000()
    {
        //Arrange
        Medic medic = new Medic("12345678900");
        medic.WorkHours = 200;       

        //Action
        var result = medic.CalculatePayment();

        //Assert
        Assert.AreEqual(66000, result);
    }
    [Test]
    public void CalculateSalary_Work250Hours_Payment60000()
    {
        //Arrange
        Medic medic = new Medic("12345678900");
        medic.WorkHours = 250;       

        //Action
        var result = medic.CalculatePayment();

        //Assert
        Assert.AreEqual(96000, result);
    }
    [Test]
    public void CalculateSalary_Work300Hours_Payment141000()
    {
        //Arrange
        Medic medic = new Medic("12345678900");
        medic.WorkHours = 300;       

        //Action
        var result = medic.CalculatePayment();

        //Assert
        Assert.AreEqual(141000, result);
    }

    [Test]
    public void CalculateSalary_MaximumWorkHours_ThrowMaximumWorkHoursException()
    {
        //Arrange
        Medic medic = new Medic("12345678900");
        medic.WorkHours = 400;

        //Action
        LimitHoursException ex = Assert.Throws<LimitHoursException>(() => medic.CalculatePayment());

        //Assert
        Assert.That(ex.Message, Is.EqualTo("O número máximo de horas foi ultrapassado!"));
    }

    [Test]
    public void CalculateSalary_NegativeWorkHours_ThrowNegativeWorkHoursException()
    {
        //Arrange
        Medic medic = new Medic("12345678900");
        medic.WorkHours = -1;

        //Action
        NegativeHoursException ex = Assert.Throws<NegativeHoursException>(() => medic.CalculatePayment());

        //Assert
        Assert.That(ex.Message, Is.EqualTo("O número mínimo de horas é inválido!"));
    }
}