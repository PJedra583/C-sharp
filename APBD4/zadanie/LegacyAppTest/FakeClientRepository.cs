using LegacyApp;

namespace LegacyAppTest;

public class FakeClientRepository : IClientRepository
{
    public Client GetById(int id)
    {
        return new Client { Type = "VeryImportantClient" };
    }
}