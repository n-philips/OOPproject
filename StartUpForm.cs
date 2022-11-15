using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BLL;

namespace GUI_Layer
{
    public partial class StartUpForm : Form
    {
        public StartUpForm()
        {
            InitializeComponent();
            ProductDAL.InitializeList();
            CustomerDAL.InitializeList();
            OrderDAL.InitializeList();
        }

        private void buttonCustomers_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerForm customerInterface = new CustomerForm();
            //customerInterface.MdiParent = this;
            customerInterface.ShowDialog();
        }

        private void buttonProducts_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductForm productInterface = new ProductForm();
            //customerInterface.MdiParent = this;
            productInterface.ShowDialog();
        }

        private void buttonOrders_Click(object sender, EventArgs e)
        {
            this.Hide();
            OrderForm orderInterface = new OrderForm();
            //customerInterface.MdiParent = this;
            orderInterface.ShowDialog();
        }

        private void StartUpForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
