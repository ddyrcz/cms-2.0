using FluentAssertions;
using NUnit.Framework;
using System;

namespace CMS.Cars.Domain.Tests
{
    [TestFixture]
    public class CarExtensionTests
    {
        [Test]
        public void IsExpirationApproaching_Should_Return_False_Case_01()
        {
            var car = new Car(Guid.NewGuid(), null, null, null, DateTime.Now.AddMonths(6), DateTime.Now.AddMonths(6), null, null, null, null);

            var result = car.IsExpirationApproaching(14);

            result.Should().BeFalse();
        }

        [Test]
        public void IsExpirationApproaching_Should_Return_False_Case_02()
        {
            var car = new Car(Guid.NewGuid(), null, null, null, DateTime.Now.AddMonths(6), DateTime.Now.AddMonths(6), null, DateTime.Now.AddMonths(6), DateTime.Now.AddMonths(6), DateTime.Now.AddMonths(6));

            var result = car.IsExpirationApproaching(14);

            result.Should().BeFalse();
        }

        [Test]
        public void IsExpirationApproaching_Should_Return_False_Case_03()
        {
            var car = new Car(Guid.NewGuid(), null, null, null, DateTime.Now.AddDays(15), DateTime.Now.AddMonths(6), null, DateTime.Now.AddMonths(6), DateTime.Now.AddMonths(6), DateTime.Now.AddMonths(6));

            var result = car.IsExpirationApproaching(14);

            result.Should().BeFalse();
        }

        [Test]
        public void IsExpirationApproaching_Should_Return_True_Case_01()
        {
            var car = new Car(Guid.NewGuid(), null, null, null, DateTime.Now.AddDays(-15), DateTime.Now, null, DateTime.Now, DateTime.Now, DateTime.Now);

            var result = car.IsExpirationApproaching(14);

            result.Should().BeTrue();
        }

        [Test]
        public void IsExpirationApproaching_Should_Return_True_Case_02()
        {
            var car = new Car(Guid.NewGuid(),
                null,
                null, 
                null, 
                DateTime.Now.AddDays(14).Date.AddHours(23).AddMinutes(59),
                DateTime.Now.AddMonths(6),
                null,
                DateTime.Now.AddMonths(6),
                DateTime.Now.AddMonths(6),
                DateTime.Now.AddMonths(6));

            var result = car.IsExpirationApproaching(14);

            result.Should().BeTrue();
        }
    }
}
