using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace ConEditor
{
    /// <summary>
    /// GITツール
    /// </summary>
    public class GitTool
    {
        private GitTool()
        {
        }

        private static GitTool instance;

        public static GitTool Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GitTool();
                    //TODO::保存したデータの参照
                }
                return instance;
            }
        }

        /// <summary>
        /// gitPath
        /// </summary>
        public string GitPath { get; set; }

        /// <summary>
        /// 設定済み？
        /// </summary>
        public bool Enable
        {
            get { return !string.IsNullOrEmpty(GitPath); }
        }

        /// <summary>
        /// 最後の実行結果
        /// </summary>
        public string LastExecuteResult { get; private set; }

        /// <summary>
        /// リポジトリの作成（ないとき）と、ユーザー名/メールアドレス/自動改行変換の設定
        /// </summary>
        /// <param name="workspace"></param>
        /// <param name="name"></param>
        /// <param name="mail"></param>
        public void Initialize(string workspace, string name, string mail)
        {
            if (!Enable) return;
            if (Directory.Exists(Path.Combine(workspace, ".git")) == false)
            {
                GitExecute(workspace, "init");
            }
            var ret = GitExecute(workspace, "config --local user.name \"" + name + "\"");
            ret += GitExecute(workspace, "config --local user.email \"" + mail + "\"");
            ret += GitExecute(workspace, "config --local core.autocrlf false");   //改行コード変換をなくす

            LastExecuteResult = ret;
        }

        /// <summary>
        /// コミットが居るか確認する
        /// </summary>
        /// <param name="workspace"></param>
        /// <returns></returns>
        public bool IsNeedCommit(string workspace)
        {
            return true;
        }

        /// <summary>
        /// とにかく全部コミットする
        /// </summary>
        /// <param name="workspace"></param>
        public void Commit(string workspace, string message)
        {
            if (!Enable) return;
            if (string.IsNullOrEmpty(message)) throw new GitCommitWithNoMessageException();
            if (IsNeedCommit(workspace) == false) throw new GitCommitNoCommitableFileException();

            GitExecute(workspace, "add *");    //add all untracked file
            var lines = message.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            var m = "";
            foreach (var line in lines)
            {
                var eline = line;
                //eline = eline.Replace("\\", @"\\");
                eline = eline.Replace("\"", "\\\"");
                m += "-m \"" + eline + "\" ";
            }
            GitExecute(workspace, "commit " + m);
        }

        /// <summary>
        /// 設定を保存しておく
        /// </summary>
        public void Save()
        {
        }

        private string GitExecute(string workspace, string cmd)
        {
            var ps = new ProcessStartInfo();
            ps.FileName = GitPath;
            ps.WorkingDirectory = workspace;
            ps.CreateNoWindow = true;
            ps.UseShellExecute = false;
            ps.RedirectStandardOutput = true;
            ps.Arguments = cmd;

            Process p = Process.Start(ps);
            p.WaitForExit();
            var px = p.StandardOutput.ReadToEnd();
            px = px.Replace("\n", "\r\n");

            if (GitExcuted != null)
            {
                GitExcuted(this, new GitExecutedEventArgs(px));
            }

            return px;
        }

        public EventHandler<GitExecutedEventArgs> GitExcuted;
    }

    public class GitCommitWithNoMessageException : Exception { }
    public class GitCommitNoCommitableFileException : Exception { }

    public class GitExecutedEventArgs : EventArgs
    {
        public GitExecutedEventArgs(string stdout)
        {
            STDOUT = stdout;
        }
       
        public string STDOUT { get; private set; }
    }
}
