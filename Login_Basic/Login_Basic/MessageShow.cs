using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Basic {
    public partial class MessageShow : Form {
        public MessageShow() {
            InitializeComponent();
        }
        static MessageShow msg; static DialogResult result = DialogResult.No;
        public static DialogResult MessageText(string Title, string Text, string btnOK) {
            msg = new MessageShow();
            msg.label1.Text = Title;
            msg.label2.Text = Text;
            msg.OK.Text = btnOK;
            msg.ShowDialog();
            return result;
        }

        private void OK_Click(object sender, EventArgs e) {
            result = DialogResult.Yes; msg.Close();
        }
    }
}
