using CsharpEgitim4.Cervices;
using CsharpEgitim4.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsharpEgitim4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        CustomerOperations customerOperations = new CustomerOperations();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var customer = new Customer()
            {
                CustomerName = txtCustomerName.Text,
                CustomerSurname = txtCustomerSurname.Text,
                CustomerCity = txtCustomerCity.Text,
                CustomerBalance = decimal.Parse(txtCustomerBalance.Text),
                CustomerShoppingCount = int.Parse(txtCustomerShoppingCount.Text),

            };
            customerOperations.AddCustomer(customer);
            MessageBox.Show("Müşteri Eklendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);  
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            List<Customer> customers = customerOperations.GetAllCustomer();
            dataGridView1.DataSource = customers;   
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string customerId=txtCustomerId.Text;
            customerOperations.DeleteCustomer(customerId);
            MessageBox.Show("Silindi");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = txtCustomerId.Text;
            var UpdateCustomer = new Customer()
            {
                CustomerName = txtCustomerName.Text,
                CustomerBalance = decimal.Parse(txtCustomerBalance.Text),
                CustomerCity = txtCustomerCity.Text,
                CustomerId = id,
                CustomerShoppingCount = int.Parse(txtCustomerShoppingCount.Text),
                CustomerSurname = txtCustomerSurname.Text,
            };
            customerOperations.UpdateCustomer(UpdateCustomer);
            MessageBox.Show("Güncellendi");
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            string id=txtCustomerId.Text;
            Customer customers = customerOperations.GetCustomerById(id);
            dataGridView1.DataSource=new List<Customer> {customers };
        }
    }
}
