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
            var list = new List<int> { 1,2,3 };
            list.Invoking(x => x.SingleWithContext())
                .Should().Throw<Exception>();
        }

        [TestMethod]
        public void TestSingle()
        {
            const int someVal = 42;
            var list = new List<int> { someVal };
            var result = list.SingleWithContext();
            result.Should().Be(someVal);
        }
    }
}
