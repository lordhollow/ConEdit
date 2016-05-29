namespace ConEditor
{
    partial class GitCommitDialog
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
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.spUD = new System.Windows.Forms.SplitContainer();
            this.pUDD = new System.Windows.Forms.Panel();
            this.btnCommit = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.spUD.Panel1.SuspendLayout();
            this.spUD.Panel2.SuspendLayout();
            this.spUD.SuspendLayout();
            this.pUDD.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessage.Location = new System.Drawing.Point(0, 0);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(457, 124);
            this.txtMessage.TabIndex = 0;
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            // 
            // spUD
            // 
            this.spUD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spUD.Location = new System.Drawing.Point(0, 0);
            this.spUD.Name = "spUD";
            this.spUD.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spUD.Panel1
            // 
            this.spUD.Panel1.Controls.Add(this.txtMessage);
            // 
            // spUD.Panel2
            // 
            this.spUD.Panel2.Controls.Add(this.txtInfo);
            this.spUD.Panel2.Controls.Add(this.pUDD);
            this.spUD.Size = new System.Drawing.Size(457, 331);
            this.spUD.SplitterDistance = 124;
            this.spUD.TabIndex = 1;
            // 
            // pUDD
            // 
            this.pUDD.Controls.Add(this.lblStatus);
            this.pUDD.Controls.Add(this.btnCommit);
            this.pUDD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pUDD.Location = new System.Drawing.Point(0, 173);
            this.pUDD.Name = "pUDD";
            this.pUDD.Size = new System.Drawing.Size(457, 30);
            this.pUDD.TabIndex = 0;
            // 
            // btnCommit
            // 
            this.btnCommit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCommit.Location = new System.Drawing.Point(374, 3);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(80, 23);
            this.btnCommit.TabIndex = 0;
            this.btnCommit.Text = "Commit";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(3, 9);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(50, 12);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Tag = "";
            this.lblStatus.Text = "lblStatus";
            // 
            // txtInfo
            // 
            this.txtInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInfo.Location = new System.Drawing.Point(0, 0);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(457, 173);
            this.txtInfo.TabIndex = 1;
            // 
            // GitCommitDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 331);
            this.Controls.Add(this.spUD);
            this.Name = "GitCommitDialog";
            this.Text = "コミット";
            this.spUD.Panel1.ResumeLayout(false);
            this.spUD.Panel1.PerformLayout();
            this.spUD.Panel2.ResumeLayout(false);
            this.spUD.Panel2.PerformLayout();
            this.spUD.ResumeLayout(false);
            this.pUDD.ResumeLayout(false);
            this.pUDD.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.SplitContainer spUD;
        private System.Windows.Forms.Panel pUDD;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.TextBox txtInfo;
    }
}