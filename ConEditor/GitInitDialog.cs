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
    public partial class GitInitDialog : Form
    {
        private string workspace;

        public GitInitDialog(string workspace)
        {
            this.workspace = workspace;

            InitializeComponent();
            lblGitPos.Text = GitTool.Instance.GitPath;
            if (string.IsNullOrEmpty(GitTool.Instance.GitPath))
            {
                btnInit.Enabled = false;
            }
        }

        private void btnFindGit_Click(object sender, EventArgs e)
        {
            var f = new OpenFileDialog();
            f.Filter = "git.exe|git.exe";
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lblGitPos.Text = f.FileName;
                GitTool.Instance.GitPath = f.FileName;
                GitTool.Instance.Save();
                btnInit.Enabled = true;

            }
        }

        private void btnInit_Click(object sender, EventArgs e)
        {

        }
    }
}
