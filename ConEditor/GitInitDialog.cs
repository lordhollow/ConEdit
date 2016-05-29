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


        public string GitPath
        {
            get { return lblGitPos.Text; }
            set { lblGitPos.Text = value; }
        }

        public GitInitDialog(string workspace)
        {

            InitializeComponent();
            this.workspace = workspace;
            lblGitPos.Text = GitTool.Instance.GitPath;
            txtName.Text = GitTool.Instance.GetUserName(workspace);
            txtMail.Text = GitTool.Instance.GetUserEMail(workspace);
            btnInit.Enabled = GitTool.Instance.Enable;
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
            var tool = GitTool.Instance;
            tool.GitPath = lblGitPos.Text;
            tool.Initialize(
                workspace,
                txtName.Text == "" ? "no name" : txtName.Text,
                txtMail.Text);
        }

        private void lblGitPos_TextChanged(object sender, EventArgs e)
        {
            var tool = GitTool.Instance;
            tool.GitPath = lblGitPos.Text;
            btnInit.Enabled = tool.Enable;
        }
    }
}
