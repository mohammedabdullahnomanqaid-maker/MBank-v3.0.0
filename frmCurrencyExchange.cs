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
    public partial class frmCurrencyExchange : Form
    {
        int ImageCounter;
        string FileName = "Currency.txt";
        public frmCurrencyExchange()
        {
            InitializeComponent();
        }

       void FillItem(string[] data)
        {
            //if (ImageCounter == 23)
            //    ImageCounter = 0;

            ListViewItem item = new ListViewItem();
            item.ImageIndex = ImageCounter;

            ImageCounter++;
            item.SubItems.Add(data[0]);

            item.SubItems.Add(data[1]);
            item.SubItems.Add(data[2]);
            item.SubItems.Add(data[3]);
            item.SubItems.Add(data[4]);
            item.SubItems.Add(data[5]);
            listViewCurrency.Items.Add(item);
        }

        void FillItemOfSearch(string[] data)
        {
            ListViewItem item = new ListViewItem();
            item.ImageIndex = ImageCounter;

            item.SubItems.Add(data[0]);

            item.SubItems.Add(data[1]);
            item.SubItems.Add(data[2]);
            item.SubItems.Add(data[3]);
            item.SubItems.Add(data[4]);
            item.SubItems.Add(data[5]);
            listViewResualtOfSearch.Items.Add(item);
            ImageCounter = 0;
        }

        void UploadListViewOfCurrency()
        {
            string[] data;
            string line;




            StreamReader reader = new StreamReader(FileName);
            while ((line = reader.ReadLine()) != null)
            {
                data = line.Split('#');
                FillItem(data);
                cbBaseCurrency.Items.Add(data[1]);
                cbFrom.Items.Add(data[1]);
                cbTo.Items.Add(data[1]);

            }
            reader.Close();
            ImageCounter = 0;

        }

        void UploadListViewResualtOfSearch()
        {
            string[] data;
            string line;




            StreamReader reader = new StreamReader(FileName);
            while ((line = reader.ReadLine()) != null)
            {
                data = line.Split('#');

                if (data[1] == mtbSearch.Text)
                {
                    listViewResualtOfSearch.Items.Clear();
                    FillItemOfSearch(data);
                    return;
                }
                ImageCounter++;
            }
            reader.Close();
            MessageBox.Show(mtbSearch.Text + " Not Found !", "Faild",MessageBoxButtons.OK,MessageBoxIcon.Error) ;
            mtbSearch.Text = "";
            ImageCounter = 0;
        }

        string CounvertToString(string []data)
        {
            string line;
            string seprator = "#";

            line = data[0] + seprator;
            line += data[1] + seprator;
            line += data[2] + seprator;
            line += data[3] + seprator;
            line += data[4] + seprator;
            line += data[5] + seprator;
            return line;
        }

        void SearchForUpdate()
        {
            string[] data;
            string line;
            string info="";
            List<string> Item=new List<string>();
            


            StreamReader reader = new StreamReader(FileName);
            while ((line = reader.ReadLine()) != null)
            {
                data = line.Split('#');

                if (data[1] == cbBaseCurrency.SelectedItem.ToString())
                {
                    DateTime time = DateTime.Now;
                    string date = time.ToString("yyyy-MM-dd");
                    data[3] = nudNewSellRate.Value.ToString();
                    data[4] = nudNewBuyRate.Value.ToString();
                    data[5] = date;
                }
               info= CounvertToString(data);
                Item.Add(info);
            }
            reader.Close();

            StreamWriter writer = new StreamWriter(FileName);
            foreach(string st in Item)
            {
                writer.WriteLine(st);

            }
            writer.Close();
        }

        bool IspnlUpdateNull()
        {
            if (nudNewSellRate.Value == 0 || nudNewBuyRate.Value == 0||cbBaseCurrency.SelectedIndex==-1)
                return true;
            return false;
        }

        bool IsPnlCalculateNull()
        {
            if (nudAmount.Value == 0 || cbFrom.SelectedIndex == -1 || cbTo.SelectedIndex == -1)
                return true;
            return false;
        }

        private void frmCurrencyExchange_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(25, 36, 58);
            btnAddCurrency.BackColor = Color.FromArgb(25, 36, 58);
            btnCalculate.BackColor = Color.FromArgb(25, 36, 58);
            btnSaveUpdate.BackColor = Color.FromArgb(25, 36, 58);
            lbCurrencyCalculator.ForeColor = Color.FromArgb(25, 36, 58);
            lbCurrencyExchange.ForeColor = Color.FromArgb(25, 36, 58);
            lbSelectedCurrencyDetails.ForeColor = Color.FromArgb(25, 36, 58);
            lbUpdateCurrencyRate.ForeColor = Color.FromArgb(25, 36, 58);
            UploadListViewOfCurrency();


        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            btnSearch.BackColor = Color.Green;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            btnSearch.BackColor = Color.FromArgb(128, 255, 128);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            UploadListViewResualtOfSearch();
        }

        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
           if(IspnlUpdateNull())
            {
                MessageBox.Show("Fill Form for update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SearchForUpdate();
                listViewCurrency.Items.Clear();
                UploadListViewOfCurrency();
                MessageBox.Show("Done Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void Clear()
        {
            mtbSearch.Clear();
            nudAmount.Value = 0;
            nudNewBuyRate.Value = 0;
            nudNewSellRate.Value = 0;
            tbResualt.Clear();
            listViewResualtOfSearch.Items.Clear();
            cbBaseCurrency.SelectedIndex = -1;
            cbFrom.SelectedIndex = -1;
            cbTo.SelectedIndex = -1;
        }

        decimal GetResaultOfAmount(string value1,string value2)
        {
            if (cbTo.SelectedItem.ToString() == cbFrom.SelectedItem.ToString())
                return nudAmount.Value;

            if ("USD" == cbTo.SelectedItem.ToString())
            {
                decimal.TryParse(value2, out decimal Value);
                return (nudAmount.Value / Value);

            }
            if ("USD" == cbFrom.SelectedItem.ToString())
            {

                decimal.TryParse(value1, out decimal Value);
                return (nudAmount.Value*Value);
                
            }
            decimal.TryParse(value2, out decimal ValueBuy);
            decimal usd = nudAmount.Value /ValueBuy;
            decimal.TryParse(value1, out decimal ValueSell);
            return usd *ValueSell;
        }

        void Calculate()
        {
            string[] data;
            string line;
            string valueofSell = "";
            string valueofBuy = "";



            StreamReader reader = new StreamReader(FileName);
            while ((line = reader.ReadLine()) != null)
            {
                data = line.Split('#');
                if (data[1] == cbFrom.SelectedItem.ToString())
                    valueofBuy = data[3];

                
                if (data[1] == cbTo.SelectedItem.ToString())
                    valueofSell = data[4];

            }
            reader.Close();

            tbResualt.Text = Math.Round(GetResaultOfAmount(valueofSell,valueofBuy),2).ToString();


        }

        private void btnSaveUpdate_MouseEnter(object sender, EventArgs e)
        {
            btnSaveUpdate.BackColor = Color.CornflowerBlue;
        }

        private void btnSaveUpdate_MouseLeave(object sender, EventArgs e)
        {
            btnSaveUpdate.BackColor = Color.FromArgb(25,36,58);

        }

        private void btnCalculate_MouseEnter(object sender, EventArgs e)
        {
            btnCalculate.BackColor = Color.CornflowerBlue;

        }

        private void btnCalculate_MouseLeave(object sender, EventArgs e)
        {
            btnCalculate.BackColor = Color.FromArgb(25, 36, 58);

        }

        private void btnAddCurrency_MouseEnter(object sender, EventArgs e)
        {
            btnAddCurrency.BackColor = Color.CornflowerBlue;

        }

        private void btnAddCurrency_MouseLeave(object sender, EventArgs e)
        {
            btnAddCurrency.BackColor = Color.FromArgb(25, 36, 58);

        }

        private void btnClear_MouseEnter(object sender, EventArgs e)
        {
            btnClear.BackColor = Color.White;
            btnClear.ForeColor = Color.Black;

        }

        private void btnClear_MouseLeave(object sender, EventArgs e)
        {
            btnClear.BackColor = Color.Gainsboro;
            btnClear.ForeColor = Color.White;


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();

        }
        
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (IsPnlCalculateNull())
            {
                MessageBox.Show("Fill Form", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(MessageBox.Show("Are you sure?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                Calculate();
                MessageBox.Show("Done Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        bool CheckPermission()
        {

            if (Convert.ToInt32(UserSession.Permission) == -1)
                return true;

            MessageBox.Show("Access Denied : Contact to admain", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return false;
        }

        private void btnAddCurrency_Click(object sender, EventArgs e)
        {
            Button btn = new Button();
            btn.Name = "btn1";
            btn.Size = new Size(12, 13);
            
            panel1.Controls.Add(btn);

            if (!CheckPermission())
                return;

            Form frm = new FrmAddCurrency();
            frm.ShowDialog();
        }

        public void AddFlagToListView(Image FlagImage)
        {
            MessageBox.Show("Count : " + imageListFlag.Images.Count.ToString());
            if(FlagImage!=null)
            imageListFlag.Images.Add(FlagImage);
            MessageBox.Show("Count : " + imageListFlag.Images.Count.ToString());
            UploadListViewOfCurrency();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
