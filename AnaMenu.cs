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
    public partial class AnaMenu : Form
    {
        public string kullanici;

        //public string connectionString = "Data Source=DESKTOP-N5A035R;Initial Catalog=Daily;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public AnaMenu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)//giris yap butonu
        {

        }

        private void button2_Click(object sender, EventArgs e)//kayıt ol butonu
        {
            Kayit kyt = new Kayit();
            kyt.Show();//o sahneye bağlıyoruz
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)//giriş yap buutonu 
        {

            
                Kayit KayitSayfasi=new Kayit();
                SqlConnection baglanti = new SqlConnection(KayitSayfasi.connectionString);
                    baglanti.Open();

                    string sql = "Select * from KullaniciEkle where KullaniciAdi=@adi AND KullaniciSifre=@sifre ";
            //girilen textle eşleşen değerleri buluyorum ve prm1 ve prm2den aldığım değerlerin de aynı olduğunu görüyorum
                    string kullanici2 = textBox1.Text.ToString();
                    SqlParameter prm1 = new SqlParameter("adi", textBox1.Text.Trim());
                    SqlParameter prm2 = new SqlParameter("sifre", textBox2.Text.Trim());
            
               
                    SqlCommand komut = new SqlCommand(sql, baglanti);
                    komut.Parameters.Add(prm1);
                    komut.Parameters.Add(prm2);

                //Sonuçları depolamak için bir DataTable nesnesi oluşturuluyor.
                //Bu nesne, SQL sorgusunun sonucunu tutar.
                DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)//DataTable nesnesinin içinde en az bir satır varsa (yani sorgunun sonucunda eşleşen bir kayıt varsa), bu blok çalışır.
                    {
                   
                     kullanici = kullanici2;

                    FrmMenu fm = new FrmMenu(kullanici2);
                        fm.Show();
                   
                

            }
                    else
                {
                    MessageBox.Show("Hatali giris");
                }
                    
            }
        }
    }

