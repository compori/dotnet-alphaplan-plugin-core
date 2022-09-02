using Base.Plugins;
using Base.Wawi;
using Names = Base.Wawi.Names;

namespace Compori.Alphaplan.Plugin.Support.Factories
{
    public class WawiFactory
    {
        /// <summary>
        /// Gets the alphaplan manager.
        /// </summary>
        /// <value>The alphaplan manager.</value>
        // ReSharper disable once MemberCanBePrivate.Global
        protected IManagerPlugins Manager { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WawiFactory"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public WawiFactory(IManagerPlugins manager)
        {
            this.Manager = manager;
        }

        /// <summary>
        /// Creates the IAdresse API.
        /// </summary>
        /// <returns>IAdresse.</returns>
        public IAdresse CreateAdresse()
        {
            return this.Manager.ManagedObject(Names.Adresse) as IAdresse;
        }

        /// <summary>
        /// Creates the IAdressgruppe API.
        /// </summary>
        /// <returns>IAdressgruppe.</returns>
        public IAdressgruppe CreateAdressgruppe()
        {
            return this.Manager.ManagedObject(Names.AdressGruppe) as IAdressgruppe;
        }

        /// <summary>
        /// Creates the IAnschrift API.
        /// </summary>
        /// <returns>IAnschrift.</returns>
        public IAnschrift CreateAnschrift()
        {
            return this.Manager.ManagedObject(Names.Anschrift) as IAnschrift;
        }

        /// <summary>
        /// Creates the IAPExe API.
        /// </summary>
        /// <returns>IAPExe.</returns>
        public IAPExe CreateAPExe()
        {
            return this.Manager.ManagedObject(Names.APExe) as IAPExe;
        }

        /// <summary>
        /// Creates the IArbeitsplan API.
        /// </summary>
        /// <returns>IArbeitsplan.</returns>
        public IArbeitsplan CreateArbeitsplan()
        {
            return this.Manager.ManagedObject(Names.Arbeitsplan) as IArbeitsplan;
        }

        /// <summary>
        /// Creates the IArtikel API.
        /// </summary>
        /// <returns>IArtikel.</returns>
        public IArtikel CreateArtikel()
        {
            return this.Manager.ManagedObject(Names.Artikel) as IArtikel;
        }

        /// <summary>
        /// Creates the IArtikelSet API.
        /// </summary>
        /// <returns>ITexte.</returns>
        public IArtikelSet CreateArtikelSet()
        {
            return this.Manager.ManagedObject(Names.ArtikelSet) as IArtikelSet;
        }


        /// <summary>
        /// Creates the IBelege API.
        /// </summary>
        /// <returns>IBelege.</returns>
        public IBelege CreateBelege()
        {
            return this.Manager.ManagedObject(Names.Belege) as IBelege;
        }

        /// <summary>
        /// Creates the IBild API.
        /// </summary>
        /// <returns>IBild.</returns>
        public IBild CreateBild()
        {
            return this.Manager.ManagedObject(Names.Bild) as IBild;
        }

        /// <summary>
        /// Creates the IBuchungsgruppe API.
        /// </summary>
        /// <returns>ITexte.</returns>
        public IBuchungsgruppe CreateBuchungsgruppe()
        {
            return this.Manager.ManagedObject(Names.BuchungsGruppe) as IBuchungsgruppe;
        }

        /// <summary>
        /// Creates the IDatei API.
        /// </summary>
        /// <returns>IDatei.</returns>
        public IDatei CreateDatei()
        {
            return this.Manager.ManagedObject(Names.Datei) as IDatei;
        }

        /// <summary>
        /// Creates the IEinheiten API.
        /// </summary>
        /// <returns>IEinheiten.</returns>
        public IEinheiten CreateEinheiten()
        {
            return this.Manager.ManagedObject(Names.Einheiten) as IEinheiten;
        }

        /// <summary>
        /// Creates the IEkPreis API.
        /// </summary>
        /// <returns>IEkPreis.</returns>
        public IEkPreis CreateEkPreis()
        {
            return this.Manager.ManagedObject(Names.EkPreis) as IEkPreis;
        }

        /// <summary>
        /// Creates the IEmail API.
        /// </summary>
        /// <returns>IEmail.</returns>
        public IEmail CreateEmail()
        {
            return this.Manager.ManagedObject(Names.Email) as IEmail;
        }

        /// <summary>
        /// Creates the IFax API.
        /// </summary>
        /// <returns>IFax.</returns>
        public IFax CreateFax()
        {
            return this.Manager.ManagedObject(Names.Fax) as IFax;
        }

        /// <summary>
        /// Creates the IGefahrGueter API.
        /// </summary>
        /// <returns>IGefahrGueter.</returns>
        public IGefahrGueter CreateGefahrGueter()
        {
            return this.Manager.ManagedObject(Names.GefahrGueter) as IGefahrGueter;
        }

        /// <summary>
        /// Creates the IInvAbschnitt API.
        /// </summary>
        /// <returns>IInvAbschnitt.</returns>
        public IInvAbschnitt CreateInvAbschnitt()
        {
            return this.Manager.ManagedObject(Names.InvAbschnitt) as IInvAbschnitt;
        }

        /// <summary>
        /// Creates the IInvListe API.
        /// </summary>
        /// <returns>IInvListe.</returns>
        public IInvListe CreateInvListe()
        {
            return this.Manager.ManagedObject(Names.InvListe) as IInvListe;
        }

        /// <summary>
        /// Creates the ILagerOrt API.
        /// </summary>
        /// <returns>ILagerOrt.</returns>
        public ILagerOrt CreateLagerOrt()
        {
            return this.Manager.ManagedObject(Names.LagerOrt) as ILagerOrt;
        }

        /// <summary>
        /// Creates the ILagerPlatz API.
        /// </summary>
        /// <returns>ILagerPlatz.</returns>
        public ILagerPlatz CreateLagerPlatz()
        {
            return this.Manager.ManagedObject(Names.LagerPlatz) as ILagerPlatz;
        }

        /// <summary>
        /// Creates the ILagerProtokoll API.
        /// </summary>
        /// <returns>ILagerProtokoll.</returns>
        public ILagerProtokoll CreateLagerProtokoll()
        {
            return this.Manager.ManagedObject(Names.LagerProtokoll) as ILagerProtokoll;
        }

        /// <summary>
        /// Creates the IManagerWawi API.
        /// </summary>
        /// <returns>IManagerWawi.</returns>
        public IManagerWawi CreateManagerWawi()
        {
            return this.Manager.ManagedObject(Names.Manager) as IManagerWawi;
        }

        /// <summary>
        /// Creates the IProduktion API.
        /// </summary>
        /// <returns>IProduktion.</returns>
        public IProduktion CreateProduktion()
        {
            return this.Manager.ManagedObject(Names.Produktion) as IProduktion;
        }

        /// <summary>
        /// Creates the IProduktionenZeiten API.
        /// </summary>
        /// <returns>IProduktionenZeiten.</returns>
        public IProduktionenZeiten CreateProduktionenZeiten()
        {
            return this.Manager.ManagedObject(Names.ProduktionenZeiten) as IProduktionenZeiten;
        }

        /// <summary>
        /// Creates the IProjekt API.
        /// </summary>
        /// <returns>IProjekt.</returns>
        public IProjekt CreateProjekt()
        {
            return this.Manager.ManagedObject(Names.Projekt) as IProjekt;
        }

        /// <summary>
        /// Creates the IRabatt API.
        /// </summary>
        /// <returns>IRabatt.</returns>
        public IRabatt CreateRabatt()
        {
            return this.Manager.ManagedObject(Names.Rabatt) as IRabatt;
        }

        /// <summary>
        /// Creates the ISeriennummer API.
        /// </summary>
        /// <returns>ISeriennummer.</returns>
        public ISeriennummer CreateSeriennummer()
        {
            return this.Manager.ManagedObject(Names.Seriennummer) as ISeriennummer;
        }

        /// <summary>
        /// Creates the ISupportinfo API.
        /// </summary>
        /// <returns>ISupportinfo.</returns>
        public ISupportinfo CreateSupportinfo()
        {
            return this.Manager.ManagedObject(Names.Supportinfo) as ISupportinfo;
        }

        /// <summary>
        /// Creates the ITermin API.
        /// </summary>
        /// <returns>ITermin.</returns>
        public ITermin CreateTermin()
        {
            return this.Manager.ManagedObject(Names.Termin) as ITermin;
        }

        /// <summary>
        /// Creates the ITexte API.
        /// </summary>
        /// <returns>ITexte.</returns>
        public ITexte CreateTexte()
        {
            return this.Manager.ManagedObject(Names.Texte) as ITexte;
        }

        /// <summary>
        /// Creates the IUebersetzungen API.
        /// </summary>
        /// <returns>IUebersetzungen.</returns>
        public IUebersetzungen CreateUebersetzungen()
        {
            return this.Manager.ManagedObject(Names.Uebersetzung) as IUebersetzungen;
        }

        /// <summary>
        /// Creates the IVkPreis API.
        /// </summary>
        /// <returns>IVkPreis.</returns>
        public IVkPreis CreateVkPreis()
        {
            return this.Manager.ManagedObject(Names.VkPreis) as IVkPreis;
        }

        /// <summary>
        /// Creates the IWaehrung API.
        /// </summary>
        /// <returns>IWaehrung.</returns>
        public IWaehrung CreateWaehrung()
        {
            return this.Manager.ManagedObject(Names.Waehrung) as IWaehrung;
        }

        /// <summary>
        /// Creates the IWarengruppe API.
        /// </summary>
        /// <returns>IWarengruppe.</returns>
        public IWarengruppe CreateWarengruppe()
        {
            return this.Manager.ManagedObject(Names.Warengruppe) as IWarengruppe;
        }

        /// <summary>
        /// Creates the IXdatei API.
        /// </summary>
        /// <returns>IXdatei.</returns>
        public IXdatei CreateXDatei()
        {
            return this.Manager.ManagedObject(Names.XDatei) as IXdatei;
        }

        /// <summary>
        /// Creates the IZahlungsbedingungen API.
        /// </summary>
        /// <returns>IZahlungsbedingungen.</returns>
        public IZahlungsbedingungen CreateZahlungsbedingungen()
        {
            return this.Manager.ManagedObject(Names.Zahlungsbedingungen) as IZahlungsbedingungen;
        }

        /// <summary>
        /// Creates the IZollTarifNummern API.
        /// </summary>
        /// <returns>IZollTarifNummern.</returns>
        public IZollTarifNummern CreateZollTarifNummern()
        {
            return this.Manager.ManagedObject(Names.ZollTarifNummern) as IZollTarifNummern;
        }

    }
}
