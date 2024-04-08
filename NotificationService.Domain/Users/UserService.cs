using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Domain.Users
{
    internal class UserService : IUserService
    {
        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            return new User { Id = Guid.NewGuid(), Name = "Amir Hosein", Email = "aha333.aha@gmail.com", PhoneNumber = "+09335583833" };
        }

        public async Task<Dictionary<string, string>> GenerateInternalTokens(Guid userId)
        {
            var user = await GetUserByIdAsync(userId);

            Dictionary<string, string> internalTokens = new Dictionary<string, string>();

            internalTokens.Add("Name", user.Name);
            internalTokens.Add("PhoneNumber", user.PhoneNumber);
            internalTokens.Add("Email", user.Email);

            return internalTokens;
        }
    }
}
