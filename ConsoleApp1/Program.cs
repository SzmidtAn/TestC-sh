// See https://aka.ms/new-console-template for more information

using System;

namespace Lesson1 {

    class Program
    {
        static void Main(string[] args)
        {
            Person per1 = new Person("Piotr");
            Console.WriteLine(per1.name);
        }
        
    }


    class Person
    {
       public string name = "Aneta";

       public Person(string getName)
       {
           name = getName;
       }
    }



}