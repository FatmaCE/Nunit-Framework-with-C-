using System;
using System.Diagnostics;

namespace CSharpFundas
{
    class Program1 : Program4 //inheritance with :
    {
        String name;
        public Program1(String name)
        {
            this.name = name;
        }
        public void getName()
        {
            Console.WriteLine("My name is " + this.name);
        }
        public void getData()
        {
            Console.WriteLine("I am inside the method ");
        }

        static void Main(string[] args)
        {

            Program1 p = new Program1("Fatma");//constructor 
            p.getData();
            p.setData();


            Console.WriteLine("Hello World!");
            int a = 4;
           // Double c = 13.3;

            Console.WriteLine("Number is " + a);

            String name = "Fatma";
            Console.WriteLine("Name is " + name);
            Console.WriteLine($"Name is {name}");

            var age = 23; //treats as a integer data type
                          //do not use this frequently use it when you do not know the data type exactly 

            Console.WriteLine("Age is " + age);
            // age ="Hello"; //once it is assigned you can not assign it to other data type

            dynamic height = 12.3;
            Console.WriteLine($"Height is {height}");
            //when it is dynamic dtat type you can reassign it to any data type 
            height = "Hello";
            Console.WriteLine($"Height is {height}");




        }
    }
}
