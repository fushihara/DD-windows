using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DD {
    class Program {
        private String basePath { get; set; }
        private String targetPath { get; set; }
        private long byteOffset { get; set; }
        private long byteLength { get; set; }
        private long byteFileSize;
        [STAThreadAttribute]
        static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
            return;
            new Program().
                setBasePath(@"K:\ゲーム・オブ・スローンズ シーズン4 戦乱の嵐-後編- 第09話「黒の城の死闘／The Watchers on the Wall」[スターチャンネル3(BS)][2014年09月22日(月)23時00分～][drop18].ts").
                setTargetPath(@"K:\ゲーム・オブ・スローンズ シーズン4 戦乱の嵐-後編- 第09話「黒の城の死闘／The Watchers on the Wall」[スターチャンネル3(BS)][2014年09月22日(月)23時00分～][drop18].dd.ts").
                setFromEnd(17 * 10 * 1000 * 1000 - 1, 17 * 11 * 1000 * 1000 - 1).//
                setFromEnd(100 * 1000 * 1000, -1 * 1024 * 1024 * 1024).//
                setFromEnd(fromMB: 20, toMB: -100).//

                
                run();
        }
        public Program setBasePath(String basePath) {
            this.basePath = basePath;
            byteFileSize = new FileInfo(basePath).Length;
            byteOffset = 0;
            byteLength = byteFileSize;
            return this;
        }
        public Program setTargetPath(String targetPath) {
            this.targetPath = targetPath;
            return this;
        }
        public Program setFromEnd(long from, long end) {
            byteOffset = from;
            if (0 < end) {
                byteLength = end - from;
            } else {
                byteLength = byteFileSize + end - from;
            }
            return this;
        }
        public Program setFromEnd(long fromGB = 0, long fromMB = 0, long fromKB = 0, long fromB = 0, long toGB = 0, long toMB = 0, long toKB = 0, long toB = 0) {
            long from = 0;
            long to = 0;
            from += fromGB * 1024 * 1024 * 1024;
            from += fromMB * 1024 * 1024;
            from += fromKB * 1024;
            from += fromB;

            to += toGB * 1024 * 1024 * 1024;
            to += toMB * 1024 * 1024;
            to += toKB * 1024;
            to += toB;
            return setFromEnd(from, to);
        }
        public void run() {
            int bufferLength = 1024 * 1024;
            long copyLength = byteLength;
            long copyTotalSize = 0;
            Console.WriteLine(copyLength);
            using (FileStream stream = File.OpenRead(basePath)) {
                File.Delete(targetPath);
                using (FileStream writeStream = File.OpenWrite(targetPath)) {
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
                        Console.Write(copyTotalSize.ToString() + "\r");
                    }
                }
            }
            File.SetCreationTime(targetPath, File.GetCreationTime(basePath));
            File.SetLastWriteTime(targetPath, File.GetLastWriteTime(basePath));
            File.SetLastAccessTime(targetPath, File.GetLastAccessTime(basePath));
        }
    }
}
