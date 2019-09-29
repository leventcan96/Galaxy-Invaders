using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Proje
{
    class AnaPencere:Form
    {
        List<DusmanUcak> dusmanucaklar = new List<DusmanUcak>();
        List<Mermi> mermiler = new List<Mermi>();
        Timer zamanlayici;//dusman ucak zamanlayıcısı
        Timer zamanlayici1;//mermi zamanlayıcısı
        DusmanUcak dusman;
         DostUcak dost;
         Mermi mermi;
        int ucaksayisi = 1,sayac=0;
        bool flag;              //Gerekli karşılaştımalar için bayraklar tanımladım
        bool baslat,bittimi;    //Gerekli karşılaştımalar için bayraklar tanımladım
        public AnaPencere(int genislik, int yukseklik)
        {
            DoubleBuffered = true;
            Width = genislik;
            Height = yukseklik;
            Paint += AnaPencere_Paint;
            KeyDown += AnaPencere_KeyDown;
            //  BackgroundImage = Image.FromFile("gökyüzü.jpg");   // ARKAPLANDA KOYDUM AMA ÇALIŞTIRINCA KASIYOR
            dost = new DostUcak();
            baslat = false;
            bittimi = false;
            zamanlayici = new Timer();
            zamanlayici1 = new Timer();
            zamanlayici.Interval = 120;
            zamanlayici1.Interval = 1;
            zamanlayici.Tick += zamanlayici_Tick;
            zamanlayici1.Tick += zamanlayici1_Tick;

                        
           
        }
        void restart()//tüm nesneleri sile fonksiyon
        {
            dusmanucaklar.Clear();
            mermiler.Clear();
            dost = new DostUcak();

        }
        void zamanlayici1_Tick(object sender, EventArgs e)
        {
            foreach (Mermi eleman in mermiler)
            {

            foreach (DusmanUcak eleman1 in dusmanucaklar)
            {
                if (eleman.Y == eleman1.Y+50 && eleman1.X-58 <= eleman.X && eleman.X <= eleman1.X + 58)//mermi ve düşman uçak çarpışmasını kontrol eden if
                {
                    flag = true;
                    ucaksayisi--;
                    dusmanucaklar.Remove(eleman1);
                    mermiler.Remove(eleman);
                    break;
                }


            }
            if (flag == true)
            {
                flag = false;
                break;
            }
            if (eleman.Y == -45)
            {

                mermiler.Remove(eleman);
                break;
            }
            else
            eleman.Y = eleman.Y - 5;
            }

            Invalidate();
        }

        void zamanlayici_Tick(object sender, EventArgs e)
        {
            sayac++;
            if (sayac >= 10)
          { 
             if (ucaksayisi < 10)
            { 
            dusman = new DusmanUcak();
            dusmanucaklar.Add(dusman);
            ucaksayisi++; sayac = 0;
            }
          }
            foreach (DusmanUcak eleman in dusmanucaklar)
            {

                if (eleman.Y == Height-150)//dusman ucak en alt alana ulaşırsa
                {
                    baslat = false;
                    ucaksayisi = 0; 
                    sayac = 0;
                    zamanlayici.Stop();
                    zamanlayici1.Stop();
                    MessageBox.Show("GAME OVER!!!");
                    bittimi = true;
                    break;
                }
                else
                    eleman.Y = eleman.Y + 5;
            }
            
          
            Invalidate();
        }


        void AnaPencere_KeyDown(object sender, KeyEventArgs e)
        {
          
            
             
            switch (e.KeyCode)//tuşlara basıldığında yapılıcaklar
            {
                case Keys.A:
                    if(baslat)
                    dost.SolaGit();
                    break;
                case Keys.D:
                    if (baslat)
                    dost.SagaGit();
                    break;
                case Keys.Space:
                    if (baslat){
                     mermi = new Mermi();
                     mermi.X = dost.X;
                     mermi.Y = dost.Y;
                      mermiler.Add(mermi); 
                        }
                    break;
                    
                case Keys.Enter:
                    if(bittimi)
                    {
                        bittimi = false;
                         restart();

                    }

                    baslat = true;
                    zamanlayici.Start();
                    zamanlayici1.Start();
                    break;
                
            
            }
            Invalidate();
           
        }

        void AnaPencere_Paint(object sender, PaintEventArgs e)
        {
            foreach (DusmanUcak eleman in dusmanucaklar)//düşmanucakların cizdirilmesi
            {
                 eleman.ciz(e.Graphics);
            }
            foreach (Mermi eleman in mermiler)//mermilerin çizdirilmesi
            {
                eleman.ciz(e.Graphics);
            }
            dost.ciz(e.Graphics); 
           
        }


       
    }
}
