using CSharpFunctionalExtensions;
using System;
using ValueObjects.Domain;
using ValueObjects.SqlServer;

namespace ValueObjects.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new ValueObjectsContext())
            {

                var email = Email.Create("Student1@student.com");
                var username = Username.Create("student1");
                var results = Result.Combine(email, username);
                if (results.IsFailure)
                {
                    System.Console.WriteLine($"Error: {results.Error}");
                }

                var student = new Student(username.Value, email.Value, GradeLevel.Freshman);
                context.Add(student);
                context.SaveChanges();
                    

            }
        }
    }
}
