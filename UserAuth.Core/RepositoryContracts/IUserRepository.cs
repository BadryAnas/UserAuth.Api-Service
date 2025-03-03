using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAuth.Core.Entities;

namespace UserAuth.Core.RepositoryContracts
{
    public interface IUserRepository
    {
        Task<ApplicationUser> AddUser(ApplicationUser? user);
        Task<ApplicationUser?> GetUserByEmailAndPassword(string? Email, string? Password);
    }
}
