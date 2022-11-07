using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNetProject
{
    public partial class Form1 : Form
    {

        ProductDal _productDal = new ProductDal();
        Product _product;

        public Form1()
        {
            InitializeComponent();
        }

        //public void Form1_Load(object sender, EventArgs e)
        //{
        //    ProductDal _productDal = new ProductDal();
        //    dataGridView1.DataSource = _productDal.GetAll();
        //}

        private void button1_Click_1(object sender, EventArgs e)
        {
            AddProduct add = new AddProduct();
            add.Show();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _productDal.GetAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            _productDal.Delete(id);
            MessageBox.Show("Deleted");
            Form1 del = new Form1();
            del.Show();


        }
    }
}
