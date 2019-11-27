using System;

namespace Task2_1_2_4

{
    internal class User
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; }
        public DateTime DateOfBirth { get; }
        public int Age
        {
            get
            {
                DateTime tmp = DateTime.Now;
                return (tmp - DateOfBirth).Days / 365;
            }
        }

        public User(string name, string lastName, string secondName, DateTime dateOfBirth)
        {
            Name = name;
            LastName = lastName;
            SecondName = secondName;
            if ((DateTime.Now - dateOfBirth).Days / 365 < 16)
            {
                throw new ArgumentException("User is too yong", nameof(dateOfBirth));
            }
            else if ((DateTime.Now - dateOfBirth).Days / 365 > 85)
            {
                throw new ArgumentException("User is too old", nameof(dateOfBirth));
            }
            else
            {
                DateOfBirth = dateOfBirth;
            }
        }
    }
}
