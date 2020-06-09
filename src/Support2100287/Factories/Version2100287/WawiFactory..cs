using Base;
using Base.Wawi;

namespace Compori.Alphaplan.Plugin.Support.Factories.Version2100287
{
    public class WawiFactory
    {
        /// <summary>
        /// Gets the alphaplan plugin.
        /// </summary>
        /// <value>Der Alphaplan Plugin Manager.</value>
        private PluginBase Plugin { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WawiFactory"/> class.
        /// </summary>
        /// <param name="plugin">The plugin.</param>
        protected WawiFactory(PluginBase plugin)
        {
            this.Plugin = plugin;
        }

        /// <summary>
        /// Creates the IAdresse API.
        /// </summary>
        /// <returns>IAdresse.</returns>
        public IAdresse CreateAdresse()
        {
            return this.Plugin.ManagedObject(Names.Adresse) as IAdresse;
        }

        /// <summary>
        /// Creates the IAnschrift API.
        /// </summary>
        /// <returns>IAnschrift.</returns>
        public IAnschrift CreateAnschrift()
        {
            return this.Plugin.ManagedObject(Names.Anschrift) as IAnschrift;
        }

        /// <summary>
        /// Creates the IAPExe API.
        /// </summary>
        /// <returns>IAPExe.</returns>
        public IAPExe CreateAPExe()
        {
            return this.Plugin.ManagedObject(Names.APExe) as IAPExe;
        }

        /// <summary>
        /// Creates the IArbeitsplan API.
        /// </summary>
        /// <returns>IArbeitsplan.</returns>
        public IArbeitsplan CreateArbeitsplan()
        {
            return this.Plugin.ManagedObject(Names.Arbeitsplan) as IArbeitsplan;
        }

        /// <summary>
        /// Creates the IArtikel API.
        /// </summary>
        /// <returns>IArtikel.</returns>
        public IArtikel CreateArtikel()
        {
            return this.Plugin.ManagedObject(Names.Artikel) as IArtikel;
        }

        /// <summary>
        /// Creates the IBelege API.
        /// </summary>
        /// <returns>IBelege.</returns>
        public IBelege CreateBelege()
        {
            return this.Plugin.ManagedObject(Names.Belege) as IBelege;
        }

        /// <summary>
        /// Creates the IBild API.
        /// </summary>
        /// <returns>IBild.</returns>
        public IBild CreateBild()
        {
            return this.Plugin.ManagedObject(Names.Bild) as IBild;
        }

        /// <summary>
        /// Creates the IDatei API.
        /// </summary>
        /// <returns>IDatei.</returns>
        public IDatei CreateDatei()
        {
            return this.Plugin.ManagedObject(Names.Datei) as IDatei;
        }

        /// <summary>
        /// Creates the IDokument API.
        /// </summary>
        /// <returns>IDokument.</returns>
        public IDokument CreateDokument()
        {
            return this.Plugin.ManagedObject(Names.Dokument) as IDokument;
        }

        /// <summary>
        /// Creates the IEinheiten API.
        /// </summary>
        /// <returns>IEinheiten.</returns>
        public IEinheiten CreateEinheiten()
        {
            return this.Plugin.ManagedObject(Names.EinheitenSet) as IEinheiten;
        }

        /// <summary>
        /// Creates the IEkPreis API.
        /// </summary>
        /// <returns>IEkPreis.</returns>
        public IEkPreis CreateEkPreis()
        {
            return this.Plugin.ManagedObject(Names.EkPreis) as IEkPreis;
        }

        /// <summary>
        /// Creates the IEmail API.
        /// </summary>
        /// <returns>IEmail.</returns>
        public IEmail CreateEmail()
        {
            return this.Plugin.ManagedObject(Names.Email) as IEmail;
        }

        /// <summary>
        /// Creates the IFax API.
        /// </summary>
        /// <returns>IFax.</returns>
        public IFax CreateFax()
        {
            return this.Plugin.ManagedObject(Names.Fax) as IFax;
        }

        /// <summary>
        /// Creates the IGefahrGueter API.
        /// </summary>
        /// <returns>IGefahrGueter.</returns>
        public IGefahrGueter CreateGefahrGueter()
        {
            return this.Plugin.ManagedObject(Names.GefahrGueter) as IGefahrGueter;
        }

        /// <summary>
        /// Creates the IInvAbschnitt API.
        /// </summary>
        /// <returns>IInvAbschnitt.</returns>
        public IInvAbschnitt CreateInvAbschnitt()
        {
            return this.Plugin.ManagedObject(Names.InvAbschnitt) as IInvAbschnitt;
        }

        /// <summary>
        /// Creates the IInvListe API.
        /// </summary>
        /// <returns>IInvListe.</returns>
        public IInvListe CreateInvListe()
        {
            return this.Plugin.ManagedObject(Names.InvListe) as IInvListe;
        }

        /// <summary>
        /// Creates the ILagerOrt API.
        /// </summary>
        /// <returns>ILagerOrt.</returns>
        public ILagerOrt CreateLagerOrt()
        {
            return this.Plugin.ManagedObject(Names.LagerOrt) as ILagerOrt;
        }

        /// <summary>
        /// Creates the ILagerPlatz API.
        /// </summary>
        /// <returns>ILagerPlatz.</returns>
        public ILagerPlatz CreateLagerPlatz()
        {
            return this.Plugin.ManagedObject(Names.LagerPlatz) as ILagerPlatz;
        }
       
        /// <summary>
        /// Creates the IManagerWawi API.
        /// </summary>
        /// <returns>IManagerWawi.</returns>
        public IManagerWawi CreateManagerWawi()
        {
            return this.Plugin.ManagedObject(Names.Manager) as IManagerWawi;
        }

        /// <summary>
        /// Creates the IProduktion API.
        /// </summary>
        /// <returns>IProduktion.</returns>
        public IProduktion CreateProduktion()
        {
            return this.Plugin.ManagedObject(Names.Produktion) as IProduktion;
        }

        /// <summary>
        /// Creates the IProduktionenZeiten API.
        /// </summary>
        /// <returns>IProduktionenZeiten.</returns>
        public IProduktionenZeiten CreateProduktionenZeiten()
        {
            return this.Plugin.ManagedObject(Names.ProduktionenZeiten) as IProduktionenZeiten;
        }

        /// <summary>
        /// Creates the IProjekt API.
        /// </summary>
        /// <returns>IProjekt.</returns>
        public IProjekt CreateProjekt()
        {
            return this.Plugin.ManagedObject(Names.Projekt) as IProjekt;
        }

        /// <summary>
        /// Creates the IRabatt API.
        /// </summary>
        /// <returns>IRabatt.</returns>
        public IRabatt CreateRabatt()
        {
            return this.Plugin.ManagedObject(Names.Rabatt) as IRabatt;
        }

        /// <summary>
        /// Creates the ISternPaket API.
        /// </summary>
        /// <returns>ISternPaket.</returns>
        public ISternPaket CreateSternPaket()
        {
            return this.Plugin.ManagedObject(Names.SternPaket) as ISternPaket;
        }

        /// <summary>
        /// Creates the IStueckliste API.
        /// </summary>
        /// <returns>IStueckliste.</returns>
        public IStueckliste CreateStueckliste()
        {
            return this.Plugin.ManagedObject(Names.Stueckliste) as IStueckliste;
        }

        /// <summary>
        /// Creates the ISupportinfo API.
        /// </summary>
        /// <returns>ISupportinfo.</returns>
        public ISupportinfo CreateSupportinfo()
        {
            return this.Plugin.ManagedObject(Names.Supportinfo) as ISupportinfo;
        }

        /// <summary>
        /// Creates the ITermin API.
        /// </summary>
        /// <returns>ITermin.</returns>
        public ITermin CreateTermin()
        {
            return this.Plugin.ManagedObject(Names.Termin) as ITermin;
        }

        /// <summary>
        /// Creates the IVkPreis API.
        /// </summary>
        /// <returns>IVkPreis.</returns>
        public IVkPreis CreateVkPreis()
        {
            return this.Plugin.ManagedObject(Names.VkPreis) as IVkPreis;
        }

        /// <summary>
        /// Creates the IWaehrung API.
        /// </summary>
        /// <returns>IWaehrung.</returns>
        public IWaehrung CreateWaehrung()
        {
            return this.Plugin.ManagedObject(Names.Waehrung) as IWaehrung;
        }

        /// <summary>
        /// Creates the IZollTarifNummern API.
        /// </summary>
        /// <returns>IZollTarifNummern.</returns>
        public IZollTarifNummern CreateZollTarifNummern()
        {
            return this.Plugin.ManagedObject(Names.ZollTarifNummern) as IZollTarifNummern;
        }
    }
}
