using ClassLibraryAscenseur;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsControlLibraryAscenseur
{
    public partial class Porte : UserControl
    {
        Etage etage;
        Thread? t;
        public Porte()
        {
            InitializeComponent();
            etage = new Etage(new Ascenseur(0,2),0);
        }

        public void InitialiserPorte(Etage _etage)
        {
            etage = _etage;
            etage.ChangementEtatPorte += ThreadMethodChangementEtatPorte;

            labelEtage.Text = etage.NumEtage.ToString();
            if (labelEtage.Text.Count() > 1)
            {
                labelEtage.Font = new System.Drawing.Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            }
        }

        public void InitialiserPorte(Etage _etage,bool _btnEtageUp, bool _btnEtageDown)
        {
            etage = _etage;
            etage.ChangementEtatPorte += ThreadMethodChangementEtatPorte;

            labelEtage.Text = etage.NumEtage.ToString();
            if (labelEtage.Text.Count() > 1)
            {
                labelEtage.Font = new System.Drawing.Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            }

            if (!_btnEtageUp)
            {
                buttonEtageUp.Enabled = false;
                buttonEtageUp.Visible = false;
            }
            if (!_btnEtageDown)
            {
                buttonEtageDown.Enabled = false;
                buttonEtageDown.Visible = false;
            }
        }


        public void MajIhm()
        {
            buttonEtageUp.BackColor = etage.AppelMonter ? Color.Red : Color.LightGray;
            buttonEtageDown.BackColor = etage.AppelDescendre ? Color.Red : Color.LightGray;
        }

        private void ThreadMethodChangementEtatPorte()
        {
            if (etage.PorteOuverte)
            {
                t = new Thread(new ThreadStart(ThreadOuvrirPorte));
            }
            else
            {
                t = new Thread(new ThreadStart(ThreadFermerPorte));
            }
            t.Start();
        }

        private void ThreadOuvrirPorte()
        {
            int count = 0;
            while (count < 50)
            {
                Thread.Sleep(20);
                pictureBoxPorteG.Invoke(new MethodInvoker(delegate
                {
                    pictureBoxPorteG.Width -= 1;
                }));
                pictureBoxPorteD.Invoke(new MethodInvoker(delegate
                {
                    pictureBoxPorteD.Width -= 1;
                    pictureBoxPorteD.Location = new Point(pictureBoxPorteD.Location.X + 1, pictureBoxPorteD.Location.Y);
                }));
                count++;
            }
        }
        private void ThreadFermerPorte()
        {
            int count = 0;
            while (count < 50)
            {
                Thread.Sleep(20);
                pictureBoxPorteG.Invoke(new MethodInvoker(delegate
                {
                    pictureBoxPorteG.Width += 1;
                }));
                pictureBoxPorteD.Invoke(new MethodInvoker(delegate
                {
                    pictureBoxPorteD.Width += 1;
                    pictureBoxPorteD.Location = new Point(pictureBoxPorteD.Location.X - 1, pictureBoxPorteD.Location.Y);
                }));
                count++;
            }
        }

        private void buttonEtageUp_Click(object sender, EventArgs e)
        {
            etage.AppelerPourMonter();
        }

        private void buttonEtageDown_Click(object sender, EventArgs e)
        {
            etage.AppelerPourDescendre();
        }
    }
}
