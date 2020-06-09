using Base.Wawi;
using DryIoc;
using Xunit;

namespace SupportTests.Factories
{
    public class Wawi2850200Test
    {
        private IContainer Container { get; } = DataContext.Container;

        [Fact()]
        public void TestResolveIAdressgruppe()
        {
            var sut1 = this.Container.Resolve<IAdressgruppe>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IAdressgruppe>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IAdressgruppe>(sut1);
        }

        [Fact()]
        public void TestResolveILagerProtokoll()
        {
            var sut1 = this.Container.Resolve<ILagerProtokoll>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<ILagerProtokoll>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<ILagerProtokoll>(sut1);
        }

        [Fact()]
        public void TestResolveISeriennummer()
        {
            var sut1 = this.Container.Resolve<ISeriennummer>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<ISeriennummer>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<ISeriennummer>(sut1);
        }

        [Fact()]
        public void TestResolveIUebersetzungen()
        {
            var sut1 = this.Container.Resolve<IUebersetzungen>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IUebersetzungen>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IUebersetzungen>(sut1);
        }

        [Fact()]
        public void TestResolveIWarengruppe()
        {
            var sut1 = this.Container.Resolve<IWarengruppe>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IWarengruppe>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IWarengruppe>(sut1);
        }

        [Fact()]
        public void TestResolveIXdatei()
        {
            var sut1 = this.Container.Resolve<IXdatei>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IXdatei>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IXdatei>(sut1);
        }

        [Fact()]
        public void TestResolveIZahlungsbedingungen()
        {
            var sut1 = this.Container.Resolve<IZahlungsbedingungen>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IZahlungsbedingungen>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IZahlungsbedingungen>(sut1);
        }
    }
}
