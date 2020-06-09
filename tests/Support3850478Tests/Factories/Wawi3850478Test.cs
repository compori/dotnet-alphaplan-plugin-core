using Base.Wawi;
using DryIoc;
using Xunit;

namespace SupportTests.Factories
{
    public class Wawi3850478Test
    {
        private IContainer Container { get; } = DataContext.Container;

        [Fact()]
        public void TestResolveIArtikelSet()
        {
            var sut1 = this.Container.Resolve<IArtikelSet>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IArtikelSet>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IArtikelSet>(sut1);
        }

        [Fact()]
        public void TestResolveIBuchungsgruppe()
        {
            var sut1 = this.Container.Resolve<IBuchungsgruppe>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IBuchungsgruppe>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IBuchungsgruppe>(sut1);
        }
    }
}
