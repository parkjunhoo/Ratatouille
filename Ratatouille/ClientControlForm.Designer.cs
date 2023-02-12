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
            this.topBarPanel = new System.Windows.Forms.Panel();
            this.dummyBtn = new System.Windows.Forms.Button();
            this.miniBtn = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.HideBtn = new System.Windows.Forms.Button();
            this.sizer = new System.Windows.Forms.Panel();
            this.clientScreenPbox = new System.Windows.Forms.PictureBox();
            this.topBarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientScreenPbox)).BeginInit();
            this.SuspendLayout();
            // 
            // topBarPanel
            // 
            this.topBarPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topBarPanel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.topBarPanel.Controls.Add(this.dummyBtn);
            this.topBarPanel.Controls.Add(this.miniBtn);
            this.topBarPanel.Controls.Add(this.titleLabel);
            this.topBarPanel.Controls.Add(this.HideBtn);
            this.topBarPanel.Location = new System.Drawing.Point(0, 0);
            this.topBarPanel.Margin = new System.Windows.Forms.Padding(0);
            this.topBarPanel.Name = "topBarPanel";
            this.topBarPanel.Size = new System.Drawing.Size(800, 30);
            this.topBarPanel.TabIndex = 9;
            this.topBarPanel.DoubleClick += new System.EventHandler(this.topBarPanel_DoubleClick);
            this.topBarPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topBarPanel_MouseDown);
            this.topBarPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topBarPanel_MouseMove);
            this.topBarPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.topBarPanel_MouseUp);
            // 
            // dummyBtn
            // 
            this.dummyBtn.Location = new System.Drawing.Point(650, 7);
            this.dummyBtn.Name = "dummyBtn";
            this.dummyBtn.Size = new System.Drawing.Size(1, 1);
            this.dummyBtn.TabIndex = 10;
            this.dummyBtn.Text = "button1";
            this.dummyBtn.UseVisualStyleBackColor = true;
            this.dummyBtn.Visible = false;
            // 
            // miniBtn
            // 
            this.miniBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.miniBtn.Location = new System.Drawing.Point(740, 4);
            this.miniBtn.Name = "miniBtn";
            this.miniBtn.Size = new System.Drawing.Size(25, 25);
            this.miniBtn.TabIndex = 9;
            this.miniBtn.Text = "_";
            this.miniBtn.UseVisualStyleBackColor = true;
            this.miniBtn.Click += new System.EventHandler(this.miniBtn_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.titleLabel.Font = new System.Drawing.Font("Neo둥근모 Pro", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(6, 6);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(128, 21);
            this.titleLabel.TabIndex = 8;
            this.titleLabel.Text = "sessionName";
            // 
            // HideBtn
            // 
            this.HideBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HideBtn.Location = new System.Drawing.Point(771, 4);
            this.HideBtn.Name = "HideBtn";
            this.HideBtn.Size = new System.Drawing.Size(25, 25);
            this.HideBtn.TabIndex = 6;
            this.HideBtn.Text = "x";
            this.HideBtn.UseVisualStyleBackColor = true;
            this.HideBtn.Click += new System.EventHandler(this.HideBtn_Click);
            // 
            // sizer
            // 
            this.sizer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sizer.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.sizer.Location = new System.Drawing.Point(770, 619);
            this.sizer.Name = "sizer";
            this.sizer.Size = new System.Drawing.Size(30, 10);
            this.sizer.TabIndex = 10;
            this.sizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sizer_MouseDown);
            this.sizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.sizer_MouseMove);
            this.sizer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.sizer_MouseUp);
            // 
            // clientScreenPbox
            // 
            this.clientScreenPbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientScreenPbox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.clientScreenPbox.Location = new System.Drawing.Point(12, 33);
            this.clientScreenPbox.Name = "clientScreenPbox";
            this.clientScreenPbox.Size = new System.Drawing.Size(776, 585);
            this.clientScreenPbox.TabIndex = 11;
            this.clientScreenPbox.TabStop = false;
            this.clientScreenPbox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.clientScreenPbox_MouseDown);
            this.clientScreenPbox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.clientScreenPbox_MouseMove);
            this.clientScreenPbox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.clientScreenPbox_MouseUp);
            // 
            // ClientControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(800, 630);
            this.ControlBox = false;
            this.Controls.Add(this.clientScreenPbox);
            this.Controls.Add(this.sizer);
            this.Controls.Add(this.topBarPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "ClientControlForm";
            this.Text = "ClientScreenForm";
            this.Activated += new System.EventHandler(this.ClientControlForm_Activated);
            this.Deactivate += new System.EventHandler(this.ClientControlForm_Deactivate);
            this.Load += new System.EventHandler(this.ClientControlForm_Load);
            this.topBarPanel.ResumeLayout(false);
            this.topBarPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientScreenPbox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel topBarPanel;
        private Button miniBtn;
        private Button HideBtn;
        private Panel sizer;
        public Label titleLabel;
        public PictureBox clientScreenPbox;
        private Button dummyBtn;
    }
}