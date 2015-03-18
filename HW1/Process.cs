using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstProject.Homework1._1
{
    class Process
    {
        Student[] stdArray;
        Lesson[] lesArray;
        double[] studentAvarage;


        public Process(Student[] stArray, Lesson[] lesArray)
        {
            this.stdArray = new Student[stArray.Length];
            this.lesArray = new Lesson[lesArray.Length];
            this.studentAvarage = new double[stArray.Length];

            for (int i = 0; i < lesArray.Length; i++)
            {
                this.lesArray[i] = lesArray[i];
            }

            for (int i = 0; i < stArray.Length; i++)
            {
                double sum = 0;
                this.stdArray[i] = stArray[i];
                
                //Ogrenci ortalamalari hesaplanir
                for (int j = 0; j < 3; j++)
                {
                    sum = sum + lesArray[j].Note[i];
                }
                studentAvarage[i] = sum / 3;
            }

        }

        //Ogrenci bilgileriyle birlikte tum notlarini goruntuler
        public void displayAll()
        {
            //Cikti formati duzenler
            string tool = "Format(Number Name:";
            for (int i = 0; i < lesArray.Length; i++)
            {
                tool = tool + " / " + lesArray[i].LessonName;
            }
            tool = tool + ")\n";
            Console.WriteLine(tool);
            
            //Ogrenci bilgileri duzenler
            for (int i = 0; i < stdArray.Length; i++)
            {
                Console.Write(stdArray[i].Number + " " + stdArray[i].Name + ": ");
                for (int j = 0; j < lesArray.Length; j++)
                {
                    Console.Write("\t/ " + lesArray[j].Note[i]);
                }
                Console.WriteLine();
            }
        }

        //Aldigi parametrelerdeki verileri donderir
        public string display(Lesson lesson, int i)
        {
            return stdArray[i].Number + " " + stdArray[i].Name + ": " + lesson.Note[i];
        }

        //Derslerin not ortalamalarini hesaplar
        public double avarageLesson(Lesson lesson)
        {
            double sum = 0;
            for (int i = 0; i < lesson.Note.Length; i++)
            {
                sum = sum + lesson.Note[i];
            }
            return sum / lesson.Note.Length;
        }

        //Ogrencileri ortalamalarina gore siralar
        public void studentAvarageList()
        {
            //Degisim icin kullanilan 2 degisken 
            double swapAvarage; 
            Student swapStudent;

            //Booble shorting kullanilir
            for (int i = 0; i < stdArray.Length - 1; i++)
            {
                for (int j = 0; j < stdArray.Length - i - 1; j++)
                {
                    if (studentAvarage[j] > studentAvarage[j + 1])
                    {
                        swapAvarage = studentAvarage[j];
                        studentAvarage[j] = studentAvarage[j + 1];
                        studentAvarage[j + 1] = swapAvarage;

                        swapStudent = stdArray[j];
                        stdArray[j] = stdArray[j + 1];
                        stdArray[j + 1] = swapStudent;
                    }
                }
            }

            //Yazim formatinin belirlenmesi ve listenin yazdirilmasi
            Console.WriteLine("Format(Number  Name: Avarage)\n");
            for (int i = 0; i < stdArray.Length; i++)
            {
                Console.WriteLine(stdArray[i].Number + " " + stdArray[i].Name + ":\t" + studentAvarage[i]);
            }
        }

        //Ogrencileri numaralarina gore siralar
        public void studentNumberList()
        {
            //Degisim icin kullanilan 2 degisken 
            Student swap;
            double lesswap;

            //Booble shorting kullanilir
            for (int i = 0; i < stdArray.Length - 1; i++)
            {
                for (int j = 0; j < stdArray.Length - 1 - i; j++)
                {
                    if (String.Compare(stdArray[j].Number, stdArray[j + 1].Number) == 1)
                    {
                        swap = stdArray[j];
                        stdArray[j] = stdArray[j + 1];
                        stdArray[j + 1] = swap;

                        for (int k = 0; k < lesArray.Length; k++)
                        {
                            lesswap = lesArray[k].Note[j];
                            lesArray[k].Note[j] = lesArray[k].Note[j + 1];
                            lesArray[k].Note[j + 1] = lesswap;
                        }
                    }
                }
            }
            displayAll();
        }

        //Notlari 60 dan az olan ogrencileri belirler
        public void lessThan60(Lesson lesson)
        {
            Console.WriteLine("for " + lesson.LessonName+":");
            for (int i = 0; i < stdArray.Length; i++)
            {
                if (lesson.Note[i] < 60)
                {
                    Console.WriteLine("\t"+display(lesson, i));
                }
            }
        }

        //Derslere gore ortalamadan yuksek alan ogrencileri belirler
        public void aboveAvarage(Lesson lesson)
        {
            Console.WriteLine("for " + lesson.LessonName+":");
            for (int i = 0; i < stdArray.Length; i++)
            {
                if (lesson.Note[i] > avarageLesson(lesson))
                {
                    Console.WriteLine("\t"+display(lesson, i));
                }
            }
        }

        //Derslere gore notlari 60 dan az olan ogrenci sayisini donderir
        public void lessThan60Amount(Lesson lesson)
        {
            int value = 0;
            Console.Write("for " + lesson.LessonName+": ");
            for (int i = 0; i < stdArray.Length; i++)
            {
                if (lesson.Note[i] < 60)
                {
                    value++;
                }
            }
            Console.WriteLine(value + "\n");
        }

        //Derslere gore notu en yuksek olanlari belirler
        public void highestNote(Lesson lesson)
        {
            double highest = lesson.Note[0];            
            string result = "Of "+ lesson.LessonName +" the highest note\n";

            //En yuksek not degerinin belirlenmesi
            for (int i = 0; i < lesson.Note.Length; i++)
            {
                if (highest < lesson.Note[i])
                {
                    highest = lesson.Note[i];                    
                }
            }
            
            //En yüksek notu alan ogrencilerin belirlenmesi
            for (int i = 0; i < lesson.Note.Length; i++)
            {
                if (lesson.Note[i] == highest)
                {
                    result = result + "\t" + display(lesson, i) + "\n";
                }
            }
            Console.WriteLine(result);
        }

        //Derslere gore notu en dusuk olanlari belirler
        public void lowestNote(Lesson lesson)
        {
            double lowest = lesson.Note[0];            
            string result = "Of " + lesson.LessonName + " the lowest note\n";
            for (int i = 0; i < lesson.Note.Length; i++)
            {
                if (lowest > lesson.Note[i])
                {
                    lowest = lesson.Note[i];                    
                }
            }
            
            //En düşün notu alan diğer öğrencileri kontrol eder
            for (int i = 0; i < lesson.Note.Length; i++)
            {
                if (lesson.Note[i] == lowest)
                {
                    result = result + "\t" + display(lesson, i) + "\n";
                }
            }
            Console.WriteLine(result);
        }
    }
}
