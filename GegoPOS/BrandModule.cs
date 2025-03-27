using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GegoPOS
{
    public partial class BrandModule : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect DBConnect = new DBConnect();
        Brand brand;
        public BrandModule(Brand br)
        {
            InitializeComponent();
            conn = new SqlConnection(DBConnect.myConnection());
            brand = br;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //This one is for inserting a new brand to the DB
            try 
            {

                if (MessageBox.Show("Save this Brand?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                { 
                    conn.Open();
                    cmd =new SqlCommand ("Insert into tbBrand(Brand) VALUES (@brand)", conn);
                    cmd.Parameters.AddWithValue("@brand", txtBrandName.Text);
                    cmd.ExecuteNonQuery();
                
                    conn.Close();
                    MessageBox.Show("Brand saved successfully", "GegoPOS");
                    Clear();
                    brand.LoadBrand();

                }
            
            } 
            catch(Exception ex)  
            {
                MessageBox.Show(ex.Message);
            
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           Clear();

        }
        public void Clear()
        { 
            txtBrandName.Clear(); 
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            txtBrandName.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to update the Brand", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                conn.Open();
                cmd = new SqlCommand("UPDATE tbBrand SET Brand = @brand WHERE Id Like'" + lblId.Text+ "'", conn);
                cmd.Parameters.AddWithValue("@brand",txtBrandName.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Brand Updated Successfully", "GegoPOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                this.Dispose();
            }
        }
    }
}
