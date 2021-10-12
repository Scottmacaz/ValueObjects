using FluentAssertions;
using System;
using ValueObjects.Domain;
using Xunit;

namespace ValueObjects.Test
{
    public class UsernameTests
    {
        [Fact]
        public void UsernameGreaterThan25CharactersIsInvalid()
        {
            var username = Username.Create("1111122222333334444455555");
            username.IsFailure.Should().BeTrue();
        }

        [Fact]
        public void UsernameOf24CharactersIsValid()
        {
            var username = Username.Create("111112222233333444445555");
            username.IsFailure.Should().BeFalse();
        }

    }
}
