using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstProject.Homework1._1
{
    class Student
    {
        static ArrayList numberList = new ArrayList(); //Ogrenci numaralari konrolunde
        string number;
        string name;
        
        public string Number
        {
            get { return number; }
            set { number = value; }
        }
        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Student(string num, string name)
        {
            this.number = num;
            this.name = name;
        }
        
        //Ogrenci numaralarinin ayni olmamasini kontrol eder
        public static Boolean numberCheck (string stdNumber)
        {
            foreach (string temp in numberList)
            {
                if (temp == stdNumber)
                {
                    return true;
                }
            }
            numberList.Add(stdNumber);        
            return false;
        }
    }
}
