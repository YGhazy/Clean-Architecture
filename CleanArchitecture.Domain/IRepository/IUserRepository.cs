using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.IRepository
{
    public interface IUserRepository : IAsyncRepository<User>
    {


    }
}
