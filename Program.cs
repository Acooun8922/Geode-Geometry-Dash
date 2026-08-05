using System;
using System.Windows.Forms;

namespace GeodeInstaller
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Auto-detect GD path or accept as CLI argument
            string gdPath = args.Length > 0 ? args[0] : PathHelper.GetGDDefaultPath();
            if (!PathHelper.IsValidGDPath(gdPath))
            {
                MessageBox.Show("Could not auto-detect Geometry Dash. Install manually via the installer form.", "Geode Installer", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Application.Run(new UI.MainForm(gdPath));
        }
    }
}