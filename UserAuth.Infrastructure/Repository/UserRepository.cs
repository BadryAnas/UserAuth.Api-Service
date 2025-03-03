using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAuth.Core.Entities;
using UserAuth.Core.RepositoryContracts;
using UserAuth.Infrastructure.DbContexts;

namespace UserAuth.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperDbContext _dbContext;

        public UserRepository(DapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApplicationUser?> AddUser(ApplicationUser? user)
        {
            user.UserId = Guid.NewGuid();

            string query = "INSERT INTO public.\"Users\"(\"UserId\",\"Email\", \"PersonName\", \"Gender\", \"Password\")" +
                "VALUES(@UserId,@Email,@PersonName,@Gender,@Password)";

            int numberOfRowsAffected =await _dbContext.dbConnection.ExecuteAsync(query, user);

            if (numberOfRowsAffected > 0)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
        {
            string query = "SELECT * FROM public.\"Users\" WHERE \"Email\"=@Email and \"Password\"=@Password";

            var parameters = new { Email = email, Password = password};

            ApplicationUser? user =await _dbContext.dbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);


            return user;


            //return new ApplicationUser()
            //{
            //    Email = email,
            //    Password = password,
            //    UserId = Guid.NewGuid(),
            //    Gender = GenderOptions.Male.ToString(),
            //    PersonName = "Badry"
            //};

        }
    }
}
