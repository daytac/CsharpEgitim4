using Npgsql;
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
    public partial class FrmCustomer : Form
    {
        public FrmCustomer()
        {
            InitializeComponent();
        }

        string connectionString = "server=localhost; port=5432;Database=CustomerDb; user id=postgres; password=12345";

        void GetAllCustomers()
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "select * from Customers";
            var command = new NpgsqlCommand(query, connection);
            var adapter = new NpgsqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connection.Close();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            GetAllCustomers();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string custonerName = txtCustomerName.Text;
            string customerCity = txtCustomerCity.Text;
            string customerSurname = txtCustomerSurname.Text;
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "insert into Customers (CustomerName, CustomerSurname, CustomerCity) values" +
                "(@customerName,@customerSurname,@customerCity)";
            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@customerName", custonerName);
            command.Parameters.AddWithValue("@customerSurname", customerSurname);
            command.Parameters.AddWithValue("@customerCity", customerCity);
            command.ExecuteNonQuery();
            MessageBox.Show("Eklendi");
            connection.Close();
            GetAllCustomers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCustomerId.Text);
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "Delete from Customers where CustomerId=@customerId";
            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@customerId", id);
            command.ExecuteNonQuery();
            MessageBox.Show("silindi");
            connection.Close();
            GetAllCustomers();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string customerName = txtCustomerName.Text;
            string customerCity = txtCustomerCity.Text;
            string customerSurname = txtCustomerSurname.Text;
            int id=int.Parse(txtCustomerId.Text);
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "update Customers set CustomerName=@customerName," +
                "CustomerSurname=@customerSurname,CustomerCity=@customerCity where CustomerId=@customerId";
            var command= new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("customerName", customerName);
                 command.Parameters.AddWithValue("customerSurname", customerSurname);
            command.Parameters.AddWithValue("customerCity", customerCity);
            command.Parameters.AddWithValue("customerId", id);
            command.ExecuteNonQuery();
            MessageBox.Show("Güncellendi");
            connection.Close();
            GetAllCustomers();
        }
    }
}
