using NUnit.Framework;

namespace Framework.Core.Tests.Specification
{
    public class SpecificationTests
    {
        [Test]
        public void BaseSpecificationTest()
        {
            var spec = new EqualsOneSpecification();

            var testValue = 1;

            var result = spec.IsSatisfiedBy(testValue);

            Assert.IsTrue(result);
        }

        [Test]
        public void AndSpecificationTest()
        {
            var left = new EqualsOneSpecification();

            var right = new GreaterThanZeroSpecification();

            var testValue = 1;

            var result = left.And(right).IsSatisfiedBy(testValue);

            Assert.IsTrue(result);
        }

        [Test]
        public void OrSpecificationTest()
        {
            var left = new EqualsOneSpecification();

            var right = new GreaterThanZeroSpecification();

            var testValue = 2;

            var result = left.Or(right).IsSatisfiedBy(testValue);

            Assert.IsTrue(result);
        }

        [Test]
        public void NotSpecificationTest()
        {
            var spec = new EqualsOneSpecification();

            var testValue = 2;

            var result = spec.Not().IsSatisfiedBy(testValue);

            Assert.IsTrue(result);
        }

        [Test]
        public void NotEqualSpecificationTest()
        {
            var left = new EqualsOneSpecification();

            var right = new EqualsTwoSpecification();

            var testValue = 1;

            var result = left.Not(right).IsSatisfiedBy(testValue);

            Assert.IsTrue(result);
        }

        [Test]
        public void CombinationSpecificationTest()
        {
            var first = new EqualsOneSpecification();

            var second = new EqualsTwoSpecification();

            var third = new GreaterThanZeroSpecification();

            var fourth = new LessThanZeroSpecification();

            var testValue = 1;

            var result = first
                .Not(second)
                .And(third)
                .Or(fourth)
                .IsSatisfiedBy(testValue);

            Assert.IsTrue(result);
        }
    }
}