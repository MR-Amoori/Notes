using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace note
{
    public partial class Form2 : Form
    {
        public int _ID;
        Form1 frm = new Form1();
        NoteRepository repository;
        public Form2()
        {
            InitializeComponent();
            repository = new NoteRepository();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (_ID == 0)
            {
                this.Text = " افزودن شخص جدید ";
                btnUpdate.Text = "اضافه کردن";
            }
            else
            {
                DataTable dt = repository.SelectRow(_ID);
                txtNote.Text = dt.Rows[0][2].ToString();
                txtTitel.Text = dt.Rows[0][1].ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool isSoccess;
            if (_ID == 0)
            {
                isSoccess = repository.Insert(txtTitel.Text, txtNote.Text);
            }
            else
            {
                isSoccess = repository.Update(_ID, txtTitel.Text, txtNote.Text);
            }
            if (isSoccess == true)
            {
                MessageBox.Show("عملیات با موفقیت انجام شد", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }

            else
            {
                MessageBox.Show(" ! ناموفق", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
