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

namespace AsiTakipSistemi
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=FURKAN;Initial Catalog=AsiTakipSistemi;Integrated Security=True");

        private void Form3_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label3.Text = DateTime.Now.ToShortDateString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToLongTimeString();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string tc;
            tc = textBox1.Text;

            if(tc.Length != 11)
            {
                MessageBox.Show("Tekrar girin!!");
            }
            else
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("select * from Hasta where TC ='" + tc + "'", baglanti);
                SqlDataAdapter adptr = new SqlDataAdapter(komut);

                DataTable dt = new DataTable();
                adptr.Fill(dt);
                dataGridView1.DataSource = dt;

                baglanti.Close();


            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = "";
        }
    }
}
