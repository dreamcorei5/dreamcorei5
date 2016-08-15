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
    public partial class MessageLogin : Form {
        public MessageLogin() {
            InitializeComponent();
        }
        static MessageLogin msg; static DialogResult result = DialogResult.No;
        public static DialogResult Message_Login(string Text, string btnOK, string btnCancel) {
            msg = new MessageLogin();
            msg.label1.Text = Text;
            msg.OK.Text = btnOK;
            msg.Cancel.Text = btnCancel;
            msg.ShowDialog();
            return result;
        }
        private void OK_Click(object sender, EventArgs e) {
            Application.Exit();
            result = DialogResult.Yes; msg.Close();
        }
        private void Cancel_Click(object sender, EventArgs e) {
            result = DialogResult.No; msg.Close();
        }
    }
}
