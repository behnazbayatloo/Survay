using Microsoft.EntityFrameworkCore;
using Survay.Contracts.RepositoryContracts;
using Survay.Domain.Dto;
using Survay.Infrastructure.AppDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survay.Infrastructure.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _dbcontext;
        public AdminRepository()
        {
            _dbcontext = new AppDbContext();
            
        }

        public LoginUserDto Login(string username , string password)
        {
            return _dbcontext.Admins.AsNoTracking().Where(a => a.UserName == username && a.Password == password)
                .Select(a => new LoginUserDto
                {
                    UserName = a.UserName,
                    Id = a.Id,
                    Role="Admin"
                }).FirstOrDefault();
        }
    }
}
