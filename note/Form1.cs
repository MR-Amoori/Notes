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
    public partial class Form1 : Form
    {
        public string notee;
        NoteRepository repositpry;
        public Form1()
        {
            InitializeComponent();
            repositpry = new NoteRepository();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SelectAll();
        }

        private void SelectAll()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = repositpry.SelectAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm._ID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                SelectAll();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog();
            if(frm.DialogResult==DialogResult.OK)
            {
                SelectAll();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id =(int) dataGridView1.CurrentRow.Cells[0].Value;
            string note = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            if (MessageBox.Show($"آیا از حذف {note} مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                repositpry.Delete(id);
                SelectAll();
            }
        }
    }
}
