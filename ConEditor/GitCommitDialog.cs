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
    /// <summary>
    /// コミットのダイアログ
    /// </summary>
    public partial class GitCommitDialog : Form
    {
        private string workspace;
        private bool needCommit;

        public GitCommitDialog(string workspace)
        {
            this.workspace = workspace;
            InitializeComponent();
            Prepare();
        }

        public string Status
        {
            get { return lblStatus.Text; }
            set { lblStatus.Text = value; }
        }

        private void Prepare()
        {
            string files;

            needCommit = GitTool.Instance.IsNeedCommit(workspace, out files);
            if (needCommit)
            {
                Status = "コミットメッセージを入力してください。";
                txtInfo.Text = files;
            }
            else
            {
                Status = "コミットできません。";
            }

            txtMessage.Text = "";
            btnCommit.Enabled = false;
        }


        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            btnCommit.Enabled = needCommit & (txtMessage.Text.Length != 0);
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            txtInfo.Text += Environment.NewLine + GitTool.Instance.Commit(workspace, txtMessage.Text);
            Prepare();
        }

    }
}
