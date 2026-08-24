using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Project_Bank_C
{
    public partial class FrmLogin : Form
    {
        string FileName = "FileUser.txt";
        string FileLoginRegister = "FileLoginRegister.txt";
        byte key = 2;

        string UserNameG;
        string PasswordG;
        string PermissionG;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {


        }

        private void mtbUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(mtbUserName.Text))
            {
                e.Cancel = true;
                mtbUserName.Focus();
                errorProvider1.SetError(mtbUserName, "UserName is empty !");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(mtbUserName, "");
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                mtbPassword.PasswordChar = '\0';
            }
            else
            {

                mtbPassword.PasswordChar = '.';
            }
        }

        string Decrypted(string word)
        {
            string newWord = "";

            for (int i = 0; i < word.Length; i++)
            {
                newWord += Convert.ToChar(Convert.ToByte(word[i]) - key);
            }

            return newWord;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // this.BackgroundImage = Properties.Resources.ImageBank;
            // label2.ForeColor = Color.AntiqueWhite;
            this.BackColor = Color.FromArgb(26, 35, 58);
            pnlLogin.BackColor = Color.FromArgb(26, 35, 58);

        }

        private void button1_Click(object sender, EventArgs e)
        {
        

            string[] data;
            string line;
            string[] fullName;

        
            if (!File.Exists(FileName))
            {
               
                if (mtbPassword.Text == "1234" && mtbUserName.Text == "admin")
                {
                    MessageBox.Show("it will switch you to add new user be sure to give it all permission -1", "switch", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Form frm = new FrmManageUser();
                    frm.ShowDialog();
                    return;
                }
                MessageBox.Show("Default \n Username=admin\n Password=1234", "Default", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            StreamReader reader = new StreamReader(FileName);
            while ((line = reader.ReadLine()) != null)
            {
                data = line.Split('#');
                if (mtbPassword.Text == Decrypted(data[3]) && mtbUserName.Text == data[1])
                {
                    UserSession.UserName = mtbUserName.Text;
                    fullName = data[2].Split(' ');
                    UserSession.FullName = fullName[0];
                    UserSession.Permission =data[4];

                    UserNameG = data[1];
                    PasswordG = data[3];
                    PermissionG = data[4];

                    reader.Close();
                    LoginRegister();

                    Form frm = new FrmInterFace();
                    frm.ShowDialog();
                    mtbUserName.Focus();
                    mtbUserName.Text = "";
                    mtbPassword.Text = "";
                    return;

                }


            }

            MessageBox.Show("Invalid Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            mtbUserName.Focus();
            mtbUserName.Text = "";
            mtbPassword.Text = "";
        }

        private void mtbPassword_Validating(object sender, CancelEventArgs e)
        {

        }

        void LoginRegister()
        {
            DateTime Date = DateTime.Now;
            string Time = Date.ToString("dd/M/yyyy-hh:mm:ss:tt");

      

            string line = Time + "#" + UserNameG + "#" + PasswordG + "#" + PermissionG;
            StreamWriter Writer = new StreamWriter(FileLoginRegister, true);
            Writer.WriteLine(line);
            Writer.Close();




        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
