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

namespace MyDaily
{
    public partial class Derslerim : Form
    {

        string connectionString = "Data Source=DESKTOP-N5A035R;Initial Catalog=Daily;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public Derslerim()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(connectionString);
            baglanti.Open();

            string sql = "SELECT DISTINCT DersAdi FROM Dersler WHERE Donem=@Donem";
            SqlParameter prm1 = new SqlParameter("Donem", listBox1.Text);

            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.Add(prm1);

            using (SqlDataReader reader = komut.ExecuteReader())
            {
                while (reader.Read())
                {
                    string dersAdi = reader["DersAdi"].ToString();
                    checkedListBox1.Items.Add(dersAdi);
                }
            }

            baglanti.Close();



            // MessageBox.Show("Bu dönemde ders yok");


        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
