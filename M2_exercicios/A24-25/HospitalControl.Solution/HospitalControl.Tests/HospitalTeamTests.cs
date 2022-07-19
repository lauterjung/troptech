using HospitalControl.Exceptions;

namespace HospitalControl.Tests;


public class HospitalTeamTests
{
    [Test]
    public void AddMember_AddMedic_MedicAdd()
    {
        // Arrange
        HospitalPayable time = new HospitalPayable();
        Medic medic = new Medic("12345678900");

        // Act
        time.AddMember(medic);

        // Assert
        Assert.That(time.Receivers[0], Is.TypeOf<Medic>());
        Assert.AreEqual(1, time.Receivers.Count);
    }

    [Test]
    public void AddMember_AddNurse_NurseAdd()
    {
        // Arrange
        HospitalPayable time = new HospitalPayable();
        Nurse nurse = new Nurse("12345678900");

        // Act
        time.AddMember(nurse);

        // Assert
        Assert.That(time.Receivers[0], Is.TypeOf<Nurse>());
        Assert.AreEqual(1, time.Receivers.Count);
    }

    [Test]
    public void AddMember_AddAdmin_AdminAdd()
    {
        // Arrange
        HospitalPayable time = new HospitalPayable();
        Admin admin = new Admin("12345678900");

        // Act
        time.AddMember(admin);

        // Assert
        Assert.That(time.Receivers[0], Is.TypeOf<Admin>());
        Assert.AreEqual(1, time.Receivers.Count);
    }

    [Test]
    public void RemoveMember_RemoveMedic_MedicRemove()
    {
        // Arrange
        HospitalPayable time = new HospitalPayable();
        IReceiver member = new IReceiver("12345678900");

        // Act
        time.Receivers.Add(member);
        time.RemoveMember("12345678900");

        // Assert        
        Assert.AreEqual(0, time.Receivers.Count);
    }

    [Test]
    public void SearchMember_SearchMedic_MedicSearch()
    {
        // Arrange
        HospitalPayable time = new HospitalPayable();
        Medic medic = new Medic("12345678900");

        // Act
        time.Receivers.Add(medic);
        IReceiver result = time.SearchReceiver("12345678900");

        // Assert
        Assert.AreEqual(medic.Id, result.Id);
        Assert.AreEqual(medic, result);
    }

    [Test]
    public void SearchMember_SearchMedic_MedicNotExists()
    {
        // Arrange
        HospitalPayable time = new HospitalPayable();

        //Action
        InvalidSearchException ex = Assert.Throws<InvalidSearchException>(() => time.SearchReceiver("12345678901"));

        //Assert
        Assert.That(ex.Message, Is.EqualTo("Este colaborador não existe!"));
    }

    [Test]
    public void RemoveMember_RemoveMedic_MedicRemoveNotExists()
    {
        // Arrange
        HospitalPayable time = new HospitalPayable();

        InvalidSearchException ex = Assert.Throws<InvalidSearchException>(() => time.RemoveReceiver("12345678901"));

        //Assert
        Assert.That(ex.Message, Is.EqualTo("Este colaborador não existe!"));
    }
}