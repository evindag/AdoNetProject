using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AdoNetProject
{
    public partial class UpdateProducts : Form
    {
        public string Name ;
        public string UnitPrice;
        public string StockAmount;
        public UpdateProducts()
        {
            InitializeComponent();
        }

        private void UpdateProducts_Load(object sender, EventArgs e)
        {
            textBox1.Text = Name;
            textBox2.Text = UnitPrice;
            textBox3.Text = StockAmount;
        }
    }
}
