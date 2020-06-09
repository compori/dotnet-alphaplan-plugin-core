using Base.Wawi;
using DryIoc;
using Xunit;

namespace SupportTests.Factories
{
    public class Wawi2100287Test
    {
        private IContainer Container { get; } = DataContext.Container;

        [Fact()]
        public void TestResolveIAdresse()
        {
            var sut1 = this.Container.Resolve<IAdresse>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IAdresse>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IAdresse>(sut1);

        }

        [Fact()]
        public void TestResolveIAnschrift()
        {
            var sut1 = this.Container.Resolve<IAnschrift>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IAnschrift>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IAnschrift>(sut1);
        }

        [Fact()]
        // ReSharper disable once InconsistentNaming
        public void TestResolveIAPExe()
        {
            var sut1 = this.Container.Resolve<IAPExe>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IAPExe>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IAPExe>(sut1);
        }

        [Fact()]
        public void TestResolveIArbeitsplan()
        {
            var sut1 = this.Container.Resolve<IArbeitsplan>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IArbeitsplan>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IArbeitsplan>(sut1);
        }

        [Fact()]
        public void TestResolveIArtikel()
        {
            var sut1 = this.Container.Resolve<IArtikel>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IArtikel>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IArtikel>(sut1);
        }


        [Fact()]
        public void TestResolveIBelege()
        {
            var sut1 = this.Container.Resolve<IBelege>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IBelege>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IBelege>(sut1);
        }

        [Fact()]
        public void TestResolveIBild()
        {
            var sut1 = this.Container.Resolve<IBild>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IBild>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IBild>(sut1);
        }

        [Fact()]
        public void TestResolveIDatei()
        {
            var sut1 = this.Container.Resolve<IDatei>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IDatei>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IDatei>(sut1);
        }

        [Fact()]
        public void TestResolveIDokument()
        {
            var sut1 = this.Container.Resolve<IDokument>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IDokument>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IDokument>(sut1);
        }

        [Fact()]
        public void TestResolveIEinheiten()
        {
            var sut1 = this.Container.Resolve<IEinheiten>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IEinheiten>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IEinheiten>(sut1);
        }

        [Fact()]
        public void TestResolveIEkPreis()
        {
            var sut1 = this.Container.Resolve<IEkPreis>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IEkPreis>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IEkPreis>(sut1);
        }

        [Fact()]
        public void TestResolveIEmail()
        {
            var sut1 = this.Container.Resolve<IEmail>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IEmail>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IEmail>(sut1);
        }

        [Fact()]
        public void TestResolveIFax()
        {
            var sut1 = this.Container.Resolve<IFax>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IFax>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IFax>(sut1);
        }

        [Fact()]
        public void TestResolveIGefahrGueter()
        {
            var sut1 = this.Container.Resolve<IGefahrGueter>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IGefahrGueter>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IGefahrGueter>(sut1);
        }

        [Fact()]
        public void TestResolveIInvAbschnitt()
        {
            var sut1 = this.Container.Resolve<IInvAbschnitt>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IInvAbschnitt>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IInvAbschnitt>(sut1);
        }

        [Fact()]
        public void TestResolveIInvListe()
        {
            var sut1 = this.Container.Resolve<IInvListe>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IInvListe>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IInvListe>(sut1);
        }

        [Fact()]
        public void TestResolveILagerOrt()
        {
            var sut1 = this.Container.Resolve<ILagerOrt>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<ILagerOrt>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<ILagerOrt>(sut1);
        }

        [Fact()]
        public void TestResolveILagerPlatz()
        {
            var sut1 = this.Container.Resolve<ILagerPlatz>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<ILagerPlatz>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<ILagerPlatz>(sut1);
        }

        [Fact()]
        public void TestResolveIManagerWawi()
        {
            var sut1 = this.Container.Resolve<IManagerWawi>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IManagerWawi>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IManagerWawi>(sut1);
        }

        [Fact()]
        public void TestResolveIProduktion()
        {
            var sut1 = this.Container.Resolve<IProduktion>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IProduktion>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IProduktion>(sut1);
        }

        [Fact()]
        public void TestResolveIProduktionenZeiten()
        {
            var sut1 = this.Container.Resolve<IProduktionenZeiten>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IProduktionenZeiten>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IProduktionenZeiten>(sut1);
        }

        [Fact()]
        public void TestResolveIProjekt()
        {
            var sut1 = this.Container.Resolve<IProjekt>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IProjekt>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IProjekt>(sut1);
        }

        [Fact()]
        public void TestResolveIRabatt()
        {
            var sut1 = this.Container.Resolve<IRabatt>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IRabatt>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IRabatt>(sut1);
        }

        [Fact()]
        public void TestResolveISternPaket()
        {
            var sut1 = this.Container.Resolve<ISternPaket>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<ISternPaket>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<ISternPaket>(sut1);
        }

        [Fact()]
        public void TestResolveIStueckliste()
        {
            var sut1 = this.Container.Resolve<IStueckliste>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IStueckliste>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IStueckliste>(sut1);
        }

        [Fact()]
        public void TestResolveISupportinfo()
        {
            var sut1 = this.Container.Resolve<ISupportinfo>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<ISupportinfo>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<ISupportinfo>(sut1);
        }

        [Fact()]
        public void TestResolveITermin()
        {
            var sut1 = this.Container.Resolve<ITermin>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<ITermin>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<ITermin>(sut1);
        }

        [Fact()]
        public void TestResolveIVkPreis()
        {
            var sut1 = this.Container.Resolve<IVkPreis>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IVkPreis>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IVkPreis>(sut1);
        }

        [Fact()]
        public void TestResolveIWaehrung()
        {
            var sut1 = this.Container.Resolve<IWaehrung>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IWaehrung>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IWaehrung>(sut1);
        }

        [Fact()]
        public void TestResolveIZollTarifNummern()
        {
            var sut1 = this.Container.Resolve<IZollTarifNummern>();
            Assert.NotNull(sut1);

            var sut2 = this.Container.Resolve<IZollTarifNummern>();
            Assert.NotNull(sut2);

            Assert.Same(sut1, sut2);

            Assert.IsAssignableFrom<IZollTarifNummern>(sut1);
        }
    }
}
