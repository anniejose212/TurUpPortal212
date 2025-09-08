// Utilities/ConfigReader.cs
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace TurUpPortal212.Utilities
{
    public static class ConfigReader
    {
        public static IConfigurationRoot Configuration { get; }

        static ConfigReader()
        {
            // Start from bin/... where tests execute
            var baseDir = AppContext.BaseDirectory;
            var jsonPath = Path.Combine(baseDir, "appsettings.json");

            // Fallback to project root if not copied (bin/../../..)
            if (!File.Exists(jsonPath))
            {
                var projDir = Path.GetFullPath(Path.Combine(baseDir, "..", "..", ".."));
                var projJson = Path.Combine(projDir, "appsettings.json");
                if (File.Exists(projJson))
                {
                    baseDir = projDir;
                    jsonPath = projJson;
                }
            }

            if (!File.Exists(jsonPath))
                throw new FileNotFoundException($"appsettings.json not found at: {jsonPath}");

            Configuration = new ConfigurationBuilder()
                .SetBasePath(baseDir)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }
    }
}
