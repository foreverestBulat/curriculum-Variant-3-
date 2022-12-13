using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curriculum
{
    internal class Course
    {
        public int Code { get; set; }
        public string Title { get; set; }
        public bool IsSpecial { get; set; }
        public int LectureHours { get; set; }
        public int PractiseHours { get; set; }
        public bool HasExam { get; set; }
        public bool HasCoursePaper { get; set; }
        public List<int> Prerequisities { get; set; }

        public Course(int code, string title, bool isSpecial, int lectureHours, 
            int practiseHours, bool hasExam, bool hasCoursePaper, List<int> prerequisities)
        {
            Code = code;
            Title = title;
            IsSpecial = isSpecial;
            LectureHours = lectureHours;
            PractiseHours = practiseHours;
            HasExam = hasExam;
            HasCoursePaper = hasCoursePaper;
            Prerequisities = prerequisities;
        }

        public override string ToString()
        {
            return "[---------------------\n" + 
                $"\tКод: {Code}\n" +
                $"\tНазвание: {Title}\n " +
                $"\tСпецкурс: {IsSpecial}\n " +
                $"\tКоличество часов лекций: {LectureHours}\n " +
                $"\tКоличество часов практик: {PractiseHours}\n " +
                $"\tЭкзамен: {HasExam}\n " +
                $"\tКурсовая работа: {HasCoursePaper}\n" + //Номера дополнительных курсов: {PrintPrerequisities()
                $"\tНомера дополнительных курсов: {PrintPrerequisities()}\n" +   
                "---------------------]";
        }

        public string PrintPrerequisities()
        {
            if (Prerequisities != null)
            {
                string r = "";
                foreach (int numberCourse in Prerequisities)
                    r += $"{Convert.ToString(numberCourse)} ";

                return r;
            }
            return "[пусто]";

        }
    }
}
