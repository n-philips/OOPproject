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
    public partial class BasicForm : Form
    {
        public BasicForm()
        {
            InitializeComponent();
        }

        #region Button clicks

        private void buttonNew_Click(object sender, EventArgs e)
        {
            Create();
        }

        private void buttonReadAll_Click(object sender, EventArgs e)
        {
            ReadAll();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            ReadItem();
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            Delete();

        }

        #endregion

        #region Methods

        public virtual void Create()
        {

        }

        public virtual void ReadAll()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void ReadItem()
        {

        }

        public virtual void Delete()
        {

        }

        #endregion

        private void buttonGoToMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            foreach (Form form in Application.OpenForms)
            {
                if (form is StartUpForm)
                {
                    form.Show();
                    break;
                }
            }
        }
    }
}
