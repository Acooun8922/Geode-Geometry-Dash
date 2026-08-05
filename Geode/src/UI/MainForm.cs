using System;
using System.Windows.Forms;

namespace GeodeInstaller
{
    public partial class MainForm : Form
    {
        private readonly GeodeDownloader _downloader = new GeodeDownloader();
        private string _gdPath;

        public MainForm()
        {
            InitializeComponent();
            _gdPath = PathHelper.GetGDDefaultPath();
            lblGDPath.Text = string.IsNullOrEmpty(_gdPath)
                ? "Geometry Dash not detected - browse manually"
                : _gdPath;
            btnInstall.Enabled = PathHelper.IsValidGDPath(_gdPath);
        }

        private async void btnInstall_Click(object sender, EventArgs e)
        {
            btnInstall.Enabled = false;
            lblStatus.Text = "Checking latest Geode version...";

            try
            {
                var version = await _downloader.GetLatestVersionAsync();
                lblStatus.Text = $"Downloading Geode {version}...";

                var tempZip = Path.Combine(Path.GetTempPath(), "geode-installer.zip");
                var progress = new Progress<double>(p => {
                    progressBar.Value = (int)(p * 100);
                    lblStatus.Text = $"Downloading... {(int)(p * 100)}%";
                });

                var url = $"https://github.com/geode-sdk/geode/releases/download/{version}/geode-installer-v{version.TrimStart('v')}-win.exe";
                await _downloader.DownloadAsync(url, tempZip, progress);

                lblStatus.Text = "Installing...";
                ModInstaller.Install(tempZip, _gdPath);
                lblStatus.Text = $"Geode {version} installed successfully!";
                MessageBox.Show($"Geode {version} installed. Launch Geometry Dash to access the mod browser.", "Done");
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Install failed";
                MessageBox.Show($"Install failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnInstall.Enabled = true;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using var dlg = new FolderBrowserDialog { Description = "Select Geometry Dash folder" };
            if (dlg.ShowDialog() == DialogResult.OK && PathHelper.IsValidGDPath(dlg.SelectedPath))
            {
                _gdPath = dlg.SelectedPath;
                lblGDPath.Text = _gdPath;
                btnInstall.Enabled = true;
            }
            else if (dlg.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("GeometryDash.exe not found in selected folder.", "Invalid path");
            }
        }
    }
}
