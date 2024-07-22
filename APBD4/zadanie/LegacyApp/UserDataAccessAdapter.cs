namespace LegacyApp;

public class UserDataAccessAdapter : IUserDataAccesAdapter
{
    public void AddUser(User user)
    {
        UserDataAccess.AddUser(user);
    }
}
