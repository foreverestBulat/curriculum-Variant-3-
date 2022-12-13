using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace curriculum
{
    internal class Curriculum
    {
        public int Code { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ConfirmationDate { get; set; }
        public Student Student { get; set; }
        public int DegreeCode { get; set; }
        public List<Degree> ListDegree { get; set; }
        public List<Course> ListCourses { get; set; }
        //public List<Student> ListStudents { get; set; }

        public Curriculum(Student student = null, int degreeCode = 0, int code = 0, DateTime creationDate = new DateTime())
        {
            Student = student;
            DegreeCode = degreeCode;
            Code = code;
            CreationDate = creationDate;
            ListDegree = new List<Degree>();
            ListCourses = new List<Course>();
        }

        public void AddNewCourse(int code, string title, bool isSpecial, int lectureHours,
            int practiseHours, bool hasExam, bool hasCoursePaper, List<int> prerequisities)
        {
            Course course = new Course(code, title, isSpecial, lectureHours, 
                practiseHours, hasExam, hasCoursePaper, prerequisities);

            ListCourses.Add(course);
        }

        public void DeleteCourse(int code)
        {
            for (int i = 0; i < ListCourses.Count; i++)
                if (ListCourses[i].Code == code)
                    ListCourses.RemoveAt(i);

            for (int i = 0; i < ListCourses.Count; i++)
                ListCourses[i].Code = i + 1;
        }

        public void PrintCourse()
        {
            Console.WriteLine("Список курсов:");
            foreach (Course course in ListCourses)
                Console.WriteLine(course.ToString());
        }

        public bool LaborIntensityOfCourse(List<int> numbers, int countCredit, int countSpecialCourse)
        {
            int c = 0;
            int lecH = 0;
            int pracH = 0;

            int countSpecCourse = 0;

            for (int i = 0; i < ListCourses.Count; i++)
            {
                if (numbers.Contains(ListCourses[i].Code))
                {
                    lecH += ListCourses[i].LectureHours;
                    pracH += ListCourses[i].PractiseHours;

                    if (ListCourses[i].HasExam) c++;
                    if (ListCourses[i].HasCoursePaper) c += 2;
                    if (ListCourses[i].IsSpecial) countSpecCourse++;
                }
            }

            c += (int)(lecH + pracH * 1.25) / 18;

            if (countSpecCourse >= countSpecialCourse)
            {
                //Console.WriteLine("Не хватает кредитов");
                return c >= countCredit;
            }
            Console.WriteLine("Не хватает кол-ва спецкурсов");
            return false;
        }

        public void Init()
        {
            //ListStudents.Add(new Student(1,
            //    "Иванов Иван Иванович",
            //    new DateTime(2002, 10, 10)));

            //ListStudents.Add(new Student(1,
            //    "Субухнакулов Булат Ильшатович",
            //    new DateTime(2004, 12, 11)));

            //ListStudents.Add(new Student(1,
            //    "Сергеев Сергей Сергеевич",
            //    new DateTime(2001, 3, 5)));

            //ListStudents.Add(new Student(1,
            //    "Дмитров Дмитрий Дмитриевич",
            //    new DateTime(2002, 7, 13)));

            //ListStudents.Add(new Student(1,
            //    "Александров Александр Александрович",
            //    new DateTime(2004, 9, 15)));


            ListDegree.Clear();
            ListDegree.Add(new Degree(
                1,
                "Интеллектуальные системы",
                70,
                2));

            ListDegree.Add(new Degree(
                2,
                "Прикладная математика",
                60,
                1));

            ListDegree.Add(new Degree(
                3,
                "Психология личной эффективности",
                30,
                0));

            ///

            ListCourses.Clear();
            ListCourses.Add(new Course(
                1,
                "Объектно-ориентированное програмирование",
                true,
                150,
                200,
                true,
                true,
                new List<int>() { 2, 3 }));

            ListCourses.Add(new Course(
                2,
                "Дискретная математика",
                true,
                40,
                20,
                true,
                false,
                null));

            ListCourses.Add(new Course(
                3,
                "Математический анализ",
                true,
                40,
                20,
                true,
                false,
                null));

            ListCourses.Add(new Course(
                4,
                "Русский язык",
                false,
                10,
                30,
                true,
                false,
                null));

            ListCourses.Add(new Course(
                5,
                "Английский язык",
                false,
                10,
                70,
                true,
                false,
                null));

            ListCourses.Add(new Course(
                6,
                "Алгебра и геометрия",
                false,
                150,
                200,
                true,
                false,
                null));

            ListCourses.Add(new Course(
                7,
                "Физкультура",
                false,
                150,
                200,
                true,
                false,
                null));

            ListCourses.Add(new Course(
                8,
                "Веб-разработка",
                false,
                5,
                40,
                false,
                false,
                null));

            ListCourses.Add(new Course(
                9,
                "Язык программирования C++",
                true,
                30,
                150,
                true,
                true,
                new List<int>() { 2, 3, 6 }));

            ListCourses.Add(new Course(
                10,
                "Язык программирования C#",
                true,
                30,
                150,
                true,
                true,
                new List<int>() { 2, 3, 6 }));

            ListCourses.Add(new Course(
                11,
                "Язык программирования Java",
                true,
                30,
                150,
                true,
                true,
                new List<int>() { 2, 3, 6 }));

            ListCourses.Add(new Course(
                12,
                "Черчение",
                false,
                10,
                50,
                false,
                false,
                new List<int> { 6 }));

            ListCourses.Add(new Course(
                13,
                "История Руси",
                false,
                50,
                10,
                false,
                false,
                null));

            ListCourses.Add(new Course(
                14,
                "История до нашей эры",
                false,
                50,
                10,
                false,
                false,
                null));

            ListCourses.Add(new Course(
                15,
                "Язык программирования Python",
                true,
                20,
                120,
                true,
                true,
                new List<int>() { 2, 3 }));
        }

        public void PrintDegrees()
        {
            Console.WriteLine("Список квалификационных степеней: ");
            foreach(var degree in ListDegree)
                Console.WriteLine(degree.ToString());
        }
    }
}
