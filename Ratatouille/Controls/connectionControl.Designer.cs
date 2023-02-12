namespace Ratatouille
{
    partial class connectionControl
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.closeConnectBtn = new System.Windows.Forms.Button();
            this.showControlFormBtn = new System.Windows.Forms.Button();
            this.NameLabel = new System.Windows.Forms.Label();
            this.dummyBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // closeConnectBtn
            // 
            this.closeConnectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.closeConnectBtn.AutoSize = true;
            this.closeConnectBtn.BackColor = System.Drawing.Color.IndianRed;
            this.closeConnectBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.closeConnectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.closeConnectBtn.ForeColor = System.Drawing.Color.Firebrick;
            this.closeConnectBtn.Location = new System.Drawing.Point(167, 5);
            this.closeConnectBtn.Name = "closeConnectBtn";
            this.closeConnectBtn.Size = new System.Drawing.Size(30, 30);
            this.closeConnectBtn.TabIndex = 13;
            this.closeConnectBtn.TabStop = false;
            this.closeConnectBtn.Text = "🔗";
            this.closeConnectBtn.UseVisualStyleBackColor = false;
            // 
            // showControlFormBtn
            // 
            this.showControlFormBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.showControlFormBtn.AutoSize = true;
            this.showControlFormBtn.BackColor = System.Drawing.Color.PaleGreen;
            this.showControlFormBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.showControlFormBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.showControlFormBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.showControlFormBtn.Location = new System.Drawing.Point(132, 5);
            this.showControlFormBtn.Name = "showControlFormBtn";
            this.showControlFormBtn.Size = new System.Drawing.Size(30, 30);
            this.showControlFormBtn.TabIndex = 12;
            this.showControlFormBtn.TabStop = false;
            this.showControlFormBtn.Text = "🖵";
            this.showControlFormBtn.UseVisualStyleBackColor = false;
            // 
            // NameLabel
            // 
            this.NameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(0, 13);
            this.NameLabel.MaximumSize = new System.Drawing.Size(200, 20);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(39, 15);
            this.NameLabel.TabIndex = 14;
            this.NameLabel.Text = "Name";
            // 
            // dummyBtn
            // 
            this.dummyBtn.Location = new System.Drawing.Point(-5, -5);
            this.dummyBtn.Name = "dummyBtn";
            this.dummyBtn.Size = new System.Drawing.Size(1, 1);
            this.dummyBtn.TabIndex = 15;
            this.dummyBtn.Text = "button1";
            this.dummyBtn.UseVisualStyleBackColor = true;
            // 
            // connectionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.dummyBtn);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.closeConnectBtn);
            this.Controls.Add(this.showControlFormBtn);
            this.Name = "connectionControl";
            this.Size = new System.Drawing.Size(200, 40);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Button closeConnectBtn;
        public Button showControlFormBtn;
        public Label NameLabel;
        public Button dummyBtn;
    }
}
