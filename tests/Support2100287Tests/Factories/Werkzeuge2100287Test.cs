using DryIoc;
using Base.Werkzeuge;
using Xunit;

namespace SupportTests.Factories
{
    public class Werkzeuge2100287Test
    {
        private IContainer Container { get; } = DataContext.Container;

        [Fact()]
        public void TestResolveIProtokoll()
        {
            var sut1 = this.Container.Resolve<IProtokoll>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IProtokoll>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IProtokoll>(sut1);

        }

        [Fact()]
        public void TestResolveIStandard()
        {
            var sut1 = this.Container.Resolve<IStandard>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IStandard>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IStandard>(sut1);
        }

        [Fact()]
        public void TestResolveIStatusMonitor()
        {
            var sut1 = this.Container.Resolve<IStatusMonitor>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IStatusMonitor>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IStatusMonitor>(sut1);
        }
    }
}
