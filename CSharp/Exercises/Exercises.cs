using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    class MyClass
    {
        private string myProperty;

        public string MyProperty
        {
            get
            {
                return myProperty.ToUpper();
            }
            set
            {
                if (value.Length < 10)
                {
                    myProperty = value;
                }
            }
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int[] Scores { get; set; }
    }

    class Exercises
    {
        static void Main(string[] args)
        {
            //// Exercise 1
            //MyClass myClass = new MyClass();
            //myClass.MyProperty = "Hello";
            //Console.WriteLine(myClass.MyProperty); // prints "HELLO"
            //Console.ReadLine();

            //// Exercise 2
            //List<Student> students = new List<Student>();
            //students.Add(
            //    new Student
            //    {
            //        FirstName = "Svetlana",
            //        LastName = "Omelchenko",
            //        Scores = new int[] { 98, 92, 81, 60 }
            //    });
            //students.Add(
            //    new Student
            //    {
            //        FirstName = "Claire",
            //        LastName = "O’Donnell",
            //        Scores = new int[] { 75, 84, 91, 39 }
            //    });
            //students.Add(
            //    new Student
            //    {
            //        FirstName = "Sven",
            //        LastName = "Mortensen",
            //        Scores = new int[] { 88, 94, 85, 91 }
            //    });
            //students.Add(
            //    new Student
            //    {
            //        FirstName = "Cesar",
            //        LastName = "Garcia",
            //        Scores = new int[] { 97, 89, 85, 82 }
            //    });

            //var query = from Student student in students
            //            where student.Scores.Average() > 80
            //            select student;

            //foreach (Student s in query)
            //    Console.WriteLine(s.LastName + ": " + s.Scores.Average());
            //Console.ReadLine();

            //// Exercise 3
            //Console.WriteLine("Enter first number: ");
            //int num1 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Enter second number: ");
            //int num2 = Convert.ToInt32(Console.ReadLine());
            //try
            //{
            //    Console.WriteLine(checked(num1 + num2));
            //}
            //catch (OverflowException e)
            //{
            //    Console.Error.WriteLine("Integer overflow.");
            //}
            //Console.ReadLine();

            // Exercise 4
            // insert after line 27 in Server.cs
            //if (tokens[0] != "GET")
            //{
            //    sw.WriteLine("HTTP/1.0 400 BAD\n");
            //    sw.Flush();
            //    continue;
            //}

            // Exercise 5
            //Console.WriteLine("IPv4: " + 
            //    Dns
            //    .GetHostEntry(Dns.GetHostName())
            //    .AddressList
            //    .First(f => f.AddressFamily == AddressFamily.InterNetwork)
            //    .ToString());
            //Console.ReadLine();

            // Exercise 6
            // insert after line 19 in Server.cs
            //Console.WriteLine(
            //    client.
            //    Client.
            //    RemoteEndPoint.
            //    ToString().
            //    Split(':')
            //    [1]);
        }
    }
}
