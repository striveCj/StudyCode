using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Net;

namespace StudyCode
{
    public partial class Form1T20D5 : Form
    {
        int DownloadSize = 0;
        string downloadPath = null;
        long totalSize = 0;
        FileStream filestream;
        CancellationTokenSource cts = null;
        Task task = null;
        SynchronizationContext sc;
        public Form1T20D5()
        {
            InitializeComponent();
            string url = "http://download.microsoft.com/download/7/0/3/70345ee-a747-4cc8-bd3e-98a615c3aedb/dotNetFx35setup.exe";
            txbUrl.Text = url;
            this.btmPause.Enabled = false;
            GetTotalSize();
            downloadPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + Path.GetFileName(this.txbUrl.Text.Trim());
            if (File.Exists(downloadPath))
            {
                FileInfo fileInfo = new FileInfo(downloadPath);
                DownloadSize = (int)fileInfo.Length;
                progressBar1.Value = (int)((float)DownloadSize / (float)totalSize * 100);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void btnDownLoad_Click(object sender, EventArgs e)
        {
            filestream = new FileStream(downloadPath, FileMode.OpenOrCreate);
            this.btnDownLoad.Enabled = false;
            this.btmPause.Enabled = true;
            filestream.Seek(DownloadSize, SeekOrigin.Begin);
            sc = SynchronizationContext.Current;
            cts = new CancellationTokenSource();
            task = new Task(() => DownloadFileWithTAP(txbUrl.Text.Trim(), cts.Token, new Progress<int>(p =>
            {
                sc.Post(new SendOrPostCallback((result) => progressBar1.Value = (int)result), p);
            })));
            task.Start();
        }
        public void DownloadFileWithTAP(string url,CancellationToken ct,IProgress<int> progress)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Stream responseStream = null;
            int bufferSize = 2048;
            byte[] bufferBytes = new byte[bufferSize];
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                if (DownloadSize!=0)
                {
                    request.AddRange(DownloadSize);
                }
                response = (HttpWebResponse)request.GetResponse();
                responseStream = response.GetResponseStream();
                int readSize = 0;
                while (true)
                {
                    if (ct.IsCancellationRequested==true)
                    {
                        MessageBox.Show($"下载暂停，下载的文件地址为：{downloadPath}，\n已下载的字节数为：{DownloadSize}");
                        response.Close();
                        filestream.Close();
                        sc.Post((state) =>
                        {
                            this.btnDownLoad.Enabled = true;
                            this.btmPause.Enabled = false;
                        }, null);
                        break;
                    }
                    readSize = responseStream.Read(bufferBytes, 0, bufferBytes.Length);
                    if (readSize>0)
                    {
                        DownloadSize += readSize;
                        int percentComplete= (int)((float)DownloadSize / (float)totalSize * 100);
                        filestream.Write(bufferBytes, 0, readSize);
                        progress.Report(percentComplete);
                    }
                    else
                    {
                        MessageBox.Show($"下载已完成，下载的文件地址为：{downloadPath}，\n字节总数为：{DownloadSize}");
                        sc.Post((state) =>
                        {
                            this.btnDownLoad.Enabled = false;
                            this.btmPause.Enabled = false;
                        }, null);
                        response.Close();
                        filestream.Close();
                        break;
                    }
                }
            }
            catch (AggregateException ex)
            {
                ex.Handle(e => e is OperationCanceledException);
                throw;
            }
        }
        private void btmPause_Click(object sender, EventArgs e)
        {
            cts.Cancel();
        }
        private void GetTotalSize()
        {
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(txbUrl.Text.Trim());
            HttpWebResponse response = (HttpWebResponse)myHttpWebRequest.GetResponse();
            totalSize = response.ContentLength;
            response.Close();
        }
    }
}
