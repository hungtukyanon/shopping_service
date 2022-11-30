using shopping_services.Models;

namespace shopping_services.Services.AuthService
{
    public interface IAuthRepository
    {
        public Tokens SignIn(SignIn signIn);
        public string signUp(AuthModel authModel);
        public string SignOut();
        public List<AuthModel> GetUsers();

    }
}
