using System;

namespace Task2_1_2_4
{
    internal class Employee : User
    {
        public DateTime DateOfHire { get; }
        public int Experience
        {
            get
            {
                DateTime tmp= DateTime.Now;
                return (tmp - DateOfHire).Days / 365;
            }
        }

        public string Position { get; set; }
        public Employee(string name, string lastName, string secondName, DateTime dateOfBirth, DateTime dateOfHire, string position) : base(name, lastName, secondName, dateOfBirth)
        {
            DateOfHire = dateOfHire;
            Position = position;
        }
    }
}
