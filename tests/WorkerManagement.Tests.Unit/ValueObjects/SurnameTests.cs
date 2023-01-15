using System;
using Shouldly;
using WorkerManagement.Domain.ValueObjects;
using Xunit;

namespace WorkerManagement.Tests.Unit.ValueObjects
{
    public class SurnameTests
    {
        [Fact]
        public void given_valid_surname_should_create_value_object()
        {
            // ARRANGE
            var surname = "Nowak";

            // ACT
            var result = new Surname(surname);

            // ASSERT
            result.Value.ShouldBe(surname);
        }

        [Fact]
        public void given_null_surname_should_throw_exception()
        {
            // ACT & ASSERT
            Should.Throw<Exception>(() =>
            {
                new Surname(null);
            });
        }

        [Fact]
        public void given_empty_surname_should_throw_exception()
        {
            // ACT & ASSERT
            Should.Throw<Exception>(() =>
            {
                new Surname("");
            });
        }

        [Fact]
        public void given_whitespace_surname_should_throw_exception()
        {
            // ACT & ASSERT
            Should.Throw<Exception>(() =>
            {
                new Surname(" ");
            });
        }

        [Fact]
        public void given_surname_exceeding_max_length_should_throw_exception()
        {
            // ACT & ASSERT
            Should.Throw<Exception>(() =>
            {
                new Surname(new string('N', 51));
            });
        }

        [Fact]
        public void given_string_should_implicitly_convert_to_surname()
        {
            // ARRANGE
            var surname = "Nowak";

            // ACT
            Surname result = surname;

            // ASSERT
            result.Value.ShouldBe(surname);
        }

        [Fact]
        public void given_surname_should_implicitly_convert_to_string()
        {
            // ARRANGE
            var surname = new Surname("Nowak");

            // ACT
            string result = surname;

            // ASSERT
            result.ShouldBe(surname);
        }
    }
}