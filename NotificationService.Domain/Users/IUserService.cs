using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Domain.Users
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(Guid userId);
        Task<Dictionary<string, string>> GenerateInternalTokens(Guid userId);
    }
}
