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

namespace Otopark_Otomasyonu
{
    public partial class frmseri : Form
    {
        public frmseri()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FS52QEK;Initial Catalog=otopark;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into seribilgi(marka,seri) values('"+comboBox1.Text+"' , '"+textBox1.Text+"')",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Seri Eklendi");
            comboBox1.Text = "";
            comboBox1.Items.Clear();
            Markaa();
        }

        private void frmseri_Load(object sender, EventArgs e)
        {
            Markaa();
        }

        private void Markaa()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select marka from markabilgi ", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboBox1.Items.Add(read["marka"].ToString());
            }
            baglanti.Close();
        }
    }
}
