using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hastane_randevu_sistemi
{
    public partial class Sonuc : Form
    {
        public Sonuc()
        {
            InitializeComponent();
        }
        Random rastgele = new Random();
        int sayac = 1;
        private void button2_Click(object sender, EventArgs e)
        {



                ++sayac;
            if (sayac %2==0)
                richTextBox1.Clear();
                int sayi = rastgele.Next(1, 4);

                StreamReader sr = new StreamReader(@"C:\Users\lenovo\Desktop\hastane\sonuc" + sayi + ".txt");
                richTextBox1.Text +="Sonuc"+sayi+" Adlı Dosya Sahibinin Sonuçları \n"+ sr.ReadToEnd()+"\n";
                
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {



            ++sayac;
            if (sayac %2==0)
                richTextBox1.Clear();
            int sayi2 = rastgele.Next(1, 4);

            StreamReader sr = new StreamReader(@"C:\Users\lenovo\Desktop\hastane\sonuc" + sayi2 + ".txt");
            richTextBox1.Text += "Sonuc" + sayi2 + " Adlı Dosya Sahibinin Sonuçları \n" + sr.ReadToEnd() + "\n";
        }
    }
}
