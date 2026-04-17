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
    public partial class frmLoginRegister : Form
    {
        string FileLoginRegister = "FileLoginRegister.txt";
        byte key = 2;

        string Decrypted(string word)
        {
            string newWord = "";

            for (int i = 0; i < word.Length; i++)
            {
                newWord += Convert.ToChar(Convert.ToByte(word[i]) - key);
            }

            return newWord;
        }

        public frmLoginRegister()
        {
            InitializeComponent();
        }

        private void frmLoginRegister_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(25, 36, 58);
            UploadLoginRegister();
            lbUserFullTotal.Text = UserSession.UserName + " : " + UserSession.FullName;
        }

        void FillListViewLoginRegister(string []data)
        {
            ListViewItem item = new ListViewItem(data[0]);
            item.SubItems.Add(data[1]);
            item.SubItems.Add(Decrypted(data[2]));
            item.SubItems.Add(data[3]);
            listviewLoginRegister.Items.Add(item);
        }

        void UploadLoginRegister()
        {

            StreamReader reader = new StreamReader(FileLoginRegister);
            string line;
            string[] data;
            while((line=reader.ReadLine())!=null)
            {
                data = line.Split('#');
                FillListViewLoginRegister(data);
            }
            reader.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
