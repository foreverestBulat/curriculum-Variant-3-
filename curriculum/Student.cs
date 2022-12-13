using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curriculum
{
    internal class Student
    {
        public int ApplicationNumber { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }

        public Student(int applicationNumber, string fullName, DateTime birthDate)
        {
            ApplicationNumber = applicationNumber;
            FullName = fullName;
            BirthDate = birthDate;
        }
    }
}
