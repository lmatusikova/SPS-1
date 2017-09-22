.NET & C#
========

## .NET Architecture

 - .NET is a general purpose development platform
 - programs developed with .NET need a virtual machine to run on a host. This virtual machine is called *Common Language Runtime (CLR)*
 - since the compiler doesn’t produce native machine code, and its product is  interpreted by the CLR, there’s much more security
 - .NET allows using types defined by one .NET language to be used by another under the *Common Language Infrastructure (CLI)* specification, for the conforming languages
 -  any language that conforms to the CLI specification of the .NET, can run in the .NET run-time (e.g. C#, Visual Basic, F#, J#)

![Architecture](http://i.imgur.com/9IJgF7r.png)

----------

## .NET Framework vs .NET Core

### .NET Framework

 - released in 2002
 - proprietary, owned by Microsoft
 - supports only Windows, both for development and as a running environment
 - loads of functions, packages and libraries

### .NET Core

 - released in 2016
 - open source
 - cross-platform support
 - contains core functions, but not everything

----------

C# vs Java
----------

![see sharp](https://i.pinimg.com/originals/3e/3d/cc/3e3dcc2f79d6cfb71cdd30a45e6546e7.png)

 - both are object-oriented and have much in common, e.g. garbage collection
 - syntax is similar
 - differences in some features and under the hood

----------

Some C# features
----------

### Properties
A property is a member that provides a flexible mechanism to read, write, or compute the value of a private field. Properties can be used as if they are public data members, but they are actually special methods called *accessors*. This enables data to be accessed easily and still helps promote the safety and flexibility of methods.

####Example:
Class *Date* with property *Month*:

    public class Date
    {
        private int month = 7;  // Backing store
    
        public int Month
        {
            get
            {
                return month;
            }
            set
            {
                if ((value > 0) && (value < 13))
                {
                    month = value;
                }
            }
        }
    }
We access *Month* as if it was a public variable:

    class Program
    {
        static void Main(string[] args)
        {
    		Date date = new Date();
    	    date.Month = 9;
    	    System.Console.Write(date.Month); // writes 9
    	}
    }	


### Exceptions

There are no checked exceptions in C#, so there is nothing like *throws* keyword as in Java. If a programmer wants to know what exceptions are thrown by some method (so that he can take care of them in try-catch block) he has to look into documentation.

### Structs

A struct type is a **value** type that is typically used to encapsulate small groups of related variables, like coordinates of point or RGB elements of colour. Structs can also contain constructors, methods, properties etc, although if several such members are required, you should consider making your type a class instead.
The main difference between struct and object is that struct is value type and does not support inheritance.

####Example:

    public struct CoOrds
    {
        public int x, y;
    
        public CoOrds(int p1, int p2)
        {
            x = p1;
            y = p2;
        }
    }

    // Declare and initialize struct objects.
    class Program
    {
        static void Main()
        {
            // Initialize:   
            CoOrds coords1 = new CoOrds();
            CoOrds coords2 = new CoOrds(10, 10);
    
            // Display results:
            Console.Write("CoOrds 1: ");
            Console.WriteLine("x = {0}, y = {1}", coords1.x, coords1.y);
    
            Console.Write("CoOrds 2: ");
            Console.WriteLine("x = {0}, y = {1}", coords2.x, coords2.y);
    
            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    /* Output:
        CoOrds 1: x = 0, y = 0
        CoOrds 2: x = 10, y = 10
    */

### Indexers

An Indexer is a special type of property that allows a class or structure to be accessed the same way as array for its internal collection.

#### Example:

    class StringDataStore
    {
        
        private string[] strArr = new string[10]; // internal data storage
    
        public string this[int index]
        {
            get
            {
                if (index < 0 &&  index >= strArr.Length)
                    throw new IndexOutOfRangeException("Cannot store more than 10 objects");
    
                return strArr[index];
            }
    
            set
            {
                if (index < 0 &&  index >= strArr.Length)
                    throw new IndexOutOfRangeException("Cannot store more than 10 objects");
    
                strArr[index] = value;
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            StringDataStore strStore = new StringDataStore();
    
            strStore[0] = "One";
            strStore[1] = "Two";
            strStore[2] = "Three";
            strStore[3] = "Four";
            
            for(int i = 0; i < 10 ; i++)
                Console.WriteLine(strStore[i]);
        }
    }


### LINQ to Objects

In a basic sense, LINQ to Objects represents a new approach to collections. In the old way, you had to write complex foreach loops that specified how to retrieve data from a collection. In the LINQ approach, you write declarative code that describes what you want to retrieve.

    class Student  
    {  
        public string FirstName { get; set; }  
        public string LastName { get; set; }  
        public int[] Scores { get; set; }  
    }  
    
    class Program  
    {  
        static void Main(string[] args)  
        {  
            List<Student> students = new List<Student>();  
            students.Add(  
                new Student  
                    {  
                        FirstName = "Svetlana", LastName = "Omelchenko", Scores = new int[] { 98, 92, 81, 60 }  
                    });  
            students.Add(  
                new Student  
                    {  
                        FirstName = "Claire", LastName = "O’Donnell", Scores = new int[] { 75, 84, 91, 39 }  
                    });  
            students.Add(  
                new Student  
                    {  
                        FirstName = "Sven", LastName = "Mortensen", Scores = new int[] { 88, 94, 85, 91 }  
                    });  
            students.Add(  
                new Student  
                    {  
                        FirstName = "Cesar", LastName = "Garcia", Scores = new int[] { 97, 89, 85, 82 }  
                    });  
    
            var query = from Student student in students 
                        where student.Scores[0] > 95  
                        select student;  
    
            foreach (Student s in query)  
                Console.WriteLine(s.LastName + ": " + s.Scores[0]);  
    
            // Keep the console window open in debug mode.  
            Console.WriteLine("Press any key to exit.");  
            Console.ReadKey();
		    /* Output:   
		        Omelchenko: 98  
		        Garcia: 97  
		    */   
        }  
    } 
    
Instead of string queries, we can also use methods:

    var query = students.Where(s => s.Scores[0] > 95);

### Magic keywords

#### var
`var` is a keyword for implicitly typed variable. An implicitly typed local variable is strongly typed just as if you had declared the type yourself, but the compiler determines the type. The following two declarations are functionally equivalent:

    var i = 10; // implicitly typed  
    int i = 10; //explicitly typed 

#### checked
The `checked` keyword is used to explicitly enable overflow checking for integral-type arithmetic operations and conversions.

The following example causes compiler error CS0220 because 2147483647 is the maximum value for integers. 

    int i1 = 2147483647 + 10;

   The following example, which includes variable ten, does not cause a compiler error.

    int ten = 10;
    int i2 = 2147483647 + ten;
    
   By default, the overflow in the previous statement also does not cause a run-time exception. The following line displays -2,147,483,639 as the sum of 2,147,483,647 and 10.

    Console.WriteLine(i2);

   If the previous sum is attempted in a checked environment, an OverflowException error is raised.
    
    // Checked expression.
    Console.WriteLine(checked(2147483647 + ten));
    
    // Checked block.
    checked
    {
        int i3 = 2147483647 + ten;
        Console.WriteLine(i3);
    }

#### virtual
In Java, all methods are virtual by default, so until they are not marked as `final`, they can be overriden. In C#, they are final by default and we have to add`virtual` keyword to enable overriding.

    public virtual double Area()   
    {  
        return x * y;  
    }

----------

## Hello World!

    class HelloWorld
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

--------

## Links

 - https://www.cs.colorado.edu/~kena/classes/5448/f11/presentation-materials/csharp_dotnet_adnanreza.pdf [.NET]
 - https://docs.microsoft.com/en-us/dotnet/standard/choosing-core-framework-server [Framework vs Core]
 - https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties [Properties]
 - https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-structs [Structs]
 - https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/indexers/using-indexers [Indexers]
 - https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/linq-to-objects [LINQ to Objects]
 - http://www.tutorialsteacher.com/linq/linq-method-syntax [LINQ methods]
 - https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/var [var]
 - https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/checked [checked]
 - https://msdn.microsoft.com/en-us/library/z41h7fat.aspx [useful code snippets in Visual Studio]

C# and network programming
=====

## Basic HTTP client and server

### Client
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the name of a server: ");
            string server = Console.ReadLine();
            Console.WriteLine("Please enter port number (press Enter for 80): ");
            string line = Console.ReadLine();

            int port = 80;
            if (line != "")
            {
                port = Convert.ToInt32(line);
            }

            // open the client connection and setup streams
            TcpClient client = new TcpClient(server, port);
            StreamReader sr = new StreamReader(client.GetStream());
            StreamWriter sw = new StreamWriter(client.GetStream());

            try {
                // send HTTP request
                sw.WriteLine("GET / HTTP/1.0\r\n");
                // flush it so it won't wait
                sw.Flush();

                // write the result to the console
                string data = sr.ReadLine();
                while(data != null)
                {
                    Console.WriteLine(data);
                    data = sr.ReadLine();
                }
                client.Close();
            }
            catch (Exception e)
            {
                // exception is thrown when server closes connection sooner 
                // than our client, but we can ignore it
            }
            // we wait for input so the window does not close
            Console.ReadLine();
        }
    }

### Server
    class Server
    {
        static void Main(string[] args)
        {
            // open a port on which the server listens
            TcpListener listener = new TcpListener(1234);
            listener.Start();

            while (true)
            {
                Console.WriteLine("Waiting for a connection...");
                // accept the connection
                TcpClient client = listener.AcceptTcpClient();
                StreamReader sr = new StreamReader(client.GetStream());
                StreamWriter sw = new StreamWriter(client.GetStream());

                try
                {
                    string request = sr.ReadLine();
                    Console.WriteLine(request);
                    string[] tokens = request.Split(' ');
                    string page = tokens[1];

                    if (page == "/")
                    {
                        page = "index.html";
                    }

                    StreamReader file = new StreamReader("../../web/" + page);

                    // send the response
                    sw.WriteLine("HTTP/1.0 200 OK\n");

                    // write the file line by line
                    string data = file.ReadLine();
                    while(data != null)
                    {
                        sw.WriteLine(data);
                        sw.Flush();
                        data = file.ReadLine();
                    }
                }
                catch (Exception e)
                {
                    sw.WriteLine("HTTP/1.0 404 NOT FOUND\n");
                    sw.WriteLine("<h1>ERROR</h1>");
                    sw.WriteLine("<p>The page was not found.</p>");
                    sw.Flush();
                }
            }
        }
    }

## Links
 - https://www.youtube.com/watch?v=K9-cuTmIK1o [client]
 - https://www.youtube.com/watch?v=GyuUtAqWVPU [server]

Exercises
=====

### Task 0
Set up a new project in Visual Studio (.NET Framework Console Application).

### Task 1
Create an arbitrary class with a string property that:
- accepts only strings shorter than 10 characters,
- returns that string in uppercase.

Write a method that sets the property and then writes its value to the console.

### Task 2
Use example for LINQ syntax and change it so it only selects students whose average score is greater or equal to 80.
Hint: https://msdn.microsoft.com/en-us/library/bb358946(v=vs.110).aspx

### Task 3
Write a program that reads two integers from console, computes their sum and writes it back to the console. In case the sum overflows integer, show an error message instead of the sum.

### Task 4
Edit server program so that it sends the response only to `GET` request. Return `400 BAD` response for all other types of requests.