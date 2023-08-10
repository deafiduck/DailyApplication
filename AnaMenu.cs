using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDaily
{
    public partial class AnaMenu : Form
    {
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
    }
}
