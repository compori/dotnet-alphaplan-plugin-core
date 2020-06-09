using DryIoc;
using System;
using System.Reflection;
using Compori.Alphaplan.Plugin.Logging.NLog;
using Compori.Alphaplan.Plugin.Support.Common;
using Compori.Alphaplan.Plugin.Actions;
using NLogRegistration = Compori.Alphaplan.Plugin.Logging.NLog.DryIoc.Registration;
using SupportRegistration = Compori.Alphaplan.Plugin.Support.DryIoc.Registration;
using ActionRegistration = Compori.Alphaplan.Plugin.Actions.DryIoc.Registration;

// ReSharper disable once CheckNamespace
namespace Plugin
{
    /// <summary>
    /// Die Plugin Class MainClass.
    /// Implements the <see cref="Base.PluginBase" />
    /// </summary>
    /// <seealso cref="Base.PluginBase" />
    public class MainClass : Base.PluginBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainClass"/> class.
        /// </summary>
        public MainClass()
        {
            Name = this.GetType().Assembly.GetName().Name;
        }

        /// <summary>
        /// Wird nach dem Laden zur Plugin-Initialisierung ausgeführt.
        /// </summary>
        /// <param name="information">The information.</param>
        public override void FillInformation(ref Base.IInformationBase information)
        {
            information.MenueText = this.GetType().Assembly.GetName().Name;
            information.MenueArt = Base.Globales.MenueArten.Eigene;
            information.Version = this.GetType().Assembly.GetName().Version.ToString();
        }

        /// <summary>
        /// Liefert die Parameter des Aufrufs zurück.
        /// </summary>
        /// <param name="manager">Das Plugin Manager Objekt.</param>
        /// <returns>System.Object[].</returns>
        // ReSharper disable once UnusedParameter.Local
        private static string[] GetArguments(Base.Plugins.IManagerPlugins manager)
        {
            //var result = manager.Parameter != null 
            //    ? (manager.Parameter as object[])?.Select(v => v as string).ToArray() 
            //    : Environment.GetCommandLineArgs();
            //return result ?? Array.Empty<string>();
            return Environment.GetCommandLineArgs();
        }

        /// <summary>
        /// Wird über das Schnittstellenmenü, die Kommandozeile oder via Remote Service aufgerufen.
        /// </summary>
        /// <param name="manager">Der verwaltende Manager</param>
        /// <param name="pluginInfo">Die Informationen dieses Plugin</param>
        /// <returns>Status der Funktion</returns>
        public override bool StartFunktion(ref Base.Plugins.IManagerPlugins manager, ref Base.IInformationBase pluginInfo)
        {
            Initializer.Init(this.GetType().GetAssembly());

            using (var container = new Container())
            {
                SupportRegistration.Register(container, manager, pluginInfo, this);
                ActionRegistration.Register(container);
                ActionRegistration.RegisterTestingActions(container);
                ActionRegistration.RegisterResolver(container);
                NLogRegistration.Register(container);

                var arguments = GetArguments(manager);
                var protocol = container.Resolve<IProtocol>();
                protocol.Init(
                    "TestingActionsPlugin",
                    Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                    string.Join(" ", arguments),
                    Assembly.GetExecutingAssembly().GetName().Name + ".dll");
                
                return container.Resolve<ActionDispatcher>().Dispatch(arguments);
            }
        }
    }
}
