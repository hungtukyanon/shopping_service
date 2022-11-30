﻿using Microsoft.IdentityModel.Tokens;
using shopping_services.Data;
using shopping_services.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace shopping_services.Services.AuthService
{
    public class AuthRepository : IAuthRepository
    {
        private readonly FE_DbContext _context;
        private IConfiguration _configuration;

        public AuthRepository(FE_DbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public Tokens SignIn(SignIn signIn)
        {
            var queyUser = _context.Users.AsEnumerable();
            var checkedUser = queyUser.SingleOrDefault(u => u.username == signIn.username);
            if (checkedUser == null)
            {
                return null;
            }

            bool isValidPassword = BCrypt.Net.BCrypt.Verify(signIn.password, checkedUser.password);
            if (isValidPassword)
            {
                return GenerateToken(signIn);
            }
            return null;
        }

        public string SignOut()
        {
            throw new NotImplementedException();
        }

        public string signUp(AuthModel authModel)
        {
            var hashPassword = BCrypt.Net.BCrypt.HashPassword(authModel.password);
            var user = new User
            {
                username = authModel.username,
                password = hashPassword,
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

        private Tokens GenerateToken(SignIn signIn)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, signIn.username),
                    new Claim(ClaimTypes.Role, "Admin"),
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // Save token 
            var user = _context.Users.FirstOrDefault(u => u.username == signIn.username);
            user.RefresherToken = tokenHandler.WriteToken(token);
            _context.SaveChanges();

            return new Tokens { Token = tokenHandler.WriteToken(token) };
        }
    }
}
