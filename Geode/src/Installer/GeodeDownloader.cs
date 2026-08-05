using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace GeodeInstaller
{
    public class GeodeDownloader
    {
        private readonly HttpClient _client = new HttpClient();
        private const string RELEASE_API = "https://api.github.com/repos/geode-sdk/geode/releases/latest";

        public async Task<string> GetLatestVersionAsync()
        {
            _client.DefaultRequestHeaders.Add("User-Agent", "GeodeInstaller");
            var json = await _client.GetStringAsync(RELEASE_API);
            var match = Regex.Match(json, "\"tag_name\":\\s*\"([^\"]+)\"");
            return match.Success ? match.Groups[1].Value : "unknown";
        }

        public async Task DownloadAsync(string url, string dest, IProgress<double> progress = null)
        {
            using var res = await _client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
            var total = res.Content.Headers.ContentLength ?? -1;
            using var src = await res.Content.ReadAsStreamAsync();
            using var dst = File.Create(dest);
            var buf = new byte[81920];
            long downloaded = 0;
            int read;
            while ((read = await src.ReadAsync(buf, 0, buf.Length)) > 0)
            {
                await dst.WriteAsync(buf, 0, read);
                downloaded += read;
                if (total > 0) progress?.Report((double)downloaded / total);
            }
        }
    }
}