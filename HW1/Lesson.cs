using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstProject.Homework1._1
{
    class Lesson
    {
        static int lesValue = 1;

        double[] note;

        public double[] Note
        {
            get { return note; }
            set { note = value; }
        }

        string lessonName;

        public string LessonName
        {
            get { return lessonName; }
            set { lessonName = value; }
        }

        //Ders ismi girilmediginde calisir
        public Lesson(double[] nt)
        {
            //Default isim atanir
            this.lessonName = "Lesson"+Convert.ToString(lesValue);
            lesValue++;

            note = new double[nt.Length];

            for (int i = 0; i < note.Length; i++)
            {
                this.note[i] = nt[i];
            }
        }

        public Lesson(double[] nt, string name)
        {
            lessonName = name;
            note = new double[nt.Length];

            for (int i = 0; i < note.Length; i++)
            {
                this.note[i] = nt[i];
            }
        }
    }
}
