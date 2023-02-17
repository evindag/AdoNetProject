using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkDemo
{
    public partial class Form1 : Form
    {
        private readonly ProductDal<Product, ETradeContext> _productDal = new ProductDal();
        Product _product;

        public Form1()
        {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _productDal.GetAll();
        }
        private void SearchProducts(string key)
        {
            //var result = _productDal.GetAll().Where(p=>p.Name.ToLower().Contains(key.ToLower)).ToList();
            var result = _productDal.GetByName(key);
            dataGridView1.DataSource = result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            {
                Name = textBox1.Text,
                UnitPrice=Convert.ToDecimal(textBox2.Text),
                StockAmount = Convert.ToInt32(textBox3.Text)
            });
            dataGridView1.DataSource = _productDal.GetAll();
            MessageBox.Show("Added");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _productDal.Update(new Product
            {
                Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                Name = textBox1.Text,
                UnitPrice = Convert.ToDecimal(textBox2.Text),
                StockAmount= Convert.ToInt32(textBox3.Text)
            });
            dataGridView1.DataSource = _productDal.GetAll();
            MessageBox.Show("Updated");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _productDal.Delete(new Product
            {
                Id =Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
            });
            dataGridView1.DataSource = _productDal.GetAll();
            MessageBox.Show("Deleted");
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            SearchProducts(tbxSearch.Text);
        }
    }
}
