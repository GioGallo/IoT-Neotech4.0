using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autobus
{
    public partial class Form1 : Form
    {
        private VirtualGPSSensor gps = new VirtualGPSSensor();
        private Queue<string> codaUpload = new Queue<string>();
        private string backup;
        private int nPersone;
        private int idMezzo = 1;
        public Form1()
        {
            InitializeComponent();
        }

        public void StartGPS(object sender,EventArgs e)
        {
            if(btnStop.Enabled==false && btnChiudi.Enabled==false)
            {
                timer1.Start();
                btnPartenza.Enabled = false;
                btnStop.Enabled = true;
                btnApri.Enabled = false;
                btnChiudi.Enabled = false;
            }

        }

        public void StopGPS(object sender,EventArgs e)
        {
            if (btnPartenza.Enabled == false)
            {
                timer1.Stop();
                btnPartenza.Enabled = true;
                btnStop.Enabled = false;
                btnApri.Enabled = true;
            }
        }

        public void ApriPorta(object sender ,EventArgs e)
        {
            Random random = new Random();
            nPersone = random.Next(0, 70);
            txtPersone.Text = nPersone.ToString();
            btnApri.Enabled = false;
            btnChiudi.Enabled = true;
            btnPartenza.Enabled = false;
            string apertura = backup+",\"messaggio\":\"Apertura Porte\"}";
            codaUpload.Enqueue(apertura);
        }

        public void ChiudiPorta(object sender,EventArgs e)
        {
            btnPartenza.Enabled = true;
            btnChiudi.Enabled = false;
            btnApri.Enabled = true;
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            string temp = (gps.ToJson(idMezzo));
            backup = temp;
            temp += "}";
            codaUpload.Enqueue(temp);
            txtGPS.Text += temp+"\r\n";    
        }
    }
}
