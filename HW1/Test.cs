using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstProject.Homework1._1
{
    class Test
    {
        public static void Main(String[] args)
        {
            //Lesson nesneleri yanliz not arraylari veya istege gore ders isimleri eklenerek tanimlanir
            //Eklenmeyen ders isimlerine default isimler verilir
            //Note array leri ile Student array leri iliskisi 
            //0. Student nesnesine karsilik 
            //Not dizilerinde 0. deger gelir 
            //Ornek: std[0] daki ogrenci n1[0], n2[0], n3[0] daki notlari almistir 
            //Process sinifi Lesson ve Student arrayleri alir
            //Boylece Boylece bütün degerler birbiri ile baglamıis olur

            //Deger girmeden test etmeniz icin olsuturdugum nesneler
            /*Student[] std = new Student[3];
            std[0] = new Student("1580", "ahmet");
            std[1] = new Student("1200", "ilhan");
            std[2] = new Student("1300", "mertcan");

            //Not array leri
            double[] n1 = { 70, 70, 70 };
            double[] n2 = { 23, 23, 90 };
            double[] n3 = { 80, 95, 40 };

            Lesson[] lessonArr = new Lesson[3];
            lessonArr[0] = new Lesson(n1,"mat");
            lessonArr[1] = new Lesson(n2);
            lessonArr[2] = new Lesson(n3);
            int choose;
            Process process = new Process(std, lessonArr);*/



            Console.Write("Please input student amount: ");
            int stdAmount = Int32.Parse(Console.ReadLine());

            //Ders sayisi arttirilabilir default 3 degerini verdim.
            Console.WriteLine("Please input lesson amount: (default 3) ");
            int lesAmount = 3;
            //lesAmount = Int32.Parse(Console.ReadLine());


            Student[] studentArr = new Student[stdAmount];
            Lesson[] lessonArr = new Lesson[lesAmount];
            double[] notes = new double[stdAmount];

            Console.WriteLine("\n-Student informaiton list- \n");

            //Ogrenci bilgileri girisi 
            for (int i = 0; i < stdAmount; i++)
            {               
                Console.WriteLine((i + 1) + ". Student");
                Console.Write("Number: ");
                string number = Console.ReadLine();
                Console.Write("Name: ");
                string name = Console.ReadLine();

                //Aynı numarada ogrenci eklenmemesinin kontrolu
                if (Student.numberCheck(number) )
                {
                    Console.WriteLine("\nThis number is the same as the previous!");
                    Console.WriteLine("Please enter different number\n");
                    i--;
                    continue;
                }

                studentArr[i] = new Student(number, name);
            }

            //Ders bilgileri ve notlarin girilmesi
            for (int i = 0; i < lesAmount; i++)
            {
                Console.WriteLine("\n-Notes-");
                Console.Write("Lesson Name: ");
                string lesName = Console.ReadLine();

                //Olusturulan ogrencilere gore notlain girilmesi
                for (int j = 0; j < stdAmount; j++)
                {
                    Console.WriteLine("\nInput note for " + studentArr[j].Number + "-" + studentArr[j].Name);
                    Console.Write("Note: ");
                    notes[j] = Convert.ToDouble(Console.ReadLine());
                }

                lessonArr[i] = new Lesson(notes, lesName);
            }

            Process process = new Process(studentArr, lessonArr);
            int choose; //Menu secimi icin kullanilir


            while(true)
            {
                Console.Write("\nPress(m) for menu: ");
                char value = Convert.ToChar(Console.ReadLine());
                if (value == 'm')
                    Console.Clear(); //Console temizleme metodu

                Console.WriteLine("-MENU-");
                Console.WriteLine("0- Display all student information");
                Console.WriteLine("1- Avarage of lessons");
                Console.WriteLine("2- Less than 60 students");
                Console.WriteLine("3- Above avarage strudents");
                Console.WriteLine("4- Less than 60 result amount");
                Console.WriteLine("5- The highest results");
                Console.WriteLine("6- The lowest results");
                Console.WriteLine("7- Student list with general avarage");
                Console.WriteLine("8- Student list with student number");
                Console.WriteLine("9- Exit");

                Console.Write("Choose: ");
                choose = Int32.Parse(Console.ReadLine());
                
                Console.WriteLine();

                switch (choose)
                {
                    case 0:
                        process.displayAll();
                        break;
                    case 1:
                        for (int i = 0; i < lessonArr.Length; i++)
                        {
                            Console.WriteLine("The avarage " + lessonArr[i].LessonName + ":\t" + process.avarageLesson(lessonArr[i]));
                        }
                        break;
                    case 2:
                        for (int i = 0; i < lessonArr.Length; i++)
                        {
                            process.lessThan60(lessonArr[i]);
                            Console.WriteLine();
                        }
                        break;
                    case 3:
                        for (int i = 0; i < lessonArr.Length; i++)
                        {
                            process.aboveAvarage(lessonArr[i]);
                            Console.WriteLine();
                        }
                        break;
                    case 4:
                        for (int i = 0; i < lessonArr.Length; i++)
                        {
                            process.lessThan60Amount(lessonArr[i]);
                        }
                        break;
                    case 5:
                        for (int i = 0; i < lessonArr.Length; i++)
                        {
                            process.highestNote(lessonArr[i]);
                        }
                        break;
                    case 6:
                        for (int i = 0; i < lessonArr.Length; i++)
                        {
                            process.lowestNote(lessonArr[i]);
                        }
                        break;
                    case 7:
                        process.studentAvarageList();
                        break;
                    case 8:
                        process.studentNumberList();
                        break;
                    case 9:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Incorrect entry!!!");
                        break;
                }

            }
        }
    }
}
