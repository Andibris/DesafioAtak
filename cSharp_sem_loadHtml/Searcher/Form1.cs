using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace Searcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var conteudo = textBox1.Text;
            var wc = new WebClient();
            wc.Headers.Add(HttpRequestHeader.UserAgent, conteudo);
            string pagina = wc.DownloadString("https://www.google.com/search?q=");        

            var htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(pagina + conteudo);

            dataGridView1.Rows.Clear();

            string titulo = string.Empty;
            string link = string.Empty;

            //utilizei a linha abaixo para verificar que a página html não carregava.
            dataGridView1.Rows.Add(conteudo, pagina);

            foreach (HtmlNode node in htmlDocument.GetElementbyId("rso").ChildNodes)
            {
                if (node.Attributes.Count > 0)
                {
                    titulo = node.Descendants().First(x => x.Attributes["class"] != null && x.Attributes["class"].Value.Equals("LC20lb MBeuO DKV0Md")).InnerText;
                    link = node.Descendants().First(x => x.Attributes["class"] != null && x.Attributes["class"].Value.Equals("iUh30 qLRx3b tjvcx")).InnerText;
            
                    if (!string.IsNullOrEmpty(titulo))
                    {
                        dataGridView1.Rows.Add(titulo, link);

                    }
                }
            }
        }
    }
}
