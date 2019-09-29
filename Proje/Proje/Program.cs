using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AnaPencere pencerem = new AnaPencere(1400, 900);
            pencerem.Text = "Galactic Chase";//pencere adı
            pencerem.StartPosition = FormStartPosition.CenterScreen;//program çalıştırıldığında pencerenin tam ekranın ortasında çıkması için
           
            Application.Run(pencerem);
        }
    }
}
