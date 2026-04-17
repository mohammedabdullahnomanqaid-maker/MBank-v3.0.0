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
using System.Drawing.Drawing2D;

namespace Project_Bank_C
{
    public partial class FrmManageUser : Form
    {


        int counter;
        string FileName = "FileUser.txt";
        int Permission;
        byte key=2;


        void isFullPermission()
        {
            if(rbYes.Checked)
            {
                panelPermission4.Enabled = false;
                Permission = -1;
            }
            else
            {
                panelPermission4.Enabled = true;
            }
        }
        void FillListView()
        {
            cbUsersD.Items.Add(mtbUserName.Text);
            cbUsersU.Items.Add(mtbUserName.Text);
            counter++;
            ListViewItem item = new ListViewItem(counter.ToString());
            item.SubItems.Add(mtbUserName.Text);
            item.SubItems.Add(tbFullName.Text);
            item.SubItems.Add(mtbPassword.Text);
            item.SubItems.Add(Convert.ToString(Permission));
            item.SubItems.Add(tbEmail.Text);
            item.SubItems.Add(mtbPhoneNumber.Text);
            item.SubItems.Add(cbCountry.SelectedItem.ToString());
            item.SubItems.Add(cbCity.SelectedItem.ToString());
            item.SubItems.Add(dtpDate.Text);
            listViewShowUser.Items.Add(item);
        }

        void ClearAddForm()
        {
            mtbUserName.Text = "";
            tbFullName.Text = "";
            mtbPassword.Text = "";
            rbNo.Checked = true;
            tbEmail.Text = "";
            mtbPhoneNumber.Text = ";";
            cbCity.SelectedIndex = -1;
            cbCountry.SelectedIndex = 0;
            cbZeroOFPhone.SelectedIndex = 0;
            cbPinCode.SelectedIndex = 0;
            chkManageClient.Checked = false;
            chkManageUser.Checked = false;
            chkCurrencyExchange.Checked = false;
            chkLoginRegister.Checked = false;
            chkTransaction.Checked = false;
            Permission = 0;


             mtbUserName.Focus();
        }

        void ClearDeleteForm()
        {
            lbIDD.Text = "";
            lbUserNameD.Text = "";
            lbFullNameD.Text = "";
            lbPasswordD.Text = "";
            lbEmailD.Text = "";
            lbPhoneD.Text = "";
            lbCountryD.Text = "";
            lbCityD.Text = "";
            lbDateD.Text = "";
            lbPermissionD.Text = "";
            Permission = 0;
            tbUserD.Text = "";

            tbUserD.Focus();
        }

        void ClearUpdateForm()
        {
            mtbUserNameU.Text = "";
            tbFullNameU.Text = "";
            mtbPasswordU.Text = "";
            rbNoU.Checked = true;
            tbEmailU.Text = "";
            mtbPhoneU.Text = "";
            cbCityU.SelectedIndex = -1;
            cbCountryU.SelectedIndex = 0;
            cbZeroU.SelectedIndex = 0;
            cbPinCodeU.SelectedIndex = 0;
            chkManageClientU.Checked = false;
            chkManageUserU.Checked = false;
            chkCurrencyExchangeU.Checked = false;
            chkLoginRegisterU.Checked = false;
            chkTransaction.Checked = false;
            Permission = 0;

            ; mtbUserNameU.Focus();
        }

        string []FillArray()
        {
            string[] info = new string[10];
            info[0] = counter.ToString();
            info[1] = mtbUserName.Text;
            info[2] = tbFullName.Text;
            info[3] =Encrypted(mtbPassword.Text);
           info[4] =Convert.ToString(Permission);
            info[5] = tbEmail.Text;
            info[6] = mtbPhoneNumber.Text;
            info[7] = cbCountry.SelectedItem.ToString();
            info[8] = cbCity.SelectedItem.ToString();
            info[9] = dtpDate.Text;
            return info;
        }

        string ConvertToString(string [] arr)
        {
            string line;
            string seprator="#";
            line = arr[0] + seprator;
            line += arr[1] + seprator;
            line += arr[2] + seprator;
            line += arr[3] + seprator;
            line += arr[4] + seprator;
            line += arr[5] + seprator;
            line += arr[6] + seprator;
            line += arr[7] + seprator;
            line += arr[8] + seprator;
            line += arr[9] + seprator;
            return line;
        }
        void FillFile()
        { 
            string line = ConvertToString(FillArray());
            StreamWriter writer = new StreamWriter(FileName,true);
            writer.WriteLine(line);
            writer.Close();
        }

        void FileListViewFromFile(string []data)
        {
            counter++;
            ListViewItem item = new ListViewItem(data[0]);
            item.SubItems.Add(data[1]);
            cbUsersU.Items.Add(data[1]);
            cbUsersD.Items.Add(data[1]);
            item.SubItems.Add(data[2]);
            item.SubItems.Add(Decrypted(data[3]));
            item.SubItems.Add(data[4]);
            item.SubItems.Add(data[5]);
            item.SubItems.Add(data[6]);
            item.SubItems.Add(data[7]);
            item.SubItems.Add(data[8]);
            item.SubItems.Add(data[9]);
            item.SubItems.Add(data[7]);
            listViewShowUser.Items.Add(item);
        }
        void UploadListView()
        {
            string line;
            string[] data;
            StreamReader reader = new StreamReader(FileName);
        

            listViewShowUser.Items.Clear();
            cbUsersD.Items.Clear();
            cbUsersU.Items.Clear();

            while ((line = reader.ReadLine())!= null)
            {
               
                data = line.Split('#');
                FileListViewFromFile(data);

            }
            reader.Close();

        }

        bool isFileNull()
        {
            if(File.Exists(FileName)&&new FileInfo(FileName).Length>0)
            {
                return true;
            }
            return false;
        }

        string [] AllCity(ComboBox cbCountryGeneral)
        {
            string[] Yemen = { "Sana'a", "Aden", "Taiz", "Al Hudaydah", "Al Mukalla", "Ibb", "Dhamar", "Amran", "Sayyan", "Ash Shihr", "Sahar", "Zabid", "Hajjah", "Bajil", "Dhi as-Sufal", "Rida", "Bait al-Faqih", "Al-Marawi'ah", "Yarim", "Al Bayda", "Abs", "Harad", "Ataq", "Al Mahwit", "Shibam", "Tarim", "Qishn", "Al Ghaydah", "Socotra", "Zinjibar", "Al Hazm", "Ma'rib", "Al Jawf", "Lahij", "Ad Dali'", "Midi", "Mocha" };

            string[] Saudi_Arabia = { "Riyadh", "Jeddah", "Mecca", "Medina", "Dammam", "Hofuf", "Taif", "Tabuk", "Buraydah", "Qatif", "Abha", "Khamis Mushait", "Khobar", "Hail", "Hafar Al-Batin", "Jubail", "Al-Kharj", "Qurayyat", "Najran", "Bisha", "Al Qunfudhah", "Arar", "Sakaka", "Jizan", "Al Bahah", "Dhahran", "Al-Duwadmi", "Sharurah", "Al Majma'ah", "Al-Zulfi", "Yanbu", "Al Lith", "Al-Namas", "Al-Wajh", "Rabigh", "Al-Khafji", "Al-Ula", "Unaizah", "Ar Rass", "Al Badai", "Al Bukayriyah", "Muzahmiyya", "Afif", "Turaif", "Dumat Al-Jandal", "Tubarjal", "Sabya", "Abu Arish", "Samtah", "Badr", "Al-Khurma", "Turabah", "Al-Atwalah" };

            string[] United_Arab_Emirates = { "Abu Dhabi", "Dubai", "Sharjah", "Ajman", "Ras Al Khaimah", "Fujairah", "Al Ain" };

            string[] Egypt = { "Cairo", "Alexandria", "Giza", "Sharm El Sheikh", "Luxor", "Aswan", "Port Said" };

            string[] Jordan = { "Amman", "Zarqa", "Irbid", "Aqaba", "Madaba", "Salt", "Jerash" };

            string[] Kuwait = { "Kuwait City", "Al Ahmadi", "Hawalli", "Salmiya", "Sabah Al Salem", "Jahra" };

            string[] Oman = { "Muscat", "Salalah", "Sohar", "Nizwa", "Sur", "Seeb", "Khasab" };

            string[] Qatar = { "Doha", "Al Wakrah", "Al Khor", "Lusail", "Madinat ash Shamal", "Al Rayyan" };

            string[] Bahrain = { "Manama", "Riffa", "Muharraq", "Hamad Town", "Isa Town", "Sitra" };

            string[] Iraq = { "Baghdad", "Basra", "Mosul", "Erbil", "Najaf", "Karbala", "Kirkuk" };

            string[] Syria = { "Damascus", "Aleppo", "Homs", "Latakia", "Hama", "Tartus", "Deir ez-Zor" };

            string[] Lebanon = { "Beirut", "Tripoli", "Sidon", "Tyre", "Byblos", "Baalbek", "Jounieh" };

            string[] Turkey = { "Istanbul", "Ankara", "Izmir", "Antalya", "Bursa", "Adana", "Gaziantep" };

            string[] Algeria = { "Algiers", "Oran", "Constantine", "Annaba", "Blida", "Batna", "Setif" };

            string[] Morocco = { "Rabat", "Casablanca", "Marrakesh", "Fes", "Tangier", "Agadir", "Meknes" };

            string[] Tunisia = { "Tunis", "Sfax", "Sousse", "Kairouan", "Bizerte", "Gabes", "Monastir" };

            string[] Libya = { "Tripoli", "Benghazi", "Misrata", "Bayda", "Zawiya", "Tobruk", "Zliten" };

            string[] Sudan = { "Khartoum", "Omdurman", "Port Sudan", "Nyala", "Kassala", "Obied", "Wad Madani" };

            string[] United_States = { "New York City", "Los Angeles", "Chicago", "Houston", "Miami", "Washington D.C.", "San Francisco" };

            string[] United_Kingdom = { "London", "Birmingham", "Manchester", "Glasgow", "Liverpool", "Edinburgh", "Belfast" };

            string[] France = { "Paris", "Marseille", "Lyon", "Toulouse", "Nice", "Nantes", "Strasbourg" };

            string[] Germany = { "Berlin", "Munich", "Hamburg", "Frankfurt", "Cologne", "Stuttgart", "Dusseldorf" };

            string[] Italy = { "Rome", "Milan", "Naples", "Florence", "Venice", "Turin", "Palermo" };

            string[] Spain = { "Madrid", "Barcelona", "Valencia", "Seville", "Bilbao", "Malaga", "Zaragoza" };

            string[] China = { "Beijing", "Shanghai", "Guangzhou", "Shenzhen", "Chengdu", "Wuhan", "Hangzhou" };

            string[] Japan = { "Tokyo", "Osaka", "Kyoto", "Yokohama", "Nagoya", "Sapporo", "Fukuoka" };

            string[] South_Korea = { "Seoul", "Busan", "Incheon", "Daegu", "Daejeon", "Gwangju", "Ulsan" };

            string[] India = { "New Delhi", "Mumbai", "Bangalore", "Hyderabad", "Chennai", "Kolkata", "Ahmedabad" };

            string[] Russia = { "Moscow", "Saint Petersburg", "Novosibirsk", "Yekaterinburg", "Kazan", "Nizhny Novgorod", "Sochi" };

            string[] Brazil = { "Brasilia", "Sao Paulo", "Rio de Janeiro", "Salvador", "Fortaleza", "Belo Horizonte", "Curitiba" };

            string[] City=new string[1];

            switch (cbCountryGeneral.SelectedItem.ToString())
            {
                case "Yemen":
                    City = Yemen;
                    break;

                case "Saudi Arabia":
                    City = Saudi_Arabia;
                    break;

                case "Egypt":
                    City = Egypt;
                    break;

                case "United Arab Emirates":
                    City = United_Arab_Emirates;
                    break;

                case "Jordan":
                    City = Jordan;
                    break;

                case "Kuwait":
                    City = Kuwait;
                    break;

                case "Oman":
                    City = Oman;
                    break;

                case "Qatar":
                    City = Qatar;
                    break;

                case "Bahrain":
                    City = Bahrain;
                    break;

                case "Iraq":
                    City = Iraq;
                    break;

                case "Syria":
                    City = Syria;
                    break;

                case "Lebanon":
                    City = Lebanon;
                    break;

                case "Turkey":
                    City = Turkey;
                    break;

                case "Morocco":
                    City = Morocco;
                    break;

                case "Algeria":
                    City = Algeria;
                    break;

                case "Tunisia":
                    City = Tunisia;
                    break;

                case "Libya":
                    City = Libya;
                    break;

                case "Sudan":
                    City = Sudan;
                    break;

                case "United States":
                    City = United_States;
                    break;

                case "Brazil":
                    City = Brazil;
                    break;

                case "Russia":
                    City = Russia;
                    break;

                case "India":
                    City = India;
                    break;

                case "South Korea":
                    City = South_Korea;
                    break;

                case "Japan":
                    City = Japan;
                    break;

                case "China":
                    City = China;
                    break;

                case "Spain":
                    City = Spain;
                    break;

                case "Italy":
                    City = Italy;
                    break;

                case "Germany":
                    City = Germany;
                    break;

                case "France":
                    City = France;
                    break;

                case "United Kingdom":
                    City = United_Kingdom;
                    break;

            }
            return City;

        }

        void SelectedCity()
        {
            string[] City = AllCity(cbCountry);

            foreach (string town in City)
            {
                cbCity.Items.Add(town);
            }

        }

        void SelectedCityU()
        {
            string[] City = AllCity(cbCountryU);
            cbCityU.Items.Clear();
            foreach (string town in City)
            {
                cbCityU.Items.Add(town);
            }

        }
        
        void SelectPinCodeOfPhoneNumber()
        {
            mtbPhoneNumber.Mask = "(" + cbPinCode.Items[cbCountry.SelectedIndex].ToString() + ")" + cbZeroOFPhone.Items[cbCountry.SelectedIndex].ToString();
        }
     
        void SelectPinCodeOfPhoneNumberU()
        {
            mtbPhoneU.Mask = "(" + cbPinCodeU.Items[cbCountryU.SelectedIndex].ToString() + ")" + cbZeroU.Items[cbCountryU.SelectedIndex].ToString();
        }

        bool isNull()
        {
            if (mtbUserName.Text == ""||tbFullName.Text==""
                ||tbEmail.Text==""||mtbPassword.Text==""||mtbPhoneNumber.Text==""||cbCity.SelectedIndex==-1
                ||cbCountry.SelectedIndex==-1)
            {
                MessageBox.Show("Fill Form !","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        bool isNullU()
        {
            if (mtbUserNameU.Text == "" || tbFullNameU.Text == ""
                || tbEmailU.Text == "" || mtbPasswordU.Text == "" || mtbPhoneU.Text == "" || cbCityU.SelectedIndex == -1
                || cbCountryU.SelectedIndex == -1)
            {
                MessageBox.Show("Fill Form !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        bool IsValidUserName()
        {
            StreamReader reader = new StreamReader(FileName);
            string line;
            string[] data;

            while((line=reader.ReadLine())!=null)
            {
                data = line.Split('#');
                if(data[1]==mtbUserName.Text)
                {
                    
                    reader.Close();
                    errorProvider1.SetError(mtbUserName, "this username already use ");
                    MessageBox.Show("Unvalid Username ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }

            }
            reader.Close();
            errorProvider1.SetError(mtbUserName, "");

            return true;
        }

        bool IsValidUserNameU()
        {
            StreamReader reader = new StreamReader(FileName);
            string line;
            string[] data;

            while ((line = reader.ReadLine()) != null)
            {
                data = line.Split('#');
                if(data[1]==lbUserName.Text)
                {
                    reader.Close();
                    return true;
                }
                if (data[1] == mtbUserNameU.Text)
                {

                    reader.Close();
                    errorProvider1.SetError(mtbUserNameU, "this username already use ");
                    MessageBox.Show("Unvalid Username ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }

            }
            reader.Close();
            errorProvider1.SetError(mtbUserNameU, "");

            return true;
        }
        bool IsValidPassword()
        {
            StreamReader reader = new StreamReader(FileName);
            string line;
            string[] data;

            while ((line = reader.ReadLine()) != null)
            {
                data = line.Split('#');
                if (Decrypted(data[3]) == mtbPassword.Text)
                {

                    reader.Close();
                    errorProvider1.SetError(mtbPassword, "this Password already use ");
                    MessageBox.Show("Unvalid Password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }

            }
            reader.Close();
            errorProvider1.SetError(mtbPassword, "");

            return true;
        }

        bool IsValidPasswordU()
        {
            StreamReader reader = new StreamReader(FileName);
            string line;
            string[] data;

            while ((line = reader.ReadLine()) != null)
            {
                data = line.Split('#');
                if (Decrypted(data[3]) == lbPassword.Text)
                {
                    reader.Close();
                    return true;
                }
                if (Decrypted(data[3]) == mtbPasswordU.Text)
                {

                    reader.Close();
                    errorProvider1.SetError(mtbPasswordU, "this Password already use ");
                    MessageBox.Show("Unvalid Password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }

            }
            reader.Close();
            errorProvider1.SetError(mtbPasswordU, "");

            return true;
        }

        string Encrypted(string word)
        {
            string newWord="";

            for(int i=0;i<word.Length;i++)
            {
                newWord+= Convert.ToChar(Convert.ToByte(word[i])+key);
            }

            return newWord;
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

        void FillUpdateCard(string []data)
        {
            lbID.Text = data[0];
            lbUserName.Text = data[1];
            lbFullName.Text = data[2];
            lbPassword.Text =Decrypted(data[3]);
            lbPermission.Text = data[4];
            lbEmail.Text = data[5];
            lbPhoneU.Text = data[6];
            lbCountry.Text = data[7];
            lbCity.Text = data[8];
            lbDateRegister.Text = data[9];

        }

        string[] UpdateInfo()
        {
            string[] data=new string[10];
            data[0] = counter.ToString();
            data[1] = mtbUserNameU.Text;
            data[2] = tbFullNameU.Text;
            data[3] =Encrypted(mtbPasswordU.Text);
            data[4] = Permission.ToString();
            data[5] = tbEmailU.Text;
            data[6] = mtbPhoneU.Text;
            data[7] = cbCountryU.SelectedItem.ToString();
            data[8] = cbCityU.SelectedItem.ToString();
            data[9] = dtpDateU.Text;
            return data;
        }

        void FillDeleteCard(string[] data)
        {
            lbIDD.Text =         data[0];
            lbUserNameD.Text =   data[1];
            lbFullNameD.Text =   data[2];
            lbPasswordD.Text =   data[3];
            lbPermissionD.Text = data[4];
            lbEmailD.Text =      data[5];
            lbPhoneD.Text =      data[6];
            lbCountryD.Text =    data[7];
            lbCityD.Text =       data[8];
            lbDateD.Text =       data[9];

        }

        string convertToString(string []Data)
        {
            string line;
            string seprator = "#";

            line =Data[0] +seprator;
            line += Data[1] + seprator;
            line += Data[2] + seprator;
            line +=Data[3] + seprator;
            line += Data[4] + seprator;
            line += Data[5] + seprator;
            line += Data[6] + seprator;
            line += Data[7] + seprator;
            line += Data[8] + seprator;
            line += Data[9] + seprator;

            return line;
        }

        void SearchUserForUpdateCard()
        {
            StreamReader reader = new StreamReader(FileName);
            string []data;
            string line;
            bool isFind = true;

            while((line=reader.ReadLine())!=null)
            {
                data = line.Split('#');
                if(tbUsersU.Text==data[1])
                {
                 FillUpdateCard(data);
                    isFind = false;
                }

            }
            reader.Close();
            if (isFind)
                MessageBox.Show($"{tbUsersU.Text} Not Found", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void SearchUserForUpdate()
        {
            if (MessageBox.Show("Are you sure ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                StreamReader reader = new StreamReader(FileName);
                string[] data;
                string line;
                List<string> Info = new List<string>();
                Info.Clear();
                string NewInfo;


                while ((line = reader.ReadLine()) != null)
                {
                    data = line.Split('#');
                 
                    if (tbUsersU.Text == data[1])
                    {
                        data = UpdateInfo();
                        FillUpdateCard(data);

                    }
                    NewInfo = convertToString(data);
                    Info.Add(NewInfo);

                }
                reader.Close();

                StreamWriter writer = new StreamWriter(FileName, false);

                foreach (string St in Info)
                {
                    writer.WriteLine(St);
                }

                writer.Close();

                UploadListView();
                MessageBox.Show("Updated Succesfully ", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Updated Faild ", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbUsersU.Text = "";
            }
        }

        void SearchUserForDelete()
        {
            if (MessageBox.Show("Are you sure ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cbUsersD.Items.Clear();

                StreamReader reader = new StreamReader(FileName);
                string[] data;
                string line;
                List<string> Info = new List<string>();
                Info.Clear();
                string NewInfo;


                while ((line = reader.ReadLine()) != null)
                {
                    data = line.Split('#');

                

                    if (tbUserD.Text != data[1])
                    {
                        NewInfo = convertToString(data);
                        Info.Add(NewInfo);

                    }
             

                }
                reader.Close();

                StreamWriter writer = new StreamWriter(FileName, false);

                foreach (string St in Info)
                {
                    writer.WriteLine(St);
                }

                writer.Close();

                UploadListView();
                MessageBox.Show("Deleted Succesfully ", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(" Faild ", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbUserD.Text = "";
            }
        }


        void SearchUserForShowDeleteCard()
        {
            StreamReader reader = new StreamReader(FileName);
            string[] data;
            string line;
            bool isfind = true;

            while ((line = reader.ReadLine()) != null)
            {
                data = line.Split('#');

                if (tbUserD.Text == "admin")
                {
                    MessageBox.Show("Admin can not be delete ", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnDelete.BackColor = Color.WhiteSmoke;
                    btnDelete.Enabled = false;
                    reader.Close();
                    return;
                }
                if (tbUserD.Text == data[1])
                {
                    FillDeleteCard(data);
                    btnDelete.Enabled = true;
                    btnDelete.BackColor = Color.FromArgb(255, 128, 128);


                    isfind = false;
                }
            }
            reader.Close();
            if (isfind)
            {
                MessageBox.Show($"{tbUserD.Text} Not Found", "faild", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbUserD.Text = "";
            }
        }
        public FrmManageUser()
        {
            InitializeComponent();
        }

        private void btnSubmit_MouseEnter(object sender, EventArgs e)
        {
            btnSubmit.BackColor = Color.Blue;
        }

        private void btnSubmit_MouseLeave(object sender, EventArgs e)
        {
            btnSubmit.BackColor = Color.CornflowerBlue;
        }

        private void btnUpdate_MouseEnter(object sender, EventArgs e)
        {
            btnUpdate.BackColor = Color.Blue;
        }

        private void btnUpdate_MouseLeave(object sender, EventArgs e)
        {
            btnUpdate.BackColor = Color.CornflowerBlue;
        }

        private void btnDelete_MouseEnter(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.CornflowerBlue;

        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.Red;

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (isNull())
                return;

            if (isFileNull())
            {

                if (!IsValidUserName())
                    return;

                if (!IsValidPassword())
                    return;
            }

            FillListView();
            FillFile();
            ClearAddForm();
        }

        private void rbYes_CheckedChanged(object sender, EventArgs e)
        {
            isFullPermission();
        }

        private void rbNo_CheckedChanged(object sender, EventArgs e)
        {
            isFullPermission();
        }

        private void FrmManageUser_Load(object sender, EventArgs e)
        {
           // panelSearch.BackColor = Color.FromArgb(26, 35, 58);
            lbUserFullAdd.Text = UserSession.UserName + " : " + UserSession.FullName;
            lbUserFullShow.Text = UserSession.UserName + " : " + UserSession.FullName;
            lbUserFullU.Text = UserSession.UserName + " : " + UserSession.FullName;
            lbUserFullD.Text = UserSession.UserName + " : " + UserSession.FullName;
            this.BackColor = Color.FromArgb(26, 35, 58);
           if( isFileNull())
            UploadListView();
        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectPinCodeOfPhoneNumber();
        }

        private void cbCity_DropDown(object sender, EventArgs e)
        {
            if(cbCountry.SelectedIndex!=-1)
            {
                cbCity.Items.Clear();
                SelectedCity();
            }

        }

        private void chkManageClient_CheckedChanged(object sender, EventArgs e)
        {
            if(chkManageClient.Checked)
            Permission += 1;

            else
            {
                Permission -= 1;

            }
        }

        private void chkLoginRegister_CheckedChanged(object sender, EventArgs e)
        {
            if(chkLoginRegister.Checked)
            Permission += 8;
            else
            {
                Permission -= 8;

            }
        }

        private void chkManageUser_CheckedChanged(object sender, EventArgs e)
        {
            if (chkManageUser.Checked)
                Permission += 2;
            else
            {
                Permission -= 2;

            }
        }

        private void chkCurrencyExchange_CheckedChanged(object sender, EventArgs e)
        {
            if(chkCurrencyExchange.Checked)
            Permission += 16;
            else
            {
                Permission -= 16;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
               

            if (isNullU())
                return;

            if (isFileNull())
            {
             

                if (!IsValidUserNameU())
                    return;

                if (!IsValidPasswordU())
                    return;
            }
            cbUsersU.Items.Clear();
            SearchUserForUpdate();
            ClearUpdateForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SearchUserForDelete();
            ClearDeleteForm();
        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
          

        }

        private void pictureBox3_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath gp = new GraphicsPath();

            gp.AddEllipse(0, 0, pictureBox3.Width-1, pictureBox3.Height - 1);
            pictureBox3.Region = new Region(gp);
        }

    

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SearchUserForUpdateCard();

        }

        private void cbCityU_DropDown(object sender, EventArgs e)
        {
            SelectedCityU();
        }

        private void cbCountryU_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectPinCodeOfPhoneNumberU();
        }

        private void rbYesU_CheckedChanged(object sender, EventArgs e)
        {
            panelPermission4U.Enabled = false;
            chkManageClientU.Checked = false;
            chkManageUserU.Checked = false;
            chkCurrencyExchangeU.Checked = false;
            chkLoginRegisterU.Checked = false;
        }

        private void rbNoU_CheckedChanged(object sender, EventArgs e)
        {
            panelPermission4U.Enabled = true;
   

        }

        private void chkManageUserU_CheckedChanged(object sender, EventArgs e)
        {
            if(chkManageUserU.Checked)
            {
                Permission += 2;
            }
            else
            {
                Permission -= 2;
            }
        }

        private void chkManageClientU_CheckedChanged(object sender, EventArgs e)
        {
            if (chkManageClientU.Checked)
            {
                Permission += 1;
            }
            else
            {
                Permission -= 1;
            }
        }

        private void chkLoginRegisterU_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLoginRegisterU.Checked)
            {
                Permission += 8;
            }
            else
            {
                Permission -= 8;
            }
        }

        private void chkCurrencyExchangeU_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCurrencyExchangeU.Checked)
            {
                Permission += 16;
            }
            else
            {
                Permission -= 16;
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            SearchUserForShowDeleteCard();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTransaction.Checked)
                Permission += 4;
            else
            {
                Permission -= 4;
            }
        }

        private void chkTransactionU_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTransactionU.Checked)
                Permission += 4;
            else
            {
                Permission -= 4;
            }
        }

        private void cbUsersU_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbUsersU.Text = cbUsersU.SelectedItem.ToString();
        }

        private void cbUsersD_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbUserD.Text = cbUsersD.SelectedItem.ToString();
        }
    }
}
