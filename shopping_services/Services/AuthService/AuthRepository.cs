using shopping_services.Data;
using shopping_services.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace shopping_services.Services.AuthService
{
    public class AuthRepository : IAuthRepository
    {
        private readonly FE_DbContext _context;
        private object iconfiguration;

        public AuthRepository(FE_DbContext context)
        {
            _context = context;
        }

        public string SignIn(string username, string password)
        {
            //var user = _context.Users.FirstOrDefault(u => u.username == username);
            //if (user == null)
            //{
            //    return "Username or password is incorrect";
            //}

            //if (user.password == password)
            //{
            //    return "Sing In successfully";
            //}
            //else
            //{
            //    return "Username or password is incorrect";
            //}
            var user = _context.Users.Any(u => u.username == username && u.password == password);
            if (!user)
            {
                return "Username or password is incorrect";
            }

            // Else we generate JSON Web Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_context["JWT:Key"]);


        }

        public string SignOut()
        {
            throw new NotImplementedException();
        }

        public string signUp(AuthModel authModel)
        {
            var user = new User
            {
                username = authModel.username,
                password = authModel.password,
                email = authModel.email
            };

            _context.Add(user);
            _context.SaveChanges();

            return "SignUp successfully";
        }


        public List<AuthModel> GetUsers()
        {
            var users = _context.Users.Select(user => new AuthModel
            {
                username = user.username,
                password = user.password,
                email = user.email
            });

            return users.ToList();
        }
    }
}
