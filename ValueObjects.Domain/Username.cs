using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueObjects.Domain
{
    public class Username : ValueObject
    {
        public string Value { get; }

        private Username(string username)
        {
            Value = username;
        }

        public static Result<Username> Create(string username)
        {
            if (username.Length >= 25)
            {
                return Result.Failure<Username>("Invalid username.  Must be less than 25 characters");
            }
          
            return new Username(username);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
