using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private DBConnect _dbconnect;

        public Form1()
        {
            InitializeComponent();
            _dbconnect = new DBConnect();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void Button4_Click(object sender, EventArgs e)
        {

            _dbconnect.Insert(textBox1.Text, textBox2.Text, textBox3.Text);
            RefreshList();

        }

        private void RefreshList()
        {
            List<string>[] list;
            list = _dbconnect.Select();
            dataGridView1.Rows.Clear();
            for (int i = 0; i < list[0].Count; i++)
            {
                int number = dataGridView1.Rows.Add();
                dataGridView1.Rows[number].Cells[0].Value = list[0][i];
                dataGridView1.Rows[number].Cells[1].Value = list[1][i];
                dataGridView1.Rows[number].Cells[2].Value = list[2][i];
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            _dbconnect.Delete(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            RefreshList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
