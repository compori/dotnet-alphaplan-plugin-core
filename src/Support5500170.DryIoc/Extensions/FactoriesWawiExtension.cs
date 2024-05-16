using Compori.Alphaplan.Plugin.Support.Factories;
using DryIoc;

namespace Compori.Alphaplan.Plugin.Support.DryIoc.Extensions
{
    public static class FactoriesWawiExtension
    {
        /// <summary>
        /// Register the support of the AP server Namespace APIs.
        /// </summary>
        /// <param name="registrator">The registrator.</param>
        /// <returns>IRegistrator.</returns>
        public static IRegistrator WithFactoriesWawi(this IRegistrator registrator)
        {
            if (registrator == null)
            {
                return null;
            }

            // register Wawi factory
            registrator.Register<WawiFactory>();


            //
            // Register Wawi APIs
            //
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateAdresse()), 
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateAnschrift()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateAPExe()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateArbeitsplan()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateArtikel()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateBelege()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateBild()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateDatei()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateEinheiten()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateEkPreis()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateEmail()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateFax()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateGefahrGueter()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateInvAbschnitt()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateInvListe()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateLagerOrt()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateLagerPlatz()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateManagerWawi()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateProduktion()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateProduktionenZeiten()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateProjekt()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateRabatt()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateSupportinfo()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateTermin()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateVkPreis()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateWaehrung()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateZollTarifNummern()),
                setup: Setup.With(preventDisposal: true));


            //
            // Register additional Wawi API for Version 2850.200
            //
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateAdressgruppe()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateLagerProtokoll()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateSeriennummer()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateUebersetzungen()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateWarengruppe()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateXDatei()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateZahlungsbedingungen()),
                setup: Setup.With(preventDisposal: true));


            //
            // Register additional Wawi API for Version 3400.134.
            //
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateTexte()),
                setup: Setup.With(preventDisposal: true));

            //
            // Register additional Wawi API for Version 3850.478.
            //
            registrator.Register(
                reuse: Reuse.Singleton,
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateArtikelSet()),
                setup: Setup.With(preventDisposal: true));

            registrator.Register(
                reuse: Reuse.Singleton,
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateBuchungsgruppe()),
                setup: Setup.With(preventDisposal: true));

            return registrator;
        }
    }
}
