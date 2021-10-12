using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ValueObjects.Domain
{
    public class Email : ValueObject
    {
        public string Value { get; }

        private Email(string value)
        {
            Value = value;
        }

        public static Result<Email> Create(string email)
        {
            if (email.Length > 100)
            {
                return Result.Failure<Email>("Invalid email addresss.  Must be less than 100 characters");
            }
            if (!Regex.IsMatch(email, @"^(.+)@(.+)$"))
            {
                return Result.Failure<Email>("Invalid email address.  Incorrect format.");
            }

            return new Email(email);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
