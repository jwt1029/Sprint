﻿namespace Sprint_Server
{
    partial class Form1
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.LogText = new System.Windows.Forms.TextBox();
            this.SwitchButton = new System.Windows.Forms.Button();
            this.commandText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LogText
            // 
            this.LogText.Location = new System.Drawing.Point(12, 46);
            this.LogText.Multiline = true;
            this.LogText.Name = "LogText";
            this.LogText.ReadOnly = true;
            this.LogText.Size = new System.Drawing.Size(487, 203);
            this.LogText.TabIndex = 2;
            // 
            // SwitchButton
            // 
            this.SwitchButton.Location = new System.Drawing.Point(12, 12);
            this.SwitchButton.Name = "SwitchButton";
            this.SwitchButton.Size = new System.Drawing.Size(80, 23);
            this.SwitchButton.TabIndex = 0;
            this.SwitchButton.Text = "Server On";
            this.SwitchButton.UseVisualStyleBackColor = true;
            this.SwitchButton.Click += new System.EventHandler(this.SwitchButton_Click);
            // 
            // commandText
            // 
            this.commandText.Location = new System.Drawing.Point(12, 257);
            this.commandText.Name = "commandText";
            this.commandText.Size = new System.Drawing.Size(487, 21);
            this.commandText.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 290);
            this.Controls.Add(this.commandText);
            this.Controls.Add(this.SwitchButton);
            this.Controls.Add(this.LogText);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LogText;
        private System.Windows.Forms.Button SwitchButton;
        private System.Windows.Forms.TextBox commandText;
    }
}

