namespace ConEditor
{
    partial class GrepPanel
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lstResult = new System.Windows.Forms.ListBox();
            this.pControl = new System.Windows.Forms.Panel();
            this.chkRegExp = new System.Windows.Forms.CheckBox();
            this.chkCaseSensitive = new System.Windows.Forms.CheckBox();
            this.chkFindAtEdit = new System.Windows.Forms.CheckBox();
            this.chkIncremental = new System.Windows.Forms.CheckBox();
            this.cmbKeyWord = new System.Windows.Forms.ComboBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tmIncremental = new System.Windows.Forms.Timer(this.components);
            this.pControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstResult
            // 
            this.lstResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstResult.FormattingEnabled = true;
            this.lstResult.IntegralHeight = false;
            this.lstResult.ItemHeight = 12;
            this.lstResult.Location = new System.Drawing.Point(0, 50);
            this.lstResult.Name = "lstResult";
            this.lstResult.Size = new System.Drawing.Size(228, 152);
            this.lstResult.TabIndex = 7;
            this.lstResult.SelectedIndexChanged += new System.EventHandler(this.lstResult_SelectedIndexChanged);
            // 
            // pControl
            // 
            this.pControl.Controls.Add(this.chkRegExp);
            this.pControl.Controls.Add(this.chkCaseSensitive);
            this.pControl.Controls.Add(this.chkFindAtEdit);
            this.pControl.Controls.Add(this.chkIncremental);
            this.pControl.Controls.Add(this.cmbKeyWord);
            this.pControl.Controls.Add(this.btnExecute);
            this.pControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pControl.Location = new System.Drawing.Point(0, 0);
            this.pControl.Name = "pControl";
            this.pControl.Size = new System.Drawing.Size(228, 50);
            this.pControl.TabIndex = 8;
            // 
            // chkRegExp
            // 
            this.chkRegExp.AutoSize = true;
            this.chkRegExp.Location = new System.Drawing.Point(47, 29);
            this.chkRegExp.Name = "chkRegExp";
            this.chkRegExp.Size = new System.Drawing.Size(63, 16);
            this.chkRegExp.TabIndex = 4;
            this.chkRegExp.Text = "RegExp";
            this.chkRegExp.UseVisualStyleBackColor = true;
            this.chkRegExp.CheckedChanged += new System.EventHandler(this.chkRegExp_CheckedChanged);
            // 
            // chkCaseSensitive
            // 
            this.chkCaseSensitive.AutoSize = true;
            this.chkCaseSensitive.Location = new System.Drawing.Point(3, 29);
            this.chkCaseSensitive.Name = "chkCaseSensitive";
            this.chkCaseSensitive.Size = new System.Drawing.Size(38, 16);
            this.chkCaseSensitive.TabIndex = 3;
            this.chkCaseSensitive.Text = "Aa";
            this.chkCaseSensitive.UseVisualStyleBackColor = true;
            this.chkCaseSensitive.CheckedChanged += new System.EventHandler(this.chkCaseSensitive_CheckedChanged);
            // 
            // chkFindAtEdit
            // 
            this.chkFindAtEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkFindAtEdit.AutoSize = true;
            this.chkFindAtEdit.Location = new System.Drawing.Point(177, 29);
            this.chkFindAtEdit.Name = "chkFindAtEdit";
            this.chkFindAtEdit.Size = new System.Drawing.Size(48, 16);
            this.chkFindAtEdit.TabIndex = 7;
            this.chkFindAtEdit.Text = "追従";
            this.chkFindAtEdit.UseVisualStyleBackColor = true;
            this.chkFindAtEdit.CheckedChanged += new System.EventHandler(this.chkFindAtEdit_CheckedChanged);
            // 
            // chkIncremental
            // 
            this.chkIncremental.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIncremental.AutoSize = true;
            this.chkIncremental.Location = new System.Drawing.Point(125, 29);
            this.chkIncremental.Name = "chkIncremental";
            this.chkIncremental.Size = new System.Drawing.Size(48, 16);
            this.chkIncremental.TabIndex = 5;
            this.chkIncremental.Text = "即時";
            this.chkIncremental.UseVisualStyleBackColor = true;
            this.chkIncremental.CheckedChanged += new System.EventHandler(this.chkIncremental_CheckedChanged);
            // 
            // cmbKeyWord
            // 
            this.cmbKeyWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbKeyWord.FormattingEnabled = true;
            this.cmbKeyWord.Location = new System.Drawing.Point(3, 3);
            this.cmbKeyWord.Name = "cmbKeyWord";
            this.cmbKeyWord.Size = new System.Drawing.Size(165, 20);
            this.cmbKeyWord.TabIndex = 2;
            this.cmbKeyWord.TextChanged += new System.EventHandler(this.cmbKeyWord_TextChanged);
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecute.Location = new System.Drawing.Point(171, 0);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(57, 23);
            this.btnExecute.TabIndex = 1;
            this.btnExecute.Text = "検索";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Location = new System.Drawing.Point(0, 202);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(50, 12);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "lblStatus";
            // 
            // tmIncremental
            // 
            this.tmIncremental.Interval = 500;
            // 
            // GrepPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstResult);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pControl);
            this.Name = "GrepPanel";
            this.Size = new System.Drawing.Size(228, 214);
            this.pControl.ResumeLayout(false);
            this.pControl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstResult;
        private System.Windows.Forms.Panel pControl;
        private System.Windows.Forms.CheckBox chkFindAtEdit;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.CheckBox chkIncremental;
        private System.Windows.Forms.ComboBox cmbKeyWord;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.CheckBox chkRegExp;
        private System.Windows.Forms.CheckBox chkCaseSensitive;
        private System.Windows.Forms.Timer tmIncremental;

    }
}
