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
    public partial class FrmInterFace : Form
    {
        string FileName = "FileUser.txt";

        public FrmInterFace()
        {
            InitializeComponent();
        }

        private void btnMangeClient_MouseEnter(object sender, EventArgs e)
        {
            btnMangeClient.BackColor = Color.Blue;


        }

        private void btnMangeClient_MouseLeave(object sender, EventArgs e)
        {
            btnMangeClient.BackColor = Color.CornflowerBlue;
            btnMangeClient.BackColor = Color.FromArgb(26, 35, 58);

        }

        private void btnMangeUser_MouseEnter(object sender, EventArgs e)
        {
            btnMangeUser.BackColor = Color.Blue;

        }

        private void btnMangeUser_MouseLeave(object sender, EventArgs e)
        {
            btnMangeUser.BackColor = Color.CornflowerBlue;
            btnMangeUser.BackColor = Color.FromArgb(26, 35, 58);

        }

        private void btnTransaction_MouseEnter(object sender, EventArgs e)
        {
            btnTransaction.BackColor = Color.Blue;

        }

        private void btnTransaction_MouseLeave(object sender, EventArgs e)
        {
            btnTransaction.BackColor = Color.CornflowerBlue;
            btnTransaction.BackColor = Color.FromArgb(26, 35, 58);

        }

        private void btnLoginRegister_MouseEnter(object sender, EventArgs e)
        {
            btnLoginRegister.BackColor = Color.Blue;
        }

        private void btnLoginRegister_MouseLeave(object sender, EventArgs e)
        {
            btnLoginRegister.BackColor = Color.CornflowerBlue;
            btnLoginRegister.BackColor = Color.FromArgb(26, 35, 58);

        }

        private void btnCurrencyExchange_MouseEnter(object sender, EventArgs e)
        {
            btnCurrencyExchange.BackColor = Color.Blue;
        }

        private void btnCurrencyExchange_MouseLeave(object sender, EventArgs e)
        {
            btnCurrencyExchange.BackColor = Color.CornflowerBlue;
            btnCurrencyExchange.BackColor = Color.FromArgb(26, 35, 58);

        }

        private void btnLogout_MouseEnter(object sender, EventArgs e)
        {
            btnLogout.BackColor = Color.Blue;

        }

        private void btnLogout_MouseLeave(object sender, EventArgs e)
        {
            btnLogout.BackColor = Color.CornflowerBlue;
            btnLogout.BackColor = Color.FromArgb(26, 35, 58);


        }

        bool CheckPermission(int permission)
        {

            if (Convert.ToInt32(UserSession.Permission) == -1)
                return true;

                if ((Convert.ToInt32(UserSession.Permission)& permission) == permission)
                {
                    return true;
                }
            MessageBox.Show("Access Denied : Contact to admain","Warning",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);

            return false;
        }

        private void btnMangeClient_Click(object sender, EventArgs e)
        {
            if (!CheckPermission(1))
                return;

            Form frm = new FrmBankSystem();
            frm.ShowDialog();
        }

        private void btnMangeUser_Click(object sender, EventArgs e)
        {
            if (!CheckPermission(2))
                return;

            Form frm = new FrmManageUser();
            frm.ShowDialog();
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            if (!CheckPermission(4))
                return;

            Form frm = new FrmTransaction();
            frm.ShowDialog();
        }

        private void FrmInterFace_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(26, 35, 58);
            btnCurrencyExchange.BackColor = Color.FromArgb(26, 35, 58);
            btnMangeClient.BackColor = Color.FromArgb(26, 35, 58);
            btnMangeUser.BackColor = Color.FromArgb(26, 35, 58);
            btnLoginRegister.BackColor = Color.FromArgb(26, 35, 58);
            btnLogout.BackColor = Color.FromArgb(26, 35, 58);
            btnTransaction.BackColor = Color.FromArgb(26, 35, 58);
           // lbMBank.ForeColor = Color.FromArgb(26, 35, 58);

            UserFull.Text = UserSession.UserName + " : " + UserSession.FullName;
        }

        private void btnLoginRegister_Click(object sender, EventArgs e)
        {
            if (!CheckPermission(8))
                return;

            Form frm = new frmLoginRegister();
            frm.ShowDialog();
        }

        private void btnCurrencyExchange_Click(object sender, EventArgs e)
        {
            if (!CheckPermission(16))
                return;

            Form frm = new frmCurrencyExchange();
            frm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Information)==DialogResult.Yes)
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
