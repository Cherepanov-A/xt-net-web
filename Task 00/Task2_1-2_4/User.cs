using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1_2_4
{
    class User
    {
        //private string name;
        //private string lastName;
        //private string secondName;
        private DateTime dateOfBirth;
        private int age;

        public string Name { get; set;}
        public string LastName { get; set; }
        public string SecondName { get; }
        public DateTime DateOfBirth => dateOfBirth;

        public int Age => (DateTime.Now - dateOfBirth).Days/365;
        
        public User(string name, string lastName, string secondName, DateTime dateOfBirth)
        {
            Name = name;
            LastName = lastName;
            SecondName = secondName;
            if ((DateTime.Now-dateOfBirth).Days/365<16)
            {
                throw new ArgumentException("User is too yong");
            }
            else if ((DateTime.Now - dateOfBirth).Days / 365>85)
            {
                throw new ArgumentException("User is too old");
            }
            else
            {
                this.dateOfBirth = dateOfBirth;
            }
        }
    }
}
