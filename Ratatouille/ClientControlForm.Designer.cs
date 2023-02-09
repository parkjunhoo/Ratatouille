namespace Ratatouille
{
    partial class ClientControlForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.clientScreenPbox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.clientScreenPbox)).BeginInit();
            this.SuspendLayout();
            // 
            // clientScreenPbox
            // 
            this.clientScreenPbox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.clientScreenPbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientScreenPbox.Location = new System.Drawing.Point(0, 0);
            this.clientScreenPbox.Name = "clientScreenPbox";
            this.clientScreenPbox.Size = new System.Drawing.Size(800, 450);
            this.clientScreenPbox.TabIndex = 0;
            this.clientScreenPbox.TabStop = false;
            this.clientScreenPbox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.clientScreenPbox_MouseDown);
            // 
            // ClientControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.clientScreenPbox);
            this.Name = "ClientControlForm";
            this.Text = "ClientScreenForm";
            this.Load += new System.EventHandler(this.ClientControlForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clientScreenPbox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public PictureBox clientScreenPbox;
    }
}