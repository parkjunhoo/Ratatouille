namespace Ratatouille
{
    partial class requestControl
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
            this.requestAlarmLabel = new System.Windows.Forms.Label();
            this.acceptReqBtn = new System.Windows.Forms.Button();
            this.closeReqBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // requestAlarmLabel
            // 
            this.requestAlarmLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.requestAlarmLabel.AutoSize = true;
            this.requestAlarmLabel.Location = new System.Drawing.Point(3, 13);
            this.requestAlarmLabel.MaximumSize = new System.Drawing.Size(200, 20);
            this.requestAlarmLabel.Name = "requestAlarmLabel";
            this.requestAlarmLabel.Size = new System.Drawing.Size(49, 15);
            this.requestAlarmLabel.TabIndex = 9;
            this.requestAlarmLabel.Text = "Request";
            // 
            // acceptReqBtn
            // 
            this.acceptReqBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.acceptReqBtn.AutoSize = true;
            this.acceptReqBtn.BackColor = System.Drawing.Color.PaleGreen;
            this.acceptReqBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.acceptReqBtn.ForeColor = System.Drawing.Color.Green;
            this.acceptReqBtn.Location = new System.Drawing.Point(132, 5);
            this.acceptReqBtn.Name = "acceptReqBtn";
            this.acceptReqBtn.Size = new System.Drawing.Size(30, 30);
            this.acceptReqBtn.TabIndex = 10;
            this.acceptReqBtn.Text = "✔";
            this.acceptReqBtn.UseVisualStyleBackColor = false;
            // 
            // closeReqBtn
            // 
            this.closeReqBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.closeReqBtn.AutoSize = true;
            this.closeReqBtn.BackColor = System.Drawing.Color.IndianRed;
            this.closeReqBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.closeReqBtn.ForeColor = System.Drawing.Color.Firebrick;
            this.closeReqBtn.Location = new System.Drawing.Point(167, 5);
            this.closeReqBtn.Name = "closeReqBtn";
            this.closeReqBtn.Size = new System.Drawing.Size(30, 30);
            this.closeReqBtn.TabIndex = 11;
            this.closeReqBtn.Text = "✖";
            this.closeReqBtn.UseVisualStyleBackColor = false;
            // 
            // requestControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.closeReqBtn);
            this.Controls.Add(this.acceptReqBtn);
            this.Controls.Add(this.requestAlarmLabel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "requestControl";
            this.Size = new System.Drawing.Size(200, 40);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public Label requestAlarmLabel;
        public Button acceptReqBtn;
        public Button closeReqBtn;
    }
}
