using System;

namespace LegacyApp
{
    public class UserService
    {
        private IClientRepository _clientRepository;
        private ICreditService _creditService;
        private IUserDataAccesAdapter _userDataAccesAdapter;

        [Obsolete]
        public UserService()
        {
            _clientRepository = new ClientRepository();
            _creditService = new UserCreditService();
            _userDataAccesAdapter = new UserDataAccessAdapter();
        }
        
        public UserService(IClientRepository clientRepository,ICreditService creditService,IUserDataAccesAdapter iUserDataAccesAdapter)
        {
            _clientRepository = clientRepository;
            _creditService = creditService;
            _userDataAccesAdapter = iUserDataAccesAdapter;
        }
        
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                return false;
            }

            if (!email.Contains("@") && !email.Contains("."))
            {
                return false;
            }

            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

            if (age < 21)
            {
                return false;
            }

            var client = _clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            if (client.Type == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
            }
            else
            {
                int creditLimit = _creditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                if (client.Type == "ImportantClient")
                {
                    creditLimit *= 2;
                }
                else
                {
                    //That was the business logic but i am curious why!
                    user.HasCreditLimit = true;
                }
                user.CreditLimit = creditLimit;
            }

            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }

            _userDataAccesAdapter.AddUser(user);
            return true;
        }
    }
}
