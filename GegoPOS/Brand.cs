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
    public partial class Brand : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect DBConnect = new DBConnect();
        SqlDataReader dr;
 

        public Brand()
        {
            InitializeComponent();
            conn = new SqlConnection(DBConnect.myConnection());
            LoadBrand();
           
        }
        //Retrieve data from the Brands table to this gridview
        public void LoadBrand()
        {
            int i = 0;
            dgvBrand.Rows.Clear();
            conn.Open();
            cmd= new SqlCommand("SELECT * FROM tbBrand ORDER BY Brand",conn); 
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvBrand.Rows.Add(i, dr["Id"].ToString(), dr["Brand"].ToString());
            }
            dr.Close();
            conn.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BrandModule moduleForm = new BrandModule(this);
            moduleForm.ShowDialog();
        }

        private void dgvBrand_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Update and delete from the grid
            string colName = dgvBrand.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete the Brand", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cmd = new SqlCommand("Delete from tbBrand where Id Like'" + dgvBrand[1, e.RowIndex].Value.ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Brand Deleted Successfully", "GegoPOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (colName == "Edit")
            {
                BrandModule brandModule = new BrandModule(this);
                brandModule.lblId.Text = dgvBrand[1, e.RowIndex].Value.ToString();
                brandModule.txtBrandName.Text = dgvBrand[2, e.RowIndex].Value.ToString();
                brandModule.btnSave.Enabled = false;
                brandModule.btnUpdate.Enabled = true;
                brandModule.ShowDialog();
            }
                LoadBrand();
            
        }
    }
}
