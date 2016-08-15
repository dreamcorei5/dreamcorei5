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
    public partial class MainProgram : Form {
        public MainProgram() {
            InitializeComponent();
            timer1.Start();
            lblUser.Text = Authen.getUser();
            lblName.Text = Authen.getName();
            lblPosition.Text = Authen.getPosition();
        }

        private void close_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            DateTime date = DateTime.Now;
            this.lblTime.Text = date.ToString("dd:MM:yyyy HH:mm::ss");
        }

        private void btn_Logout_Click(object sender, EventArgs e) {
            if (MessageBox.Show("คุณต้องการออกจากจากระบบ ใช่ หรือ ไม่", "ยืนยันการออกจากระบบ", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes) {
                this.Close();
                Login L = new Login();
                L.Show();
            }
        }
    }
}
