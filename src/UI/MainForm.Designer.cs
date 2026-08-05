namespace GeodeInstaller.UI
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
            this.lblGDPath  = new Label();
            this.btnInstall = new Button();
            this.btnBrowse  = new Button();
            this.lblStatus  = new Label();
            this.SuspendLayout();

            this.lblGDPath.Location  = new System.Drawing.Point(16, 20);
            this.lblGDPath.Size       = new System.Drawing.Size(420, 22);
            this.lblGDPath.AutoSize   = false;
            this.btnInstall.Text      = "Install Geode";
            this.btnInstall.Location  = new System.Drawing.Point(16, 60);
            this.btnInstall.Size      = new System.Drawing.Size(120, 36);
            this.btnInstall.Click    += new EventHandler(this.btnInstall_Click);
            this.btnBrowse.Text      = "Browse...";
            this.btnBrowse.Location   = new System.Drawing.Point(150, 60);
            this.btnBrowse.Size       = new System.Drawing.Size(80, 36);
            this.btnBrowse.Click     += new EventHandler(this.btnBrowse_Click);
            this.lblStatus.Text       = "Ready";
            this.lblStatus.Location   = new System.Drawing.Point(16, 110);
            this.lblStatus.Size       = new System.Drawing.Size(420, 22);

            this.Controls.AddRange(new Control[] { this.lblGDPath, this.btnInstall, this.btnBrowse, this.lblStatus });
            this.Text          = "Geode Installer v5.8.3";
            this.ClientSize    = new System.Drawing.Size(480, 160);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }

        private Label  lblGDPath;
        private Button btnInstall;
        private Button btnBrowse;
        private Label  lblStatus;
    }
}