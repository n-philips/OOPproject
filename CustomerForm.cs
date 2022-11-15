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
    public partial class CustomerForm : BasicForm
    {
        public CustomerForm()
        {
            InitializeComponent();
            HideAll();
            ClearAllTextBoxes();
        }

        CustomerBLL custbll = new CustomerBLL();

        public void HideAll()
        {
            labelPromptEnterCustInfo.Visible = false;
            labelName.Visible = false;
            labelID.Visible = false;
            textBoxname.Visible = false;
            textBoxID.Visible = false;

            labelPromptEnterCustInfo.Enabled = false;
            labelName.Enabled = false;
            labelID.Enabled = false;
            textBoxname.Enabled = false;
            textBoxID.Enabled = false;

            labelPromptEnterCredCardInfo.Visible = false;
            labelCreditCardNum.Visible = false;
            labelExpDate.Visible = false;
            labelCVV.Visible = false;
            labelCharges.Visible = false;
            textBoxCardNum.Visible = false;
            textBoxMonth.Visible = false;
            labelMonth.Visible = false;
            textBoxYear.Visible = false;
            labelYear.Visible = false;
            textBoxCVV.Visible = false;
            textBoxCharges.Visible = false;

            labelPromptEnterCredCardInfo.Enabled = false;
            labelCreditCardNum.Enabled = false;
            labelExpDate.Enabled = false;
            labelCVV.Enabled = false;
            labelCharges.Enabled = false;
            textBoxCardNum.Enabled = false;
            textBoxMonth.Enabled = false;
            labelMonth.Enabled = false;
            textBoxYear.Enabled = false;
            labelYear.Enabled = false;
            textBoxCVV.Enabled = false;
            textBoxCharges.Enabled = false;

            buttonCreateCustomer.Visible = false;
            buttonCreateCustomer.Enabled = false;

            buttonSubmitRead.Visible = false;
            buttonSubmitRead.Enabled = false;

            listBoxRead.Visible = false;
            listBoxRead.Enabled = false;

            buttonEditForUpdate.Visible = false;
            buttonEditForUpdate.Enabled = false;

            labelPromptToEditCustInfo.Visible = false;
            labelPromptToEditCustInfo.Enabled = false;
            buttonSubmitUpdate.Visible = false;
            buttonSubmitUpdate.Enabled = false;

            buttonSubmitDelete.Visible = false;
            buttonSubmitDelete.Enabled = false;
        }

        public void ClearAllTextBoxes()
        {
            textBoxname.Text = null;
            textBoxID.Text = null;
            textBoxCardNum.Text = null;
            textBoxCVV.Text = null;
            textBoxMonth.Text = null;
            textBoxYear.Text = null;
            textBoxCharges.Text = null;
        }

        #region Create

        public override void Create()
        {
            HideAll();
            ShowCreateControls();
        }

        public void ShowCreateControls()
        {
            labelPromptEnterCustInfo.Visible = true;
            labelName.Visible = true;
            labelID.Visible = true;
            textBoxname.Visible = true;
            textBoxID.Visible = true;

            labelPromptEnterCustInfo.Enabled = true;
            labelName.Enabled = true;
            labelID.Enabled = true;
            textBoxname.Enabled = true;
            textBoxID.Enabled = true;

            labelPromptEnterCredCardInfo.Visible = true;
            labelCreditCardNum.Visible = true;
            labelExpDate.Visible = true;
            labelCVV.Visible = true;
            labelCharges.Visible = true;
            textBoxCardNum.Visible = true;
            textBoxMonth.Visible = true;
            labelMonth.Visible = true;
            textBoxYear.Visible = true;
            labelYear.Visible = true;
            textBoxCVV.Visible = true;
            textBoxCharges.Visible = true;

            labelPromptEnterCredCardInfo.Enabled = true;
            labelCreditCardNum.Enabled = true;
            labelExpDate.Enabled = true;
            labelCVV.Enabled = true;
            labelCharges.Enabled = true;
            textBoxCardNum.Enabled = true;
            textBoxMonth.Enabled = true;
            labelMonth.Enabled = true;
            textBoxYear.Enabled = true;
            labelYear.Enabled = true;
            textBoxCVV.Enabled = true;
            textBoxCharges.Enabled = true;

            buttonCreateCustomer.Visible = true;
            buttonCreateCustomer.Enabled = true;
        }

        private void buttonCreateCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxname.TextLength != 0 && textBoxID.TextLength != 0 && textBoxCardNum.TextLength != 0 && textBoxMonth.TextLength != 0 && textBoxCVV.TextLength != 0 && textBoxCharges.TextLength != 0)
                {
                    string name = textBoxname.Text;
                    int id = int.Parse(textBoxID.Text);
                    string cardnum = textBoxCardNum.Text;
                    int year = int.Parse(textBoxYear.Text);
                    int month = int.Parse(textBoxMonth.Text);
                    string cvv = textBoxCVV.Text;
                    decimal charges = decimal.Parse(textBoxCharges.Text);
                    Date expdate = new Date(month, year);
                    CreditCard crdt = new CreditCard(name, cardnum, expdate, cvv, charges);
                    Customer cust = new Customer(name, id, crdt);
                    custbll.Create(cust);

                    MessageBox.Show("Customer" + " " + cust.Name + " " + "has been succesfully added");

                }
                else
                {
                    MessageBox.Show("Please fill all the fields");
                }
            }
            catch(ItemAlreadyExistsException)
            {
                MessageBox.Show("Customer with this ID already exists");
            }
            catch
            {
                MessageBox.Show("Please check your information and try again", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Read_Item

        /// <summary>
        /// show 'Read' controls and prompt user to enter ID
        /// </summary>
        public override void ReadItem()
        {
            HideAll();
            ClearAllTextBoxes();
            labelID.Visible = true;
            labelID.Enabled = true;
            textBoxID.Visible = true;
            textBoxID.Enabled = true;
            buttonSubmitRead.Visible = true;
            buttonSubmitRead.Enabled = true;
        }

        /// <summary>
        /// Send (user input) ID to read method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSubmitRead_Click(object sender, EventArgs e)
        {
            if(textBoxID.TextLength != 0)
            {
                int custID = int.Parse(textBoxID.Text);
                ReadCustomer(custID);
            }
            else
            {
                MessageBox.Show("Please enter the ID of the customer you would like to view", "No input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Read a customer from list and display
        /// </summary>
        /// <param name="custID"></param>
        /// <returns></returns>
        public bool ReadCustomer(int custID)
        {
            try
            {
                Customer readCust = custbll.ReadItem(custID);

                buttonSubmitRead.Visible = false;
                buttonSubmitRead.Enabled = false;

                labelName.Visible = true;
                labelName.Enabled = true;
                labelCreditCardNum.Visible = true;
                labelCreditCardNum.Enabled = true;
                labelExpDate.Visible = true;
                labelExpDate.Enabled = true;
                labelCVV.Visible = true;
                labelCVV.Enabled = true;
                labelCharges.Visible = true;
                labelCharges.Enabled = true;

                textBoxname.Visible = true;
                textBoxname.Enabled = true;
                textBoxCardNum.Visible = true;
                textBoxCardNum.Enabled = true;
                textBoxCVV.Visible = true;
                textBoxCVV.Enabled = true;
                textBoxYear.Visible = true;
                textBoxYear.Enabled = true;
                textBoxMonth.Visible = true;
                textBoxMonth.Enabled = true;
                textBoxCharges.Visible = true;
                textBoxCharges.Enabled = true;
                

                textBoxname.Text = readCust.Name;
                textBoxCardNum.Text = $"{readCust.CustomerCard.CreditCardNumber}";
                textBoxYear.Text = $"{readCust.CustomerCard.ExpirationDate.Year}";
                textBoxMonth.Text = $"{readCust.CustomerCard.ExpirationDate.Month}";
                textBoxCVV.Text = readCust.CustomerCard.CVV;
                textBoxCharges.Text = $"{ readCust.CustomerCard.Charges}";

                return true;
            }
            catch
            {
                MessageBox.Show("Customer not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //this code is never reached
            return false;
        }
        #endregion

        #region ReadAll

        public override void ReadAll()
        {
            HideAll();
            listBoxRead.Items.Clear();
            listBoxRead.Visible = true;
            listBoxRead.Enabled = true;

            try
            {
                foreach (var cust in custbll.ReadAll())
                {
                    listBoxRead.Items.Add(cust);
                }
            }
            catch
            {
                MessageBox.Show("There are no customers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Update

        /// <summary>
        /// show 'Update' controls and prompt user to enter ID
        /// </summary>
        public override void Update()
        {
            HideAll();
            ClearAllTextBoxes();
            labelID.Visible = true;
            labelID.Enabled = true;
            textBoxID.Visible = true;
            textBoxID.Enabled = true;
            buttonEditForUpdate.Visible = true;
            buttonEditForUpdate.Enabled = true;
        }

        /// <summary>
        /// Show customer info and prompt user to update desired fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEditForUpdate_Click(object sender, EventArgs e)
        {
            if (textBoxID.TextLength != 0)
            {
                int custID = int.Parse(textBoxID.Text);
                //ReadCustomer(custID);

                if (ReadCustomer(custID) == true)
                {
                    buttonEditForUpdate.Visible = false;
                    buttonEditForUpdate.Enabled = false;
                    buttonSubmitUpdate.Visible = true;
                    buttonSubmitUpdate.Enabled = true;
                    textBoxID.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Please enter the ID of the customer you would like to update", "No input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        /// <summary>
        /// Update customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSubmitUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxname.TextLength != 0 && textBoxCardNum.TextLength != 0 && textBoxYear.TextLength != 0 && textBoxMonth.TextLength != 0 && textBoxCVV.TextLength != 0)
                {
                    Customer updated = new Customer();
                    updated.Name = textBoxname.Text;
                    updated.ID = int.Parse(textBoxID.Text);
                    int year = int.Parse(textBoxYear.Text);
                    int month = int.Parse(textBoxMonth.Text);
                    Date expdate = new Date(month, year);
                    CreditCard crdt = new CreditCard(textBoxname.Text, textBoxCardNum.Text, expdate, textBoxCVV.Text, decimal.Parse(textBoxCharges.Text));
                    updated.CustomerCard = crdt;
                    custbll.Update(updated);
                    MessageBox.Show($"Product {updated.ID} has been successfully updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Invalid input. Please check your informatoin and try again", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        #endregion 

        #region Delete
        public override void Delete()
        {
            HideAll();
            ClearAllTextBoxes();
            labelID.Visible = true;
            textBoxID.Visible = true;
            buttonSubmitDelete.Visible = true;
            labelID.Enabled = true;
            textBoxID.Enabled = true;
            buttonSubmitDelete.Enabled = true;
        }

        private void buttonSubmitDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxID.TextLength != 0)
                {
                    int custID = int.Parse(textBoxID.Text);
                    custbll.Delete(custID);
                    MessageBox.Show("Customer" + " " + custID + " " + "has been succesfully removed");
                }
                else
                {
                    MessageBox.Show("Please fill all the fields");
                }
            }
            catch(ItemNotFoundException)
            {
                MessageBox.Show("Product not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void CustomerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
