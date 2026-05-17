using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GenerativeAI;
using OpenAI;

namespace BasicLinqOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Welcome to Basic LINQ Operations in C#\n");
            // var data = openAICode();
            // Console.WriteLine("Progeam is running while waiting for OpenAI response...\n");
            // await data;
            // Console.WriteLine("Continuing with LINQ operations...\n");
            Console.WriteLine("Added CI CD Settings\n");
            var students = new List<Student>
            {
                new Student { Id = 1, Name = "Anu", Department = "Computer Science", Marks = 89 },
                new Student { Id = 2, Name = "Bala", Department = "Commerce", Marks = 72 },
                new Student { Id = 3, Name = "Charan", Department = "Computer Science", Marks = 95 },
                new Student { Id = 4, Name = "Divya", Department = "Mathematics", Marks = 64 },
                new Student { Id = 5, Name = "Esha", Department = "Commerce", Marks = 81 },
                new Student { Id = 6, Name = "Farhan", Department = "Mathematics", Marks = 76 }
            };
            var findCheck = students.Find(student => student.Name.Contains("an"));
            Console.WriteLine(String.Format("First student with 'an' in their name: {0}", findCheck));

            Console.WriteLine("Basic LINQ Operations\n"); // Demonstrating various LINQ operations on the students list.

            // Where: filter records.
            var highScorers = students.Where(student => student.Marks >= 80);
            PrintStudents("Students with marks >= 80", highScorers);

            // OrderByDescending: sort records.
            var sortedByMarks = students.OrderByDescending(student => student.Marks);
            PrintStudents("Students sorted by marks", sortedByMarks);

            // Select: project records into a different shape.
            var studentNames = students.Select(student => student.Name);
            Console.WriteLine("Student names:");
            foreach (var name in studentNames)
            {
                Console.WriteLine($"- {name}");
            }
            Console.WriteLine();

            // FirstOrDefault: find one matching record.
            var commerceStudent = students.FirstOrDefault(student => student.Department == "Commerce");
            Console.WriteLine("First Commerce student:");
            Console.WriteLine(commerceStudent == null ? "No student found" : commerceStudent.ToString());
            Console.WriteLine();

            // Any: check if at least one record matches.
            var hasTopper = students.Any(student => student.Marks > 90);
            Console.WriteLine($"Any student scored above 90? {hasTopper}");
            Console.WriteLine();

            // Count, Sum, Average, Max, Min: aggregate values.
            Console.WriteLine("Marks summary:");
            Console.WriteLine($"Total students: {students.Count()}");
            Console.WriteLine($"Total marks: {students.Sum(student => student.Marks)}");
            Console.WriteLine($"Average marks: {students.Average(student => student.Marks):0.00}");
            Console.WriteLine($"Highest marks: {students.Max(student => student.Marks)}");
            Console.WriteLine($"Lowest marks: {students.Min(student => student.Marks)}");
            Console.WriteLine();

            // GroupBy: group records by a value.
            var groupedSteundents = students.GroupBy(student => student.Department);
            Console.WriteLine("Students grouped by department:");
            foreach (var group in groupedSteundents)
            {
                Console.WriteLine($" Department:{group.Key}");
                foreach (var student in group)
                {
                    Console.WriteLine($" - {student.Name} ({student.Marks} marks)");
                }
            }
        }
        static async Task Gemini()
        {

            var apiKey = "YOUR_API_KEY";

            var model = new GenerativeModel(
                model: "gemini-pro",
                apiKey: apiKey
            );

            var response = await model.GenerateContentAsync("Explain async await in simple terms");

            Console.WriteLine(response.Text);

        }
        static async Task openAICode()
        {
            Console.WriteLine("OpenAI API Example\n");
            Thread.Sleep(2000);
            Console.WriteLine("Simulating API call to OpenAI...\n");
            Console.WriteLine("This is a placeholder for OpenAI API code. You can replace this with actual API calls to interact with OpenAI models.");

            // var client = new OpenAIClient(apikey);



            // Console.Write("Ask something: ");
            // var userInput = Console.ReadLine();

            // var response = await client.GetChatClient("gpt-4o-mini")
            //     .CompleteChatAsync(userInput);

            // Console.WriteLine("\nAI Response:\n");
            // Console.WriteLine(response.Value.Content[0].Text);
            // This method is intentionally left blank to demonstrate code completion.
        }

        static void PrintStudents(string title, IEnumerable<Student> students)
        {
            Console.WriteLine($"{title}:");
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();
        }
    }

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public int Marks { get; set; }

        public override string ToString()
        {
            return $"{Id}. {Name} - {Department} - {Marks} marks";
        }
    }
}
