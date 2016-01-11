using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DD {
    public partial class FormProgress : Form {
        private String saveFilePath;
        private String loadFilePath;
        private long byteOffset;
        private long byteLength;
        private BackgroundWorker bw = new BackgroundWorker();
        public String SaveFilePath
        {
            set
            {
                saveFilePath = value;
            }
        }
        public String LoadFilePath
        {
            set
            {
                loadFilePath = value;
            }
        }
        public long ByteOffset
        {
            set
            {
                byteOffset = value;
            }
        }
        public long ByteLength
        {
            set
            {
                byteLength = value;
            }
        }
        public FormProgress(String staticMessage) {
            InitializeComponent();
            TextBoxStaticMessage.Text = staticMessage;
            bw.WorkerSupportsCancellation = true;
        }
        private void FormProgress_Load(object sender, EventArgs e) {
            bw.DoWork += bw_DoWork;
            bw.WorkerReportsProgress = true;
            bw.ProgressChanged += bgWorker_ProgressChanged;
            bw.RunWorkerCompleted += bgWorker_RunWorkerCompleted;
            bw.RunWorkerAsync();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e) {
            int bufferLength = 1024 * 1024;
            long copyLength = byteLength;
            long copyTotalSize = 0;
            Console.WriteLine(copyLength);
            try {
                using (FileStream stream = File.OpenRead(loadFilePath)) {
                    File.Delete(saveFilePath);
                    using (FileStream writeStream = File.OpenWrite(saveFilePath)) {
                        BinaryReader reader = new BinaryReader(stream);
                        BinaryWriter writer = new BinaryWriter(writeStream);
                        stream.Seek(byteOffset, SeekOrigin.Begin);
                        byte[] buffer = new Byte[bufferLength];
                        int bytesRead;
                        while (true) {
                            if (bufferLength < copyLength) {
                                bytesRead = stream.Read(buffer, 0, bufferLength);
                                copyLength -= bytesRead;
                                copyTotalSize += bytesRead;
                                writeStream.Write(buffer, 0, bytesRead);
                                if (copyLength == 0) {
                                    break;
                                }
                            } else {
                                stream.Read(buffer, 0, (int)copyLength);
                                writeStream.Write(buffer, 0, (int)copyLength);
                                break;
                            }
                            if (bw.CancellationPending) {
                                e.Cancel = true;
                                break;
                            }
                            bw.ReportProgress((int)(10000f * copyTotalSize / byteLength), new List<long> { byteLength, copyTotalSize });

                        }
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                return;
            }
            File.SetCreationTime(saveFilePath, File.GetCreationTime(loadFilePath));
            File.SetLastWriteTime(saveFilePath, File.GetLastWriteTime(loadFilePath));
            File.SetLastAccessTime(saveFilePath, File.GetLastAccessTime(loadFilePath));
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            var data = (List<long>)e.UserState;
            StringBuilder sb = new StringBuilder();
            FormMain.setByteInformation(sb, data[0], "<-TotalLength\r\n");
            FormMain.setByteInformation(sb, data[1], "<-copyLength");
            this.TextBoxDynamic.Text = sb.ToString();
            this.Text = e.ProgressPercentage / 100f + "％完了";
            this.progressBarDynamic.Maximum = 10000;
            this.progressBarDynamic.Value = e.ProgressPercentage;
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e) {
            bw.CancelAsync();
            ButtonCancel.Enabled = false;
        }
    }
}
