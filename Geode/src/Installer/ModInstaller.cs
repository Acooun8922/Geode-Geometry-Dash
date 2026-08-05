using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace GeodeInstaller
{
    public static class ModInstaller
    {
        public static void Install(string zipPath, string gdPath)
        {
            string modsDir = Path.Combine(gdPath, "geode", "mods");
            Directory.CreateDirectory(modsDir);

            using var archive = ZipFile.OpenRead(zipPath);
            foreach (var entry in archive.Entries)
            {
                if (entry.FullName.EndsWith(".geode", StringComparison.OrdinalIgnoreCase)
                    || entry.FullName.EndsWith(".dll", StringComparison.OrdinalIgnoreCase))
                {
                    string dest = Path.Combine(modsDir, entry.Name);
                    entry.ExtractToFile(dest, overwrite: true);
                    Console.WriteLine($"Installed: {entry.Name}");
                }
            }
        }

        public static void Uninstall(string modFileName, string gdPath)
        {
            string target = Path.Combine(gdPath, "geode", "mods", modFileName);
            if (File.Exists(target))
            {
                File.Delete(target);
                Console.WriteLine($"Removed: {modFileName}");
            }
        }

        public static string[] ListInstalled(string gdPath)
        {
            string modsDir = Path.Combine(gdPath, "geode", "mods");
            if (!Directory.Exists(modsDir)) return Array.Empty<string>();
            return Directory.GetFiles(modsDir)
                .Where(f => f.EndsWith(".geode") || f.EndsWith(".dll"))
                .Select(Path.GetFileName)
                .ToArray();
        }
    }
}
