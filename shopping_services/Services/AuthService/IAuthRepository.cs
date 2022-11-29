using shopping_services.Models;

namespace shopping_services.Services.AuthService
{
    public interface IAuthRepository
    {
        public string SignIn(string username, string password);
        public string signUp(AuthModel authModel);
        public string SignOut();
        public List<AuthModel> GetUsers();

    }
}
