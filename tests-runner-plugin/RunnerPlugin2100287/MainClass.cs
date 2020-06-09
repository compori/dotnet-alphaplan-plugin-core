using Compori.Testing.Xunit.AssemblyRunner;
using DryIoc;
using System.Collections.Generic;
using System.Reflection;
using Compori.Alphaplan.Plugin.Support.DryIoc;
using Compori.Alphaplan.Plugin.Logging.NLog;

// ReSharper disable once CheckNamespace
namespace Plugin
{
    public class MainClass : Base.PluginBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainClass"/> class.
        /// </summary>
        public MainClass()
        {
            Name = Assembly.GetExecutingAssembly().GetName().Name;
        }

        /// <summary>
        /// Wird nach dem Laden zur Plugin-Initialisierung ausgeführt.
        /// </summary>
        /// <param name="information">The information.</param>
        public override void FillInformation(ref Base.IInformationBase information)
        {
            information.MenueText = Assembly.GetExecutingAssembly().GetName().Name;
            information.MenueArt = Base.Globales.MenueArten.Eigene;
            information.Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        /// <summary>
        /// Startet das Plugin
        /// </summary>
        /// <param name="manager">Der verwaltende Manager</param>
        /// <param name="pluginInfo">Die Informationen dieses Plugin</param>
        /// <returns>Status der Funktion</returns>
        public override bool StartFunktion(ref Base.Plugins.IManagerPlugins manager, ref Base.IInformationBase pluginInfo)
        {
            Initializer.Init(this.GetType().GetAssembly());
            var log = NLog.LogManager.GetLogger("TestRunner");

            var locations = new List<string>
            {
                typeof(Support.BaseIntegrationTests.DataContext).Assembly.Location,
                typeof(SupportTests.DataContext).Assembly.Location
            };

            using (var runner = new RunnerFactory().Create(locations.ToArray()))
            {
                runner.OnTestPassed = (result, test) =>
                {
                    log.Info($"OK: {test.TestDisplayName}");
                };
                runner.OnTestFailed = (result, test) =>
                {
                    log.Warn($"FAILED : {test.TestDisplayName} - {test.ExceptionMessage} {test.ExceptionStackTrace}");
                };

                using (var container = new Container())
                {
                    Registration.Register(container, manager, pluginInfo, this);
                    Support.BaseIntegrationTests.DataContext.Container = container;
                    SupportTests.DataContext.Container = container;
                    runner.Execute();
                }

                log.Info($"Total   : {runner.Summary.Total}");
                log.Info($"Failed  : {runner.Summary.Failed}");
                log.Info($"Skipped : {runner.Summary.Skipped}");
                log.Info($"Skipped : {runner.Summary.ExecutionTime}");
                
                return runner.Summary.Failed > 0;
            }
        }
    }
}
