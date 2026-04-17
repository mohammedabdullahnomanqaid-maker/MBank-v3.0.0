
namespace Project_Bank_C
{
    partial class frmLoginRegister
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.lbUserFullTotal = new System.Windows.Forms.Label();
            this.listviewLoginRegister = new System.Windows.Forms.ListView();
            this.ClientName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AccountNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AccountBalance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.listviewLoginRegister);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(183, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(621, 454);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.pictureBox9);
            this.panel4.Controls.Add(this.lbUserFullTotal);
            this.panel4.Location = new System.Drawing.Point(209, -9);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(236, 42);
            this.panel4.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Lime;
            this.label13.Location = new System.Drawing.Point(140, 11);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 18);
            this.label13.TabIndex = 2;
            this.label13.Text = "(Active) ";
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox9.Image = global::Project_Bank_C.Properties.Resources.DefaultIcon;
            this.pictureBox9.Location = new System.Drawing.Point(204, 4);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(31, 35);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox9.TabIndex = 1;
            this.pictureBox9.TabStop = false;
            // 
            // lbUserFullTotal
            // 
            this.lbUserFullTotal.AutoSize = true;
            this.lbUserFullTotal.BackColor = System.Drawing.Color.Transparent;
            this.lbUserFullTotal.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserFullTotal.ForeColor = System.Drawing.Color.Black;
            this.lbUserFullTotal.Location = new System.Drawing.Point(3, 11);
            this.lbUserFullTotal.Name = "lbUserFullTotal";
            this.lbUserFullTotal.Size = new System.Drawing.Size(137, 18);
            this.lbUserFullTotal.TabIndex = 0;
            this.lbUserFullTotal.Text = "Admin : Johan Doe ";
            // 
            // listviewLoginRegister
            // 
            this.listviewLoginRegister.BackColor = System.Drawing.Color.Silver;
            this.listviewLoginRegister.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ClientName,
            this.AccountNumber,
            this.AccountBalance,
            this.columnHeader1});
            this.listviewLoginRegister.FullRowSelect = true;
            this.listviewLoginRegister.GridLines = true;
            this.listviewLoginRegister.HideSelection = false;
            this.listviewLoginRegister.Location = new System.Drawing.Point(-1, 78);
            this.listviewLoginRegister.Name = "listviewLoginRegister";
            this.listviewLoginRegister.Size = new System.Drawing.Size(444, 375);
            this.listviewLoginRegister.TabIndex = 2;
            this.listviewLoginRegister.UseCompatibleStateImageBehavior = false;
            this.listviewLoginRegister.View = System.Windows.Forms.View.Details;
            // 
            // ClientName
            // 
            this.ClientName.Text = "Date/Time";
            this.ClientName.Width = 200;
            // 
            // AccountNumber
            // 
            this.AccountNumber.Text = "User Name";
            this.AccountNumber.Width = 80;
            // 
            // AccountBalance
            // 
            this.AccountBalance.Text = "Password";
            this.AccountBalance.Width = 80;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Permission";
            this.columnHeader1.Width = 80;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(-1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(617, 1);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Project_Bank_C.Properties.Resources.FlagNavy;
            this.pictureBox1.Location = new System.Drawing.Point(-4, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(188, 454);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox7.Image = global::Project_Bank_C.Properties.Resources.logoutNavy;
            this.pictureBox7.Location = new System.Drawing.Point(-7, -3);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(59, 50);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 5;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // frmLoginRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 450);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "frmLoginRegister";
            this.Text = "MBank";
            this.Load += new System.EventHandler(this.frmLoginRegister_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView listviewLoginRegister;
        private System.Windows.Forms.ColumnHeader ClientName;
        private System.Windows.Forms.ColumnHeader AccountNumber;
        private System.Windows.Forms.ColumnHeader AccountBalance;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label lbUserFullTotal;
        private System.Windows.Forms.PictureBox pictureBox7;
    }
}