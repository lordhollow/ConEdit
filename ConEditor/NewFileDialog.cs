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
    public partial class NewFileDialog : Form
    {
        bool configDirty;
        Binder binder;
        AutoNumberingEngine engine;

        public NewFileDialog(Binder binder)
        {
            InitializeComponent();
            this.binder = binder;
            txtPre.Text = binder.Config.NewFilePattern.Prefix;
            txtSuf.Text = binder.Config.NewFilePattern.Suffix;
            numMin.Value = binder.Config.NewFilePattern.MinValue;
            configDirty = false;
            engine = new AutoNumberingEngine(txtPre.Text, txtSuf.Text, (UInt32)numMin.Value);

            renew();
        }

        private void txtPre_TextChanged(object sender, EventArgs e)
        {
            configDirty = true;
        }

        private void txtSuf_TextChanged(object sender, EventArgs e)
        {
            configDirty = true;
        }

        private void numMin_ValueChanged(object sender, EventArgs e)
        {
            configDirty = true;
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            renew();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtNewFile.Text == "")
            {
                MessageBox.Show("ファイル名を入力してください");
                return;
            }
            else if (engine.IsValidPattern(txtNewFile.Text) == false)
            {
                MessageBox.Show("ファイル名に使用できない文字()が含まれています。");
                return;
            }
            NewFileName = txtNewFile.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void renew()
        {
            if (engine.SetPattern(txtPre.Text, txtSuf.Text) == false)
            {
                MessageBox.Show("ファイル名に使用できない文字()がパターンに含まれています。");
                return;
            }
            engine.MinValue = (UInt32)numMin.Value;
            var newName = engine.GetNextName(from content in binder select content.FileNameBody);
            txtNewFile.Text = newName;
            if (configDirty)
            {
                binder.SaveConfigulation();
                configDirty = false;
            }
        }

        public string NewFileName { get; private set; }
    }
}
