using SQLite;
using ProjektMAUI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjektMAUI.Models
{
    public class User
    {


        [PrimaryKey, AutoIncrement]
        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public User() { }

        public User(string FirstName, string LastName,string Email) 
        {
            this.FirstName = FirstName;
            this.LastName = LastName;   
            this.Email = Email;
        }
    }
}
