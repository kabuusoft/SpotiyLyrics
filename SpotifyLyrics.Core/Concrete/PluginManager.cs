using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Microsoft.Extensions.Logging;
using SpotifyLyrics.Core.Abstract;
using SpotifyLyrics.Plugin.Abstract;

namespace SpotifyLyrics.Core.Concrete
{
    public class PluginManager : BaseLog<PluginManager>, IPluginManager
    {
        public PluginManager(ILogger<PluginManager> logger) : base(logger)
        {
        }

        public List<IPlugin> LoadPlugins()
        {
            try
            {
                var list = new List<IPlugin>();
                var exts = new[] { "dll", "exe" };

                var applicationDirectory = AppContext.BaseDirectory;
                var libraryFiles = Directory
                    .EnumerateFiles(applicationDirectory, "*.*")
                    .Where(file => exts.Any(x => file.EndsWith(x, StringComparison.OrdinalIgnoreCase)));

                foreach (var libraryFile in libraryFiles)
                {
                    try
                    {
                        var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(libraryFile);
                        var types = assembly.GetTypes();
                        foreach (var aType in types)
                        {
                            try
                            {
                                string interfaceName = typeof(IPlugin).FullName;
                                if (string.IsNullOrEmpty(interfaceName))
                                {
                                    continue;
                                }

                                var interfaces = aType.GetInterfaces().Select(q => q.FullName);
                                //if (aType.IsClass && aType.BaseType != null && aType.BaseType.FullName == interfaceName)
                                //if (aType.IsAssignableFrom(typeof(BasePlugin)))
                                if(interfaces.Contains(interfaceName))
                                {

                                    //var plugin1 = Activator.CreateInstance(aType);
                                    var plugin = (IPlugin)Activator.CreateInstance(aType);

                                    list.Add(plugin);
                                }
                            }
                            catch (Exception e)
                            {
                                LogError($"LoadPlugins for loop2 file name {libraryFile}", e);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        LogError($"LoadPlugins for loop file name {libraryFile}", e);
                    }
                }

                return list;
            }
            catch (Exception e)
            {
                LogFatal("LoadPlugins", e);
                return new List<IPlugin>();
            }
        }
    }
}