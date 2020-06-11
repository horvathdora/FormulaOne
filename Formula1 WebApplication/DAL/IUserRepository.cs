using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formula1_WebApplication.DAL
{
    public interface IUserRepository
    {
        Task SeedUserAsync();
    }
}
