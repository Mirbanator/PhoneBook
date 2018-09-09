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
namespace PhoneBook
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mrb\Documents\contacts.mdf;Integrated Security=True;Connect Timeout=30");
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e) //Add method
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Table123 values('" + ID_textbox.Text + "','" + FirstName.Text+"','"+LastName.Text+"','"+PhoneNr.Text+"')";
            cmd.ExecuteNonQuery();
            con.Close();
            show_data();
            MessageBox.Show("contact added");
        }
        public void show_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Table123";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            show_data();
        }

        private void button2_Click(object sender, EventArgs e) //Edit method
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Table123 set fname='" +FirstName.Text+ "', lname='" + LastName.Text + "',phonenr='" + PhoneNr.Text + "' where id='" + ID_textbox.Text+"'";
            cmd.ExecuteNonQuery();
            con.Close();
            show_data();
            MessageBox.Show("Contact updated");
        }

        private void button3_Click(object sender, EventArgs e) //Delete method
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Table123 where fname='"+FirstName.Text+"'";
            cmd.ExecuteNonQuery();
            con.Close();
            show_data();
            MessageBox.Show("Contact deleted");
        }

        private void button4_Click(object sender, EventArgs e) //Search method
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Table123 where fname like'%"+Search.Text+"%'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void ShowData_Click(object sender, EventArgs e)
        {
            show_data();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)  //Shows selected column data in textviews
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            ID_textbox.Text = dataGridView1[0, dataGridView1.SelectedRows[0].Index].Value.ToString();
            FirstName.Text = dataGridView1[1, dataGridView1.SelectedRows[0].Index].Value.ToString();
            LastName.Text = dataGridView1[2, dataGridView1.SelectedRows[0].Index].Value.ToString();
            PhoneNr.Text = dataGridView1[3, dataGridView1.SelectedRows[0].Index].Value.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
