using Base.ApServer;
using DryIoc;
using Xunit;

namespace SupportTests.Factories
{
    public class ApServer2850200Test
    {
        private IContainer Container { get; } = DataContext.Container;

        [Fact()]
        public void TestResolveILogin()
        {
            var sut1 = this.Container.Resolve<ILizenzInfo>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<ILizenzInfo>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<ILizenzInfo>(sut1);
        }


        [Fact()]
        public void TestResolveISemaphore()
        {
            var sut1 = this.Container.Resolve<ISemaphore>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<ISemaphore>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<ISemaphore>(sut1);
        }
    }
}
