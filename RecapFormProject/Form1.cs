using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecapFormProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                dgwProduct.DataSource = context.Products.ToList(); 
            }
            using (NorthwindContext context = new NorthwindContext())
            {
                cbxCategory.DataSource = context.Categories.ToList();
                cbxCategory.DisplayMember= "CategoryName";
                cbxCategory.ValueMember= "CategoryId";
            }
            
         }   
        
        private void ListProductsByCategory(int categoryId)
            {
                using (NorthwindContext context = new NorthwindContext())
                {
                dgwProduct.DataSource = context.Products.Where(p => p.CategoryId==categoryId).ToList();
                    
                }

            }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListProductsByCategory(Convert.ToInt32(cbxCategory.SelectedValue)); 
            }
            catch
            {

                
            }
             
        }
        private void ListProductsByProductName(string productName)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                dgwProduct.DataSource = context.Products.Where(p => p.ProductName.ToLower().Contains(productName)).ToList();

            }

        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            string productName = tbxSearch.Text;
            if (string.IsNullOrEmpty(productName))
            {
                using (NorthwindContext context = new NorthwindContext())
                {
                    dgwProduct.DataSource = context.Products.ToList();
                }
            }
            else
            {
                ListProductsByProductName(tbxSearch.Text);
            }
            }
             
            
        }
    }    

