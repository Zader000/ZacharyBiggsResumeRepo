using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabLinq2
{
    public class Program
    {
        #region student list
        private static List<Student> students = new List<Student> {
            new Student("Don", 40, "CS", 2015, true),
            new Student("Dan", 22, "CS", 2012, true),
            new Student("Dee", 31, "CS", 2013, false),
            new Student("Bob", 18, "CJ", 2013, false),
            new Student("Ben", 19, "CJ", 2013, true),
            new Student("Jan", 24, "FA", 2012, true),
            new Student("Jim", 17, "FA", 2014, false),
            new Student("Rob", 28, "EE", 2015, true),
            new Student("Ray", 35, "EE", 2012, true)
         };
        #endregion

        #region Main
        static void Main(string[] args)
        {
            IEnumerable<Student> students2013 =
                students
                .Where(s => s.Year == 2013)
                .Select(s => s);
            Console.WriteLine("Students graduation in 2013: ");
            Console.WriteLine(String.Join("\n", students2013));
            Console.WriteLine();

            int numberStudents2015 =
                students
                .Where(s => s.Year == 2015)
                .Select(s => s)
                .Count();
            Console.WriteLine($"Count of students graduating in 2015: {numberStudents2015}\n");

            int youngestEEStudent =
                students
                .Where(s => s.Major == "EE")
                .Min(s => s.Age);
            Console.WriteLine($"Youngest EE student: {youngestEEStudent}\n");

            double averageAgeCSStudent =
                students
                .Where(s => s.Major == "CS")
                .Average(s => s.Age);
            Console.WriteLine($"Average age of CS Student: {averageAgeCSStudent}\n");

            IEnumerable<Student> first4Students =
                students
                .Take(4)
                .OrderBy(s => s.Year)
                .ThenBy(s => s.Age);
            Console.WriteLine($"First 4 students: ");
            Console.WriteLine(String.Join("\n", first4Students));
            Console.WriteLine();

            Console.WriteLine("======ADD ADDITIONAL STUDENTS======\n");
            students.Add(new Student("Mia", 16, "EE", 2015, false));
            students.Add(new Student("Noa", 31, "CS", 2022, true));



            Console.WriteLine("Students graduation in 2013: ");
            Console.WriteLine(String.Join("\n", students2013));
            Console.WriteLine();

            Console.WriteLine($"Count of students graduating in 2015: {numberStudents2015}\n");

            Console.WriteLine($"Youngest EE student: {youngestEEStudent}\n");

            Console.WriteLine($"Average age of CS Student: {averageAgeCSStudent}\n");

            Console.WriteLine($"First 4 students: ");
            Console.WriteLine(String.Join("\n", first4Students));
            Console.WriteLine();


            //LinqChallenge2();
        }

        static void LinqChallenge2()
        {
            Console.WriteLine("\nL I N Q   C H A L L E N G E 2:");

            Console.WriteLine("\n\n======= Group students by honor (no group name):");
            GroupStudentsByHonorNoGroupName();

            Console.WriteLine("\n\n======= Group students by honor (with group name):");
            GroupStudentsByHonorWithGroupName();

            Console.WriteLine("\n\n======= Group students by major:");
            GroupStudentsByMajor();

            Console.WriteLine("\n\n======= Group students by first letter of major:");
            GroupStudentsByFirstLetterOfMajor();

            Console.WriteLine("\n\n======= Group student names by year:");
            GroupStudentNamesByYear();

            Console.WriteLine("\n\n======= Group student names by year (ordered by year):");
            GroupStudentNamesByYearOrdered();

            Console.WriteLine("\n\n======= Number of students per year:");
            NumberOfStudentsPerYear();

            Console.WriteLine("\n\n======= List Numbered Students:");
            ListNumberedStudents();

            Console.WriteLine("\n\n. . . press enter . . .");
            Console.Read();
        }
        #endregion

        #region groupStudentsByHonor()
        private static void GroupStudentsByHonorNoGroupName()
        {
            var honorGroups = from student in students
                                 group student by student.Honor;   
            foreach(var group in honorGroups)
            {
                Console.WriteLine(group.Key ? "Honor Students:" : "Non-Honor Students:");
                foreach(Student s in group)
                {
                    Console.WriteLine($"  {s}");
                }
            }     
        }

        private static void GroupStudentsByHonorWithGroupName()
        {
            var honorGroups = from student in students
                              group student by student.Honor into g
                              select new {Honor = g.Key, Students = g};
            foreach (var group in honorGroups)
            {
                Console.WriteLine(group.Honor ? "Honor Students:" : "Non-Honor Students:");
                foreach (Student s in group.Students)
                {
                    Console.WriteLine($"  {s}");
                }
            }
        }
        #endregion

        #region groupStudentsByMajor()
        private static void GroupStudentsByMajor()
        {
            var majorGrouped = from student in students
                               group student by student.Major into g
                               select new { Major = g.Key, Students = g};

            foreach (var group in majorGrouped)
            {
                Console.WriteLine(group.Major);
                foreach (Student s in group.Students)
                {
                    Console.WriteLine($"  {s}");
                }
            }
        }
        #endregion

        #region groupStudentsByFirstLetterOfMajor()
        private static void GroupStudentsByFirstLetterOfMajor()
        {
            var firstLetterOfMajorGrouped = from student in students
                                           group student by student.Major[0] into g
                                           select new { FirstLetterOfMajor = g.Key, 
                                               Students = g};
            foreach (var group in firstLetterOfMajorGrouped)
            {
                Console.WriteLine(group.FirstLetterOfMajor);
                foreach (Student s in group.Students)
                {
                    Console.WriteLine($"  {s}");
                }
            }

        }
        #endregion

        #region GroupStudentNamesByYear
        private static void GroupStudentNamesByYear()
        {
            var groupedNamesByYear = from student in students
                                     group student.Name by student.Year into g
                                     select new { Year = g.Key, StudentNames = g };

            foreach (var group in groupedNamesByYear)
            {
                Console.WriteLine(group.Year);
                foreach (string name in group.StudentNames)
                {
                    Console.WriteLine($"  {name}");
                }
            }
        }
        #endregion

        #region GroupStudentNamesByYearOrdered
        private static void GroupStudentNamesByYearOrdered()
        {
            var groupedNamesByYearOrdered = from student in students
                                            group student.Name by student.Year into g
                                            orderby g.Key
                                            select new { Year = g.Key, StudentNames = g };

            foreach (var group in groupedNamesByYearOrdered)
            {
                Console.WriteLine(group.Year);
                Console.WriteLine(string.Join(", ", group.StudentNames));
            }
        }
        #endregion

        #region NumberOfStudentsPerYear
        private static void NumberOfStudentsPerYear()
        {
            var studentCountPerYear = from student in students
                                       group student by student.Year into g
                                       select new { Year = g.Key, Count = g.Count() };
            foreach (var group in studentCountPerYear)
            {
                Console.WriteLine($"Count for {group.Year}: {group.Count}");
            }
        }
        #endregion

        #region ListNumberedStudents
        private static void ListNumberedStudents()
        {
            // not part of final
            // https://slcc.instructure.com/courses/730411/modules/items/15530430
        }
        #endregion
    }
}
