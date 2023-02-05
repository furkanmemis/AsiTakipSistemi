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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=FURKAN;Initial Catalog=AsiTakipSistemi;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label1.Text = DateTime.Now.ToShortDateString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongTimeString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ad = textBox1.Text;
            string email = textBox2.Text;
            string adres = textBox3.Text;
            string telefon = textBox4.Text;

            if (adres == "" || ad == "" || telefon == "")
            {
                MessageBox.Show("Eksik bilgiler var!!");
            }
            else
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into Hastane(Ad,Email,Adres,TelefonNo) values(@p1,@p2,@p3,@p4)", baglanti);
                komut.Parameters.AddWithValue("@p1", ad);
                komut.Parameters.AddWithValue("@p2", email);
                komut.Parameters.AddWithValue("@p3", adres);
                komut.Parameters.AddWithValue("@p4", telefon);
                komut.ExecuteNonQuery();

                baglanti.Close();
                MessageBox.Show("Yeni hastane eklendi");

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";



            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ad = textBox5.Text;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Hastane where Ad ='" + ad + "'", baglanti);
            SqlDataAdapter adptr = new SqlDataAdapter(komut);

            DataTable dt = new DataTable();
            adptr.Fill(dt);
            dataGridView1.DataSource = dt;

            baglanti.Close();
            textBox5.Text = "";
        }
    }
}
