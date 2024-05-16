using ProjektDoKupki.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektDoKupki.Services
{
    public class UserService : IUserService
    {
        private SQLiteAsyncConnection _dbConnection;
        public UserService() {

            SetUpOb();
      
        }

        private async void SetUpOb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Student.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await  _dbConnection.CreateTableAsync<User>();
            }
        }

        public async Task<int> CheckIsExsist(User student)
        {
            var list = await GetStudentService();
            int IsExsists = 0;

            list.ForEach(item =>
            {
                if (item == student) { IsExsists = 1; }

            });

            return IsExsists;
        }

        public Task<int> AddStudent(User student)
        {
          return _dbConnection.InsertAsync(student);
        }

        public Task<int> DeleteStudent(User student)
        {
            return _dbConnection.DeleteAsync(student);
        }

        public async Task<List<User>> GetStudentService()
        {
            var studentList =await _dbConnection.Table<User>().ToListAsync();
            return studentList;
        }

        public Task<int> UpdateStudent(User student)
        {
            return _dbConnection.UpdateAsync(student);
        }
    }
}
