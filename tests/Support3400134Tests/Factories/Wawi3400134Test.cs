using Base.Wawi;
using DryIoc;
using Xunit;

namespace SupportTests.Factories
{
    public class Wawi3400134Test
    {
        private IContainer Container { get; } = DataContext.Container;

        [Fact()]
        public void TestResolveITexte()
        {
            var sut1 = this.Container.Resolve<ITexte>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<ITexte>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<ITexte>(sut1);
        }
    }
}
