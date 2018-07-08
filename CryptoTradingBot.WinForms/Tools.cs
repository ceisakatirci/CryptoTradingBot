using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoTradingBot.WinForms
{
    public static class Tools
    {
        private static string labelBaslangic(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            var indeks = str.IndexOf(':');
            if (indeks < 0)
                return str;

            return str.Remove(indeks).Trim() + ": ";
        }

        public static string IctenDisaHatalariAl(this Exception ex)
        {
            var hata = ex.Message;
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                hata += ", " + ex.Message;
            }
            return hata;
        }

        public static void Yazdir(this Label label, string str)
        {
            if (label.InvokeRequired)
            {
                label.Invoke(new Action(() => label.Text = labelBaslangic(label.Text) + str));
                return;
            }
            label.Text = labelBaslangic(label.Text) + str;
        }
        public static void Yazdir(this ListBox listBox, string str)
        {
            if (listBox.InvokeRequired)
            {
                listBox.Invoke(new Action(() => { listBox.Items.Add(str); }));
                return;
            }
            listBox.Items.Add(str);
        }
        public static byte[] Serialize(this Object obj)
        {
            if (obj == null)
                return null;

            using (var memoryStream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();

                binaryFormatter.Serialize(memoryStream, obj);

                var compressed = Compress(memoryStream.ToArray());
                return compressed;
            }
        }
        public static Object DeSerialize(this byte[] arrBytes)
        {
            using (var memoryStream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();
                var decompressed = Decompress(arrBytes);

                memoryStream.Write(decompressed, 0, decompressed.Length);
                memoryStream.Seek(0, SeekOrigin.Begin);

                return binaryFormatter.Deserialize(memoryStream);
            }
        }

        public static byte[] Compress(byte[] input)
        {
            byte[] compressesData;

            using (var outputStream = new MemoryStream())
            {
                using (var zip = new GZipStream(outputStream, CompressionMode.Compress))
                {
                    zip.Write(input, 0, input.Length);
                }

                compressesData = outputStream.ToArray();
            }

            return compressesData;
        }

        public static byte[] Decompress(byte[] input)
        {
            byte[] decompressedData;

            using (var outputStream = new MemoryStream())
            {
                using (var inputStream = new MemoryStream(input))
                {
                    using (var zip = new GZipStream(inputStream, CompressionMode.Decompress))
                    {
                        zip.CopyTo(outputStream);
                    }
                }

                decompressedData = outputStream.ToArray();
            }

            return decompressedData;
        }


    }
}
