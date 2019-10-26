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

        [Test]
        public void Can_Resolve_Types_Without_Default_Ctor()
        {
            Container ioc = new Container();

            ioc.For<ILogger>().Use<SqlServerLogger>();
            ioc.For<IRepository<Employee>>().Use<SqlRepository<Employee>>();


            var repository = ioc.Resolve <IRepository<Employee>>();

            Assert.AreEqual(typeof(SqlRepository<Employee>), repository.GetType());
        }
    }
}