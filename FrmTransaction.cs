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
using System.Threading;

namespace Project_Bank_C
{
    public partial class FrmTransaction : Form
    {

        string FileBalance = "Balance.txt";
        string FileTransferLog = "TransferLog.txt";
        decimal Acc_Balance;
        Decimal TotalBalanceOfMBank;
        bool isFind = true;
        decimal AmountOfTransfer;
        int SignOfDepositeOrWithdraw;

        string s_Acc;
        string d_Acc;
        string s_Balance;
        string d_Balance;


        public FrmTransaction()
        {
            InitializeComponent();
        }

        string FileName = "MClient.text";

        void FillItem(string[] data)
        {
            ListViewItem item = new ListViewItem(data[1]);
            item.SubItems.Add(data[2]);
            item.SubItems.Add(data[9]);
            listviewTotalBalance.Items.Add(item);
        }

        void FillListView()
        {
            string[] data;
            string line;
            StreamReader reader = new StreamReader(FileName);
            while ((line = reader.ReadLine()) != null)
            {
                data = line.Split('#');
                FillItem(data);
            }
            reader.Close();
        }

        string Withdraw(decimal AccountBalance)
        {
            AccountBalance -= Acc_Balance;
            return Convert.ToString(AccountBalance);
        }

        string Deposite(decimal AccountBalance)
        {
            AccountBalance += Acc_Balance;
            return Convert.ToString(AccountBalance);
        }

        string ConvertToString(string[] data)
        {
            string line;
            string seprator = "#";

            line = data[0] + seprator;
            line += data[1] + seprator;
            line += data[2] + seprator;
            line += data[3] + seprator;
            line += data[4] + seprator;
            line += data[5] + seprator;
            line += data[6] + seprator;
            line += data[7] + seprator;
            line += data[8] + seprator;
            line += data[9] + seprator;
            line += data[10];

            return line;
        }

        void UploadListView()
        {
            string[] data;
            string line;
            string info;
            List<string> item = new List<string>();
            using (StreamReader reader = new StreamReader(FileName))
            {
                listviewTotalBalance.Items.Clear();


                while ((line = reader.ReadLine()) != null)
                {
                    data = line.Split('#');
                    if (mtbAccountNumberW.Text == data[2])
                    {
                        data[9] = Withdraw(Convert.ToDecimal(data[9]));
                        isFind = false;
                    }
                    FillItem(data);
                    info = ConvertToString(data);
                    item.Add(info);

                }


            }


            using (StreamWriter writer = new StreamWriter(FileName))
            {
                foreach (string St in item)
                {
                    writer.WriteLine(St);
                }
            }
        }

        bool IsMoneyEnouth()

        {
            string[] data;
            string line;
            StreamReader reader = new StreamReader(FileName);



            while ((line = reader.ReadLine()) != null)
            {
                data = line.Split('#');
                if (mtbAccountNumberW.Text == data[2])
                {

                    isFind = false;
                    if (Convert.ToDecimal(data[9]) > Acc_Balance)
                    {
                        reader.Close();
                        return true;
                    }

                    else
                    {
                        MessageBox.Show("Insufficient balance for this transaction ! ", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ClearWithdraw();
                    }
                }

            }

            if (isFind)
            {
                MessageBox.Show(mtbAccountNumberW.Text + " Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearWithdraw();
            }
            reader.Close();
            return false;


        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            btnWithdraw.BackColor = Color.Blue;
        }

        private void btnWithdraw_MouseLeave(object sender, EventArgs e)
        {
            btnWithdraw.BackColor = Color.CornflowerBlue;
        }

        private void btnDeposite_MouseEnter(object sender, EventArgs e)
        {
            btnDeposite.BackColor = Color.Blue;
        }

        private void btnDeposite_MouseLeave(object sender, EventArgs e)
        {
            btnDeposite.BackColor = Color.CornflowerBlue;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            btnTransferT.BackColor = Color.Blue;
        }

        private void btnSubmitT_MouseLeave(object sender, EventArgs e)
        {
            btnTransferT.BackColor = Color.CornflowerBlue;
        }


        void ColorOfForm()
        {
            this.BackColor = Color.FromArgb(25, 36, 58);
            pnlAccountNumberW.BackColor = Color.FromArgb(25, 36, 58);
            pnlAccountNumberD.BackColor = Color.FromArgb(25, 36, 58);
            pnlAmountW.BackColor = Color.FromArgb(25, 36, 58);
            pnlAmountD.BackColor = Color.FromArgb(25, 36, 58);
            pnlTransfer.BackColor = Color.FromArgb(25, 36, 58);
            pnlTitleBank.BackColor = Color.FromArgb(25, 36, 58);
            pnlOfTotalaBalance.BackColor = Color.FromArgb(25, 36, 58);
            lblIVEUTILZATION.ForeColor = Color.FromArgb(25, 36, 58);
            progressBarBalance.ForeColor = Color.FromArgb(25, 36, 58);
        }

        void ActiveUser()
        {
            lbaUserFullW.Text = UserSession.UserName + " : " + UserSession.FullName;
            lbUserFullLog.Text = UserSession.UserName + " : " + UserSession.FullName;
            lbUserFullTotal.Text = UserSession.UserName + " : " + UserSession.FullName;
            lbUserFullTransfer.Text = UserSession.UserName + " : " + UserSession.FullName;
            lbUserFullD.Text = UserSession.UserName + " : " + UserSession.FullName;
        }

        private void FrmTransaction_Load(object sender, EventArgs e)
        {
            ColorOfForm();

            ActiveUser();

            UploadListViewOfTransferLog();

            FillListView();

            VaultMBank();
        }

        void GetTotalBalanceOfBank(MaskedTextBox mtbAmount, int num = 1)
        {
            string[] data;
            string line;
            decimal AccountBalance;
            StreamReader reader = new StreamReader(FileBalance);
            line = reader.ReadLine().Trim();
            reader.Close();

            AccountBalance = Convert.ToDecimal(line);
            TotalBalanceOfMBank = AccountBalance;
            SignOfDepositeOrWithdraw = num;

            mtbAmount.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            if (decimal.TryParse(mtbAmount.Text, out Acc_Balance))
                AccountBalance += (Acc_Balance * num);

            StreamWriter writer = new StreamWriter(FileBalance);
            writer.WriteLine(AccountBalance.ToString());
            writer.Close();

        }

        void ClearWithdraw()
        {
            mtbAccountNumberW.Text = "";
            mtbAmountW.Text = "";
        }

        bool IsWithdrawNull()
        {
            if (mtbAccountNumberW.Text == "" || mtbAmountW.Text == "")
            {
                MessageBox.Show("Fill Form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            if (IsWithdrawNull())
                return;



            if (MessageBox.Show("Are you sure ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                GetTotalBalanceOfBank(mtbAmountW);

                if (!IsMoneyEnouth())
                    return;



                UploadListView();




                VaultMBank();

                ClearWithdraw();
                MessageBox.Show("Done Successfully ? ", "Withdraw", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(" Faild ? ", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        bool IsDepositeNull()
        {
            if (mtbAccountNumberD.Text == "" || mtbAmountD.Text == "")
            {
                MessageBox.Show("Fill Form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        bool IsMoneyEnouthForDeposite()

        {
            string[] data;
            string line;
            bool isFindClient = true;
            StreamReader reader = new StreamReader(FileName);



            while ((line = reader.ReadLine()) != null)
            {
                data = line.Split('#');
                if (mtbAccountNumberD.Text == data[2])
                {

                    isFindClient = false;
                    if (TotalBalanceOfMBank > Convert.ToDecimal(data[9]))
                    {
                        reader.Close();
                        return true;
                    }

                    else
                    {
                        MessageBox.Show("Insufficient balance for this transaction ! ", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ClearDepositeForm();
                    }
                }

            }

            if (isFindClient)
            {
                MessageBox.Show(mtbAccountNumberD.Text + " Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearDepositeForm();
            }
            reader.Close();
            return false;

        }

        void ClearDepositeForm()
        {
            mtbAccountNumberD.Text = "";
            mtbAmountD.Text = "";
        }

        void UploadListViewAfterDeposte()
        {
            string[] data;
            string line;
            string info;
            List<string> item = new List<string>();
            StreamReader reader = new StreamReader(FileName);

            listviewTotalBalance.Items.Clear();


            while ((line = reader.ReadLine()) != null)
            {
                data = line.Split('#');
                if (mtbAccountNumberD.Text == data[2])
                {
                    data[9] = Deposite(Convert.ToDecimal(data[9]));
                    isFind = false;
                }
                FillItem(data);
                info = ConvertToString(data);
                item.Add(info);

            }


            reader.Close();


            StreamWriter writer = new StreamWriter(FileName);
            foreach (string St in item)
            {
                writer.WriteLine(St);
            }
            writer.Close();
        }

        void MBankBalance()
        {
            string line;
            decimal AccountBalance;
            StreamReader reader = new StreamReader(FileBalance);
            line = reader.ReadLine().Trim();
            reader.Close();

            AccountBalance = Convert.ToDecimal(line);
            TotalBalanceOfMBank = AccountBalance;
        }

        private void btnDeposite_Click(object sender, EventArgs e)
        {
            if (IsDepositeNull())
                return;

            if (MessageBox.Show("Are you sure ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                MBankBalance();
                GetTotalBalanceOfBank(mtbAmountD, -1);

                if (!IsMoneyEnouthForDeposite())
                    return;

                UploadListViewAfterDeposte();



                VaultMBank();

                ClearDepositeForm();
                MessageBox.Show("Done Successfully ? ", "Deposite", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(" Faild ? ", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        bool IsTransferFormNull()
        {
            if (mtbSender.Text == "" || mtbAmountT.Text == "" || mtbGeter.Text == "")
            {
                MessageBox.Show("Fill Form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        void GetAmountOfTransfer()
        {
            mtbAmountT.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            decimal.TryParse(mtbAmountT.Text, out AmountOfTransfer);

        }

        void ClearTransferForm()
        {
            mtbSender.Text = "";
            mtbAmountT.Text = "";
            mtbGeter.Text = "";
        }
        bool IsMoneyEnouthForTransfer()

        {
            string[] data;
            string line;
            bool isGeterFind = true;
            StreamReader reader = new StreamReader(FileName);
            // bool IsGeterFind = true;
            bool IsSenderFind = true;
            bool ISEnouth = false;



            while ((line = reader.ReadLine()) != null)
            {
                data = line.Split('#');

                if (mtbGeter.Text == data[2])
                {
                    isGeterFind = false;
                }

                if (mtbSender.Text == data[2])
                {
                    IsSenderFind = false;

                    if (AmountOfTransfer < Convert.ToDecimal(data[9]))
                    {
                        ISEnouth = false;
                    }

                    else
                    {
                        ISEnouth = true;
                    }
                }
           

              





            }

            if(ISEnouth)
            {
                MessageBox.Show("Insufficient balance for this transaction ! ", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearTransferForm();
            }

            if (IsSenderFind)
            {
                MessageBox.Show("Sender : " + mtbSender.Text + " Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearTransferForm();
            }

            if (isGeterFind)
            {
                MessageBox.Show("Getter : " + mtbGeter.Text + " Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearTransferForm();
            }
            reader.Close();
            return (isGeterFind || IsSenderFind||ISEnouth);

        }

        void UploadListViewAfterDeposteAfterTransfer()
        {
            string[] data;
            string line;
            string info;
            decimal ClientSender = new decimal();
            decimal ClientGeter = new decimal();
            ClientGeter += AmountOfTransfer;
            List<string> item = new List<string>();
            StreamReader reader = new StreamReader(FileName);

            listviewTotalBalance.Items.Clear();


            while ((line = reader.ReadLine()) != null)
            {
                data = line.Split('#');
                if (mtbSender.Text == data[2])
                {
                    s_Acc = data[2];
                    s_Balance = data[9];

                    ClientSender = Convert.ToDecimal(data[9]);
                    ClientSender -= AmountOfTransfer;
                    data[9] = ClientSender.ToString();
                }

                if (mtbGeter.Text == data[2])
                {
                    d_Acc = data[2];
                    d_Balance = data[9];

                    ClientGeter = Convert.ToDecimal(data[9]);
                    ClientGeter += AmountOfTransfer;
                    data[9] = ClientGeter.ToString();
                }

                FillItem(data);
                info = ConvertToString(data);
                item.Add(info);

            }


            reader.Close();


            StreamWriter writer = new StreamWriter(FileName);
            foreach (string St in item)
            {
                writer.WriteLine(St);
            }
            writer.Close();
        }

        private void btnSubmitT_Click(object sender, EventArgs e)
        {
            if (IsTransferFormNull())
                return;

            if (MessageBox.Show("Are you sure ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                GetAmountOfTransfer();

                if (IsMoneyEnouthForTransfer())
                    return;

                UploadListViewAfterDeposteAfterTransfer();

                SaveTransferLog();

                ClearTransferForm();
                MessageBox.Show("Done Successfully ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void SaveTransferLog()
        {
            StreamWriter writer = new StreamWriter(FileTransferLog, true);
            DateTime now = DateTime.Now;
            string Date = now.ToString("dd/MM/yyyy-hh:mm:ss:tt");
            ListViewItem item = new ListViewItem(Date);
            item.SubItems.Add(s_Acc);
            item.SubItems.Add(d_Acc);
            item.SubItems.Add(AmountOfTransfer.ToString());
            item.SubItems.Add(s_Balance);
            item.SubItems.Add(d_Balance);
            item.SubItems.Add(UserSession.UserName);

            listViewTransferLog.Items.Add(item);
            string Line = Date + "#" + s_Acc + "#" + d_Acc + "#" + AmountOfTransfer.ToString() + "#" + s_Balance + "#" + d_Balance + "#" + UserSession.UserName;
            writer.WriteLine(Line);
            writer.Close();
        }

        void FillTransferLogForm(string[] data)
        {
            ListViewItem item = new ListViewItem(data[0]);
            item.SubItems.Add(data[1]);
            item.SubItems.Add(data[2]);
            item.SubItems.Add(data[3]);
            item.SubItems.Add(data[4]);
            item.SubItems.Add(data[5]);
            item.SubItems.Add(data[6]);
            listViewTransferLog.Items.Add(item);
        }

        void UploadListViewOfTransferLog()
        {
            string line;
            string[] data;
            StreamReader reader = new StreamReader(FileTransferLog, true);
            while ((line = reader.ReadLine()) != null)
            {
                data = line.Split('#');
                FillTransferLogForm(data);
            }
            reader.Close();
        }

        decimal GetTotalBalanceFromFile()
        {
            StreamReader reader = new StreamReader(FileBalance);
            decimal Balance = Convert.ToDecimal(reader.ReadLine());
            reader.Close();
            return Balance;
        }

        void VaultMBank()
        {
            lbTotalBalance.Text = Convert.ToString("R.Y" + GetTotalBalanceFromFile());
            lbAvaliableSpace.Text = (20000000 - GetTotalBalanceFromFile()).ToString();

            if (progressBarBalance.Value < progressBarBalance.Maximum)
            {
                progressBarBalance.Value = Convert.ToInt32(GetTotalBalanceFromFile());




                progressBarBalance.Value += ((Convert.ToInt32(Acc_Balance)) * SignOfDepositeOrWithdraw);
                decimal Value = (((decimal)progressBarBalance.Value / progressBarBalance.Maximum) * 100);
                lbPercent.Text = ((int)Value).ToString() + "%";
                lbPercent.Refresh();

            }

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPageVault_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hhh");
        }
    }


}
