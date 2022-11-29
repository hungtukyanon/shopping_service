﻿using Microsoft.AspNetCore.Mvc;
using shopping_services.Models;
using shopping_services.Services.AuthService;

namespace shopping_services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        public AuthsController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            try
            {
                return Ok(_authRepository.GetUsers());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("sign-in")]
        public IActionResult SingIn(string username, string password)
        {
            var token = _authRepository.SignIn(username, password);
            if(token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }

        [HttpPost("sign-up")]
        public IActionResult SignUp(AuthModel authModel)
        {
            try
            {
                return Ok(_authRepository.signUp(authModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
