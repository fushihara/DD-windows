using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DD {
    public partial class FormMain : Form {
        public static readonly long ByteBase = 1024;
        private long BaseFileSize = -1;
        private long byteOffset;
        private long byteLength;
        public FormMain() {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e) {
            RadioButtonTrimTypeA.Checked = true;
            ByteInputControl_A1.setBase(ByteBase);
            ByteInputControl_A2.setBase(ByteBase);
            ByteInputControl_B1.setBase(ByteBase);
            ByteInputControl_B2.setBase(ByteBase);
            ByteInputControl_C1.setBase(ByteBase);
            ByteInputControl_C2.setBase(ByteBase);

            ByteInputControl_A1.ValueChanged += (a, b) => { UpdateStatus(); };
            ByteInputControl_A2.ValueChanged += (a, b) => { UpdateStatus(); };
            ByteInputControl_B1.ValueChanged += (a, b) => { UpdateStatus(); };
            ByteInputControl_B2.ValueChanged += (a, b) => { UpdateStatus(); };
            ByteInputControl_C1.ValueChanged += (a, b) => { UpdateStatus(); };
            ByteInputControl_C2.ValueChanged += (a, b) => { UpdateStatus(); };
            UpdateStatus();
            TextBoxFromFilePath.DragEnter += (a, b) => { b.Effect = b.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None; };
            TextBoxToFilePath.DragEnter += (a, b) => { b.Effect = b.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None; };
            TextBoxFromFilePath.DragDrop += (a, b) => {
                string[] fileName = (string[])b.Data.GetData(DataFormats.FileDrop, false);
                TextBoxFromFilePath.Text = fileName[0];
                BaseFileSize = new System.IO.FileInfo(fileName[0]).Length;
                UpdateStatus();
            };
            TextBoxToFilePath.DragDrop += (a, b) => {
                string[] fileName = (string[])b.Data.GetData(DataFormats.FileDrop, false);
                TextBoxToFilePath.Text = fileName[0];
                UpdateStatus();
            };
        }

        private void RadioButtonTrimTypeA_CheckedChanged(object sender, EventArgs e) {
            ByteInputControl_A1.SetEnable(true);
            ByteInputControl_A2.SetEnable(true);
            ByteInputControl_B1.SetEnable(false);
            ByteInputControl_B2.SetEnable(false);
            ByteInputControl_C1.SetEnable(false);
            ByteInputControl_C2.SetEnable(false);
            UpdateStatus();
        }

        private void RadioButtonTrimTypeB_CheckedChanged(object sender, EventArgs e) {
            ByteInputControl_A1.SetEnable(false);
            ByteInputControl_A2.SetEnable(false);
            ByteInputControl_B1.SetEnable(true);
            ByteInputControl_B2.SetEnable(true);
            ByteInputControl_C1.SetEnable(false);
            ByteInputControl_C2.SetEnable(false);
            UpdateStatus();
        }
        private void RadioButtonTrimTypeC_CheckedChanged(object sender, EventArgs e) {
            ByteInputControl_A1.SetEnable(false);
            ByteInputControl_A2.SetEnable(false);
            ByteInputControl_B1.SetEnable(false);
            ByteInputControl_B2.SetEnable(false);
            ByteInputControl_C1.SetEnable(true);
            ByteInputControl_C2.SetEnable(true);
            UpdateStatus();
        }
        public static void setByteInformation(StringBuilder sb, long rawbyte, String tail) {
            // 1234567890(10GB1000MB1000KB1000B) ←ファイルサイズ
            if (rawbyte == -1) {
                sb.AppendFormat("           0(   0G    0M    0K    0byte){0}", tail);
            } else {
                long g, m, k, b;
                ByteInputControl.ConvertGMKB(rawbyte, ByteBase, out g, out m, out k, out b);
                sb.AppendFormat("{0,12}({1,4}G {2,4}M {3,4}K {4,4}byte){5}", rawbyte, g, m, k, b, tail);
            }
        }
        private void UpdateStatus() {
            StringBuilder sb = new StringBuilder();
            if (RadioButtonTrimTypeA.Checked) {
                long head = ByteInputControl_A1.getByte();
                long tail = ByteInputControl_A2.getByte();
                sb.AppendLine("左からファイルサイズ-右の間を切り出します。頭の1バイトとケツの1バイトをカットする");
                if (BaseFileSize != -1) {
                    do {
                        if (BaseFileSize < head + tail) {
                            byteOffset = -1;
                            break;
                        }
                        byteOffset = head;
                        byteLength = BaseFileSize - head - tail;
                    } while (false);
                }
            } else if (RadioButtonTrimTypeB.Checked) {
                long head = ByteInputControl_B1.getByte();
                long size = ByteInputControl_B2.getByte();
                sb.AppendLine("左から左＋右の間を切り出します。1バイト目から100バイト分(101バイト目まで)切り出す");
                if (BaseFileSize != -1) {
                    do {
                        if (BaseFileSize < head + size) {
                            byteOffset = -1;
                            break;
                        }
                        byteOffset = head;
                        byteLength = size;
                    } while (false);
                }
            } else if (RadioButtonTrimTypeC.Checked) {
                long head = ByteInputControl_C1.getByte();
                long tail = ByteInputControl_C2.getByte();
                sb.AppendLine("左から右の間を切り出します。1バイト目から100バイト目の間を切り出すとき");
                if (BaseFileSize != -1) {
                    do {
                        if (tail <= head) {
                            byteOffset = -1;
                            break;
                        }
                        byteOffset = head;
                        byteLength = tail - head;
                    } while (false);
                }
            }
            setByteInformation(sb, BaseFileSize, "←読み込んだファイルサイズ\r\n");
            setByteInformation(sb, byteOffset, "←切り出し開始オフセット\r\n");
            setByteInformation(sb, byteLength, "←切り出すファイルサイズ");
            TextBoxStatus.Text = (byteOffset == -1 ? "エラー:" : "") + sb.ToString();
        }
        private void ButtonOpenFileDialogFrom_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "開くファイルを選択してください";
            ofd.CheckPathExists = true;
            if (ofd.ShowDialog() == DialogResult.OK) {
                TextBoxFromFilePath.Text = ofd.FileName;
                BaseFileSize = new System.IO.FileInfo(ofd.FileName).Length;
                UpdateStatus();
            }
        }

        private void ButtonOpenFileDialogTo_Click(object sender, EventArgs e) {
            SaveFileDialog ofd = new SaveFileDialog();
            ofd.Title = "保存するファイルを選択してください";
            ofd.CheckPathExists = true;
            if (ofd.ShowDialog() == DialogResult.OK) {
                TextBoxToFilePath.Text = ofd.FileName;
            }
        }

        private void ButtonCopyPath_Click(object sender, EventArgs e) {
            String path = TextBoxFromFilePath.Text.Trim();
            if (path == "") {
                return;
            }
            TextBoxToFilePath.Text = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path)) + ".dd" + Path.GetExtension(path);
        }

        private void ButtonStart_Click(object sender, EventArgs e) {
            String loadPath = TextBoxFromFilePath.Text.Trim();
            String savePath = TextBoxToFilePath.Text.Trim();
            if (loadPath == "" || !new FileInfo(loadPath).Exists) {
                MessageBox.Show("読み込むファイルがありません");
                return;
            }
            if (savePath == "") {
                MessageBox.Show("書き出すファイルの指定がありません");
                return;
            }
            if (((Control.ModifierKeys & Keys.Shift) != Keys.Shift) && new FileInfo(savePath).Exists) {
                DialogResult dr = MessageBox.Show("書き出すファイルが存在します。上書きしてよろしいですか？\r\n[" + savePath + "]", "ファイル存在エラー", MessageBoxButtons.OKCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Cancel) {
                    return;
                }
            }
            {
                String outDrive = Path.GetPathRoot(savePath);
                DriveInfo drive = new DriveInfo(outDrive);
                if (drive.AvailableFreeSpace < byteLength) {
                    MessageBox.Show("空き容量がありません");
                    return;
                }
            }
            if (byteOffset == -1) {
                MessageBox.Show("ファイルサイズの指定が異常です");
                return;
            }
            FormProgress fp = new FormProgress(DateTime.Now.ToString("yyyy/MM/dd (ddd) HH:mm:ss") + "\r\n" + TextBoxStatus.Text);
            fp.SaveFilePath = savePath;
            fp.LoadFilePath = loadPath;
            fp.ByteLength = byteLength;
            fp.ByteOffset = byteOffset;
            this.Hide();
            fp.ShowDialog(this);
            this.Show();
            fp.Dispose();
        }
    }
}
