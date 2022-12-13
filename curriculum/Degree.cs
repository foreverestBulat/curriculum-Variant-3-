using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curriculum
{
    internal class Degree
    {
        public int Code { get; set; }
        public string Title { get; set; }
        public int CreditsRequired { get; set; }
        public int SpecialCoursesRequired { get; set; }

        public Degree(int code, string title, int creditsRequired, int specialCoursesRequired)
        {
            Code = code;
            Title = title;
            CreditsRequired = creditsRequired;
            SpecialCoursesRequired = specialCoursesRequired;
        }

        public override string ToString()
        {
            return "[---------------\n" +
                $"\tКод: {Code}\n" +
                $"\tНазвагие {Title}\n" +
                $"\tНужное количество кредитов: {CreditsRequired}\n" +
                $"\tМнимальное кол-во спецкурсов {SpecialCoursesRequired}\n" +
                    "---------------]";
        }
        //public void Init()
        //{

        //}
    }
}
