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
    public partial class ReplaceKeywordInputDialog : Form
    {
        public ReplaceKeywordInputDialog()
        {
            InitializeComponent();
        }
        private bool replaceAll;

        public bool ReplaceAllMode
        {
            get { return replaceAll; }
            set
            {
                replaceAll = value;
                pAllControl.Visible = replaceAll;
                pEachControl.Visible = !replaceAll;
            }
        }

        public string ReplaceFrom
        {
            get { return lblReplaceTarget.Text; }
            set { lblReplaceTarget.Text = value; }
        }

        public string ReplaceTo
        {
            get { return txtReplaceResult.Text; }
            set { txtReplaceResult.Text = value; }
        }

        public bool ReplaceAll { get; private set; }

        public bool RequireContinue { get; private set; }

        public bool SkipThis { get; private set; }

        public event EventHandler<ReplaceKeywordDecideEventArgs> ReplaceRequired;

        private void InvokeReplaceRequiredEvent(DialogResult dialogResult)
        {
            if (ReplaceRequired != null)
            {
                ReplaceRequired(this, new ReplaceKeywordDecideEventArgs(ReplaceTo, ReplaceAll, RequireContinue));
            }
            else
            {
                DialogResult = dialogResult;
            }
        }

        private void btnReplaceThis_Click(object sender, EventArgs e)
        {
            ReplaceAll = false;
            RequireContinue = false;
            SkipThis = false;
            InvokeReplaceRequiredEvent(DialogResult.OK);
        }

        private void btnReplaceNext_Click(object sender, EventArgs e)
        {
            ReplaceAll = false;
            RequireContinue = true;
            InvokeReplaceRequiredEvent(DialogResult.Retry);

        }

        private void btnReplaceAll1_Click(object sender, EventArgs e)
        {
            ReplaceAll = true;
            RequireContinue = false;
            InvokeReplaceRequiredEvent(DialogResult.OK);
        }

        private void btnReplaceAll2_Click(object sender, EventArgs e)
        {
            ReplaceAll = true;
            RequireContinue = false;
            InvokeReplaceRequiredEvent(DialogResult.OK);
        }

        private void btnSkipNext_Click(object sender, EventArgs e)
        {
            if (ReplaceRequired != null)
            {
                ReplaceRequired(this, new ReplaceKeywordDecideEventArgs());
            }
            else
            {
                DialogResult = DialogResult.No;
            }

        }

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }

    public class ReplaceKeywordDecideEventArgs : EventArgs
    {
        /// <summary>
        /// 置換する
        /// </summary>
        /// <param name="replaceTo"></param>
        /// <param name="all"></param>
        /// <param name="reqContinue"></param>
        public ReplaceKeywordDecideEventArgs(string replaceTo, bool all, bool reqContinue)
        {
            ReplaceTo = replaceTo;
            ReplaceAll = all;
            RequireContinue = reqContinue;
            Skip = false;
        }

        /// <summary>
        /// 飛ばす奴作る
        /// </summary>
        public ReplaceKeywordDecideEventArgs()
        {
            RequireContinue = true;
            Skip = true;
        }

        /// <summary>
        /// 置換後
        /// </summary>
        public string ReplaceTo { get; private set; }
        
        /// <summary>
        /// 全置換希望
        /// </summary>
        public bool ReplaceAll { get; private set; }

        /// <summary>
        /// 置換を継続
        /// </summary>
        public bool RequireContinue { get; private set; }

        /// <summary>
        /// これは飛ばす
        /// </summary>
        public bool Skip { get; private set; }
    }
}
