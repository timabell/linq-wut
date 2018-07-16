using System;
using System.Collections.Generic;
using FluentAssertions;
using LinqWut;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqWutTests
{
    [TestClass]
    public class LinqWutTests
    {
        [TestMethod]
        public void TestSingle_When_Multiple()
        {
            var list = new List<int> { 1, 2, 3 };
            list.Invoking(x => x.SingleWithContext())
                .Should().Throw<InvalidOperationException>().WithMessage("Expected 1 System.Int32 but got 3");
        }

        [TestMethod]
        public void TestSingle_When_None()
        {
            var list = new List<int>();
            list.Invoking(x => x.SingleWithContext())
                .Should().Throw<InvalidOperationException>().WithMessage("Expected 1 System.Int32 but got 0");
        }

        [TestMethod]
        public void TestSingle()
        {
            const int someVal = 42;
            var list = new List<int> { someVal };
            var result = list.SingleWithContext();
            result.Should().Be(someVal);
        }

        [TestMethod]
        public void TestSingle_When_Multiple_WithContext()
        {
            var interestingListSource = new List<int> { 1, 2, 3 };
            string context = $"when looking in {nameof(interestingListSource)}";
            interestingListSource.Invoking(x => x.SingleWithContext(context))
                .Should().Throw<InvalidOperationException>().WithMessage("Expected 1 System.Int32 but got 3 " + context);
        }

        [TestMethod]
        public void TestSingle_When_None_WithContext()
        {
            var someEmptyList = new List<int>();
            string context = $"when looking in {nameof(someEmptyList)}";
            someEmptyList.Invoking(x => x.SingleWithContext(context))
                .Should().Throw<InvalidOperationException>().WithMessage("Expected 1 System.Int32 but got 0 " + context);
        }

    }
}
