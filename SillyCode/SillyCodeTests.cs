using System;
using System.Collections.Generic;

using NSubstitute;
using NUnit.Framework;

namespace SillyCode
{
    /// <summary>
    /// These are here to make sure we don't look stupid by claiming that the code does something
    /// other than what it really does.
    /// </summary>
    [TestFixture]
    public class SillyCodeTests
    {
        [Test]
        public void GetOrCreateValue_ShouldGetValue_WhenValueExists()
        {
            Assert.That(SillyCode.GetOrCreateValue(new Dictionary<string, string>() { { "foo", "bar"}}, "foo", () => ""), Is.EqualTo("bar"));
        }

        [Test]
        public void GetOrCreateValue_ShouldCreateValue_WhenNoValueExists() 
        {
            Assert.That(SillyCode.GetOrCreateValue(new Dictionary<string, string>(), "foo", () => "baz"), Is.EqualTo("baz"));
        }

        [Test]
        public void IsEmpty_ShouldReturnTrue_WhenEmpty()
        {
            Assert.That(SillyCode.IsEmpty(new int[0]), Is.True);
        }

        [Test]
        public void IsEmpty_ShouldReturnFalse_WhenNotEmpty()
        {
            Assert.That(SillyCode.IsEmpty(new[] { 1 }), Is.False);
        }

        [Test]
        public void HaveSameSum_ShouldReturnTrue_WhenEmpty()
        {
            Assert.That(SillyCode.HaveSameSum(new double[0], new Double[0]), Is.True);
        }

        [Test]
        public void HaveSameSum_ShouldReturnFalse_WhenDifferent()
        {
            Assert.That(SillyCode.HaveSameSum(new[] { 1.0 }, new[] { 2.0 }), Is.False);
        }

        [Test]
        public void CountFrequencies_ShouldCountFrequencies()
        {
            var values = new int[] { 1, 1, 2 };
            var predicates = new[] { new Predicate<int>(i => i == 1), new Predicate<int>(i => i == 2), new Predicate<int>(i => i == 3) };
            CollectionAssert.AreEqual(new[] { 2, 1, 0 }, SillyCode.CountFrequencies(values, predicates));
        }

        [Test]
        public void GetHashCode_ShouldReturnCorrectValue()
        {
            Assert.That(SillyCode.GetHashCode(23), Is.EqualTo(12));
        }

        [Test]
        public void ReferenceSameObjects_ShouldReturnTrue_WhenEmpty()
        {
            var dataSource = Substitute.For<IDataSource<int, object>>();
            Assert.That(SillyCode.ReferenceSameObjects(new int[0], new int[0], dataSource), Is.True);
        }

        [Test]
        public void ReferenceSameObjects_ShouldReturnTrue_WhenSame()
        {
            var dataSource = Substitute.For<IDataSource<int, object>>();
            var value = new object();
            dataSource.FetchValue(1).Returns(value);
            dataSource.FetchValue(2).Returns(value);

            Assert.That(SillyCode.ReferenceSameObjects(new[] { 1 }, new[] { 2 }, dataSource), Is.True);
        }

        [Test]
        public void ReferenceSameObjects_ShouldReturnFalse_WhenDifferent()
        {
            var dataSource = Substitute.For<IDataSource<int, object>>();
            dataSource.FetchValue(1).Returns(new object());
            dataSource.FetchValue(2).Returns(new object());

            Assert.That(SillyCode.ReferenceSameObjects(new[] { 1 }, new[] { 2 }, dataSource), Is.False);
        }
    }
}
