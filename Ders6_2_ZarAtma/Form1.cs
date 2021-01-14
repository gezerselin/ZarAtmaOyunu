using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ders6_2_ZarAtma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
             * bu oyunda iki oyuncu vardır
             * her oyuncunun bir zarı vardır
             * oyuncular zar atar
             * zarlar karşılaştırılır
             * büyük atan kazanır
             * 
             * nesneler
             *  - oyun
             *   -oyuncu
             *   -zar
             */

        }

        Oyun zarOyunu = new Oyun();
        private void ButonAd1_Click(object sender, EventArgs e)
        {
            string oyuncuAdi = textBoxOyuncu1Ad.Text;
            int BirinciOyuncuBakiye = Convert.ToInt32(textBoxOyuncu1Bakiye.Text);
            zarOyunu.BirinciOyuncu = new Oyuncu(oyuncuAdi, BirinciOyuncuBakiye);
            zarOyunu.BirinciOyuncu.OyuncununZari=new Zar();
            LabelOyuncu1Ad.Text = zarOyunu.BirinciOyuncu.Ad;
            labelOyuncu1Bakiye.Text = Convert.ToString(zarOyunu.BirinciOyuncu.Bakiye);

        }

        private void buttonAd2_Click(object sender, EventArgs e)
        {
            string ikinciOyuncu = textBoxOyuncu2Ad.Text;
            int İkinciOyuncuBakiye = Convert.ToInt32(textBoxOyuncu2Bakiye.Text);
            zarOyunu.İkinciOyuncu = new Oyuncu(ikinciOyuncu, İkinciOyuncuBakiye);
            zarOyunu.İkinciOyuncu.OyuncununZari = new Zar();
            LabelOyuncu2Ad.Text = zarOyunu.İkinciOyuncu.Ad;
            labelOyuncu2Bakiye.Text = Convert.ToString(zarOyunu.İkinciOyuncu.Bakiye);
        }

        private void birinciOyuncu_Click(object sender, EventArgs e)
        {
            zarOyunu.IlkOyuncuZarAt();
            labelOyuncu1Zar.Text = zarOyunu.BirinciOyuncu.OyuncununZari.Deger.ToString();
            ButtonIkinciOyuncu.Enabled = true;
            
        }

        private void ikinciOyuncu_Click(object sender, EventArgs e)
        {
            zarOyunu.IkinciOyuncuZarAt();
            labelOyuncu2Zar.Text = zarOyunu.İkinciOyuncu.OyuncununZari.Deger.ToString();
            Oyuncu EliKazananOyuncu = zarOyunu.Karsilastir();
            labelOyuncu1Bakiye.Text = Convert.ToString(zarOyunu.BirinciOyuncu.Bakiye);
            labelOyuncu2Bakiye.Text = Convert.ToString(zarOyunu.İkinciOyuncu.Bakiye);


            if (zarOyunu.BirinciOyuncu.Bakiye >= 0 && zarOyunu.İkinciOyuncu.Bakiye >= 0)
            {
                if (EliKazananOyuncu != null)
                {
                    labelKazanan.Text = $"{EliKazananOyuncu.Ad},{EliKazananOyuncu.OyuncununZari.Deger} atarak bu eli kazandı";
                }
                else
                {
                    labelKazanan.Text = "berabere";
                }
            }
            else
            {
                Oyuncu KazananOyunucu = zarOyunu.kazananBul();
                labelKazanan.Text = $"!!!!{KazananOyunucu.Ad} oyunu kazandı!!!";
                ButtonIkinciOyuncu.Enabled = false;
                birinciOyuncu.Enabled = false;
                buttonTekrarOyna.Enabled = true;
            }

        }

        private void buttonBahis_Click(object sender, EventArgs e)
        {
            string bahis = textBoxBahisTutari.Text;
            zarOyunu.Bahistutari = Convert.ToInt32(bahis);
            labelBahisTutar.Text = $"Bahis tutarı {zarOyunu.Bahistutari} olarak ayarlandı";
        }

        private void buttonTekrarOyna_Click(object sender, EventArgs e)
        {
            buttonTekrarOyna.Enabled = false;
            birinciOyuncu.Enabled = true;
            textBoxBahisTutari.Text= null;
            textBoxOyuncu1Ad.Text = null;
            textBoxOyuncu2Ad.Text = null;
            textBoxOyuncu1Bakiye.Text = null;
            textBoxOyuncu2Bakiye.Text = null;
            labelBahisTutar.Text = null;
            labelKazanan.Text= null;
            labelOyuncu1Bakiye.Text = null;
            labelOyuncu2Bakiye.Text=null;
            labelOyuncu1Zar.Text = null;
            labelOyuncu2Zar.Text = null;
            LabelOyuncu1Ad.Text = null;
            LabelOyuncu2Ad.Text = null;
            labelKazanan.Text = null;
            
        }
    }
}
