using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTradingBot.WinForms
{
    [Serializable]
    class Kayit
    {
        //public List<decimal> Volumes1Saatlik { get; set; }
        public List<decimal> Volumes4Saatlik { get; set; }
        //public List<decimal> Closes1Saatlik { get; set; }
        public List<decimal> Closes4Saatlik { get; set; }
        public string Sembol { get; set; }
        public Kayit(string sembol)
        {
            Sembol = sembol;
            //Volumes1Saatlik = new List<decimal>();
            Volumes4Saatlik = new List<decimal>();
            //Closes1Saatlik = new List<decimal>();
            Closes4Saatlik = new List<decimal>();
        }
    }
}
