using curriculum;
using System.Collections;

Curriculum curriculum = new Curriculum();
curriculum.Init();

while (true)
{
    Console.WriteLine("Создать учебную программу: 1\n" +
        "Добавить учебный курс: 2\n" +
        "Удалить курс: 3\n" +
        "Закончить программу: 4");

    int change = int.Parse(Console.ReadLine());

    switch (change)
    {
        case 1:
            Console.WriteLine("Введите номер заявления: ");
            int applicationNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите ФИО студента: ");
            string fullName = Console.ReadLine();

            Console.WriteLine("Введите регистрационный номер учебной программы: ");
            int regNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите через пробел дату рождения студента(дд/мм/гггг): ");
            string[] date = Console.ReadLine().Split(' ');
            DateTime dateBirth = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));

            var student = new Student(applicationNumber, fullName, dateBirth);

            Console.WriteLine("Выберите квалификационную степень: ");
            curriculum.PrintDegrees();
            int code = int.Parse(Console.ReadLine());

            curriculum.Student = student;
            curriculum.DegreeCode = code;
            curriculum.Code = regNumber;
            curriculum.CreationDate = DateTime.Now;


            Console.WriteLine("Выберите какие курсы вы хотите изучить(вводите номера курсов через пробел): ");
            curriculum.PrintCourse();
            string strSelectedСourses = Console.ReadLine();
            List<int> selectedCourses = new List<int>();
            foreach (var num in strSelectedСourses.Split(' '))
                selectedCourses.Add(int.Parse(num));


            if (curriculum.LaborIntensityOfCourse(selectedCourses, curriculum.ListDegree[code - 1].CreditsRequired, curriculum.ListDegree[code - 1].SpecialCoursesRequired))
            {
                Console.WriteLine("Вы можете получить выбранную степень");
            }
            else
            {
                Console.WriteLine("Вы не можете получить выбранную степень");
            }
            continue;
        case 2:
            Console.WriteLine("Введите название нового курса: ");
            string title = Console.ReadLine();

            Console.WriteLine("Ваш курс является специальным(ДА - 1, НЕТ - 0)?");
            int intSpecCourse = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите кол-во часов лекций: ");
            int lectureHours = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите кол-во часов практик: ");
            int practiseHours = int.Parse(Console.ReadLine());

            Console.WriteLine("У вашего курса есть экзамен(ДА - 1, НЕТ - 0)?");
            int intHasExam = int.Parse(Console.ReadLine());

            Console.WriteLine("У вашего курса есть курсовая работа(ДА - 1, НЕТ - 0)?");
            int intHasCoursePaper = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Назвовите номера дополнительных курсов для вашего через пробел(если нету, ничего не пишите): ");
            curriculum.PrintCourse();
            List<int> numbers = null;
            string str = Console.ReadLine();
            if(str != "")
                foreach (var number in str.Split())
                {
                    numbers = new List<int>();
                    numbers.Add(int.Parse(number));
                }

            curriculum.AddNewCourse(curriculum.ListCourses.Count + 1, title, Convert.ToBoolean(intSpecCourse), lectureHours, practiseHours, Convert.ToBoolean(intHasExam), Convert.ToBoolean(intHasCoursePaper), numbers);
            //curriculum.PrintCourse();
            continue;
        case 3:
            Console.WriteLine("Напишите код курса который хотите удалить: ");
            curriculum.PrintCourse();
            int a = int.Parse(Console.ReadLine());
            curriculum.DeleteCourse(a);

            continue;
        case 4:
            return ;
    }
}

//Curriculum curriculum1 = new Curriculum();