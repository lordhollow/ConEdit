namespace ConEditor
{
    partial class GitInitDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.btnInit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblGitPos = new System.Windows.Forms.Label();
            this.btnFindGit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mail";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(52, 48);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(346, 19);
            this.txtName.TabIndex = 2;
            // 
            // txtMail
            // 
            this.txtMail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMail.Location = new System.Drawing.Point(52, 73);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(346, 19);
            this.txtMail.TabIndex = 3;
            // 
            // btnInit
            // 
            this.btnInit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInit.Location = new System.Drawing.Point(290, 116);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(108, 23);
            this.btnInit.TabIndex = 4;
            this.btnInit.Text = "初期化or再設定";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "GIT";
            // 
            // lblGitPos
            // 
            this.lblGitPos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGitPos.Location = new System.Drawing.Point(50, 9);
            this.lblGitPos.Name = "lblGitPos";
            this.lblGitPos.Size = new System.Drawing.Size(296, 12);
            this.lblGitPos.TabIndex = 6;
            this.lblGitPos.Text = "label4";
            this.lblGitPos.TextChanged += new System.EventHandler(this.lblGitPos_TextChanged);
            // 
            // btnFindGit
            // 
            this.btnFindGit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindGit.Location = new System.Drawing.Point(352, 4);
            this.btnFindGit.Name = "btnFindGit";
            this.btnFindGit.Size = new System.Drawing.Size(46, 23);
            this.btnFindGit.TabIndex = 7;
            this.btnFindGit.Text = "...";
            this.btnFindGit.UseVisualStyleBackColor = true;
            this.btnFindGit.Click += new System.EventHandler(this.btnFindGit_Click);
            // 
            // GitInitDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 147);
            this.Controls.Add(this.btnFindGit);
            this.Controls.Add(this.lblGitPos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "GitInitDialog";
            this.Text = "GIT初期設定";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblGitPos;
        private System.Windows.Forms.Button btnFindGit;
    }
}