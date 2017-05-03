using MvvmCross.Test.Core;
using NUnit.Framework;

namespace Aliens.MegaU.Core.Tests.Fakes.Common
{
    public class TestContainer: MvxIoCSupportingTest
    {
        [OneTimeSetUp]
        public void SetupMvxContainer()
        {
            base.Setup();
        }

    }
}
