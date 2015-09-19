namespace DD {
    partial class FormProgress {
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
            this.TextBoxStaticMessage = new System.Windows.Forms.TextBox();
            this.progressBarDynamic = new System.Windows.Forms.ProgressBar();
            this.TextBoxDynamic = new System.Windows.Forms.TextBox();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextBoxStaticMessage
            // 
            this.TextBoxStaticMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxStaticMessage.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBoxStaticMessage.Location = new System.Drawing.Point(12, 12);
            this.TextBoxStaticMessage.Multiline = true;
            this.TextBoxStaticMessage.Name = "TextBoxStaticMessage";
            this.TextBoxStaticMessage.ReadOnly = true;
            this.TextBoxStaticMessage.Size = new System.Drawing.Size(564, 76);
            this.TextBoxStaticMessage.TabIndex = 0;
            // 
            // progressBarDynamic
            // 
            this.progressBarDynamic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarDynamic.Location = new System.Drawing.Point(12, 93);
            this.progressBarDynamic.Name = "progressBarDynamic";
            this.progressBarDynamic.Size = new System.Drawing.Size(564, 23);
            this.progressBarDynamic.TabIndex = 1;
            // 
            // TextBoxDynamic
            // 
            this.TextBoxDynamic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxDynamic.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBoxDynamic.Location = new System.Drawing.Point(12, 123);
            this.TextBoxDynamic.Multiline = true;
            this.TextBoxDynamic.Name = "TextBoxDynamic";
            this.TextBoxDynamic.ReadOnly = true;
            this.TextBoxDynamic.Size = new System.Drawing.Size(564, 38);
            this.TextBoxDynamic.TabIndex = 2;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCancel.Location = new System.Drawing.Point(12, 167);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(564, 23);
            this.ButtonCancel.TabIndex = 3;
            this.ButtonCancel.Text = "キャンセル";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // FormProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 194);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.TextBoxDynamic);
            this.Controls.Add(this.progressBarDynamic);
            this.Controls.Add(this.TextBoxStaticMessage);
            this.MaximumSize = new System.Drawing.Size(9999, 221);
            this.MinimumSize = new System.Drawing.Size(200, 221);
            this.Name = "FormProgress";
            this.Text = "FormProgress";
            this.Load += new System.EventHandler(this.FormProgress_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxStaticMessage;
        private System.Windows.Forms.ProgressBar progressBarDynamic;
        private System.Windows.Forms.TextBox TextBoxDynamic;
        private System.Windows.Forms.Button ButtonCancel;
    }
}