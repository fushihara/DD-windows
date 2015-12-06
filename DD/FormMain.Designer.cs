namespace DD {
    partial class FormMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.RadioButtonTrimTypeA = new System.Windows.Forms.RadioButton();
            this.RadioButtonTrimTypeB = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TextBoxStatus = new System.Windows.Forms.TextBox();
            this.TextBoxFromFilePath = new System.Windows.Forms.TextBox();
            this.ButtonOpenFileDialogFrom = new System.Windows.Forms.Button();
            this.ButtonOpenFileDialogTo = new System.Windows.Forms.Button();
            this.TextBoxToFilePath = new System.Windows.Forms.TextBox();
            this.ButtonCopyPath = new System.Windows.Forms.Button();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.ByteInputControl_B2 = new DD.ByteInputControl();
            this.ByteInputControl_B1 = new DD.ByteInputControl();
            this.ByteInputControl_A2 = new DD.ByteInputControl();
            this.ByteInputControl_A1 = new DD.ByteInputControl();
            this.SuspendLayout();
            // 
            // RadioButtonTrimTypeA
            // 
            this.RadioButtonTrimTypeA.AutoSize = true;
            this.RadioButtonTrimTypeA.Location = new System.Drawing.Point(12, 12);
            this.RadioButtonTrimTypeA.Name = "RadioButtonTrimTypeA";
            this.RadioButtonTrimTypeA.Size = new System.Drawing.Size(709, 16);
            this.RadioButtonTrimTypeA.TabIndex = 0;
            this.RadioButtonTrimTypeA.TabStop = true;
            this.RadioButtonTrimTypeA.Text = "頭を 　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　カット＆尻を 　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　" +
    "　カット";
            this.RadioButtonTrimTypeA.UseVisualStyleBackColor = true;
            this.RadioButtonTrimTypeA.CheckedChanged += new System.EventHandler(this.RadioButtonTrimTypeA_CheckedChanged);
            // 
            // RadioButtonTrimTypeB
            // 
            this.RadioButtonTrimTypeB.AutoSize = true;
            this.RadioButtonTrimTypeB.Location = new System.Drawing.Point(12, 44);
            this.RadioButtonTrimTypeB.Name = "RadioButtonTrimTypeB";
            this.RadioButtonTrimTypeB.Size = new System.Drawing.Size(741, 16);
            this.RadioButtonTrimTypeB.TabIndex = 1;
            this.RadioButtonTrimTypeB.TabStop = true;
            this.RadioButtonTrimTypeB.Text = "頭を　　　　　　 　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　カット＆ファイルサイズを　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　" +
    "　　　　　　に";
            this.RadioButtonTrimTypeB.UseVisualStyleBackColor = true;
            this.RadioButtonTrimTypeB.CheckedChanged += new System.EventHandler(this.RadioButtonTrimTypeB_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Location = new System.Drawing.Point(12, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(737, 1);
            this.panel1.TabIndex = 8;
            // 
            // TextBoxStatus
            // 
            this.TextBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxStatus.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBoxStatus.Location = new System.Drawing.Point(12, 77);
            this.TextBoxStatus.Multiline = true;
            this.TextBoxStatus.Name = "TextBoxStatus";
            this.TextBoxStatus.ReadOnly = true;
            this.TextBoxStatus.Size = new System.Drawing.Size(741, 46);
            this.TextBoxStatus.TabIndex = 9;
            this.TextBoxStatus.Text = "1234567890(10GB1000MB1000KB1000B) ←ファイルサイズ\r\n1234567890(10GB1000MB1000KB1000B) ←ファ" +
    "イルサイズ\r\n1234567890(10GB1000MB1000KB1000B) ←ファイルサイズ";
            // 
            // TextBoxFromFilePath
            // 
            this.TextBoxFromFilePath.AllowDrop = true;
            this.TextBoxFromFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxFromFilePath.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBoxFromFilePath.Location = new System.Drawing.Point(12, 133);
            this.TextBoxFromFilePath.Name = "TextBoxFromFilePath";
            this.TextBoxFromFilePath.Size = new System.Drawing.Size(679, 19);
            this.TextBoxFromFilePath.TabIndex = 10;
            // 
            // ButtonOpenFileDialogFrom
            // 
            this.ButtonOpenFileDialogFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonOpenFileDialogFrom.Location = new System.Drawing.Point(697, 129);
            this.ButtonOpenFileDialogFrom.Name = "ButtonOpenFileDialogFrom";
            this.ButtonOpenFileDialogFrom.Size = new System.Drawing.Size(52, 23);
            this.ButtonOpenFileDialogFrom.TabIndex = 11;
            this.ButtonOpenFileDialogFrom.Text = "参照";
            this.ButtonOpenFileDialogFrom.UseVisualStyleBackColor = true;
            this.ButtonOpenFileDialogFrom.Click += new System.EventHandler(this.ButtonOpenFileDialogFrom_Click);
            // 
            // ButtonOpenFileDialogTo
            // 
            this.ButtonOpenFileDialogTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonOpenFileDialogTo.Location = new System.Drawing.Point(697, 172);
            this.ButtonOpenFileDialogTo.Name = "ButtonOpenFileDialogTo";
            this.ButtonOpenFileDialogTo.Size = new System.Drawing.Size(52, 23);
            this.ButtonOpenFileDialogTo.TabIndex = 13;
            this.ButtonOpenFileDialogTo.Text = "参照";
            this.ButtonOpenFileDialogTo.UseVisualStyleBackColor = true;
            this.ButtonOpenFileDialogTo.Click += new System.EventHandler(this.ButtonOpenFileDialogTo_Click);
            // 
            // TextBoxToFilePath
            // 
            this.TextBoxToFilePath.AllowDrop = true;
            this.TextBoxToFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxToFilePath.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBoxToFilePath.Location = new System.Drawing.Point(12, 176);
            this.TextBoxToFilePath.MinimumSize = new System.Drawing.Size(679, 19);
            this.TextBoxToFilePath.Name = "TextBoxToFilePath";
            this.TextBoxToFilePath.Size = new System.Drawing.Size(679, 19);
            this.TextBoxToFilePath.TabIndex = 12;
            // 
            // ButtonCopyPath
            // 
            this.ButtonCopyPath.Location = new System.Drawing.Point(302, 152);
            this.ButtonCopyPath.Name = "ButtonCopyPath";
            this.ButtonCopyPath.Size = new System.Drawing.Size(104, 23);
            this.ButtonCopyPath.TabIndex = 14;
            this.ButtonCopyPath.Text = "↓コピー";
            this.ButtonCopyPath.UseVisualStyleBackColor = true;
            this.ButtonCopyPath.Click += new System.EventHandler(this.ButtonCopyPath_Click);
            // 
            // ButtonStart
            // 
            this.ButtonStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonStart.Location = new System.Drawing.Point(12, 201);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(737, 23);
            this.ButtonStart.TabIndex = 15;
            this.ButtonStart.Text = "スタート(Shift押下で上書き確認スキップ)";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // ByteInputControl_B2
            // 
            this.ByteInputControl_B2.Location = new System.Drawing.Point(453, 40);
            this.ByteInputControl_B2.Name = "ByteInputControl_B2";
            this.ByteInputControl_B2.Size = new System.Drawing.Size(283, 24);
            this.ByteInputControl_B2.TabIndex = 7;
            // 
            // ByteInputControl_B1
            // 
            this.ByteInputControl_B1.Location = new System.Drawing.Point(59, 39);
            this.ByteInputControl_B1.Name = "ByteInputControl_B1";
            this.ByteInputControl_B1.Size = new System.Drawing.Size(283, 24);
            this.ByteInputControl_B1.TabIndex = 6;
            // 
            // ByteInputControl_A2
            // 
            this.ByteInputControl_A2.Location = new System.Drawing.Point(408, 7);
            this.ByteInputControl_A2.Name = "ByteInputControl_A2";
            this.ByteInputControl_A2.Size = new System.Drawing.Size(283, 24);
            this.ByteInputControl_A2.TabIndex = 5;
            // 
            // ByteInputControl_A1
            // 
            this.ByteInputControl_A1.Location = new System.Drawing.Point(59, 7);
            this.ByteInputControl_A1.Name = "ByteInputControl_A1";
            this.ByteInputControl_A1.Size = new System.Drawing.Size(283, 24);
            this.ByteInputControl_A1.TabIndex = 4;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 224);
            this.Controls.Add(this.ButtonStart);
            this.Controls.Add(this.ButtonCopyPath);
            this.Controls.Add(this.ButtonOpenFileDialogTo);
            this.Controls.Add(this.TextBoxToFilePath);
            this.Controls.Add(this.ButtonOpenFileDialogFrom);
            this.Controls.Add(this.TextBoxFromFilePath);
            this.Controls.Add(this.TextBoxStatus);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ByteInputControl_B2);
            this.Controls.Add(this.ByteInputControl_B1);
            this.Controls.Add(this.ByteInputControl_A2);
            this.Controls.Add(this.ByteInputControl_A1);
            this.Controls.Add(this.RadioButtonTrimTypeB);
            this.Controls.Add(this.RadioButtonTrimTypeA);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(9999, 251);
            this.MinimumSize = new System.Drawing.Size(761, 251);
            this.Name = "FormMain";
            this.Text = "DD";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton RadioButtonTrimTypeA;
        private System.Windows.Forms.RadioButton RadioButtonTrimTypeB;
        private ByteInputControl ByteInputControl_A1;
        private ByteInputControl ByteInputControl_A2;
        private ByteInputControl ByteInputControl_B1;
        private ByteInputControl ByteInputControl_B2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TextBoxStatus;
        private System.Windows.Forms.TextBox TextBoxFromFilePath;
        private System.Windows.Forms.Button ButtonOpenFileDialogFrom;
        private System.Windows.Forms.Button ButtonOpenFileDialogTo;
        private System.Windows.Forms.TextBox TextBoxToFilePath;
        private System.Windows.Forms.Button ButtonCopyPath;
        private System.Windows.Forms.Button ButtonStart;

    }
}