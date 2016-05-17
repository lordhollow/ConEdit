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
    public partial class GitHistoryDialog : Form
    {
        private string workspace;
        public GitHistoryDialog(string workspace)
        {
            this.workspace = workspace;
            InitializeComponent();
        }
    }
}
