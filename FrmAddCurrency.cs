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
    public partial class FrmAddCurrency : Form
    {
        string FileName = "Currency.txt";
        Image FlagImage;
        public FrmAddCurrency()
        {
            InitializeComponent();
        }

        private void FrmAddCurrency_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(26, 35, 58);
            btnSubmit.BackColor = Color.FromArgb(26, 35, 58);
        }

        void AddCurrency()
        {
            DateTime time = DateTime.Now;
            string format = time.ToString("yyyy-MM-dd");
            StreamWriter writer = new StreamWriter(FileName, true);
            string line = mtbCountry.Text + "#" + mtbCode.Text + "#" + mtbCurrencyName.Text + "#" + mtbSellRate.Text + "#" + mtbBuyRate.Text + "#" + format;
            writer.WriteLine(line);
            writer.Close();
        }

        bool IsNull()
        {

            if (mtbCountry.Text == "" || mtbCode.Text == "" || mtbBuyRate.Text == ""
                || mtbSellRate.Text == "" || mtbCurrencyName.Text == "")
                return true;
            return false;
        }

        private void btnAddFlag_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Title = "Add Flag";
            openFileDialog1.Filter = "PNG|*png";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                picAddFlag.Image = Image.FromFile(openFileDialog1.FileName);
                 FlagImage = Image.FromFile(openFileDialog1.FileName);
            }

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (IsNull())
            {
                MessageBox.Show("Fill Form", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Are you sure ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
             
                    AddCurrency();
                frmCurrencyExchange frm = (frmCurrencyExchange)Application.OpenForms["frmCurrencyExchange"];
               frm.AddFlagToListView(FlagImage);



                MessageBox.Show("Done Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
