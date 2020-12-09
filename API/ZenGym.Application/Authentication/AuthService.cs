using System;
using System.Threading.Tasks;
using ZenGym.Application.Common;
using ZenGym.Domain.Entities;
using ZenGym.Domain.Services;

namespace ZenGym.Application.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly IUserDataService _userDataService;

        public AuthService(IUserDataService userDataService)
        {
            _userDataService = userDataService;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _userDataService.GetByUsername(username);

            if (user == null)
                return null;

            if (!CommonSecurity.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;


        }
        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CommonSecurity.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            return await _userDataService.CreateAsync(user);

        }


        public async Task<bool> UserExists(string username) => await _userDataService.IsUserExist(username);
    }
}