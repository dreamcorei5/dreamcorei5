using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Login_Basic {
    public partial class Login : Form {
        SqlConnection connect = Connect_DB.SqlConnect();
        SqlDataAdapter da;
        public Login() {
            InitializeComponent();
        }
        private void show_main() {
            MainProgram main = new MainProgram();
            main.Show();
        }
        int check_num_login = 0;
        private bool authen() {
            bool check = false;
            if(TextBox_User.Text.Trim() == "" | TextBox_Password.Text.Trim() == "") {
                MessageShow.MessageText("MessageBox","Please input username and password to the system","OK");
                check = true;
            }
            return check;
        }
        private void btn_login_Click(object sender, EventArgs e) {
            if (authen() == true) {
                return;
            }
            else {
                var check_login = "select * from Employees where username = @user COLLATE SQL_Latin1_General_CP1_CS_AS and password = @pwd COLLATE SQL_Latin1_General_CP1_CS_AS";
                SqlCommand comm = new SqlCommand(check_login, connect);
                comm.Parameters.AddWithValue("@user", TextBox_User.Text);
                comm.Parameters.AddWithValue("@pwd", TextBox_Password.Text);
                da = new SqlDataAdapter(comm);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int i = ds.Tables[0].Rows.Count;
                if (i == 0) {
                    check_num_login += 1;
                    if (check_num_login > 3) {
                        MessageShow.MessageText("รหัสผิดเกิน 3 ครั้ง ออกโปรแกรม","คุณป้อนรหัสผิดเกิน 3 ครั้ง กรุณาออกจากโปรแกรม","OK");
                        this.Close();
                        return;
                    }
                    MessageShow.MessageText("ผิดพลาด ไม่สามารถ Login ได้", "Username หรือ Password ไม่ถูกต้อง ผิดครั้งที่ " + check_num_login.ToString(),"OK");
                    TextBox_Password.Clear();
                    return;
                }
                else {
                    Authen authen = new Authen();
                    authen.setUser(this.TextBox_User.Text);
                    var query = "select * from Employees where Username = '" + TextBox_User.Text.Trim() + "'";
                    da = new SqlDataAdapter(query, connect);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0) {
                        var id = dt.Rows[0]["empId"].ToString();
                        authen.setId(Convert.ToInt32(id));
                        var name = dt.Rows[0]["name"].ToString();
                        authen.setName(name);
                        var position = dt.Rows[0]["position"].ToString();
                        authen.setPosition(position);
                    }
                    //MessageBox.Show("User Login  : \t" + Authen.getUser() + "\n\n\nยินดีต้อนรับคุณ  : \t" + Authen.getName() + " \tครับ/ค่ะ ");
                    this.Hide();
                    show_main();
                }
            }
        }

        private void btn_clear_Click(object sender, EventArgs e) {
            TextBox_User.Clear();
            TextBox_Password.Clear();
        }

        private void close_Click(object sender, EventArgs e) {
            MessageLogin.Message_Login("Do you want to exit ?", "OK", "CANCEL");
        }

        private void btn_login_KeyDown(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.Enter) {
                btn_login_Click(sender, e);
            }
        }

        private void TextBox_User_KeyDown(object sender, KeyEventArgs e) {
            btn_login_KeyDown(sender, e);
        }

        private void TextBox_Password_KeyDown(object sender, KeyEventArgs e) {
            btn_login_KeyDown(sender, e);
        }
    }
}
