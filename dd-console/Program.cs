using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dd_console {
    class Program {
        String inputFile = "";
        int mode = 0;
        long arg1 = 0;
        long arg2 = 0;
        static void Main(string[] args) {
            Program prg = new Program();
            for (int i = 0; i < args.Length; i++) {
                //if (i == 0) { continue; }
                String arg = args[i];
                if (String.IsNullOrWhiteSpace(arg)) {
                    continue;
                } else if (arg.StartsWith("m1:")) {
                    prg.mode = 1;
                    String[] arg2Byte = arg.Substring("m1:".Length).Split('/');
                    prg.arg1 = ByteFormatter.getByteFromGMKBString(arg2Byte[0]);
                    prg.arg2 = ByteFormatter.getByteFromGMKBString(arg2Byte[1]);
                } else if (arg.StartsWith("m2:")) {
                    prg.mode = 2;
                    String[] arg2Byte = arg.Substring("m1:".Length).Split('/');
                    prg.arg1 = ByteFormatter.getByteFromGMKBString(arg2Byte[0]);
                    prg.arg2 = ByteFormatter.getByteFromGMKBString(arg2Byte[1]);
                } else if (arg.StartsWith("m3:")) {
                    prg.mode = 3;
                    String[] arg2Byte = arg.Substring("m1:".Length).Split('/');
                    prg.arg1 = ByteFormatter.getByteFromGMKBString(arg2Byte[0]);
                    prg.arg2 = ByteFormatter.getByteFromGMKBString(arg2Byte[1]);
                } else if (System.IO.File.Exists(arg)) {
                    prg.inputFile = arg;
                }
            }
            if (prg.mode == 0 && prg.inputFile == "") {
                showHelp();
                return;
            } else if (prg.mode == 0) {
                String fs = ByteFormatter.getFormatGMKBString(new System.IO.FileInfo(prg.inputFile).Length);
                Console.WriteLine($"filesize {fs}");
                return;
            }
            if (!true) {
                Console.WriteLine($"mode:{prg.mode}");
                Console.WriteLine($"arg1:{ByteFormatter.getFormatGMKBString(prg.arg1)}");
                Console.WriteLine($"arg1:{ByteFormatter.getFormatGMKBString(prg.arg2)}");
            }
            prg.run();
        }
        static void showHelp() {
            String message = @"
m1
<-1mb->              <-1mb->
-------00000000000000-------
m2
<-1mb->
<--------3mb-------->
-------00000000000000-------
m3
<-1mb-><----2mb----->
-------00000000000000-------

ddw file.ts
filesize 10GB 100MB  10kb  1b

ddw file.ts ""m1: 100GB 100MB / 1GB""
 10.00 % [10GB 100MB  10kb  1b / 10GB 100MB  10kb  1b]";
            Console.WriteLine(message);
        }
        void run() {
            // ファイルの存在確認
            if (System.IO.File.Exists(this.inputFile) == false) {
                Console.Error.WriteLine("ファイルがありませんでした");
                return;
            }
            long origFileSize = new System.IO.FileInfo(this.inputFile).Length;
            //引数からコピーの開始オフセットとコピーする長さを求める
            long copyOffset = 0;
            long copyLength = 0;
            if (this.mode == 1) {
                copyOffset = this.arg1;
                copyLength = origFileSize - this.arg1 - this.arg2;

            } else if (this.mode == 2) {
                copyOffset = this.arg1;
                copyLength = this.arg2 - this.arg1;
                if (this.arg2 < this.arg1) {
                    Console.Error.WriteLine("第一パラメーターより第二パラメーターの値が小さいです");
                    return;
                }
            } else if (this.mode == 3) {
                copyOffset = this.arg1;
                copyLength = this.arg2;
            }
            if (origFileSize < copyOffset) {
                Console.Error.WriteLine("コピー開始のオフセットがファイルサイズを超えています");
                return;
            }
            // lengthが大き過ぎたらそれは修正する
            if (origFileSize < (copyOffset + copyLength)) {
                copyLength = origFileSize - copyOffset;
            }
            // 空き容量確認
            {
                String outDrive = Path.GetPathRoot(this.inputFile);
                DriveInfo drive = new DriveInfo(outDrive);
                if (drive.AvailableFreeSpace < copyLength) {
                    Console.Error.WriteLine("ドライブの空き容量が不足しています");
                    return;
                }
            }
            String saveFilePath = Path.Combine(Path.GetDirectoryName(this.inputFile), Path.GetFileNameWithoutExtension(this.inputFile) + "_trim" + Path.GetExtension(this.inputFile));
            if (!true) {
                Console.WriteLine($"copyOffset:{ByteFormatter.getFormatGMKBString(copyOffset)}");
                Console.WriteLine($"copyLength:{ByteFormatter.getFormatGMKBString(copyLength)}");
                Console.WriteLine($"outFile:{saveFilePath}");
            }
            //return;
            // 開始
            int bufferLength = 1024 * 1024;
            long remainingCopyLength = copyLength;
            long copyTotalSize = 0;
            using (FileStream stream = File.OpenRead(this.inputFile)) {
                File.Delete(saveFilePath);
                using (FileStream writeStream = File.OpenWrite(saveFilePath)) {
                    BinaryReader reader = new BinaryReader(stream);
                    BinaryWriter writer = new BinaryWriter(writeStream);
                    stream.Seek(copyOffset, SeekOrigin.Begin);
                    byte[] buffer = new Byte[bufferLength];
                    int bytesRead;
                    while (true) {
                        String p = String.Format("{0,5:##0.0}", (double)copyTotalSize / (double)copyLength * 100.0);
                        //Console.Write($"\r{p}% [{ByteFormatter.getFormatGMKBString(copyTotalSize)}/{ByteFormatter.getFormatGMKBString(copyLength)}]");
                        Console.Write($"\r{p}% [");
                        ByteFormatter.writeFormatGMKBStringColor(copyTotalSize);
                        Console.Write($"/");
                        ByteFormatter.writeFormatGMKBStringColor(copyLength);
                        Console.Write($"]");
                        if (bufferLength < remainingCopyLength) {
                            bytesRead = stream.Read(buffer, 0, bufferLength);
                            remainingCopyLength -= bytesRead;
                            copyTotalSize += bytesRead;
                            writeStream.Write(buffer, 0, bytesRead);
                            if (remainingCopyLength == 0) {
                                break;
                            }
                        } else {
                            stream.Read(buffer, 0, (int)remainingCopyLength);
                            writeStream.Write(buffer, 0, (int)remainingCopyLength);
                            break;
                        }

                    }
                    Console.WriteLine();
                }
                File.SetCreationTime(saveFilePath, File.GetCreationTime(this.inputFile));
                File.SetLastWriteTime(saveFilePath, File.GetLastWriteTime(this.inputFile));
                File.SetLastAccessTime(saveFilePath, File.GetLastAccessTime(this.inputFile));
            }
        }
    }
}
