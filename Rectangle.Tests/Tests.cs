using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rectangle.Impl;

namespace Rectangle.Tests
{
    public class Tests
    {
        private RectangleComparer _comparer;

        [SetUp]
        public void Setup()
        {
            _comparer = new RectangleComparer();
        }



        private static IEnumerable<TestCaseData> AddTestCases()
        {
            yield return new TestCaseData(
                new List<Point>()
                {
                    new Point() {X = 0, Y = 0},
                    new Point() {X = 1, Y = 0},
                    new Point() {X = 0, Y = 1},
                    new Point() {X = 1, Y = 1},
                    new Point(){X = 1, Y = 2}
                },
                new Impl.Rectangle() {Height = 1, Width = 1, X = 0, Y = 0});
            yield return new TestCaseData(
                new List<Point>()
                {
                    new Point() {X = 0, Y = 0},
                    new Point() {X = 1, Y = 0},
                    new Point() {X = 0, Y = 1},
                    new Point() {X = 1, Y = 1},
                    new Point(){X = 2, Y = 0}
                },
                new Impl.Rectangle() {Height = 1, Width = 1, X = 0, Y = 0});
            yield return new TestCaseData(
                new List<Point>()
                {
                    new Point() {X = 0, Y = 0},
                    new Point() {X = 1, Y = 0},
                    new Point() {X = 0, Y = 1},
                    new Point() {X = 1, Y = 1},
                    new Point(){X = 0, Y = -2}
                },
                new Impl.Rectangle() {Height = 1, Width = 1, X = 0, Y = 0});
            yield return new TestCaseData(
                new List<Point>()
                {
                    new Point() {X = 0, Y = 0},
                    new Point() {X = 1, Y = 0},
                    new Point() {X = 0, Y = 1},
                    new Point() {X = 1, Y = 1},
                    new Point(){X = -2, Y = 0}
                },
                new Impl.Rectangle() {Height = 1, Width = 1, X = 0, Y = 0});
        }

        [Test]
        public void WhenInputList_IsNull_ShouldThrowArgumentNullException()
        {
            //arrange
            var expectedEx = typeof(ArgumentNullException);
            //act
            var actEx = Assert.Catch(() => Service.FindRectangle(null));
            //assert
            Assert.AreEqual(expectedEx, actEx.GetType());

        }

        [Test]
        public void WhenInputList_ContainsLessThenTwoPoints_ShouldThrowArgumentException()
        {
            //arrange
            var points = new List<Point>() {new Point()};
            var expectedEx = typeof(ArgumentException);
            //act
            var actEx = Assert.Catch(() => Service.FindRectangle(points));
            //assert
            Assert.AreEqual(expectedEx, actEx.GetType());

        }

        [Test]
        public void WhenInputList_ContainsDuplicates_ShouldThrowArgumentException()
        {
            var points = new List<Point>() {new Point() {X = 1, Y = 1}, new Point() {X = 1, Y = 1}};
            var expectedEx = typeof(ArgumentException);
            //act
            var actEx = Assert.Catch(() => Service.FindRectangle(points));
            //assert
            Assert.AreEqual(expectedEx, actEx.GetType());
        }

        [Test]
        [TestCaseSource(nameof(AddTestCases))]
        public void ShouldReturn_CorrectRectangle(List<Point> points, Impl.Rectangle expected)
        {
            //act
            var actual = Service.FindRectangle(points);
            //assert
            Assert.True(_comparer.Equals(actual, expected));
        }

        [Test]
        public void WhenCannotCreateRectangle_ShouldThrowArgumentException()
        {
            var points = new List<Point>()
            {
                new Point() {X = 1, Y = 1},
                new Point() {X = 2, Y = 2},
                new Point() {X = 1, Y = 2},
                new Point() {X = 2, Y = 1}
            };
            var expectedEx = typeof(ArgumentException);
            //act
            var actEx = Assert.Catch(() => Service.FindRectangle(points));
            //assert
            Assert.AreEqual(expectedEx, actEx.GetType());
        }
    }
}