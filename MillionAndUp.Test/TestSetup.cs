using System;
using System.Collections.Generic;
using Autofac;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Test
{
    public static class TestSetup
    {
        public static IContainer Container { get; private set; }

        [OneTimeSetUp]
        public static void Setup()
        {
            var testContainer = new TestInyectionContainer();
            Container = testContainer.Container;
        }
    }
}
