using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AdoNetProject
{
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductDal _productDal = new ProductDal();
            _productDal.Add(new Product
            {
                Name = textBox1.Text,
                UnitPrice=Convert.ToDecimal(textBox3.Text),
                StockAmount=Convert.ToInt32(textBox2.Text)
            });
            MessageBox.Show("Product Added !");
        } 

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateProducts update = new UpdateProducts();
            update.Name = textBox1.Text;
            update.UnitPrice = textBox2.Text;
            update.StockAmount = textBox3.Text;
            update.ShowDialog();
            Form1 added = new Form1();
            added.Show();
        }
    }
}
