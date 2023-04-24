using NUnit.Framework;


namespace ProcessKillerUtility
{
    [TestFixture]
    public class TestCases
    {
        ProcessKiller processKiller;
        string[] args;

        [SetUp]
        public void SetUp()
        {
            processKiller = new ProcessKiller();
        }

        [Test]
        public void CheckParamsNumber()
        {
            args = new string[] {"notepad", "2" , "1" };

            Assert.AreEqual(3, args.Length,"3 arguments expected");
        }

        [Test]
        public void CheckDurationParamType()
        {
            args = new string[] { "notepad", "x", "1" };

            Assert.Throws(typeof(FormatException),() => processKiller.Kill(args));
        }

        [Test]
        public void CheckFrequencyParamType()
        {
            args = new string[] { "notepad", "1", "x" };
            
            Assert.Throws(typeof(FormatException), () => processKiller.Kill(args));
        }

    }
}
