using ProjektMAUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektMAUI.Services
{
    public interface IUserService
    {
        Task<List<User>> GetUserService();

        Task<int> CheckIsExsist(User student);

        Task<int> AddUser(User student);

        Task<int> DeleteUser(User student);




    }
}
