using System;
using System.Collections.Generic;
using System.Linq;

namespace LabLinq2
{
    /// <summary>
    /// Student defined by its name, major, graduation year,
    /// and whether the student is an honor student or not.
    ///
    /// author: CSIS 2420 - do not modify
    /// </summary>
    public class Student
    {
        public string Name { get; }
        public int Age { get; }
        public string Major { get; }
        public int Year { get; }
        public bool Honor { get; }

        public Student(string name, int age, string major, int year, bool honor)
        {
            Name = name;
            Age = age;
            Major = major;
            Year = year;
            Honor = honor;
        }

        public override string ToString()
        {
            return string.Format("{0}{1} {2} ({3}) .. {4}", Honor ? "*" : " ", Name, Age, Year, Major);
        }
    }

}
