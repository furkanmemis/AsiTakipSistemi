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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AsiTakipSistemi
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=FURKAN;Initial Catalog=AsiTakipSistemi;Integrated Security=True");

        private void Form7_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label1.Text = DateTime.Now.ToShortDateString();

            baglanti.Open();

            SqlCommand komut = new SqlCommand("select * from Saglayici", baglanti);
            SqlCommand komut1 = new SqlCommand("select * from Asi", baglanti);
            
            SqlDataAdapter adptr = new SqlDataAdapter(komut);
            SqlDataAdapter adptr1 = new SqlDataAdapter(komut1);

            DataTable dt = new DataTable();
            adptr.Fill(dt);
            dataGridView1.DataSource = dt;

            DataTable dt1 = new DataTable();
            adptr1.Fill(dt1);
            dataGridView2.DataSource = dt1;

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

        private void button2_Click(object sender, EventArgs e)
        {
            string tedarikci_id = textBox1.Text;
            string asi_id = textBox2.Text;

            if(tedarikci_id == "" || asi_id == "")
            {
                MessageBox.Show("Tedarikçi ID`sini ve aşı ID`sini doğru bir şekilde giriniz!!");
            }
            else
            {
                string tarih = DateTime.Now.ToShortDateString();
                baglanti.Open();

                SqlCommand komut = new SqlCommand("insert into TedarikEder(AsiID,SaglayiciID,Tarih) values(@p1,@p2,@p3)", baglanti);

                komut.Parameters.AddWithValue("@p1", asi_id);
                komut.Parameters.AddWithValue("@p2", tedarikci_id);
                komut.Parameters.AddWithValue("@p3", tarih);
                komut.ExecuteNonQuery();

                baglanti.Close();

                MessageBox.Show("Yeni sipariş alındı!!");
                textBox1.Text = "";
                textBox2.Text = "";





            }



        }
    }
}
