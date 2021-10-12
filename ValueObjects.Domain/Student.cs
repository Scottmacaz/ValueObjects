using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ValueObjects.Domain
{
    public class Student : Entity
    {
        public  Username Username { get; private set; }
        public Email Email { get; private set; }
        public GradeLevel GradeLevel { get; private set; }

        public Student(Username username, Email email, GradeLevel gradeLevel)
        {
            Username = username;
            Email = email;
            GradeLevel = gradeLevel;
        }
                
    }
}
