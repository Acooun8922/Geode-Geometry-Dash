namespace GeodeInstaller
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblGDPath   = new System.Windows.Forms.Label();
            this.lblStatus   = new System.Windows.Forms.Label();
            this.btnInstall  = new System.Windows.Forms.Button();
            this.btnBrowse   = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();

            this.lblGDPath.Location = new System.Drawing.Point(16, 16);
            this.lblGDPath.Size     = new System.Drawing.Size(460, 22);
            this.lblGDPath.AutoEllipsis = true;

            this.lblStatus.Location = new System.Drawing.Point(16, 120);
            this.lblStatus.Size     = new System.Drawing.Size(460, 22);

            this.btnInstall.Text     = "Install Geode";
            this.btnInstall.Location = new System.Drawing.Point(16, 50);
            this.btnInstall.Size     = new System.Drawing.Size(140, 36);
            this.btnInstall.Click   += new System.EventHandler(this.btnInstall_Click);

            this.btnBrowse.Text     = "Browse...";
            this.btnBrowse.Location = new System.Drawing.Point(170, 50);
            this.btnBrowse.Size     = new System.Drawing.Size(100, 36);
            this.btnBrowse.Click   += new System.EventHandler(this.btnBrowse_Click);

            this.progressBar.Location = new System.Drawing.Point(16, 96);
            this.progressBar.Size     = new System.Drawing.Size(460, 20);

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblGDPath, this.btnInstall, this.btnBrowse,
                this.progressBar, this.lblStatus });

            this.Text          = "Geode Installer v5.8.3";
            this.ClientSize    = new System.Drawing.Size(492, 160);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label    lblGDPath, lblStatus;
        private System.Windows.Forms.Button   btnInstall, btnBrowse;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}
