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
    public class NormalUserRepository : INormalUserRepository
    {
        private readonly AppDbContext _dbcontext;
        public NormalUserRepository()
        {
            _dbcontext= new AppDbContext();
        }
        public LoginUserDto Login(string username, string password)
        {
            return _dbcontext.NormalUsers.AsNoTracking().Where(a => a.UserName == username && a.Password == password)
                .Select(a => new LoginUserDto
                {
                    UserName = a.UserName,
                    Id = a.Id,
                    Role="Normal"
                }).FirstOrDefault();
        }

    }
}
