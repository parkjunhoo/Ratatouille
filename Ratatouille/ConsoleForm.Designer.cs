namespace Ratatouille
{
    partial class ConsoleForm
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.exitBtn = new System.Windows.Forms.Button();
            this.consoleLogTbox = new System.Windows.Forms.TextBox();
            this.commandTbox = new System.Windows.Forms.TextBox();
            this.topBarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topBarPanel
            // 
            this.topBarPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topBarPanel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.topBarPanel.Controls.Add(this.titleLabel);
            this.topBarPanel.Controls.Add(this.exitBtn);
            this.topBarPanel.Location = new System.Drawing.Point(-2, 0);
            this.topBarPanel.Name = "topBarPanel";
            this.topBarPanel.Size = new System.Drawing.Size(588, 45);
            this.topBarPanel.TabIndex = 7;
            this.topBarPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topBarPanel_MouseDown);
            this.topBarPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topBarPanel_MouseMove);
            this.topBarPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.topBarPanel_MouseUp);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.titleLabel.Font = new System.Drawing.Font("Neo둥근모 Pro", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(14, 13);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(83, 21);
            this.titleLabel.TabIndex = 8;
            this.titleLabel.Text = "Console";
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(549, 9);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(25, 25);
            this.exitBtn.TabIndex = 6;
            this.exitBtn.Text = "x";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // consoleLogTbox
            // 
            this.consoleLogTbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consoleLogTbox.BackColor = System.Drawing.Color.Black;
            this.consoleLogTbox.ForeColor = System.Drawing.Color.White;
            this.consoleLogTbox.Location = new System.Drawing.Point(12, 62);
            this.consoleLogTbox.Multiline = true;
            this.consoleLogTbox.Name = "consoleLogTbox";
            this.consoleLogTbox.ReadOnly = true;
            this.consoleLogTbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.consoleLogTbox.Size = new System.Drawing.Size(560, 344);
            this.consoleLogTbox.TabIndex = 8;
            this.consoleLogTbox.TextChanged += new System.EventHandler(this.consoleLogTbox_TextChanged);
            // 
            // commandTbox
            // 
            this.commandTbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commandTbox.BackColor = System.Drawing.Color.Black;
            this.commandTbox.ForeColor = System.Drawing.Color.White;
            this.commandTbox.Location = new System.Drawing.Point(12, 426);
            this.commandTbox.Name = "commandTbox";
            this.commandTbox.Size = new System.Drawing.Size(560, 23);
            this.commandTbox.TabIndex = 9;
            this.commandTbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.commandTbox_KeyDown);
            this.commandTbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.commandTbox_KeyPress);
            // 
            // ConsoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.ControlBox = false;
            this.Controls.Add(this.commandTbox);
            this.Controls.Add(this.consoleLogTbox);
            this.Controls.Add(this.topBarPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConsoleForm";
            this.Text = "ConsoleForm";
            this.Load += new System.EventHandler(this.ConsoleForm_Load);
            this.topBarPanel.ResumeLayout(false);
            this.topBarPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel topBarPanel;
        private Label titleLabel;
        private Button exitBtn;
        private TextBox consoleLogTbox;
        private TextBox commandTbox;
    }
}