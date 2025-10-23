using Survay.Contracts.RepositoryContracts;
using Survay.Contracts.ServiceContracts;
using Survay.Domain.Entities;
using Survay.Infrastructure.Repositories;
using Survay.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survay.Services
{
    public class LoginService : ILoginService
    {
        private readonly INormalUserRepository _nuser;

        private readonly IAdminRepository _admin;
        public LoginService()
        {
            _nuser = new NormalUserRepository();

            _admin = new AdminRepository();
        }

        public bool Login(string username, string password)
        {
            var user = _admin.Login(username, password);
            if (user == null)
            {
                user = _nuser.Login(username, password);

                if (user == null)
                {
                    return false;
                }
                else
                {
                    InMemoryDb.Athenticate(user);
                    return true;
                }
            }
            else
            {
                InMemoryDb.Athenticate(user);
                return true;
            }
        }
    }
}
