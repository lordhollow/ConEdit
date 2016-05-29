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
            get { return !string.IsNullOrEmpty(GitPath) && File.Exists(GitPath); }
        }

        /// <summary>
        /// 最後の実行結果
        /// </summary>
        public string LastExecuteResult { get; private set; }

        /// <summary>
        /// ユーザー名の取得
        /// </summary>
        /// <param name="workspace"></param>
        /// <returns></returns>
        public string GetUserName(string workspace)
        {
            if (!Enable) return "";
            return GitExecute(workspace, "config --local --get user.name");
        }

        /// <summary>
        /// ユーザーメールアドレスの取得の取得
        /// </summary>
        /// <param name="workspace"></param>
        /// <returns></returns>
        public string GetUserEMail(string workspace)
        {
            if (!Enable) return "";
            return GitExecute(workspace, "config --local --get user.email");
        }

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
            ret += GitExecute(workspace, "config --local core.quotepath false");   //ファイル名の数値参照をなくす
            
            LastExecuteResult = ret;
        }

        /// <summary>
        /// コミットが居るか確認する
        /// </summary>
        /// <param name="workspace"></param>
        /// <returns></returns>
        public bool IsNeedCommit(string workspace, out string targetFiles)
        {
            targetFiles = "";
            if (!Enable) return false;
            var ret = GitExecute(workspace, "status -s .", out targetFiles);
            return ((ret == 0) && (string.IsNullOrEmpty(targetFiles) == false));
        }

        /// <summary>
        /// とにかく全部コミットする
        /// </summary>
        /// <param name="workspace"></param>
        public string Commit(string workspace, string message)
        {
            string output;
            if (!Enable) return "gitが無効です";
            if (string.IsNullOrEmpty(message)) throw new GitCommitWithNoMessageException();
            if (IsNeedCommit(workspace, out output) == false) throw new GitCommitNoCommitableFileException();

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
            output = GitExecute(workspace, "commit " + m);
            return output;
        }

        /// <summary>
        /// 履歴の取得
        /// </summary>
        /// <param name="workspace"></param>
        /// <returns></returns>
        public string GetHistory(string workspace)
        {
            if (!Enable) return "";
            return GitExecute(workspace, "log --oneline");
        }


        /// <summary>
        /// 設定を保存しておく
        /// </summary>
        public void Save()
        {
        }

        private string GitExecute(string workspace, string cmd)
        {
            string s;
            GitExecute(workspace, cmd, out s);
            return s;
        }

        private int GitExecute(string workspace, string cmd, out string stdOut)
        {
            var ps = new ProcessStartInfo();
            ps.FileName = GitPath;
            ps.WorkingDirectory = workspace;
            ps.CreateNoWindow = true;
            ps.UseShellExecute = false;
            ps.RedirectStandardOutput = true;
            ps.Arguments = cmd;
            ps.StandardOutputEncoding = Encoding.UTF8;

            Process p = Process.Start(ps);
            p.WaitForExit();
            var px = p.StandardOutput.ReadToEnd();
            px = px.Replace("\n", "\r\n");

            if (GitExcuted != null)
            {
                GitExcuted(this, new GitExecutedEventArgs(px));
            }
            stdOut = px;
            return p.ExitCode;
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
