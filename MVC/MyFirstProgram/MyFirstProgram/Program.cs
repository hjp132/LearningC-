using System;

namespace MyFirstProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            var pluralsightCourse = new Course();
            pluralsightCourse.Name = "Working with C# Records";
            pluralsightCourse.Author = "Roland Guijt";

            var anotherCourse = pluralsightCourse;
            Console.WriteLine(pluralsightCourse.Name);
            Console.WriteLine(pluralsightCourse.Author);

            var classroomCourse = new CourseRecord(
                "Working with C# Records",
                "Roland Guijt"
                );


            Console.ReadLine();
        }
    }
    public class Course
    {
        public string Name { get; set; }
        public string Author { get; set; }

        public void Deconstruct(out string name, out string author)
        {
            name = Name;
            author = Author;
        }
    }

    public record CourseRecord(string Name, string Author);
    
}
