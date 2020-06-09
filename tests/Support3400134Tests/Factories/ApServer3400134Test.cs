using Base.ApServer;
using DryIoc;
using Xunit;

namespace SupportTests.Factories
{
    public class ApServer3400134Test
    {
        private IContainer Container { get; } = DataContext.Container;

        [Fact()]
        public void TestResolveIQuery()
        {
            var sut1 = this.Container.Resolve<IQuery>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IQuery>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IQuery>(sut1);
        }
    }
}
