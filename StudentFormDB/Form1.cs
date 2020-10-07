using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentFormDB
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
           this.BackColor = Color.FromArgb(140, 234, 242);
          // pictureBox3.BackColor = Color.FromArgb(140, 234, 242);
            panel1.BackColor = Color.FromArgb(140, 234, 242);
            //  label3.BackColor = Color.FromArgb(44, 76, 148);
            btnCancel.BackColor = Color.FromArgb(44, 76, 148);
            btnSave.BackColor = Color.FromArgb(44, 76, 148);
            panel2.BackColor = Color.FromArgb(140, 234, 242);
            panel3.BackColor = Color.FromArgb(140, 234, 242);
            btnGet.BackColor = Color.FromArgb(44, 76, 148);
            btnUpdate.BackColor = Color.FromArgb(44, 76, 148);
            btnDelete.BackColor = Color.FromArgb(44, 76, 148);
           // label3.BackColor = Color.FromArgb(217, 226, 245);
            
           // label14.ForeColor = Color.FromArgb(45, 148, 241);
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server=LAPTOP-Q2N7MAED\SQLEXPRESS ;Database=StudentInformation;Trusted_Connection=True");
            con.Open();
            MessageBox.Show("connected");
            SqlCommand cmd = new SqlCommand("StudentGet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", txtIdGet.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtGetName.Text = dr["Name"].ToString();
                txtGetEmail.Text = dr["Email"].ToString();
                txtGetPhone.Text = dr["Phone"].ToString();

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {

                #region DatabaseSave
                if (txtName.Text != ""&&txtPhone.Text!=""&&txtEmail.Text!="")
                {
                 SqlConnection con = new SqlConnection(@"Server=LAPTOP-Q2N7MAED\SQLEXPRESS ;Database=StudentInformation;Trusted_Connection=True");
                con.Open();
                    Int64 tempPhone = Convert.ToInt64(txtPhone.Text);
                // MessageBox.Show("connected");
                SqlCommand cmd = new SqlCommand("StudentSave", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Phone", tempPhone.ToString());
                cmd.ExecuteNonQuery();
                lstBox.Items.Add(txtName.Text);
                MessageBox.Show("Saved Succesfully",MessageBoxButtons.OK.ToString());
                con.Close();
            }
                else
            {
                MessageBox.Show("Plese Enter the Datas");
            }
            #endregion
        }
            catch (Exception)
            {

                MessageBox.Show("Invalid Data",MessageBoxIcon.Error.ToString(),MessageBoxButtons.OK);
            }
            txtName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
            #region DataDelete
            SqlConnection con = new SqlConnection(@"Server=LAPTOP-Q2N7MAED\SQLEXPRESS ;Database=StudentInformation;Trusted_Connection=True");
            con.Open();
            //MessageBox.Show("connected");
            SqlCommand cmd = new SqlCommand("StudentDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", txtIdDelete.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Deleted");
            txtIdDelete.Text = string.Empty;
            #endregion
            }
            catch (Exception)
            {
                MessageBox.Show("Enter Valid data","StudentInformation",MessageBoxButtons.OK);
                txtIdDelete.Text = "";
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region DataListBox
            SqlConnection con = new SqlConnection(@"Server=LAPTOP-Q2N7MAED\SQLEXPRESS ;Database=StudentInformation;Trusted_Connection=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("StudentName", con);
            // MessageBox.Show("connected");
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lstBox.Items.Add(dr["Name"].ToString());
            }
            con.Close(); 
            #endregion
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server=LAPTOP-Q2N7MAED\SQLEXPRESS ;Database=StudentInformation;Trusted_Connection=True");
            con.Open();
           
            // MessageBox.Show("connected");
            SqlCommand cmd = new SqlCommand("StudentUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", txtIdGet.Text);
            cmd.Parameters.AddWithValue("@Name", txtGetName.Text);
            cmd.Parameters.AddWithValue("@Email", txtGetEmail.Text);
            cmd.Parameters.AddWithValue("@Phone", txtGetPhone.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("StudentInformation","Deleted",MessageBoxButtons.OK);
            // lstBox.Items.Add(txtName.Text);
            con.Close();
        }
    }
}
