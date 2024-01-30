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

namespace CRUDStoredProcedure
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-KA53HTR;Initial Catalog=CRUD_SP;Persist Security Info=True;User ID=sa;Password=7GbE6:cX1NQG");

        private void button1_Click(object sender, EventArgs e)
        {
            int empid = int.Parse(txtID.Text);
            string empname = txtName.Text, city = cbCity.Text, contact = txtContact.Text, sex = "";
            DateTime Joindate = DateTime.Parse(txtJoiningDate.Text);
            int age = int.Parse(txtAge.Text);
            
            if (rbMale.Checked == true)
            {
                sex = "Male";
            }
            else
            {
                sex = "Female";
            }
            con.Open();
            SqlCommand c = new SqlCommand($"exec InsertEmp_SP {empid}, {empname}, {city}, {age}, {sex}, {Joindate}, {contact}", con);
            c.ExecuteNonQuery();
            MessageBox.Show("Successfully inserted!...");
            getEmpList();
        }

        void getEmpList()
        {
            SqlCommand c = new SqlCommand("exec ListEmp", con);
            SqlDataAdapter sd = new SqlDataAdapter(c);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getEmpList();
        }
    }
}
