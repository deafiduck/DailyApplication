using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


namespace MyDaily
{
    public partial class Kayit : Form
    {
        String sifre1="";
        String sifre2="";

        public string conString = "Data Source=DESKTOP-N5A035R;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        public Kayit()
        {
            InitializeComponent();
        }

       
        private void Kayit_Load(object sender, EventArgs e)
        {

        }

        private void TxtMail_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtAdi_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtKullaniciAdi_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtSifre_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtSifre2_TextChanged(object sender, EventArgs e)
        {

            if (sifre1 != sifre2)
            {
                //hata ver
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void TxtSifre2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "insert into Test(adi,mail,kullaniciAdi,sifre)values( " +TxtAdi.Text.ToString()+ "')" + TxtMail.Text.ToString()+ "')"+TxtKullaniciAdi.Text.ToString()+ "')" + TxtSifre.Text.ToString()+"')";
                SqlCommand cmd=new SqlCommand(q,con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Connection made Succesfully");

            }
        }
    }
}
