using System;
using System.IO;
using System.Text.RegularExpressions;

namespace GeodeInstaller
{
    public static class PathHelper
    {
        public static string GetGDDefaultPath()
        {
            string[] candidates = {
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Steam", "steamapps", "common", "Geometry Dash"),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),    "Steam", "steamapps", "common", "Geometry Dash"),
            };
            foreach (var p in candidates)
                if (Directory.Exists(p)) return p;
            return null;
        }

        public static bool IsValidGDPath(string path)
        {
            return !string.IsNullOrEmpty(path)
                && Directory.Exists(path)
                && File.Exists(Path.Combine(path, "GeometryDash.exe"));
        }

        public static string SanitizePath(string path)
        {
            return Regex.Replace(path.Trim(), @"[""']", "");
        }
    }
}