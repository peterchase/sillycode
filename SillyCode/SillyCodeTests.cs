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
        public void GetValueSafely_ShouldReturnDefault_WhenKeyIsWrongType()
        {
            var dataSource = Substitute.For<IDataSource<string, int>>();
            Assert.That(SillyCode.GetValueSafely(1, dataSource), Is.EqualTo(0));
        }

        [Test]
        public void GetValueSafely_ShouldGetValueFromDataSource_WhenKeyIsCorrectType()
        {
            var dataSource = Substitute.For<IDataSource<string, int>>();
            dataSource.FetchValue("foo").Returns(34);
            Assert.That(SillyCode.GetValueSafely("foo", dataSource), Is.EqualTo(34));
        }

        [Test]
        public void GetSchemeOrDefault_ShouldReturnHttp_WhenUriIsNull()
        {
            Assert.That(SillyCode.GetSchemeOrDefault(null), Is.EqualTo("http"));
        }

        [Test]
        public void GetSchemeOrDefault_ShouldReturnScheme_WhenUriIsNotNull()
        {
            Assert.That(SillyCode.GetSchemeOrDefault(new Uri("https://www.grantadesign.com")), Is.EqualTo("https"));
        }

        [Test]
        public void SumAllProducts_ShouldReturnZero_WhenEmpty()
        {
            var dataSource = Substitute.For<IDataSource<int, int>>();
            Assert.That(SillyCode.SumAllProducts(new int[0], new int[0], dataSource), Is.EqualTo(0));
        }

        [Test]
        public void SumAllProducts_ShouldReturnProduct_WhenSingle()
        {
            var dataSource = Substitute.For<IDataSource<int, int>>();
            dataSource.FetchValue(1).Returns(2);
            dataSource.FetchValue(2).Returns(2);

            Assert.That(SillyCode.SumAllProducts(new[] { 1 }, new[] { 2 }, dataSource), Is.EqualTo(4));
        }

        [Test]
        public void SumAllProducts_ShouldReturnSumOfProducts_WhenMultiple()
        {
            var dataSource = Substitute.For<IDataSource<int, int>>();
            dataSource.FetchValue(1).Returns(1);
            dataSource.FetchValue(2).Returns(2);
            dataSource.FetchValue(3).Returns(5);

            Assert.That(SillyCode.SumAllProducts(new[] { 1, 2 }, new[] { 2, 3 }, dataSource), Is.EqualTo(21));
        }
    }
}
