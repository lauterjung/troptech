using HospitalControl.Exceptions;

namespace HospitalControl.Tests;

public class NurseTests
{
    [Test]
    public void CalculateSalary_Work100Hours_Payment4000()
    {
        //Arrange
        Nurse nurse = new Nurse("12345678900");
        nurse.WorkHours = 100;

        //Action
        var result = nurse.CalculatePayment();

        //Assert
        Assert.AreEqual(4000, result);
    }

    [Test]
    public void CalculateSalary_Work200Hours_Payment8800()
    {
        //Arrange
        Nurse nurse = new Nurse("12345678900");
        nurse.WorkHours = 200;

        //Action
        var result = nurse.CalculatePayment();

        //Assert
        Assert.AreEqual(8800, result);
    }

    [Test]
    public void CalculateSalary_MaximumWorkHours_ThrowMaximumWorkHoursException()
    {
        //Arrange
        Nurse nurse = new Nurse("12345678900");
        nurse.WorkHours = 300;

        //Action
        LimitHoursException ex = Assert.Throws<LimitHoursException>(() => nurse.CalculatePayment());

        //Assert
        Assert.That(ex.Message, Is.EqualTo("O número máximo de horas foi ultrapassado!"));
    }

    [Test]
    public void CalculateSalary_NegativeWorkHours_ThrowNegativeWorkHoursException()
    {
        //Arrange
        Nurse nurse = new Nurse("12345678900");
        nurse.WorkHours = -1;

        //Action
        NegativeHoursException ex = Assert.Throws<NegativeHoursException>(() => nurse.CalculatePayment());

        //Assert
        Assert.That(ex.Message, Is.EqualTo("O número mínimo de horas é inválido!"));
    }
}