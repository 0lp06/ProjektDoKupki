using ProjektDoKupki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektDoKupki.Services
{
    public interface IUserService
    {
        Task<List<User>> GetStudentService();

        Task<int> CheckIsExsist(User student);

        Task<int> AddStudent(User student);

        Task<int> DeleteStudent(User student);

        Task<int> UpdateStudent(User student);




    }
}
