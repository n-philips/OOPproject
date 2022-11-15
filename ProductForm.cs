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
using Entities;

namespace GUI_Layer
{
    public partial class ProductForm : BasicForm
    {
        public ProductForm()
        {
            InitializeComponent();
            HideAllButtons();
        }

        ProductBLL prod = new ProductBLL();

        #region Hide, disable, and clear

        /// <summary>
        /// Hide and disable all unused buttons
        /// </summary>
        public void HideAllButtons()
        {
            labelName.Visible = false;
            labelNumber.Visible = false;
            labelcost.Visible = false;
            labelstock.Visible = false;
            textBoxcost.Visible = false;
            textBoxname.Visible = false;
            textBoxnumber.Visible = false;
            textBoxstock.Visible = false;
            buttonSubmitCreate.Visible = false;
            labelEnter.Visible = false;
            listBoxShowAll.Visible = false;
            labelPromptToEnterProdIDUpdate.Visible = false;
            buttonDelete.Visible = false;
            buttonSubmitRead.Visible = false;
            buttonSubmitUpdate.Visible = false;
            buttonEditForUpdate.Visible = false;
            labelPromptToEnterProdIDRead.Visible = false;

            labelName.Enabled = false;
            labelNumber.Enabled = false;
            labelcost.Enabled = false;
            labelstock.Enabled = false;
            textBoxcost.Enabled = false;
            textBoxname.Enabled = false;
            textBoxnumber.Enabled = false;
            textBoxstock.Enabled = false;
            buttonSubmitCreate.Enabled = false;
            labelEnter.Enabled = false;
            listBoxShowAll.Enabled = false;
            labelPromptToEnterProdIDUpdate.Enabled = false;
            buttonDelete.Enabled = false;
            buttonSubmitRead.Enabled = false;
            buttonSubmitUpdate.Enabled = false;
            buttonEditForUpdate.Enabled = false;
            labelPromptToEnterProdIDRead.Visible = false;
        }

        public void ClearAllTextBoxes()
        {
            textBoxname.Text = null;
            textBoxnumber.Text = null;
            textBoxstock.Text = null;
            textBoxcost.Text = null;
        }
        #endregion

        #region Create

        //Pull up 'Create' buttons
        public override void Create()
        {
            HideAllButtons();
            ClearAllTextBoxes();
            labelName.Visible = true;
            labelNumber.Visible = true;
            labelcost.Visible = true;
            labelstock.Visible = true;
            textBoxcost.Visible = true;
            textBoxname.Visible = true;
            textBoxnumber.Visible = true;
            textBoxstock.Visible = true;
            buttonSubmitCreate.Visible = true;
            labelEnter.Visible = true;

            labelName.Enabled = true;
            labelNumber.Enabled = true;
            labelcost.Enabled = true;
            labelstock.Enabled = true;
            textBoxcost.Enabled = true;
            textBoxname.Enabled = true;
            textBoxnumber.Enabled = true;
            textBoxstock.Enabled = true;
            buttonSubmitCreate.Enabled = true;
            labelEnter.Enabled = true;
        }

        private void buttonSubmitCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxcost.TextLength != 0 && textBoxname.TextLength != 0 && textBoxnumber.TextLength != 0 && textBoxstock.TextLength != 0)
                {
                    Product pr = new Product(int.Parse(textBoxnumber.Text), textBoxname.Text, decimal.Parse(textBoxcost.Text), int.Parse(textBoxstock.Text));
                    prod.Create(pr);
                    MessageBox.Show("Product" + " " + pr.ProductName + " " + pr.ProductNumber + " " + "has been succesfully added");

                }
                else
                {
                    MessageBox.Show("Please fill all the fields");
                }
            }
            catch(ItemAlreadyExistsException)
            {
                MessageBox.Show("Product with this ID already exists");
            }
            catch
            {
                MessageBox.Show("Please check your information and try again", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Read All

        public override void ReadAll()
        {
            HideAllButtons();
            listBoxShowAll.Items.Clear();
            listBoxShowAll.Visible = true;
            listBoxShowAll.Enabled = true;
            try
            {
                foreach (var prod in prod.ReadAll())
                {
                    listBoxShowAll.Items.Add(prod);
                }
            }
            catch
            {
                MessageBox.Show("There are no products in stock", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Update

        //Pull up update buttons
        public override void Update()
        {
            HideAllButtons();
            ClearAllTextBoxes();
            labelNumber.Visible = true;
            textBoxnumber.Visible = true;
            labelPromptToEnterProdIDUpdate.Visible = true;
            buttonEditForUpdate.Visible = true;

            labelNumber.Enabled = true;
            textBoxnumber.Enabled = true;
            labelPromptToEnterProdIDUpdate.Enabled = true;
            buttonEditForUpdate.Enabled = true;
        }

        //Find the product user wants to update
        private void buttonEditForUpdate_Click(object sender, EventArgs e)
        {
            if (textBoxnumber.TextLength != 0)
            {
                int prodNum = int.Parse(textBoxnumber.Text);
                if (ReadProduct(prodNum) == true)
                {
                    buttonEditForUpdate.Visible = false;
                    buttonEditForUpdate.Enabled = false;
                    buttonSubmitUpdate.Visible = true;
                    buttonSubmitUpdate.Enabled = true;
                    textBoxnumber.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Please enter the product ID of the item you would like to update", "No input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Update - update the product that the user entered the ID of
        private void buttonSubmitUpdate_Click(object sender, EventArgs e)
        {
            if (textBoxname.TextLength != 0 && textBoxcost.TextLength != 0 && textBoxstock.TextLength != 0)
            {
                Product updated = new Product();
                updated.ProductNumber = int.Parse(textBoxnumber.Text);
                updated.ProductName = textBoxname.Text;
                updated.CostPerUnit = decimal.Parse(textBoxcost.Text);
                updated.AmountInStock = int.Parse(textBoxstock.Text);
                prod.Update(updated);
                MessageBox.Show($"Product {updated.ProductNumber} has been successfully updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        #region Read Item

        //Pull up read buttons
        public override void ReadItem()
        {
            HideAllButtons();
            ClearAllTextBoxes();
            labelNumber.Visible = true;
            textBoxnumber.Visible = true;
            labelPromptToEnterProdIDRead.Visible = true;
            buttonSubmitRead.Visible = true;

            labelNumber.Enabled = true;
            textBoxnumber.Enabled = true;
            labelPromptToEnterProdIDRead.Enabled = true;
            buttonSubmitRead.Enabled = true;
        }

        // Read product - used by read button, and by update button
        public bool ReadProduct(int prodNumber)
        {
            try
            {
                Product readProd = prod.ReadItem(prodNumber);
                labelName.Visible = true;
                labelcost.Visible = true;
                labelstock.Visible = true;
                textBoxcost.Visible = true;
                textBoxname.Visible = true;
                textBoxstock.Visible = true;

                labelName.Enabled = true;
                labelcost.Enabled = true;
                labelstock.Enabled = true;
                textBoxcost.Enabled = true;
                textBoxname.Enabled = true;
                textBoxstock.Enabled = true;

                textBoxname.Text = readProd.ProductName;
                textBoxstock.Text = $"{readProd.AmountInStock}";
                textBoxcost.Text = $"{readProd.CostPerUnit}";
                return true;
            }
            catch
            {
                MessageBox.Show("Product not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //this code is never reached
            return false;
        }

        //read out the porduct the user entered the ID of
        private void buttonSubmitRead_Click(object sender, EventArgs e)
        {
            if (textBoxnumber.TextLength != 0)
            {
                int productID = int.Parse(textBoxnumber.Text);
                if (ReadProduct(productID) == true)
                {
                    textBoxnumber.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Please enter the ID of the product you would like to see");
            }
        }
        #endregion

        #region Delete

        // Pull up delete buttons
        public override void Delete()
        {
            HideAllButtons();
            ClearAllTextBoxes();
            textBoxnumber.Visible = true;
            labelNumber.Visible = true;
            buttonDelete.Visible = true;

            textBoxnumber.Enabled = true;
            labelNumber.Enabled = true;
            buttonDelete.Enabled = true;
        }

        // Delete - remove the product that the user entered the ID of
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxnumber.TextLength != 0)
                {
                    int productId = int.Parse(textBoxnumber.Text);
                    prod.Delete(productId);
                    MessageBox.Show("Product" + " " + productId + " " + "has been succesfully removed");
                }
                else
                {
                    MessageBox.Show("Please fill all the fields");
                }
            }
            catch
            {
                MessageBox.Show("Product not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion


        private void ProductForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
