namespace Ratatouille
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.serverAddrLine = new System.Windows.Forms.Panel();
            this.ServerAddrTBox = new System.Windows.Forms.TextBox();
            this.serverConnectStartBtn = new System.Windows.Forms.Button();
            this.serverAddrLabel = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cllientConnectStartBtn = new System.Windows.Forms.Button();
            this.clientAddrTBox = new System.Windows.Forms.TextBox();
            this.ClientAddrLabel = new System.Windows.Forms.Label();
            this.clientAddrLine = new System.Windows.Forms.Panel();
            this.topBarPanel = new System.Windows.Forms.Panel();
            this.showConsoleBtn = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.miniBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.requestListPanel = new System.Windows.Forms.Panel();
            this.requestListLabel = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.topBarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // serverAddrLine
            // 
            this.serverAddrLine.BackColor = System.Drawing.Color.Gray;
            this.serverAddrLine.Location = new System.Drawing.Point(19, 72);
            this.serverAddrLine.Name = "serverAddrLine";
            this.serverAddrLine.Size = new System.Drawing.Size(257, 2);
            this.serverAddrLine.TabIndex = 0;
            // 
            // ServerAddrTBox
            // 
            this.ServerAddrTBox.BackColor = System.Drawing.Color.Gainsboro;
            this.ServerAddrTBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ServerAddrTBox.Font = new System.Drawing.Font("Neo둥근모 Pro", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ServerAddrTBox.Location = new System.Drawing.Point(19, 50);
            this.ServerAddrTBox.Name = "ServerAddrTBox";
            this.ServerAddrTBox.Size = new System.Drawing.Size(257, 21);
            this.ServerAddrTBox.TabIndex = 1;
            this.ServerAddrTBox.Enter += new System.EventHandler(this.ServerAddrTBox_Enter);
            this.ServerAddrTBox.Leave += new System.EventHandler(this.ServerAddrTBox_Leave);
            // 
            // serverConnectStartBtn
            // 
            this.serverConnectStartBtn.BackColor = System.Drawing.Color.White;
            this.serverConnectStartBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("serverConnectStartBtn.BackgroundImage")));
            this.serverConnectStartBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.serverConnectStartBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.serverConnectStartBtn.FlatAppearance.BorderSize = 2;
            this.serverConnectStartBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightBlue;
            this.serverConnectStartBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.serverConnectStartBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.serverConnectStartBtn.Font = new System.Drawing.Font("Neo둥근모 Pro", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.serverConnectStartBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.serverConnectStartBtn.Location = new System.Drawing.Point(326, 51);
            this.serverConnectStartBtn.Name = "serverConnectStartBtn";
            this.serverConnectStartBtn.Size = new System.Drawing.Size(75, 23);
            this.serverConnectStartBtn.TabIndex = 2;
            this.serverConnectStartBtn.Text = "연결 시작";
            this.serverConnectStartBtn.UseVisualStyleBackColor = false;
            this.serverConnectStartBtn.Click += new System.EventHandler(this.serverConnectStartBtn_Click);
            // 
            // serverAddrLabel
            // 
            this.serverAddrLabel.AutoSize = true;
            this.serverAddrLabel.Location = new System.Drawing.Point(16, 36);
            this.serverAddrLabel.Name = "serverAddrLabel";
            this.serverAddrLabel.Size = new System.Drawing.Size(61, 12);
            this.serverAddrLabel.TabIndex = 3;
            this.serverAddrLabel.Text = "서버 주소:";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(7, 42);
            this.tabControl.Margin = new System.Windows.Forms.Padding(15);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(415, 178);
            this.tabControl.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.serverConnectStartBtn);
            this.tabPage1.Controls.Add(this.serverAddrLabel);
            this.tabPage1.Controls.Add(this.serverAddrLine);
            this.tabPage1.Controls.Add(this.ServerAddrTBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(407, 152);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "원격제어 요청";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cllientConnectStartBtn);
            this.tabPage2.Controls.Add(this.clientAddrTBox);
            this.tabPage2.Controls.Add(this.ClientAddrLabel);
            this.tabPage2.Controls.Add(this.clientAddrLine);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(407, 150);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "원격제어 하기";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cllientConnectStartBtn
            // 
            this.cllientConnectStartBtn.BackColor = System.Drawing.Color.White;
            this.cllientConnectStartBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cllientConnectStartBtn.BackgroundImage")));
            this.cllientConnectStartBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cllientConnectStartBtn.FlatAppearance.BorderColor = System.Drawing.Color.LightBlue;
            this.cllientConnectStartBtn.FlatAppearance.BorderSize = 2;
            this.cllientConnectStartBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightBlue;
            this.cllientConnectStartBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.cllientConnectStartBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cllientConnectStartBtn.Font = new System.Drawing.Font("Neo둥근모 Pro", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cllientConnectStartBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cllientConnectStartBtn.Location = new System.Drawing.Point(326, 51);
            this.cllientConnectStartBtn.Name = "cllientConnectStartBtn";
            this.cllientConnectStartBtn.Size = new System.Drawing.Size(75, 23);
            this.cllientConnectStartBtn.TabIndex = 7;
            this.cllientConnectStartBtn.Text = "연결 시작";
            this.cllientConnectStartBtn.UseVisualStyleBackColor = false;
            this.cllientConnectStartBtn.Click += new System.EventHandler(this.cllientConnectStartBtn_Click);
            // 
            // clientAddrTBox
            // 
            this.clientAddrTBox.BackColor = System.Drawing.Color.Gainsboro;
            this.clientAddrTBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clientAddrTBox.Font = new System.Drawing.Font("Neo둥근모 Pro", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.clientAddrTBox.Location = new System.Drawing.Point(19, 50);
            this.clientAddrTBox.Name = "clientAddrTBox";
            this.clientAddrTBox.Size = new System.Drawing.Size(257, 21);
            this.clientAddrTBox.TabIndex = 6;
            this.clientAddrTBox.Enter += new System.EventHandler(this.ClientAddrTBox_Enter);
            this.clientAddrTBox.Leave += new System.EventHandler(this.ClientAddrTBox_Leave);
            // 
            // ClientAddrLabel
            // 
            this.ClientAddrLabel.AutoSize = true;
            this.ClientAddrLabel.Location = new System.Drawing.Point(16, 36);
            this.ClientAddrLabel.Name = "ClientAddrLabel";
            this.ClientAddrLabel.Size = new System.Drawing.Size(97, 12);
            this.ClientAddrLabel.TabIndex = 8;
            this.ClientAddrLabel.Text = "클라이언트 주소:";
            // 
            // clientAddrLine
            // 
            this.clientAddrLine.BackColor = System.Drawing.Color.Gray;
            this.clientAddrLine.Location = new System.Drawing.Point(19, 72);
            this.clientAddrLine.Name = "clientAddrLine";
            this.clientAddrLine.Size = new System.Drawing.Size(257, 2);
            this.clientAddrLine.TabIndex = 5;
            // 
            // topBarPanel
            // 
            this.topBarPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topBarPanel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.topBarPanel.Controls.Add(this.showConsoleBtn);
            this.topBarPanel.Controls.Add(this.titleLabel);
            this.topBarPanel.Controls.Add(this.miniBtn);
            this.topBarPanel.Controls.Add(this.exitBtn);
            this.topBarPanel.Location = new System.Drawing.Point(-6, -3);
            this.topBarPanel.Name = "topBarPanel";
            this.topBarPanel.Size = new System.Drawing.Size(440, 37);
            this.topBarPanel.TabIndex = 6;
            this.topBarPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topBarPanel_MouseDown);
            this.topBarPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topBarPanel_MouseMove);
            this.topBarPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.topBarPanel_MouseUp);
            // 
            // showConsoleBtn
            // 
            this.showConsoleBtn.BackColor = System.Drawing.Color.White;
            this.showConsoleBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("showConsoleBtn.BackgroundImage")));
            this.showConsoleBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.showConsoleBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.showConsoleBtn.FlatAppearance.BorderSize = 2;
            this.showConsoleBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightBlue;
            this.showConsoleBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.showConsoleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showConsoleBtn.Font = new System.Drawing.Font("Neo둥근모 Pro", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.showConsoleBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.showConsoleBtn.Location = new System.Drawing.Point(293, 7);
            this.showConsoleBtn.Name = "showConsoleBtn";
            this.showConsoleBtn.Size = new System.Drawing.Size(75, 23);
            this.showConsoleBtn.TabIndex = 9;
            this.showConsoleBtn.Text = "Console";
            this.showConsoleBtn.UseVisualStyleBackColor = false;
            this.showConsoleBtn.Click += new System.EventHandler(this.showConsoleBtn_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.titleLabel.Font = new System.Drawing.Font("Neo둥근모 Pro", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(15, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(94, 21);
            this.titleLabel.TabIndex = 8;
            this.titleLabel.Text = "라따뚜이";
            // 
            // miniBtn
            // 
            this.miniBtn.Location = new System.Drawing.Point(374, 5);
            this.miniBtn.Name = "miniBtn";
            this.miniBtn.Size = new System.Drawing.Size(25, 25);
            this.miniBtn.TabIndex = 7;
            this.miniBtn.Text = "_";
            this.miniBtn.UseVisualStyleBackColor = true;
            this.miniBtn.Click += new System.EventHandler(this.miniBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(405, 5);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(25, 25);
            this.exitBtn.TabIndex = 6;
            this.exitBtn.Text = "x";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // requestListPanel
            // 
            this.requestListPanel.AutoScroll = true;
            this.requestListPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.requestListPanel.Location = new System.Drawing.Point(9, 264);
            this.requestListPanel.Name = "requestListPanel";
            this.requestListPanel.Padding = new System.Windows.Forms.Padding(10);
            this.requestListPanel.Size = new System.Drawing.Size(413, 195);
            this.requestListPanel.TabIndex = 9;
            // 
            // requestListLabel
            // 
            this.requestListLabel.AutoSize = true;
            this.requestListLabel.Font = new System.Drawing.Font("Neo둥근모 Pro", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.requestListLabel.ForeColor = System.Drawing.Color.White;
            this.requestListLabel.Location = new System.Drawing.Point(7, 235);
            this.requestListLabel.Name = "requestListLabel";
            this.requestListLabel.Size = new System.Drawing.Size(218, 24);
            this.requestListLabel.TabIndex = 10;
            this.requestListLabel.Text = "원격제어 요청 목록";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(430, 480);
            this.Controls.Add(this.requestListLabel);
            this.Controls.Add(this.requestListPanel);
            this.Controls.Add(this.topBarPanel);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Neo둥근모 Pro", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "Ratatouille";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.topBarPanel.ResumeLayout(false);
            this.topBarPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel topBarPanel;
        private Panel serverAddrLine;
        private TextBox ServerAddrTBox;
        private Button serverConnectStartBtn;
        private Label serverAddrLabel;
        private TabControl tabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button cllientConnectStartBtn;
        private Panel clientAddrLine;
        private TextBox clientAddrTBox;
        private Label ClientAddrLabel;
        private Button exitBtn;
        private Button miniBtn;
        private Label titleLabel;
        private System.Windows.Forms.Timer timer1;
        private Button showConsoleBtn;
        public Panel requestListPanel;
        private Label requestListLabel;
    }
}