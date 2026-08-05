using System;
using System.Windows.Forms;
using System.IO;

namespace GeodeInstaller.UI
{
    public partial class MainForm : Form
    {
        private readonly string _gdPath;
        private readonly GeodeDownloader _downloader = new GeodeDownloader();
        private readonly string _zipPath = Path.Combine(Path.GetTempPath(), "geode-installer.zip");

        public MainForm(string gdPath)
        {
            _gdPath = gdPath ?? "";
            InitializeComponent();
            lblGDPath.Text = string.IsNullOrEmpty(gdPath) ? "Geometry Dash not detected — browse manually" : gdPath;
            btnInstall.Enabled = !string.IsNullOrEmpty(gdPath);
        }

        private async void btnInstall_Click(object sender, EventArgs e)
        {
            btnInstall.Enabled = false;
            lblStatus.Text = "Downloading Geode...";

            try
            {
                var (version, url) = await GetLatestRelease();
                lblStatus.Text = $"Downloading Geode {version}...";
                await _downloader.DownloadAsync(url, _zipPath);

                lblStatus.Text = "Installing...";
                ModInstaller.Install(_zipPath, _gdPath);
                lblStatus.Text = "Geode installed successfully!";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Install failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Install failed";
            }
            finally
            {
                btnInstall.Enabled = true;
            }
        }

        private async Task<(string version, string url)> GetLatestRelease()
        {
            var version = await _downloader.GetLatestVersionAsync();
            var url = $"https://github.com/geode-sdk/geode/releases/download/{version}/GeodeInstaller-win.zip";
            return (version, url);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using var dlg = new FolderBrowserDialog { Description = "Select Geometry Dash folder" };
            if (dlg.ShowDialog() == DialogResult.OK && PathHelper.IsValidGDPath(dlg.SelectedPath))
            {
                lblGDPath.Text = dlg.SelectedPath;
                btnInstall.Enabled = true;
            }
        }
    }
}