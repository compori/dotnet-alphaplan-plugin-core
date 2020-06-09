using Compori.Alphaplan.Plugin.Support.Factories;
using DryIoc;

namespace Compori.Alphaplan.Plugin.Support.DryIoc.Extensions
{
    public static class FactoriesWawiVersion2100287Extension
    {
        /// <summary>
        /// Register the support of the AP server Namespace APIs for version 2100.287.
        /// </summary>
        /// <param name="registrator">The registrator.</param>
        /// <returns>IRegistrator.</returns>
        public static IRegistrator WithFactoriesWawiVersion2100287(this IRegistrator registrator)
        {
            if (registrator == null)
            {
                return null;
            }

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
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateDokument()),
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
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateSternPaket()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateStueckliste()),
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

            return registrator;
        }
    }
}
