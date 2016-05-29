namespace ConEditor
{
    partial class ReplaceKeywordInputDialog
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
            this.lblReplaceTarget = new System.Windows.Forms.Label();
            this.txtReplaceResult = new System.Windows.Forms.TextBox();
            this.btnReplaceThis = new System.Windows.Forms.Button();
            this.btnCancel1 = new System.Windows.Forms.Button();
            this.btnReplaceNext = new System.Windows.Forms.Button();
            this.btnReplaceAll1 = new System.Windows.Forms.Button();
            this.pEachControl = new System.Windows.Forms.Panel();
            this.pAllControl = new System.Windows.Forms.Panel();
            this.btnCancel2 = new System.Windows.Forms.Button();
            this.btnReplaceAll2 = new System.Windows.Forms.Button();
            this.btnSkipNext = new System.Windows.Forms.Button();
            this.pEachControl.SuspendLayout();
            this.pAllControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblReplaceTarget
            // 
            this.lblReplaceTarget.AutoSize = true;
            this.lblReplaceTarget.Location = new System.Drawing.Point(12, 9);
            this.lblReplaceTarget.Name = "lblReplaceTarget";
            this.lblReplaceTarget.Size = new System.Drawing.Size(91, 12);
            this.lblReplaceTarget.TabIndex = 0;
            this.lblReplaceTarget.Text = "lblReplaceTarget";
            // 
            // txtReplaceResult
            // 
            this.txtReplaceResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReplaceResult.Location = new System.Drawing.Point(12, 24);
            this.txtReplaceResult.Name = "txtReplaceResult";
            this.txtReplaceResult.Size = new System.Drawing.Size(487, 19);
            this.txtReplaceResult.TabIndex = 1;
            // 
            // btnReplaceThis
            // 
            this.btnReplaceThis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReplaceThis.Location = new System.Drawing.Point(417, 3);
            this.btnReplaceThis.Name = "btnReplaceThis";
            this.btnReplaceThis.Size = new System.Drawing.Size(68, 22);
            this.btnReplaceThis.TabIndex = 2;
            this.btnReplaceThis.Text = "置換";
            this.btnReplaceThis.UseVisualStyleBackColor = true;
            this.btnReplaceThis.Click += new System.EventHandler(this.btnReplaceThis_Click);
            // 
            // btnCancel1
            // 
            this.btnCancel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel1.Location = new System.Drawing.Point(40, 3);
            this.btnCancel1.Name = "btnCancel1";
            this.btnCancel1.Size = new System.Drawing.Size(68, 22);
            this.btnCancel1.TabIndex = 3;
            this.btnCancel1.Text = "終了";
            this.btnCancel1.UseVisualStyleBackColor = true;
            this.btnCancel1.Click += new System.EventHandler(this.btnCancel1_Click);
            // 
            // btnReplaceNext
            // 
            this.btnReplaceNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReplaceNext.Location = new System.Drawing.Point(215, 3);
            this.btnReplaceNext.Name = "btnReplaceNext";
            this.btnReplaceNext.Size = new System.Drawing.Size(95, 22);
            this.btnReplaceNext.TabIndex = 4;
            this.btnReplaceNext.Text = "置換して次へ";
            this.btnReplaceNext.UseVisualStyleBackColor = true;
            this.btnReplaceNext.Click += new System.EventHandler(this.btnReplaceNext_Click);
            // 
            // btnReplaceAll1
            // 
            this.btnReplaceAll1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReplaceAll1.Location = new System.Drawing.Point(316, 3);
            this.btnReplaceAll1.Name = "btnReplaceAll1";
            this.btnReplaceAll1.Size = new System.Drawing.Size(95, 22);
            this.btnReplaceAll1.TabIndex = 5;
            this.btnReplaceAll1.Text = "全置換";
            this.btnReplaceAll1.UseVisualStyleBackColor = true;
            this.btnReplaceAll1.Click += new System.EventHandler(this.btnReplaceAll1_Click);
            // 
            // pEachControl
            // 
            this.pEachControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pEachControl.Controls.Add(this.btnSkipNext);
            this.pEachControl.Controls.Add(this.btnCancel1);
            this.pEachControl.Controls.Add(this.btnReplaceAll1);
            this.pEachControl.Controls.Add(this.btnReplaceThis);
            this.pEachControl.Controls.Add(this.btnReplaceNext);
            this.pEachControl.Location = new System.Drawing.Point(23, 65);
            this.pEachControl.Name = "pEachControl";
            this.pEachControl.Size = new System.Drawing.Size(489, 28);
            this.pEachControl.TabIndex = 6;
            // 
            // pAllControl
            // 
            this.pAllControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pAllControl.Controls.Add(this.btnCancel2);
            this.pAllControl.Controls.Add(this.btnReplaceAll2);
            this.pAllControl.Location = new System.Drawing.Point(23, 65);
            this.pAllControl.Name = "pAllControl";
            this.pAllControl.Size = new System.Drawing.Size(489, 28);
            this.pAllControl.TabIndex = 7;
            // 
            // btnCancel2
            // 
            this.btnCancel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel2.Location = new System.Drawing.Point(316, 3);
            this.btnCancel2.Name = "btnCancel2";
            this.btnCancel2.Size = new System.Drawing.Size(68, 22);
            this.btnCancel2.TabIndex = 3;
            this.btnCancel2.Text = "終了";
            this.btnCancel2.UseVisualStyleBackColor = true;
            this.btnCancel2.Click += new System.EventHandler(this.btnCancel2_Click);
            // 
            // btnReplaceAll2
            // 
            this.btnReplaceAll2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReplaceAll2.Location = new System.Drawing.Point(390, 3);
            this.btnReplaceAll2.Name = "btnReplaceAll2";
            this.btnReplaceAll2.Size = new System.Drawing.Size(95, 22);
            this.btnReplaceAll2.TabIndex = 5;
            this.btnReplaceAll2.Text = "全置換";
            this.btnReplaceAll2.UseVisualStyleBackColor = true;
            this.btnReplaceAll2.Click += new System.EventHandler(this.btnReplaceAll2_Click);
            // 
            // btnSkipNext
            // 
            this.btnSkipNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSkipNext.Location = new System.Drawing.Point(114, 3);
            this.btnSkipNext.Name = "btnSkipNext";
            this.btnSkipNext.Size = new System.Drawing.Size(95, 22);
            this.btnSkipNext.TabIndex = 6;
            this.btnSkipNext.Text = "スキップして次へ";
            this.btnSkipNext.UseVisualStyleBackColor = true;
            this.btnSkipNext.Click += new System.EventHandler(this.btnSkipNext_Click);
            // 
            // ReplaceKeywordInputDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 96);
            this.Controls.Add(this.txtReplaceResult);
            this.Controls.Add(this.lblReplaceTarget);
            this.Controls.Add(this.pEachControl);
            this.Controls.Add(this.pAllControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ReplaceKeywordInputDialog";
            this.Text = "置換";
            this.pEachControl.ResumeLayout(false);
            this.pAllControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReplaceTarget;
        private System.Windows.Forms.TextBox txtReplaceResult;
        private System.Windows.Forms.Button btnReplaceThis;
        private System.Windows.Forms.Button btnCancel1;
        private System.Windows.Forms.Button btnReplaceNext;
        private System.Windows.Forms.Button btnReplaceAll1;
        private System.Windows.Forms.Panel pEachControl;
        private System.Windows.Forms.Panel pAllControl;
        private System.Windows.Forms.Button btnCancel2;
        private System.Windows.Forms.Button btnReplaceAll2;
        private System.Windows.Forms.Button btnSkipNext;
    }
}