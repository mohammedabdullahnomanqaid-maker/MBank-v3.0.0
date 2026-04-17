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
    public partial class FrmBankSystem : Form
    {
        string FileName = "MClient.text";

        string FileBalance = "Balance.txt";
    
            
      



        int counter = 0;
        byte key = 2;
        string[] password = new string[100];
        string[] accountNumber = new string[100];
        List<string[]> arrSv = new List<string[]>();
        decimal Acc_Balance;


        void FillForDelete(string[] arr)
        {
            lbID.Text = arr[0];
            lbName.Text = arr[1];
            lbAccountNumber.Text = arr[2];
            lbPhone.Text = arr[3];
            lbEmail.Text = arr[4];
            lbAge.Text = arr[5];
            lbCountry.Text = arr[6];
            lbGender.Text = arr[7];
            lbPassword.Text = arr[8];
            lbBalanceD.Text = arr[9];
            lbDateRegister.Text = arr[10];

        }

        void FillForUpdate(string[] arr)
        {
            lbIDU.Text = arr[0];
            lbNameU.Text = arr[1];
            lbAccountNumberU.Text = arr[2];
            lbPhoneU.Text = arr[3];
            lbEmailU.Text = arr[4];
            lbAgeU.Text = arr[5];
            lbCountryU.Text = arr[6];
            lbGenderU.Text = arr[7];
            lbPasswordU.Text =Decrypted(arr[8]);
            lbBalanceU.Text = arr[9];
            lbDateRegisterU.Text = arr[10];
            mtbAccountNumberU.Text= arr[2];
            mtbPasswordU.Text =Decrypted(arr[8]);
            mtbBalance.Text = arr[9];



        }

        string convertToString(string[] arr)
        {
            string seprator = "#";
            string line;
            line = arr[0]+ seprator;
            line+= arr[1] + seprator;
            line += arr[2] + seprator;
            line += arr[3] + seprator;
            line += arr[4] + seprator;
            line += arr[5] + seprator;
            line += arr[6] + seprator;
            line += arr[7] + seprator;
            line += arr[8] + seprator;
            line += arr[9] + seprator;
         //   line += lbBalanceU.Text + seprator;
            line += arr[10];

            return line;

        }

        bool IsFileNull()
        {
            if (File.Exists(FileName) && new FileInfo(FileName).Length > 0)
            {
                return true;
            }
            return false;
        }

        void CardClear()
        {
            mtbClient.Clear();
            lbID.Text = "";
            lbName.Text = "";
            lbAccountNumber.Text = "";
            lbPhone.Text = "";
            lbEmail.Text = "";
            lbAge.Text = "";
            lbCountry.Text = "";
            lbGender.Text = "";
            lbPassword.Text = "";
            lbDateRegister.Text = "";
        }

        void BoxClear()
        {
            mtbClient.Clear();
            tbNameU.Text = "";
            mtbAccountNumberU.Text = "";
            mtbPhoneU.Text = "";
            tbEmailU.Text = "";
            cbMonthU.SelectedIndex = -1;
            cbMonthU.SelectedIndex = -1;
            cbGenderU.SelectedIndex = -1;
            cbAccountNumberU.SelectedIndex = -1;
            cbZeroU.SelectedIndex = 0;
            cbPinCodeU.SelectedIndex = 0;
            cbCountryU.SelectedIndex = 0;

            mtbClientU.Text = "";
            mtbDayU.Text = "";
            mtbYearU.Text = "";
            mtbPasswordU.Text = "";
            mtbBalance.Text = "";
        }

            void CardUpdate(string [] arr)
        {
            mtbClient.Clear();
            lbIDU.Text = arr[0];
            lbNameU.Text = arr[1];
            lbAccountNumberU.Text = arr[2];
            lbPhoneU.Text = arr[3];
            lbEmailU.Text = arr[4];
            lbAgeU.Text = arr[5];
            lbCountryU.Text = arr[6];
            lbGenderU.Text = arr[7];
            lbPasswordU.Text =Decrypted(arr[8]);
            lbDateRegisterU.Text = arr[9];
        }

        void SaveToFile()
        {
            StreamWriter writer = new StreamWriter(FileName, true);



            int Day = Convert.ToInt32(mtbDay.Text);
            int year = Convert.ToInt32(mtbYear.Text);
            int month = Convert.ToInt32(cbMonth.SelectedIndex.ToString());

            DateTime BirtDay = new DateTime(year, month + 1, Day);
            DateTime Today = DateTime.Today;

            int age = Today.Year - BirtDay.Year;


            string line;
            string seprator = "#";

            line = counter.ToString() + seprator;
            line += tbName.Text + seprator;
            line += mtbAccountNumber.Text + seprator;
            line += mtbPhoneNumber.Text + seprator;
            line += tbEmail.Text + seprator;
            line += Convert.ToString(age.ToString() + seprator);
            line += cbCountry.SelectedItem.ToString() + seprator;
            line += cbGender.SelectedItem.ToString() + seprator;
            line += Ecrypted(mtbPassword.Text) + seprator;
            line += Convert.ToString(Acc_Balance)+ seprator;
            line += dateTimePicker1.Text;

            writer.WriteLine(line, true);

            writer.Close();


        }

        string SaveToFileU()
        {



            int Day = Convert.ToInt32(mtbDayU.Text);
            int year = Convert.ToInt32(mtbYearU.Text);
            int month = Convert.ToInt32(cbMonthU.SelectedIndex.ToString());

            DateTime BirtDay = new DateTime(year, month + 1, Day);
            DateTime Today = DateTime.Today;

            int age = Today.Year - BirtDay.Year;


            string line;
            string seprator = "#";

            line = counter.ToString() + seprator;
            line += tbNameU.Text + seprator;
            line += mtbAccountNumberU.Text + seprator;
            line += mtbPhoneU.Text + seprator;
            line += tbEmailU.Text + seprator;
            line += Convert.ToString(age.ToString() + seprator);
            line += cbCountryU.SelectedItem.ToString() + seprator;
            line += cbGenderU.SelectedItem.ToString() + seprator;
            line += Ecrypted(mtbPasswordU.Text) + seprator;
            line += lbBalanceU.Text + seprator;
            line += dateTimePicker1.Text;

            return line;



        }



        string SaveAfterDelete(string[] arr)
        {




            string line;
            string seprator = "#";

            line = arr[0] + seprator;
            line += arr[1] + seprator;
            line += arr[2] + seprator;
            line += arr[3] + seprator;
            line += arr[4] + seprator;
            line += arr[5] + seprator;
            line += arr[6] + seprator;
            line += arr[7] + seprator;
            line += Ecrypted(arr[8]) + seprator;
            line += arr[9] + seprator;
            line += arr[10];


            return line;

        }

        void LoadFromFile()
        {
            cbClient.Items.Clear();
            cbAccountNumberU.Items.Clear();

            StreamReader reader = new StreamReader(FileName);
            string[] data = new string[100];
            string line;

            counter = 0;
            while ((line = reader.ReadLine()) != null)
            {
                counter++;
                data = line.Split('#');

                FillItem(data);

            }


            reader.Close();
        }

        string Ecrypted(string password)
        {
            string tempPassword = "";
            for (int i = 0; i < password.Length; i++)
            {
                tempPassword += Convert.ToChar(Convert.ToInt32(password[i]) + key);
            }
            return tempPassword;
        }

        string Decrypted(string password)
        {
            string tempPassword = "";
            for (int i = 0; i < password.Length; i++)
            {
                tempPassword += Convert.ToChar(Convert.ToInt32(password[i]) - key);
            }
            return tempPassword;
        }

        public FrmBankSystem()
        {
            InitializeComponent();

        }



        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

            mtbPhoneNumber.Mask = "(" + cbPinCode.Items[cbCountry.SelectedIndex].ToString() + ")" + cbZero.Items[cbCountry.SelectedIndex].ToString();

        }

        void ResetForm()
        {
            tbName.Clear();
            mtbPassword.Clear();
            mtbAccountNumber.Clear();

            cbZero.SelectedIndex = 0;
            cbPinCode.SelectedIndex = 0;
            cbCountry.SelectedIndex = 0;

            mtbPhoneNumber.Clear();
            tbEmail.Clear();
            mtbDay.Clear();
            cbMonth.SelectedIndex = -1;
            mtbYear.Clear();
            cbGender.SelectedIndex = -1;
            mtbAccountBalance.Clear();
            tbName.Focus();

        }

        void FillItem(string[] data)
        {


            ListViewItem item = new ListViewItem(data[0].ToString());

            item.SubItems.Add(data[1].ToString());
            item.SubItems.Add(data[2].ToString());
            accountNumber[counter - 1] = data[2].ToString();
            cbClient.Items.Add(accountNumber[counter - 1]);
            cbAccountNumberU.Items.Add(accountNumber[counter - 1]);

            item.SubItems.Add(data[3].ToString());
            item.SubItems.Add(data[4].ToString());
            item.SubItems.Add(data[5].ToString());
            item.SubItems.Add(data[6].ToString());
            item.SubItems.Add(data[7].ToString());
            password[counter - 1] = Decrypted(data[8]).ToString();
            item.SubItems.Add(Decrypted(data[8]).ToString());
            item.SubItems.Add(data[9].ToString());
            item.SubItems.Add(data[10].ToString());

            listView1.Items.Add(item);
            ResetForm();

        }
        bool isValidPassword()
        {

            for (int i = 0; i < password.Length; i++)
            {


                if (mtbPassword.Text == password[i])
                {
                    mtbPassword.Focus();
                    MessageBox.Show("Unvaild Password ! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    errorProvider1.SetError(mtbPassword, "this password already used ! ");
                    return true;
                }
                else
                {
                    errorProvider1.SetError(mtbPassword, "");
                    tbName.Focus();
                }

            }
            return false;

        }

        bool isValidPasswordForUpdate()
        {

            for (int i = 0; i < password.Length; i++)
            {
                if(lbPasswordU.Text==password[i])
                {
                    errorProvider1.SetError(mtbPasswordU, "");
                    tbNameU.Focus();
                    return false;
                }

                if (mtbPasswordU.Text == password[i])
                {
                    mtbPasswordU.Focus();
                    errorProvider1.SetError(mtbPasswordU, "this password already used ! ");
                    return true;
                }
                else
                {
                    errorProvider1.SetError(mtbPasswordU, "");
                    tbNameU.Focus();
                }

            }
            return false;

        }

        bool isValidAccountNumber()
        {

            for (int i = 0; i < accountNumber.Length; i++)
            {

            

                if (mtbAccountNumber.Text == accountNumber[i])
                {
                    mtbAccountNumber.Focus();
                    MessageBox.Show("Unvaild AccountNumber ! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    errorProvider1.SetError(mtbAccountNumber, "this accountNumber already used ! ");
                    return true;
                }
                else
                {
                    errorProvider1.SetError(mtbAccountNumber, "");
                    tbName.Focus();
                }

            }
            return false;

        }

        bool isValidAccountNumberForUpdate()
        {

            for (int i = 0; i < accountNumber.Length; i++)
            {

                if(lbAccountNumberU.Text==accountNumber[i])
                {
                    errorProvider1.SetError(mtbAccountNumberU, "");
                    tbNameU.Focus();
                    return false;
                }

                if (mtbAccountNumberU.Text == accountNumber[i])
                {
                    mtbAccountNumberU.Focus();
                    errorProvider1.SetError(mtbAccountNumberU, "this accountNumber already used ! ");
                    return true;
                }
                else
                {
                    errorProvider1.SetError(mtbAccountNumberU, "");
                    tbNameU.Focus();
                }

            }
            return false;

        }

        bool IsFullAllTextBox()
        {
            if (string.IsNullOrWhiteSpace(tbName.Text) || string.IsNullOrWhiteSpace(mtbAccountNumber.Text) ||
                string.IsNullOrWhiteSpace(mtbDay.Text) || string.IsNullOrWhiteSpace(mtbYear.Text) ||
                string.IsNullOrWhiteSpace(tbEmail.Text) || string.IsNullOrWhiteSpace(mtbPhoneNumber.Text) ||
                string.IsNullOrWhiteSpace(mtbPassword.Text) || (cbGender.SelectedIndex == -1) || cbMonth.SelectedIndex == -1)
            {
                return true;
            }
            return false;


        }

        bool IsFullAllTextBoxForUpdate()
        {
            if (string.IsNullOrWhiteSpace(tbNameU.Text) || string.IsNullOrWhiteSpace(mtbAccountNumberU.Text) ||
                string.IsNullOrWhiteSpace(mtbDayU.Text) || string.IsNullOrWhiteSpace(mtbYearU.Text) ||
                string.IsNullOrWhiteSpace(tbEmailU.Text) || string.IsNullOrWhiteSpace(mtbPhoneU.Text) ||
                string.IsNullOrWhiteSpace(mtbPasswordU.Text) || (cbGenderU.SelectedIndex == -1) || cbMonthU.SelectedIndex == -1)
            {
                return true;
            }
            return false;


        }

        void GetAccountBalance()
        {
            decimal TotalBalance=new decimal();
            
            StreamReader reader = new StreamReader(FileBalance);
           TotalBalance=Convert.ToDecimal(reader.ReadLine().Trim());
            reader.Close();

           mtbAccountBalance.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            if(decimal.TryParse(mtbAccountBalance.Text,out  Acc_Balance))



           TotalBalance = TotalBalance - Acc_Balance;

            StreamWriter writer = new StreamWriter(FileBalance);
            writer.WriteLine(TotalBalance.ToString());
            writer.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (IsFullAllTextBox())
            {
                MessageBox.Show("Fill all box ! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


            if (isValidPassword())
            {
                return;
            }

            if (isValidAccountNumber())
            {
                return;
            }

            counter++;
            GetAccountBalance();
            SaveToFile();
            listView1.Items.Clear();
            LoadFromFile();
        }

        void isAdmin()
        {
            if (UserSession.UserName != "admin")
            {
                mtbAccountBalance.Text = "0";

                mtbAccountBalance.Enabled = false;
            }
            else
            {

            }
        }

        private void FrmBankSystem_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(26, 35, 58);
            isAdmin();
            lbUserFullAdd.Text = UserSession.UserName + " : " + UserSession.FullName;
            lbUserFullShow.Text = UserSession.UserName + " : " + UserSession.FullName;
            lbUserFullU.Text = UserSession.UserName + " : " + UserSession.FullName;
            lbUserFullD.Text = UserSession.UserName + " : " + UserSession.FullName;
            if (IsFileNull())
            LoadFromFile();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.CornflowerBlue;
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.Red;
        }

        private void button1_MouseEnter_1(object sender, EventArgs e)
        {
            btnShow.BackColor = Color.Blue;
        }

        private void btnShow_MouseLeave(object sender, EventArgs e)
        {
            btnShow.BackColor = Color.CornflowerBlue;
        }

        private void btnSubmit_MouseEnter(object sender, EventArgs e)
        {
            btnSubmit.BackColor = Color.Blue;
        }

        private void btnSubmit_MouseLeave(object sender, EventArgs e)
        {
            btnSubmit.BackColor = Color.CornflowerBlue;
        }

        private void button1_MouseEnter_2(object sender, EventArgs e)
        {
            btnUpadate.BackColor = Color.Blue;
        }

        private void btnUpadate_MouseLeave(object sender, EventArgs e)
        {
            btnUpadate.BackColor = Color.CornflowerBlue;
        }

        private void btnShowU_MouseEnter(object sender, EventArgs e)
        {
            btnShowU.BackColor = Color.Blue;

        }

        private void btnShowU_MouseLeave(object sender, EventArgs e)
        {
            btnShowU.BackColor = Color.CornflowerBlue;

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            bool isCheck = true;
            string[] data;
            string line;
            StreamReader reader = new StreamReader(FileName);

         

            while ((line = reader.ReadLine()) != null)
            {
                data = line.Split('#');
                if (data[2] == mtbClient.Text)
                {
                    FillForDelete(data);
                    isCheck = false;
                }

            }
            if (isCheck)
            {
                MessageBox.Show("Client with " + mtbClient.Text + " Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtbClient.Clear();

            }
            reader.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure !", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                cbAccountNumberU.Items.Clear();
                cbClient.Items.Clear();
                arrSv.Clear();
                string[] data = new string[100];
                string line;
                StreamReader reader = new StreamReader(FileName);
                while ((line = reader.ReadLine()) != null)
                {
                    data = line.Split('#');
                    if (mtbClient.Text == data[2])
                        continue;

                    arrSv.Add(data);
                }
                reader.Close();


                StreamWriter writer = new StreamWriter(FileName, false);
                listView1.Items.Clear();

                foreach (string[] item in arrSv)
                {
                    line = SaveAfterDelete(item);
                    writer.WriteLine(line);
                    FillItem(item);
                }

                writer.Close();
                CardClear();

            }

        }

        private void btnShowU_Click(object sender, EventArgs e)
        {
            bool isCheck = true;
            string[] data;
            string line;
            StreamReader reader = new StreamReader(FileName);

            if (reader.EndOfStream)
            {
                MessageBox.Show("Client with " + mtbClientU.Text + " Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtbClientU.Clear();
            }

            while ((line = reader.ReadLine()) != null)
            {
                data = line.Split('#');
                if (data[2] == mtbClientU.Text)
                {
                    FillForUpdate(data);
                    isCheck = false;
                }

            }
            if (isCheck)
            {
                MessageBox.Show("Client with " + mtbClientU.Text + " Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtbClientU.Clear();

            }
            reader.Close();
        }

        void FillCardForUpdate()
        {
            List<string> Save = new List<string>();

            string line;
            string[] data;
            arrSv.Clear();
            string info;
            StreamReader reader = new StreamReader(FileName);
            while ((line = reader.ReadLine()) != null)
            {
                data = line.Split('#');
                info = convertToString(data);
                if (mtbClientU.Text == data[2])
                {
                    info = SaveToFileU();
                    data = info.Split('#');

                    CardUpdate(data);
                }
                Save.Add(info);
            }
            reader.Close();

            StreamWriter writer = new StreamWriter(FileName, false);

            foreach (string LINE in Save)
            {
                writer.WriteLine(LINE, true);
            }
            writer.Close();
        }
        private void btnUpadate_Click(object sender, EventArgs e)
        {

            if (IsFullAllTextBoxForUpdate())
            {
                MessageBox.Show("Fill all box ! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }



            if (isValidPasswordForUpdate())
            {
                return;
            }

            if (isValidAccountNumberForUpdate())
            {
                return;
            }

            FillCardForUpdate();
            listView1.Items.Clear();
            LoadFromFile();
            BoxClear();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbCountryU_SelectedIndexChanged(object sender, EventArgs e)
        {
            mtbPhoneU.Mask = "(" + cbPinCodeU.Items[cbCountryU.SelectedIndex].ToString() + ")" + cbZeroU.Items[cbCountryU.SelectedIndex].ToString();

        }

        private void cbAccountNumberU_SelectedIndexChanged(object sender, EventArgs e)
        {
            mtbClientU.Text = cbAccountNumberU.SelectedItem.ToString();
        }

        private void cbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            mtbClient.Text = cbClient.SelectedItem.ToString();
        }

        private void mtbClientU_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
