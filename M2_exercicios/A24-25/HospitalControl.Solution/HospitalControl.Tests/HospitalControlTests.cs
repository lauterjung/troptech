using HospitalControl.Exceptions;

namespace HospitalControl.Tests;

public class HospitalControlTests
{

    [Test]
    public void MakePayment_GeneratesPaymentList()
    {
        //Arrange
        HospitalControl control = new HospitalControl();
        HospitalPayable team = new HospitalPayable();
        string identification = "12345678900";
        Admin admin = new Admin(identification);
        admin.WorkHours = 1;
        team.Receivers.Add(admin);
        control.HospitalPayable = team;

        //Action
        control.MakePayments();

        //Assert
        Assert.AreEqual(admin.PaymentList[0].Payment, 110);
    }

    [Test]
    public void InformHours_ValidInput_AddsValue()
    {
        //Arrange
        HospitalControl control = new HospitalControl();
        HospitalPayable team = new HospitalPayable();
        string identification = "12345678900";
        int workedHours = 1;
        Admin admin = new Admin(identification);
        team.Receivers.Add(admin);
        control.HospitalPayable = team;

        //Action
        control.InformHours(identification, workedHours);

        //Assert
        Assert.AreEqual(1, admin.WorkHours);
    }
}