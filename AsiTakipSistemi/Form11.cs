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

namespace AsiTakipSistemi
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=FURKAN;Initial Catalog=AsiTakipSistemi;Integrated Security=True");

        private void Form11_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label1.Text = DateTime.Now.ToShortDateString();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Randevu", baglanti);
            SqlDataAdapter adptr = new SqlDataAdapter(komut);

            DataTable dt = new DataTable();
            adptr.Fill(dt);
            dataGridView1.DataSource = dt;

            baglanti.Close();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongTimeString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Randevu", baglanti);
            SqlDataAdapter adptr = new SqlDataAdapter(komut);

            DataTable dt = new DataTable();
            adptr.Fill(dt);
            dataGridView1.DataSource = dt;

            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);

            if(textBox1.Text == "")
            {
                MessageBox.Show("Eksik bilgier var");
            }
            else
            {
                baglanti.Open();

                SqlCommand komut = new SqlCommand("delete from Randevu where RandevuID = @p1", baglanti);
                komut.Parameters.AddWithValue("@p1", id);

                komut.ExecuteNonQuery();

                baglanti.Close();

                MessageBox.Show("Randevu silindi");


                textBox1.Text = "";
            }


        }
    }
}
