using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GegoPOS
{
    public partial class MainForm : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect DBConnect = new DBConnect();
        public MainForm()
        {
            InitializeComponent();
            CustomizeDesing();
            conn = new SqlConnection(DBConnect.myConnection());
            MessageBox.Show("I am connected");
            conn.Open();
            conn.Close();
        }
        #region panelSlide
       
        private void CustomizeDesing()
        { 
            panelSubProduct.Visible = false;
            panelSubRecord.Visible = false;
            panelSubStock.Visible = false;
            panelSubSetting.Visible = false;  
        
        }

        private void hideSubmenu() 
        { 
            if (panelSubProduct.Visible== true)
                 panelSubProduct.Visible = false;
            if (panelSubRecord.Visible == true)
                panelSubRecord.Visible = false;
            if (panelSubStock.Visible == true)
                panelSubStock.Visible = false;
            if (panelSubSetting.Visible == true)
                panelSubSetting.Visible = false;
        }
        private void showSubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubmenu();
                submenu.Visible = true;
            }
            else
            {
                submenu.Visible = false;
            }
        }
        #endregion panelSlide
        
        private Form activeForm=null;
        public void openChildForm(Form childForm) 
        {
        if(activeForm != null)
                activeForm.Close();
        activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            lblTitle.Text =childForm.Text;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {

        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            showSubmenu(panelSubProduct);
        }

        private void btnProductList_Click(object sender, EventArgs e)
        {
            hideSubmenu();  
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void btnBrand_Click(object sender, EventArgs e)
        {
            openChildForm(new Brand());
            hideSubmenu();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            showSubmenu(panelSubStock);
        }

        private void btnStockEntry_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void btnStockAdjustment_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            showSubmenu(panelSubRecord);
        }

        private void btnSaleHistory_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void btnPOSRecord_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            showSubmenu(panelSubSetting);
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            hideSubmenu();

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }
    }
}
