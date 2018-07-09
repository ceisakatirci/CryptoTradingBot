using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Binance.Net;
using CryptoCompare;
using Trady.Analysis;
using ZedGraph;


namespace CryptoTradingBot.WinForms
{
    public partial class Form1 : Form
    {
        private static int _limit = 987;
        private Dictionary<string, Kayit> _kayitlar = new Dictionary<string, Kayit>();
        private readonly object lockerKayitlar = new object();
        private readonly RollingPointPairList _sma21Listesi = new RollingPointPairList(_limit);
        private long _sayac;
        private readonly RollingPointPairList _close4Listesi = new RollingPointPairList(_limit);
        private readonly string _dosyaAdi = "kayitlar.bin";

        //private readonly RollingPointPairList _hacimListesi = new RollingPointPairList(_limit);
        public Form1()
        {
            InitializeComponent();
            LineItem closes = new LineItem("Closes4", _close4Listesi, Color.Blue, SymbolType.None, 2f);
            LineItem ema21 = new LineItem("Sma21", _sma21Listesi, Color.Red, SymbolType.None, 2f);
            //BarItem hacim = new BarItem("Hacim", _hacimListesi, Color.Red);
            zedGraphControl1.GraphPane.CurveList.Add(closes);
            zedGraphControl1.GraphPane.CurveList.Add(ema21);
            //zedGraphControl1.GraphPane.AddBar("Hacim",_hacimListesi,Color.Green);
            zedGraphControl1.GraphPane.YAxis.Scale.MaxAuto = true;
            zedGraphControl1.GraphPane.XAxis.Scale.MaxAuto = true;
            zedGraphControl1.GraphPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);
            zedGraphControl1.GraphPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45F);

        }
        private void _listeyeEkle(RollingPointPairList rollingPoint, ZedGraphControl zedGraph, double x, double y)
        {
            //x1++; c++;
            rollingPoint.Add(x, y);
            zedGraph.AxisChange();
            zedGraph.Invalidate();
            //zedGraph.Refresh();
        }
        private void btnBaslat_Click(object sender, EventArgs e)
        {
            lbSinyaller.Items.Clear();
            lbHatalar.Items.Clear();
            label_BinanceListelenenCoinAdet.Yazdir(string.Empty);
            lbIslenenCoinAdet.Yazdir(string.Empty);
            Task.Run(() =>
            {
                using (var binanceClient = new BinanceClient())
                {
                    var data = binanceClient.GetAllPrices().Data;
                    var enumerable = data.Where(x => x.Symbol.EndsWith("BTC"))
                        .Select(x => x.Symbol = x.Symbol.Replace("BTC", "")).ToList();
                    label_BinanceListelenenCoinAdet.Yazdir(enumerable.Count().ToString());
                    enumerable
                        .AsParallel()
                        .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                        .ForAll(_analizEt);
                }
            }).ContinueWith(t =>
            {
                if (File.Exists(_dosyaAdi))
                    File.Delete(_dosyaAdi);
                if (!_kayitlar.Any())
                    MessageBox.Show("Kayit Yok!");
                File.WriteAllBytes(_dosyaAdi, _kayitlar.Serialize());
                MessageBox.Show("Kaydedildi");

            });

            lbSinyalAdet.Yazdir(_kayitlar.Count().ToString());

        }

        private void _analizEt(string sembol)
        {
            var client = new CryptoCompareClient();
            HistoryResponse historyHour;
            try
            {
                lbIslenenCoinAdet.Yazdir(Interlocked.Increment(ref _sayac).ToString());
                var task = client.History.HourAsync(sembol, "BTC", _limit - 1, "Binance");
                task.Wait();
                historyHour = task.Result;
            }
            catch (Exception ex)
            {
                lbHatalar.Yazdir(sembol + "Coini Binance da Mevcut Değil: " + ex.IctenDisaHatalariAl());
                return;
            }
            var coinData = new Kayit(sembol);
            var candleDataList = historyHour.Data;
            var candles = candleDataList.Where(x => x.Close > 0).ToList();
            if (!candles.Any())
            {
                lbHatalar.Yazdir("Hiç Mum Yok, Coin: " + sembol);
                return;
            }

            var kalan = candles.Count % 4;
            candles = candles.Skip(kalan).ToList();
            var son4Indeks = candles.Count / 4;
            for (var i = 0; i < son4Indeks; i++)
            {
                var mumlar = candles.Skip(i * 4).Take(4);
                var candleData = new CandleData();
                foreach (var mum in mumlar)
                {
                    candleData.VolumeTo += mum.VolumeTo;
                }
                candleData.Close = mumlar.Last().Close;
                coinData.Closes4Saatlik.Add(candleData.Close);
                coinData.Volumes4Saatlik.Add(candleData.VolumeTo);
            }     
            var sma21 = coinData.Closes4Saatlik.Sma(21);
            if (coinData.Closes4Saatlik.Any() && sma21.Any() && coinData.Closes4Saatlik.Last() > sma21.Last())
            {
                lbSinyaller.Yazdir(sembol);
                kayilardaYoksaEkleVarsaGuncelle(coinData);
            }
        }
        private void kayilardaYoksaEkleVarsaGuncelle(Kayit coinData)
        {
            lock (lockerKayitlar)
            {
                if (!_kayitlar.ContainsKey(coinData.Sembol))
                    _kayitlar.Add(coinData.Sembol, coinData);
                _kayitlar[coinData.Sembol] = coinData;
            }
        }

        private void btnYukle_Click(object sender, EventArgs e)
        {
            lbSinyaller.Items.Clear();

            if (File.Exists(_dosyaAdi))
            {
                _kayitlar = (Dictionary<string, Kayit>)File.ReadAllBytes(_dosyaAdi).DeSerialize();
                if (_kayitlar != null && _kayitlar.Any())
                {
                    var temp = _kayitlar.OrderByDescending(x => x.Value.Volumes4Saatlik.Any() ? x.Value.Volumes4Saatlik.Last() : 0.0m);
                    foreach (var key in temp)
                    {
                        lbSinyaller.Items.Add(key.Key);
                    }
                }
            }
        }

        private void lbSinyaller_DoubleClick(object sender, EventArgs e)
        {
            _listedenSecilenCoiniAl(sender, e);
        }
        private void _listedenSecilenCoiniAl(object sender, EventArgs e)
        {
            var temp = (ListBox)sender;
            if (temp.SelectedItem != null)
            {
                _coinGrafikCiz(temp.SelectedItem.ToString());
            }
        }

        private void _coinGrafikCiz(string sembol)
        {
            if (string.IsNullOrWhiteSpace(sembol))
                return;
            if (sembol.Contains("-"))
                sembol = sembol.Substring(sembol.IndexOf('-') + 1);
            if (_kayitlar.ContainsKey(sembol))
            {
                var closes4Satlik = _kayitlar[sembol].Closes4Saatlik;
                var hacimler = _kayitlar[sembol].Volumes4Saatlik;
                //closes = closes.Where(x => x > 0).ToList();
                if (!closes4Satlik.Any())
                    return;
                _close4Listesi.Clear();
                _sma21Listesi.Clear();
                var count = closes4Satlik.Count;
                var sma21 = closes4Satlik.Sma(21);
                for (int i = 0; i < count; i++)
                {
                    _listeyeEkle(_close4Listesi, zedGraphControl1, i, Convert.ToDouble(closes4Satlik[i]));
                    _listeyeEkle(_sma21Listesi, zedGraphControl1, i, Convert.ToDouble(sma21[i]));
                    //_listeyeEkle(_hacimListesi, zedGraphControl1, i, Convert.ToDouble(hacimler[i]));
                }
                lblSma21.Yazdir((sma21.LastOrDefault() ?? 0.0m).ToString("0.000000000"));
                lblKapanis.Yazdir(closes4Satlik.Last().ToString("0.000000000"));
                lbKapanisOnceki.Yazdir(closes4Satlik[count - 2].ToString("0.000000000"));
                lblHacim.Yazdir(hacimler.Last().ToString("0.000000000"));
            }
        }

        private void btnSirala_Click(object sender, EventArgs e)
        {
            lbSinyaller.Items.Clear();
            lbHatalar.Items.Clear();
            //var temp = _kayitlar.Values.OrderByDescending(x => x.Closes4Saatlik[x.Closes4Saatlik.Count - 1] - x.Closes4Saatlik[x.Closes4Saatlik.Count - 2]);
            /*
             var people = from x in excel.Worksheet<CountryEconomics>("Sheet1")
             let c = ((double)x.Inflation) / ((double)x.GDP)
             orderby c ascending 
             select c;
             
             */

            var temp = from x in _kayitlar.Values
                       orderby x.Sembol 
                       //orderby x.Volumes4Saatlik.Last() descending
                       //let count = x.Closes4Saatlik.Count
                       //let yuzde = x.Closes4Saatlik[count - 1] / x.Closes4Saatlik[count - 2] * 100
                       //let sonuc = ((yuzde > 0.0m ? yuzde : 0.0m) * 0.4m) + (x.Volumes4Saatlik.Last() * 0.6m)
                       //orderby sonuc
                       select x;

            foreach (var item in temp)
            {
                lbSinyaller.Items.Add(item.Sembol);
            }
            lbSinyalAdet.Yazdir(temp.Count().ToString());
        }

        private void lbSinyaller_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                _listedenSecilenCoiniAl(sender, e);
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            if (File.Exists(_dosyaAdi))
                File.Delete(_dosyaAdi);
        }

        private void btnHacimselSiralama_Click(object sender, EventArgs e)
        {

            lbSinyaller.Items.Clear();
            lbHatalar.Items.Clear();
            //var temp = _kayitlar.Values.OrderByDescending(x => x.Closes4Saatlik[x.Closes4Saatlik.Count - 1] - x.Closes4Saatlik[x.Closes4Saatlik.Count - 2]);
            /*
             var people = from x in excel.Worksheet<CountryEconomics>("Sheet1")
             let c = ((double)x.Inflation) / ((double)x.GDP)
             orderby c ascending 
             select c;
             
             */

            var temp = from x in _kayitlar.Values
                       orderby x.Volumes4Saatlik.Last() descending
                       //let count = x.Closes4Saatlik.Count
                       //let yuzde = x.Closes4Saatlik[count - 1] / x.Closes4Saatlik[count - 2] * 100
                       //let sonuc = ((yuzde > 0.0m ? yuzde : 0.0m) * 0.4m) + (x.Volumes4Saatlik.Last() * 0.6m)
                       //orderby sonuc
                       select x;

            foreach (var item in temp)
            {
                lbSinyaller.Items.Add(item.Sembol);
            }
            lbSinyalAdet.Yazdir(temp.Count().ToString());
        }
    }

}
