using Base.ApServer;
using DryIoc;
using Xunit;

namespace SupportTests.Factories
{
    public class ApServer2100287Test
    {
        private IContainer Container { get; } = DataContext.Container;

        [Fact()]
        public void TestResolveILogin()
        {
            var sut1 = this.Container.Resolve<ILogin>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<ILogin>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<ILogin>(sut1);
        }

        [Fact()]
        public void TestResolveIReader()
        {
            var sut1 = this.Container.Resolve<IReader>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IReader>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IReader>(sut1);
        }

        [Fact()]
        public void TestResolveIService()
        {
            var sut1 = this.Container.Resolve<IService>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IService>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IService>(sut1);
        }

        [Fact()]
        public void TestResolveIWriter()
        {
            var sut1 = this.Container.Resolve<IWriter>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IWriter>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IWriter>(sut1);
        }
    }
}
