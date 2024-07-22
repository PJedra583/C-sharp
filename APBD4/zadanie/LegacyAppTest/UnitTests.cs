using LegacyApp;

namespace LegacyAppTest;

public class UnitTests
{
    [Fact]
    public void AddUser_Should_Return_False_When_Email_Without_At_And_Dot()
    {
        //Arrange
        string firstName = "Peter";
        string lastName = "Parker";
        DateTime birthDate = new DateTime(1990, 1, 1);
        int clientId = 2;
        String email = "parker";
        var service = new UserService();
        //Act
        bool result = service.AddUser(firstName, lastName, email, birthDate, clientId);
        //Assert
        Assert.Equal(false,result);
    }

    [Fact]
    public void Adduser_Should_Return_False_When_Firstname_Is_Missing()
    {
        var service = new UserService();
        var result = service.AddUser(null, null, "zalewski@wp.pl", new DateTime(1990, 1, 1), 3);
        Assert.Equal(false,result);
    }

    [Fact]
    public void Adduser_Should_return_false_When_Client_Under_21()
    {
        var service = new UserService();
        var result = service.AddUser("Peter", "parker", "zalewski@wp.pl", DateTime.Now, 4);
        Assert.Equal(false,result);
    }
    
    [Fact]
    public void Adduser_should_return_true_when_executed_propely()
    {
        var service = new UserService(new FakeClientRepository(),new FakeUserCreditService(),new UserDataAccessAdapter());
        var result = service.AddUser("Peter", "Parker", "zalewski@wp.pl", new DateTime(1990, 1, 1), 1);
        Assert.Equal(true,result);
    }
}