using ProjektMAUI.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektMAUI.Services
{
    public class UserService : IUserService
    {
        private SQLiteAsyncConnection _dbConnection;
        public UserService() {

            SetUpOb();
      
        }

        private async void SetUpOb()
        {
            // łącznie się z bazą danych
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Student.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await  _dbConnection.CreateTableAsync<User>();
            }
        }

        public async Task<int> CheckIsExsist(User user)
        {
            //sprawdza czy dany element istnieje w tablicy
            var list = await GetUserService();
            int IsExsists = 0;

            list.ForEach(item =>
            {
                if (item == user) { IsExsists = 1; }

            });

            return IsExsists;
        }

        public Task<int> AddUser(User user)
        {
            //dodaje użytkownika do bazy dancyh
          return _dbConnection.InsertAsync(user);
        }

        public Task<int> DeleteUser(User user)
        {
            //usuwa użytkownika z bazy danych
            return _dbConnection.DeleteAsync(user);
        }

        public async Task<List<User>> GetUserService()
        {
            //pobiera elementy z tablicy
            var userList =await _dbConnection.Table<User>().ToListAsync();
            return userList;
        }
    }
}
