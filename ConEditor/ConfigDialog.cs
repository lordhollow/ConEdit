using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConEditor
{
    public partial class ConfigDialog : Form
    {
        Configulation config;
        ActualLineNumberConverterProvider actualLineNumberProvider;

        public ConfigDialog(Configulation config)
        {
            InitializeComponent();
            this.config = config;

            cmbLineNoMethod.Items.Clear();
            cmbLineNoMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLineNoMethod.Items.Add(new LineNoMethodListItem("なし", LineNoMethod.None));
            cmbLineNoMethod.Items.Add(new LineNoMethodListItem("全体通し", LineNoMethod.Total));
            cmbLineNoMethod.Items.Add(new LineNoMethodListItem("全体通し(境界を除く)", LineNoMethod.TotalIgnoreBorder));
            cmbLineNoMethod.Items.Add(new LineNoMethodListItem("ファイル個別", LineNoMethod.Individual));
            cmbLineNoMethod.Items.Add(new LineNoMethodListItem("ファイルインデックス+ファイル個別", LineNoMethod.IndividualWithIndex));

            actualLineNumberProvider = new ActualLineNumberConverterProvider();
            actualLineNumberProvider.Binder = Binder.CreateSampleData();
            azPreview.Document = actualLineNumberProvider.Binder.Document;

            EnumFonts();
            ApplyConfig();
            RegistorEvents();
            updatePreview();
        }


        private void EnumFonts()
        {
            var fc = new System.Drawing.Text.InstalledFontCollection();
            foreach (var f in fc.Families)
            {
                if (f.IsStyleAvailable(FontStyle.Regular))
                {
                    cmbFontFace.Items.Add(f.Name);
                }
            }
        }

        private void ApplyConfig()
        {
            for (int i = 0; i < cmbFontFace.Items.Count; i++)
            {
                if (cmbFontFace.Items[i].ToString() == config.FontName)
                {
                    cmbFontFace.SelectedIndex = i;
                }
            }
            numFontSize.Value = config.FontSize;
            chkWrap.Checked = config.Wordwrap;
            numWrapWidth.Value = config.Width;
            for (int i = 0; i < cmbLineNoMethod.Items.Count; i++)
            {
                if ((cmbLineNoMethod.Items[i] as LineNoMethodListItem).Method == config.LineNoMethod)
                {
                    cmbLineNoMethod.SelectedIndex = i;
                    break;
                }
            }
        }

        private void RegistorEvents()
        {
            cmbFontFace.SelectedIndexChanged += (s, a) => { updatePreview(); };
            numFontSize.ValueChanged += (s, a) => { updatePreview(); };
            chkWrap.CheckedChanged += (s, a) => { updatePreview(); };
            numWrapWidth.ValueChanged += (s, a) => { updatePreview(); };
            cmbLineNoMethod.SelectedIndexChanged += (s, a) => { updatePreview(); };
            azPreview.Resize += (s, a) => {
                if (chkWrap.Checked && (numWrapWidth.Value <= 0))
                {
                    azPreview.ViewWidth = azPreview.ClientSize.Width;
                }
            };
        }

        private void updatePreview()
        {
            string fontFace = "";
            if (cmbFontFace.SelectedIndex >= 0)
            {
                fontFace = cmbFontFace.Items[cmbFontFace.SelectedIndex].ToString();
            }

            azPreview.FontInfo = new Sgry.Azuki.FontInfo(fontFace, (int)numFontSize.Value, FontStyle.Regular);
            if (chkWrap.Checked)
            {
                if (numWrapWidth.Value <= 0)
                {
                    azPreview.ViewWidth = azPreview.ClientSize.Width;
                }
                else
                {
                    azPreview.ViewWidth = (int)(numWrapWidth.Value *  azPreview.View.HRulerUnitWidth);
                }
                azPreview.ViewType = Sgry.Azuki.ViewType.WrappedProportional;
            }
            else
            {
                azPreview.ViewType = Sgry.Azuki.ViewType.Proportional;
            }

            actualLineNumberProvider.Method = (cmbLineNoMethod.SelectedItem as LineNoMethodListItem).Method;
            azPreview.View.ActualLineNumberConverter = actualLineNumberProvider.ActualLineNumberConverter;
            azPreview.View.ShowLineNumber = actualLineNumberProvider.ShowLineNumber;
            azPreview.View.LineNumberWidthPad = actualLineNumberProvider.LineNumberPad;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string fontFace = "";
            if (cmbFontFace.SelectedIndex >= 0)
            {
                fontFace = cmbFontFace.Items[cmbFontFace.SelectedIndex].ToString();
            }
            config.FontName = fontFace;
            config.FontSize = (int)numFontSize.Value;
            config.Wordwrap = chkWrap.Checked;
            config.Width = (int)numWrapWidth.Value;
            config.LineNoMethod = (cmbLineNoMethod.SelectedItem as LineNoMethodListItem).Method;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

    }

    class LineNoMethodListItem
    {
        public LineNoMethodListItem(string caption, LineNoMethod method)
        {
            Caption = caption;
            Method = method;
        }

        public string Caption { get; private set; }
        public LineNoMethod Method { get; private set; }
        public override string ToString()
        {
            return Caption;
        }
    }

}
