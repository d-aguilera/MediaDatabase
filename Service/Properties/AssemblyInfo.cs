using MediaDatabase.Service.SignalR;

using Microsoft.Owin;

using System;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

using log4net.Config;

[assembly: AssemblyTitle("MediaDatabase Windows Service")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("MediaDatabase")]
[assembly: AssemblyCopyright("Copyright © DSA 2016")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: ComVisible(false)]
[assembly: Guid("78c535f9-e4a2-4841-a905-113267967eeb")]
[assembly: CLSCompliant(true)]
[assembly: OwinStartup(typeof(Startup))]
[assembly: NeutralResourcesLanguage("en")]
[assembly: XmlConfigurator(ConfigFile ="log4net.config", Watch = true)]
