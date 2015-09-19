using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DD {
    public partial class ByteInputControl : UserControl {
        public delegate void onValueChange(object sender, ByteInputControlEventArgs e);
        public event onValueChange ValueChanged;

        private long ByteValue = 0;
        private long Base = 1024;
        public ByteInputControl() {
            InitializeComponent();
            ValueChanged += (a, b) => { };
        }
        public void setBase(long baseValue) {
            Base = baseValue;
            UpdateByte(ByteValue);
        }
        public static void ConvertGMKB(long rawByte, long BaseByte, out long GByte, out long MByte, out long KByte, out long Byte) {
            Byte = rawByte % BaseByte;
            KByte = rawByte / BaseByte % BaseByte;
            MByte = rawByte / BaseByte / BaseByte % BaseByte;
            GByte = rawByte / BaseByte / BaseByte / BaseByte % BaseByte;
        }

        private void ByteInputControlcs_Load(object sender, EventArgs e) {
            //指数を指定
            NumericUpDownGB.Maximum = Base + 1;
            NumericUpDownMB.Maximum = Base + 1;
            NumericUpDownKB.Maximum = Base + 1;
            NumericUpDownB.Maximum = Base + 1;
            UpdateByte(0);
            SetEnable(true);
        }
        public void UpdateByte(long newByte) {
            long gb, mb, kb, b;
            ConvertGMKB(newByte, Base, out gb, out mb, out kb, out b);
            if (NumericUpDownGB.Maximum < gb) {
                throw new ArgumentException("指定値[" + newByte + "]が指定範囲外です");
            }
            NumericUpDownGB.Value = gb;
            NumericUpDownMB.Value = mb;
            NumericUpDownKB.Value = kb;
            NumericUpDownB.Value = b;
            ByteValue = GetNowFormValue();
            ValueChanged(this, new ByteInputControlEventArgs(ByteValue));
        }
        public long getByte() {
            return ByteValue;
        }
        private long GetNowFormValue() {
            long gb = (long)NumericUpDownGB.Value;
            long mb = (long)NumericUpDownMB.Value;
            long kb = (long)NumericUpDownKB.Value;
            long b = (long)NumericUpDownB.Value;
            return gb * Base * Base * Base + mb * Base * Base + kb * Base + b;
        }
        public void SetEnable(Boolean enabled) {
            NumericUpDownGB.Enabled = enabled;
            NumericUpDownMB.Enabled = enabled;
            NumericUpDownKB.Enabled = enabled;
            NumericUpDownB.Enabled = enabled;
            LabelGB.ForeColor = enabled ? SystemColors.WindowText : SystemColors.GrayText;
            LabelMB.ForeColor = enabled ? SystemColors.WindowText : SystemColors.GrayText;
            LabelKB.ForeColor = enabled ? SystemColors.WindowText : SystemColors.GrayText;
            LabelB.ForeColor = enabled ? SystemColors.WindowText : SystemColors.GrayText;
        }
        private void NumericUpDownGB_ValueChanged(object sender, EventArgs e) {
            long number = (long)NumericUpDownGB.Value;
            if (number == -1) {
                NumericUpDownGB.Value = 0;
            } else if (Base < number) {
                NumericUpDownGB.Value = Base;
            }
            ByteValue = GetNowFormValue();
            ValueChanged(this, new ByteInputControlEventArgs(ByteValue));
        }

        private void NumericUpDownMB_ValueChanged(object sender, EventArgs e) {
            long number = (long)NumericUpDownMB.Value;
            if (number == -1) {
                if (NumericUpDownGB.Value != 0) {
                    NumericUpDownGB.Value--;
                    NumericUpDownMB.Value = Base;
                } else {
                    NumericUpDownMB.Value = 0;
                }
            } else if (Base < number) {
                Decimal beforeParentValue = NumericUpDownGB.Value;
                NumericUpDownGB.Value++;
                if (beforeParentValue == NumericUpDownGB.Value) {
                    NumericUpDownMB.Value = Base;
                } else {
                    NumericUpDownMB.Value = 0;
                }
            }
            ByteValue = GetNowFormValue();
            ValueChanged(this, new ByteInputControlEventArgs(ByteValue));
        }

        private void NumericUpDownKB_ValueChanged(object sender, EventArgs e) {
            long number = (long)NumericUpDownKB.Value;
            if (number == -1) {
                if (NumericUpDownMB.Value != 0) {
                    NumericUpDownMB.Value--;
                    NumericUpDownKB.Value = Base;
                } else {
                    NumericUpDownKB.Value = 0;
                }
            } else if (Base < number) {
                Decimal beforeParentValue = NumericUpDownMB.Value;
                NumericUpDownMB.Value++;
                if (beforeParentValue == NumericUpDownMB.Value) {
                    NumericUpDownKB.Value = Base;
                } else {
                    NumericUpDownKB.Value = 0;
                }
            }
            ByteValue = GetNowFormValue();
            ValueChanged(this, new ByteInputControlEventArgs(ByteValue));
        }

        private void NumericUpDownB_ValueChanged(object sender, EventArgs e) {
            long number = (long)NumericUpDownB.Value;
            if (number == -1) {
                if (NumericUpDownKB.Value != 0) {
                    NumericUpDownKB.Value--;
                    NumericUpDownB.Value = Base;
                } else {
                    NumericUpDownB.Value = 0;
                }
            } else if (Base < number) {
                Decimal beforeParentValue = NumericUpDownKB.Value;
                NumericUpDownKB.Value++;
                if (beforeParentValue == NumericUpDownKB.Value) {
                    NumericUpDownB.Value = Base;
                } else {
                    NumericUpDownB.Value = 0;
                }
            }
            ByteValue = GetNowFormValue();
            ValueChanged(this, new ByteInputControlEventArgs(ByteValue));
        }
    }
    public class ByteInputControlEventArgs : EventArgs {
        public readonly long ByteValue;
        public ByteInputControlEventArgs(long byteValue) {
            ByteValue = byteValue;
        }
    }
}
