using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;
using Entities;

namespace GUI_Layer
{
    public partial class OrderForm : BasicForm
    {
        OrderBll ordBLL = new OrderBll();
        ProductBLL prodBLL = new ProductBLL();
        CustomerBLL custBLL = new CustomerBLL();

        public OrderForm()
        {
            InitializeComponent();
            HideAll();
            Clear();
        }

        #region HideAndClear

        public void Clear()
        {
            foreach (Control guiControl in this.Controls)
            {
                if (guiControl.GetType() == typeof(System.Windows.Forms.TextBox))
                {
                    TextBox t = (TextBox)guiControl;
                    t.Clear();
                }
            }
            numericUpDownProductQuantity.Value = 0;
            listBoxItemsOrdered.Items.Clear();
            comboBoxProducts.SelectedItem = null;
        }

        public void HideAll()
        {
            labelName.Visible = false;
            textBoxname.Visible = false;
            textBoxOrdNum.Visible = false;
            labelOrderNum.Visible = false;
            textBoxProdNum.Visible = false;
            textBoxQuantity.Visible = false;
            labelQuantity.Visible = false;
            labelProdNum.Visible = false;
            //buttonSubmitRead.Visible = false;
            buttonSubmitForRead.Visible = false;
            listBoxReadOrder.Visible = false;
            listBoxItemsOrdered.Visible = false;
            labelChooseProducts.Visible = false;
            comboBoxProducts.Visible = false;
            labelCustPlacingOrder.Visible = false;
            textBoxCustPlacingOrderID.Visible = false;
            comboBoxProducts.Visible = false;
            numericUpDownProductQuantity.Visible = false;
            buttonAddProdToOrder.Visible = false;
            labelCart.Visible = false;
            labelProductQuantity.Visible = false;
            buttonSubmitOrder.Visible = false;
            buttonShowUpdateControls.Visible = false;
            textBoxOrdNumForUpdate.Visible = false;
            labelPromptUpdate.Visible = false;
            buttonSubmitForDelete.Visible = false;
            labelReadOrderStuff.Visible = false;

            buttonAddToUpdateOrder.Visible = false;
            buttonAddToUpdateOrder.Enabled = false;
            buttonUpdateOrder.Visible = false;
            buttonUpdateOrder.Enabled = false;

            labelName.Enabled = false;
            textBoxname.Enabled = false;
            textBoxOrdNum.Enabled = false;
            textBoxProdNum.Enabled = false;
            textBoxQuantity.Enabled = false;
            labelQuantity.Enabled = false;
            labelProdNum.Enabled = false;
            //buttonSubmitRead.Enabled = false;
            buttonSubmitForRead.Enabled = false;
            listBoxReadOrder.Enabled = false;
            listBoxItemsOrdered.Enabled = false;
            labelChooseProducts.Enabled = false;
            comboBoxProducts.Enabled = false;
            labelCustPlacingOrder.Enabled = false;
            textBoxCustPlacingOrderID.Enabled = false;
            comboBoxProducts.Enabled = false;
            numericUpDownProductQuantity.Enabled = false;
            buttonAddProdToOrder.Enabled = false;
            labelCart.Enabled = false;
            labelProductQuantity.Enabled = false;
            buttonSubmitOrder.Enabled = false;
            buttonShowUpdateControls.Enabled = false;
            textBoxOrdNumForUpdate.Enabled = false;
            labelPromptUpdate.Enabled = false;
            buttonSubmitForDelete.Enabled = false;
            labelReadOrderStuff.Enabled = false;
            labelOrderNum.Enabled = false;
            buttonRemoveFromUpdateOrder.Visible = false;
            buttonRemoveFromUpdateOrder.Enabled = false;
        }
        #endregion

        #region Create
        List<Order> cart = new List<Order>();

        public void ShowCreateControls()
        {
            //labelNewOrder.Visible = true;
            labelChooseProducts.Visible = true;
            comboBoxProducts.Visible = true;
            labelCustPlacingOrder.Visible = true;
            textBoxCustPlacingOrderID.Visible = true;
            listBoxItemsOrdered.Visible = true;
            comboBoxProducts.Visible = true;
            numericUpDownProductQuantity.Visible = true;
            buttonAddProdToOrder.Visible = true;
            labelCart.Visible = true;
            labelProductQuantity.Visible = true;
            buttonSubmitOrder.Visible = true;

            //labelNewOrder.Enabled = true;
            labelChooseProducts.Enabled = true;
            comboBoxProducts.Enabled = true;
            labelCustPlacingOrder.Enabled = true;
            textBoxCustPlacingOrderID.Enabled = true;
            listBoxItemsOrdered.Enabled = true;
            comboBoxProducts.Enabled = true;
            numericUpDownProductQuantity.Enabled = true;
            buttonAddProdToOrder.Enabled = true;
            labelCart.Enabled = true;
            labelProductQuantity.Enabled = true;
            buttonSubmitOrder.Enabled = true;
        }
        public override void Create()
        {
            HideAll();
            Clear();
            ShowCreateControls();
            listBoxItemsOrdered.Items.Add(String.Format("{0, -35}{1, 5}", "Item:", "Quantity:"));
            List<Product> prodlist = prodBLL.ReadAll();
            foreach(Product prod in prodlist)
            {
                comboBoxProducts.Items.Add(prod);
            }
        }

        private void buttonAddProdToOrder_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    custBLL.ReadItem(int.Parse(textBoxCustPlacingOrderID.Text));
                }
                catch
                {
                    throw new ItemNotFoundException();
                }
                

                if (comboBoxProducts.SelectedItem != null && numericUpDownProductQuantity.Value != 0)
                {
                    Product newprod = (Product)comboBoxProducts.Items[comboBoxProducts.SelectedIndex];
                    Order ord = new Order(newprod.ProductNumber, int.Parse(textBoxCustPlacingOrderID.Text), (int)numericUpDownProductQuantity.Value);
                    cart.Add(ord);
                    //listBoxItemsOrdered.Items.Add($"{newprod.ProductName}   {ord.OrderQuantity}");
                    listBoxItemsOrdered.Items.Add(String.Format("{0, -32}{1, 5}", $"{newprod.ProductName}", $"{ord.OrderQuantity}"));
                    numericUpDownProductQuantity.Value = 0;
                    comboBoxProducts.SelectedItem = null;
                }
                else
                {
                    throw new NullInputException();
                }
            }
            catch (ItemNotFoundException)
            {
                MessageBox.Show("Invalid customer ID.\nPlease check that the number is correct and try again.",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(NullInputException)
            {
                MessageBox.Show("Please fill all the fields",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSubmitOrder_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Order neword in cart)
                {
                    ordBLL.Create(neword);
                    Product ordered = prodBLL.ReadItem(neword.ProductNumber);
                    ordered.AmountInStock -= neword.OrderQuantity;
                    prodBLL.Update(ordered);
                }
                Order.NumOfOrders++;
                MessageBox.Show("Your order has been completed successfully.", "Order placed", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }
            catch
            {
                MessageBox.Show("We're sorry. Order cannot be clompleted at this time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        #region Read
        public override void ReadItem()
        {
            HideAll();
            Clear();

            //buttonSubmitRead.Visible = true;
            //buttonSubmitRead.Enabled = true;
            textBoxOrdNum.Visible = true;
            labelOrderNum.Visible = true;
            textBoxOrdNum.Enabled = true;
            buttonSubmitForRead.Visible = true;
            buttonSubmitForRead.Enabled = true;
            /*if (textBoxOrdNum.TextLength != 0)
            {
                int ordID = int.Parse(textBoxOrdNum.Text);
                ordBLL.ReadItem(ordID);
                return true;
            }
            else
            {
                MessageBox.Show("Please enter the order number of the customer you would like to view", "No input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;*/
        }

        //step 1: show prompt and a box to enter order num
        //step 2: get the order - mdone
        //step 3: display

        private void buttonSubmitForRead_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxOrdNum.TextLength != 0)
                {
                    int ordID = int.Parse(textBoxOrdNum.Text);
                    ReadOrder(ordID);

                }
                else
                {
                    throw new NullInputException();
                }
            }
            catch (ItemNotFoundException)
            {
                MessageBox.Show("Order not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NullInputException)
            {
                MessageBox.Show("Please enter the order number of the order you would like to view", "No input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool ReadOrder(int ordID)
        {
                List<Order> items = ordBLL.ReadItem(ordID);
                listBoxItemsOrdered.Visible = true;
                listBoxItemsOrdered.Enabled = true;
                labelCart.Visible = true;
                labelCart.Enabled = true;
                labelReadOrderStuff.Visible = true;
                labelReadOrderStuff.Enabled = true;
            textBoxCustPlacingOrderID.Text = $"{items[0].CustomerID}";

                foreach (var item in items)
                {
                    Product prod = prodBLL.ReadItem(item.ProductNumber);
                    listBoxItemsOrdered.Items.Add(String.Format("{0, -32}{1, 5}", $"{prod.ProductName}", $"{item.OrderQuantity}"));
                    labelReadOrderStuff.Text = $"Order number: {item.OrderNumber}\nTime of order: {item.TimeOfOrder}";
                }
                return true;
            
        }


        #endregion

        #region ReadAll

        public override void ReadAll()
        {
            HideAll();
            listBoxReadOrder.Items.Clear();
            listBoxReadOrder.Visible = true;
            listBoxReadOrder.Enabled = true;

            try
            {
                foreach (var ord in ordBLL.ReadAll())
                {
                    listBoxReadOrder.Items.Add(ord);
                }
            }
            catch
            {
                MessageBox.Show("There are no Orders", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Update

        public override void Update()
        {
            HideAll();
            Clear();
            textBoxOrdNum.Visible = true;
            labelOrderNum.Visible = true;
            labelOrderNum.Enabled = true;
            textBoxOrdNum.Enabled = true;
            labelPromptUpdate.Visible = true;
            //textBoxOrdNumForUpdate.Visible = true;
            buttonShowUpdateControls.Visible = true;
            labelPromptUpdate.Enabled = true;
            //textBoxOrdNumForUpdate.Enabled = true;
            buttonShowUpdateControls.Enabled = true;
        }

        private void buttonShowUpdateControls_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxOrdNum.TextLength != 0)
                {
                    int ordID = int.Parse(textBoxOrdNum.Text);
                    HideAll();
                    //Clear();
                    listBoxItemsOrdered.Items.Add(String.Format("{0, -35}{1, 5}", "Item:", "Quantity:"));
                    List<Product> prodlist = prodBLL.ReadAll();
                    foreach (Product prod in prodlist)
                    {
                        comboBoxProducts.Items.Add(prod);
                    }
                    ReadOrder(ordID);
                    cart = ordBLL.ReadItem(ordID);
                    labelChooseProducts.Visible = true;
                    labelChooseProducts.Enabled = true;
                    labelChooseProducts.Text = "Please select a product to add/remove";
                    comboBoxProducts.Visible = true;
                    comboBoxProducts.Enabled = true;
                    labelProductQuantity.Visible = true;
                    labelProductQuantity.Enabled = true;
                    numericUpDownProductQuantity.Visible = true;
                    numericUpDownProductQuantity.Enabled = true;
                    buttonAddToUpdateOrder.Visible = true;
                    buttonAddToUpdateOrder.Enabled = true;
                    labelCustPlacingOrder.Visible = true;
                    labelCustPlacingOrder.Enabled = true;
                    textBoxCustPlacingOrderID.Visible = true;
                    labelCustPlacingOrder.Text = "Customer ID:";
                    buttonUpdateOrder.Visible = true;
                    buttonUpdateOrder.Enabled = true;
                    buttonRemoveFromUpdateOrder.Visible = true;
                    buttonRemoveFromUpdateOrder.Enabled = true;
                }
                else
                {
                    throw new NullInputException();
                }
            }
            catch (ItemNotFoundException)
            {
                MessageBox.Show("Order not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NullInputException)
            {
                MessageBox.Show("Please enter the order number of the order you would like to update", "No input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddToUpdateOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxProducts.SelectedItem != null && numericUpDownProductQuantity.Value != 0)
                {
                    Product newprod = (Product)comboBoxProducts.Items[comboBoxProducts.SelectedIndex];
                    Order ord = new Order(cart[0].OrderNumber, newprod.ProductNumber, int.Parse(textBoxCustPlacingOrderID.Text), (int)numericUpDownProductQuantity.Value);
                    cart.Add(ord);
                    //listBoxItemsOrdered.Items.Add($"{newprod.ProductName}   {ord.OrderQuantity}");
                    listBoxItemsOrdered.Items.Add(String.Format("{0, -32}{1, 5}", $"{newprod.ProductName}", $"{ord.OrderQuantity}"));
                    numericUpDownProductQuantity.Value = 0;
                    comboBoxProducts.SelectedItem = null;
                }
                else
                {
                    throw new NullInputException();
                }
            }
            catch
            {
                MessageBox.Show("Please check that your input is valid", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }


        private void buttonRemoveFromUpdateOrder_Click(object sender, EventArgs e)
        {
            Product newprod = (Product)comboBoxProducts.Items[comboBoxProducts.SelectedIndex];
            int quantity = 0;
            foreach(var item in cart)
            {
                if(item.ProductNumber == newprod.ProductNumber)
                {
                    quantity = item.OrderQuantity;
                    cart.Remove(item);
                    break;
                }
            }
            
            //listBoxItemsOrdered.Items.Add($"{newprod.ProductName}   {ord.OrderQuantity}");
            listBoxItemsOrdered.Items.Remove(String.Format("{0, -32}{1, 5}", $"{newprod.ProductName}", $"{quantity}"));
            numericUpDownProductQuantity.Value = 0;
            comboBoxProducts.SelectedItem = null;
        }


        //update product
        private void buttonUpdateOrder_Click(object sender, EventArgs e)
        {
            try
            {
                ordBLL.Update(cart);
                MessageBox.Show("Your order has been updated successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(ItemNotFoundException)
            {
                MessageBox.Show("Order not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        #endregion

        #region Delete
        public override void Delete()
        {
            HideAll();
            Clear();

            textBoxOrdNum.Visible = true;
            buttonSubmitForDelete.Visible = true;
            textBoxOrdNum.Enabled = true;
            buttonSubmitForDelete.Enabled = true;
            labelOrderNum.Visible = true;
            labelOrderNum.Enabled = true;

        }

        private void buttonSubmitForDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxOrdNum.TextLength != 0)
                {
                    int ordNum = int.Parse(textBoxOrdNum.Text);
                    ordBLL.Delete(ordNum);
                    MessageBox.Show("Order" + " " + ordNum + " " + "has been succesfully removed");
                    //now I just need to update the storage in the stock
                }
                else
                {
                    MessageBox.Show("Please fill all the fields");
                }
            }
            catch
            {
                MessageBox.Show("order not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion 
        private void OrderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBoxOrdNum_TextChanged(object sender, EventArgs e)
        {
            listBoxItemsOrdered.Items.Clear();
        }

    }
}
