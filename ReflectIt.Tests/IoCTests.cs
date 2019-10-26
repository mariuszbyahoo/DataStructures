using NUnit.Framework;

namespace ReflectIt.Tests
{
    public class IoCTests
    {
        [Test]
        public void Can_Resolve_Types()
        {
            Container ioc = new Container();

            ioc.For<ILogger>().Use<SqlServerLogger>();

            var logger = ioc.Resolve<ILogger>();

            Assert.AreEqual(typeof(SqlServerLogger), logger.GetType());
        }
    }
}