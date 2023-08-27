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

namespace MyDaily
{
    public partial class Sayfa : Form
    {

       

        public Sayfa()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void Kaydet_Click(object sender, EventArgs e)
        {
            AnaMenu ana = new AnaMenu();
            Kayit KayitS = new Kayit();
            SqlConnection baglanti = new SqlConnection(KayitS.connectionString);
            baglanti.Open();

            string date;
            date = dateTimePicker1.Text;
            //buraya yazılanları txtye kaydet 
            string metin = richTextBox1.Text;

            StreamWriter sw = new StreamWriter(date);
            sw.WriteLine(metin);
            sw.Close();
            MessageBox.Show("basarili");
        }
    }
}
