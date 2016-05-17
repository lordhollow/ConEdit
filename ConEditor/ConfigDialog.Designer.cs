namespace ConEditor
{
    partial class ConfigDialog
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
            Sgry.Azuki.FontInfo fontInfo1 = new Sgry.Azuki.FontInfo();
            this.label1 = new System.Windows.Forms.Label();
            this.numFontSize = new System.Windows.Forms.NumericUpDown();
            this.cmbFontFace = new System.Windows.Forms.ComboBox();
            this.chkWrap = new System.Windows.Forms.CheckBox();
            this.numWrapWidth = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.azPreview = new Sgry.Azuki.WinForms.AzukiControl();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbLineNoMethod = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWrapWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "フォント";
            // 
            // numFontSize
            // 
            this.numFontSize.Location = new System.Drawing.Point(267, 13);
            this.numFontSize.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numFontSize.Name = "numFontSize";
            this.numFontSize.Size = new System.Drawing.Size(76, 19);
            this.numFontSize.TabIndex = 1;
            this.numFontSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // cmbFontFace
            // 
            this.cmbFontFace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFontFace.FormattingEnabled = true;
            this.cmbFontFace.Location = new System.Drawing.Point(56, 12);
            this.cmbFontFace.Name = "cmbFontFace";
            this.cmbFontFace.Size = new System.Drawing.Size(205, 20);
            this.cmbFontFace.TabIndex = 2;
            // 
            // chkWrap
            // 
            this.chkWrap.AutoSize = true;
            this.chkWrap.Location = new System.Drawing.Point(12, 42);
            this.chkWrap.Name = "chkWrap";
            this.chkWrap.Size = new System.Drawing.Size(109, 16);
            this.chkWrap.TabIndex = 3;
            this.chkWrap.Text = "長い行の折り返し";
            this.chkWrap.UseVisualStyleBackColor = true;
            // 
            // numWrapWidth
            // 
            this.numWrapWidth.Location = new System.Drawing.Point(267, 40);
            this.numWrapWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numWrapWidth.Name = "numWrapWidth";
            this.numWrapWidth.Size = new System.Drawing.Size(76, 19);
            this.numWrapWidth.TabIndex = 4;
            this.numWrapWidth.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "折り返し幅";
            // 
            // azPreview
            // 
            this.azPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.azPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.azPreview.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.azPreview.DrawingOption = ((Sgry.Azuki.DrawingOption)(((((((Sgry.Azuki.DrawingOption.DrawsFullWidthSpace | Sgry.Azuki.DrawingOption.DrawsTab) 
            | Sgry.Azuki.DrawingOption.DrawsEol) 
            | Sgry.Azuki.DrawingOption.HighlightCurrentLine) 
            | Sgry.Azuki.DrawingOption.ShowsLineNumber) 
            | Sgry.Azuki.DrawingOption.ShowsDirtBar) 
            | Sgry.Azuki.DrawingOption.HighlightsMatchedBracket)));
            this.azPreview.FirstVisibleLine = 0;
            this.azPreview.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            fontInfo1.Name = "MS UI Gothic";
            fontInfo1.Size = 9;
            fontInfo1.Style = System.Drawing.FontStyle.Regular;
            this.azPreview.FontInfo = fontInfo1;
            this.azPreview.ForeColor = System.Drawing.Color.Black;
            this.azPreview.GetSelectTextFilter = null;
            this.azPreview.IsSingleLineMode = true;
            this.azPreview.Location = new System.Drawing.Point(12, 91);
            this.azPreview.Name = "azPreview";
            this.azPreview.ScrollPos = new System.Drawing.Point(0, 0);
            this.azPreview.Size = new System.Drawing.Size(331, 165);
            this.azPreview.TabIndex = 6;
            this.azPreview.Text = "エディタプレビュー";
            this.azPreview.ViewWidth = 4129;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(267, 267);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(186, 267);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "行番号表示";
            // 
            // cmbLineNoMethod
            // 
            this.cmbLineNoMethod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLineNoMethod.FormattingEnabled = true;
            this.cmbLineNoMethod.Location = new System.Drawing.Point(83, 65);
            this.cmbLineNoMethod.Name = "cmbLineNoMethod";
            this.cmbLineNoMethod.Size = new System.Drawing.Size(260, 20);
            this.cmbLineNoMethod.TabIndex = 10;
            // 
            // ConfigDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 302);
            this.Controls.Add(this.cmbLineNoMethod);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.azPreview);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numWrapWidth);
            this.Controls.Add(this.chkWrap);
            this.Controls.Add(this.cmbFontFace);
            this.Controls.Add(this.numFontSize);
            this.Controls.Add(this.label1);
            this.Name = "ConfigDialog";
            this.Text = "ConfigDialog";
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWrapWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numFontSize;
        private System.Windows.Forms.ComboBox cmbFontFace;
        private System.Windows.Forms.CheckBox chkWrap;
        private System.Windows.Forms.NumericUpDown numWrapWidth;
        private System.Windows.Forms.Label label2;
        private Sgry.Azuki.WinForms.AzukiControl azPreview;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbLineNoMethod;
    }
}