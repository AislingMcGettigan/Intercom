using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntercomTest.Tests.Helper
{
    public class TestHelper
    {
        public static void ExpectException<T>(Action action) where T : Exception
        {
            try
            {
                action();
                Assert.Fail("Expected exception " + typeof(T).Name);
            }
            catch (T exception)
            {
                // Expected
            }
        }
    }
}
