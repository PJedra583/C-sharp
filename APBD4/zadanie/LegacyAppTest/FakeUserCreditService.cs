using LegacyApp;

namespace LegacyAppTest;

public class FakeUserCreditService : ICreditService
{
    public int GetCreditLimit(string lastName, DateTime dateOfBirth)
    {
        return 1000;
    }
}
