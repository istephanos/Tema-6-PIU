using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibrarieModele;
using StocareDateClienti;

namespace Clienti_form
{
    public partial class Form1 : Form
    {
        AdministrareClienti_FisierText AdminClienti;
        AdministrareMasini_FisierText AdminMasini;
        private Label lblNumeClient;
        private Label lblPrenumeClient;
        private Label lblCNPClient;

        private Label[] lblsNumeClient;
        private Label[] lblsPrenumeClient;
        private Label[] lblsCNPClient;

        private const int LATIME_CONTROL = 100;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 120;
        private const int OFFSET_X = 50;
        public Form1()
        {
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string numeFisier1 = ConfigurationManager.AppSettings["NumeFisier1"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;
            string caleCompletaFisier1 = locatieFisierSolutie + "\\" + numeFisier1;

            AdminClienti = new AdministrareClienti_FisierText(caleCompletaFisier);
            AdminMasini = new AdministrareMasini_FisierText(caleCompletaFisier1);

            InitializeComponent();

            //setare proprietati
            this.Size = new Size(320, 300);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.LimeGreen;
            this.Text = "Informatii Clienti";
            this.CenterToScreen();
            AfiseazaClienti();
        }
        
        private void AfiseazaClienti()
        {
            //adaugare control de tip label pentru 'Nume'
            lblNumeClient = new Label();
            lblNumeClient.Width = LATIME_CONTROL;
            lblNumeClient.Text = "Nume";
            lblNumeClient.Left = OFFSET_X + 0;
            lblNumeClient.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblNumeClient);

            //adaugare control de tip label pentru 'Prenume'
            lblPrenumeClient = new Label();
            lblPrenumeClient.Width = LATIME_CONTROL;
            lblPrenumeClient.Text = "Prenume";
            lblPrenumeClient.Left = OFFSET_X + DIMENSIUNE_PAS_X;
            lblPrenumeClient.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblPrenumeClient);

            //adaugare control de tip label pentru 'CNP'
            lblCNPClient = new Label();
            lblCNPClient.Width = LATIME_CONTROL;
            lblCNPClient.Text = "CNP";
            lblCNPClient.Left = OFFSET_X + 2*DIMENSIUNE_PAS_X;
            lblCNPClient.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblCNPClient);

            Client[] clienti = AdminClienti.GetClienti(out int NrClienti);
            lblsNumeClient = new Label[NrClienti];
            lblsPrenumeClient = new Label[NrClienti];
            lblsCNPClient = new Label[NrClienti];

            int i = 0;
            foreach(Client client in clienti)
            {
                //adaugare control de tip label pentru 'NumeClient'
                lblsNumeClient[i] = new Label();
                lblsNumeClient[i].Width = LATIME_CONTROL;
                lblsNumeClient[i].Text = client.nume;
                lblsNumeClient[i].Left = OFFSET_X + 0;
                lblsNumeClient[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsNumeClient[i]);

                //adaugare control de tip label pentru 'PrenumeClient'
                lblsPrenumeClient[i] = new Label();
                lblsPrenumeClient[i].Width = LATIME_CONTROL;
                lblsPrenumeClient[i].Text = client.prenume;
                lblsPrenumeClient[i].Left =OFFSET_X + DIMENSIUNE_PAS_X;
                lblsPrenumeClient[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsPrenumeClient[i]);

                //adaugare control de tip label pentru 'cnpClient'
                lblsCNPClient[i] = new Label();
                lblsCNPClient[i].Width = LATIME_CONTROL;
                lblsCNPClient[i].Text = client.cnp;
                lblsCNPClient[i].Left =OFFSET_X + DIMENSIUNE_PAS_X;
                lblsCNPClient[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsCNPClient[i]);
                i++;
            }
        }
    }
}
