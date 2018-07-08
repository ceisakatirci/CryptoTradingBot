namespace CryptoTradingBot.WinForms
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnBaslat = new System.Windows.Forms.Button();
            this.label_BinanceListelenenCoinAdet = new System.Windows.Forms.Label();
            this.lbHatalar = new System.Windows.Forms.ListBox();
            this.lbSinyaller = new System.Windows.Forms.ListBox();
            this.btnYukle = new System.Windows.Forms.Button();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.lblKapanis = new System.Windows.Forms.Label();
            this.lblHacim = new System.Windows.Forms.Label();
            this.lblEma21 = new System.Windows.Forms.Label();
            this.btnAlfabetikSiralama = new System.Windows.Forms.Button();
            this.lbIslenenCoinAdet = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.lbKapanisOnceki = new System.Windows.Forms.Label();
            this.btnHacimselSiralama = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBaslat
            // 
            this.btnBaslat.Location = new System.Drawing.Point(254, 759);
            this.btnBaslat.Name = "btnBaslat";
            this.btnBaslat.Size = new System.Drawing.Size(75, 23);
            this.btnBaslat.TabIndex = 0;
            this.btnBaslat.Text = "Başlat";
            this.btnBaslat.UseVisualStyleBackColor = true;
            this.btnBaslat.Click += new System.EventHandler(this.btnBaslat_Click);
            // 
            // label_BinanceListelenenCoinAdet
            // 
            this.label_BinanceListelenenCoinAdet.AutoSize = true;
            this.label_BinanceListelenenCoinAdet.Location = new System.Drawing.Point(23, 748);
            this.label_BinanceListelenenCoinAdet.Name = "label_BinanceListelenenCoinAdet";
            this.label_BinanceListelenenCoinAdet.Size = new System.Drawing.Size(149, 13);
            this.label_BinanceListelenenCoinAdet.TabIndex = 1;
            this.label_BinanceListelenenCoinAdet.Text = "Binance Listelenen Coin Adet:";
            // 
            // lbHatalar
            // 
            this.lbHatalar.FormattingEnabled = true;
            this.lbHatalar.Location = new System.Drawing.Point(23, 429);
            this.lbHatalar.Name = "lbHatalar";
            this.lbHatalar.Size = new System.Drawing.Size(354, 303);
            this.lbHatalar.TabIndex = 2;
            // 
            // lbSinyaller
            // 
            this.lbSinyaller.FormattingEnabled = true;
            this.lbSinyaller.Location = new System.Drawing.Point(408, 429);
            this.lbSinyaller.Name = "lbSinyaller";
            this.lbSinyaller.Size = new System.Drawing.Size(370, 303);
            this.lbSinyaller.TabIndex = 3;
            this.lbSinyaller.SelectedIndexChanged += new System.EventHandler(this.lbSinyaller_SelectedIndexChanged);
            this.lbSinyaller.DoubleClick += new System.EventHandler(this.lbSinyaller_DoubleClick);
            // 
            // btnYukle
            // 
            this.btnYukle.Location = new System.Drawing.Point(420, 758);
            this.btnYukle.Name = "btnYukle";
            this.btnYukle.Size = new System.Drawing.Size(75, 23);
            this.btnYukle.TabIndex = 4;
            this.btnYukle.Text = "Yükle";
            this.btnYukle.UseVisualStyleBackColor = true;
            this.btnYukle.Click += new System.EventHandler(this.btnYukle_Click);
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.zedGraphControl1.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(1077, 406);
            this.zedGraphControl1.TabIndex = 5;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // lblKapanis
            // 
            this.lblKapanis.AutoSize = true;
            this.lblKapanis.Location = new System.Drawing.Point(807, 419);
            this.lblKapanis.Name = "lblKapanis";
            this.lblKapanis.Size = new System.Drawing.Size(48, 13);
            this.lblKapanis.TabIndex = 6;
            this.lblKapanis.Text = "Kapanış:";
            // 
            // lblHacim
            // 
            this.lblHacim.AutoSize = true;
            this.lblHacim.Location = new System.Drawing.Point(807, 466);
            this.lblHacim.Name = "lblHacim";
            this.lblHacim.Size = new System.Drawing.Size(40, 13);
            this.lblHacim.TabIndex = 7;
            this.lblHacim.Text = "Hacim:";
            // 
            // lblEma21
            // 
            this.lblEma21.AutoSize = true;
            this.lblEma21.Location = new System.Drawing.Point(807, 494);
            this.lblEma21.Name = "lblEma21";
            this.lblEma21.Size = new System.Drawing.Size(43, 13);
            this.lblEma21.TabIndex = 8;
            this.lblEma21.Text = "Ema21:";
            // 
            // btnAlfabetikSiralama
            // 
            this.btnAlfabetikSiralama.Location = new System.Drawing.Point(520, 758);
            this.btnAlfabetikSiralama.Name = "btnAlfabetikSiralama";
            this.btnAlfabetikSiralama.Size = new System.Drawing.Size(143, 23);
            this.btnAlfabetikSiralama.TabIndex = 9;
            this.btnAlfabetikSiralama.Text = "Alfabetik Sıralama";
            this.btnAlfabetikSiralama.UseVisualStyleBackColor = true;
            this.btnAlfabetikSiralama.Click += new System.EventHandler(this.btnSirala_Click);
            // 
            // lbIslenenCoinAdet
            // 
            this.lbIslenenCoinAdet.AutoSize = true;
            this.lbIslenenCoinAdet.Location = new System.Drawing.Point(23, 779);
            this.lbIslenenCoinAdet.Name = "lbIslenenCoinAdet";
            this.lbIslenenCoinAdet.Size = new System.Drawing.Size(93, 13);
            this.lbIslenenCoinAdet.TabIndex = 10;
            this.lbIslenenCoinAdet.Text = "İşlenen Coin Adet:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(810, 536);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnTemizle
            // 
            this.btnTemizle.Location = new System.Drawing.Point(873, 758);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(75, 23);
            this.btnTemizle.TabIndex = 12;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // lbKapanisOnceki
            // 
            this.lbKapanisOnceki.AutoSize = true;
            this.lbKapanisOnceki.Location = new System.Drawing.Point(807, 443);
            this.lbKapanisOnceki.Name = "lbKapanisOnceki";
            this.lbKapanisOnceki.Size = new System.Drawing.Size(85, 13);
            this.lbKapanisOnceki.TabIndex = 6;
            this.lbKapanisOnceki.Text = "Kapanış Önceki:";
            // 
            // btnHacimselSiralama
            // 
            this.btnHacimselSiralama.Location = new System.Drawing.Point(691, 758);
            this.btnHacimselSiralama.Name = "btnHacimselSiralama";
            this.btnHacimselSiralama.Size = new System.Drawing.Size(143, 23);
            this.btnHacimselSiralama.TabIndex = 9;
            this.btnHacimselSiralama.Text = "Hacimsel Sıralama";
            this.btnHacimselSiralama.UseVisualStyleBackColor = true;
            this.btnHacimselSiralama.Click += new System.EventHandler(this.btnHacimselSiralama_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 801);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.lbIslenenCoinAdet);
            this.Controls.Add(this.btnHacimselSiralama);
            this.Controls.Add(this.btnAlfabetikSiralama);
            this.Controls.Add(this.lblEma21);
            this.Controls.Add(this.lblHacim);
            this.Controls.Add(this.lbKapanisOnceki);
            this.Controls.Add(this.lblKapanis);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.btnYukle);
            this.Controls.Add(this.lbSinyaller);
            this.Controls.Add(this.lbHatalar);
            this.Controls.Add(this.label_BinanceListelenenCoinAdet);
            this.Controls.Add(this.btnBaslat);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBaslat;
        private System.Windows.Forms.Label label_BinanceListelenenCoinAdet;
        private System.Windows.Forms.ListBox lbHatalar;
        private System.Windows.Forms.ListBox lbSinyaller;
        private System.Windows.Forms.Button btnYukle;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Label lblKapanis;
        private System.Windows.Forms.Label lblHacim;
        private System.Windows.Forms.Label lblEma21;
        private System.Windows.Forms.Button btnAlfabetikSiralama;
        private System.Windows.Forms.Label lbIslenenCoinAdet;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Label lbKapanisOnceki;
        private System.Windows.Forms.Button btnHacimselSiralama;
    }
}

