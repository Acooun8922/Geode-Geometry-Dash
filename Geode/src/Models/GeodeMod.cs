using System;
using System.Collections.Generic;

namespace GeodeInstaller
{
    public class GeodeMod
    {
        public string   Id           { get; set; }
        public string   Name         { get; set; }
        public string   Version      { get; set; }
        public string   Developer    { get; set; }
        public string   Description  { get; set; }
        public string[] Tags         { get; set; }
        public string[] Dependencies { get; set; }
        public bool     Enabled      { get; set; } = true;
        public bool     IsMobileOnly { get; set; } = false;
        public int      DownloadCount{ get; set; }
        public string   DownloadUrl  { get; set; }
    }

    public class GeodeModList
    {
        public List<GeodeMod> Mods { get; set; } = new();
        public string LastUpdated   { get; set; }
    }
}
