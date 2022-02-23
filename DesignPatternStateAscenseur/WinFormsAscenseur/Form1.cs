using ClassLibraryAscenseur;
using ClassLibraryAscenseur.Etats;

namespace WinFormsAscenseur
{
    public partial class Form1 : Form
    {
        private Ascenseur monAscenseur;
        private bool afficherEtat;
        private bool porteOuverteIhm;

        Thread? t;

        public Form1()
        {
            InitializeComponent();

            monAscenseur = new Ascenseur(-1, 3);
            afficherEtat = false;
            porteOuverteIhm = false;

            monAscenseur.ChangementEtatPorte += ChangementEtatPorteIhm;

        }
      
        private void MajIhm()
        {
            labelEtage.Text = monAscenseur.EtageCourant.NumEtage.ToString();

            button_1.ForeColor = monAscenseur.demandesEtageInterne.Contains(-1) ? Color.Red : Color.Black;
            button0.ForeColor = monAscenseur.demandesEtageInterne.Contains(0) ? Color.Red : Color.Black;
            button1.ForeColor = monAscenseur.demandesEtageInterne.Contains(1) ? Color.Red : Color.Black;
            button2.ForeColor = monAscenseur.demandesEtageInterne.Contains(2) ? Color.Red : Color.Black;
            button3.ForeColor = monAscenseur.demandesEtageInterne.Contains(3) ? Color.Red : Color.Black;

            
            if (afficherEtat)
            {
                if (monAscenseur.Etat.GetType() == typeof(Monte))
                {
                    labelEtat.Text = "Etat :         Monte";
                }
                else if (monAscenseur.Etat.GetType() == typeof(Descend))
                {
                    labelEtat.Text = "Etat :         Descend";
                }
                else if (monAscenseur.Etat.GetType() == typeof(ArretePorteOuverte))
                {
                    labelEtat.Text = "Etat : Porte ouverte";
                }
                else
                {
                    labelEtat.Text = "Etat :         Arrêté";
                }
                labelEtat.Visible = true;
            }
            else
            {
                labelEtat.Visible = false;
            }
        }


        private void button_Click(object sender, EventArgs e)
        {
            monAscenseur.DemandeEtageInterne(Convert.ToInt32(((Button)sender).Text));

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MajIhm();
        }

        private void buttonEtages_Click(object sender, EventArgs e)
        {
            Form f1 = new Form2(monAscenseur);
            f1.Show();
        }

        private void buttonEtat_Click(object sender, EventArgs e)
        {
            afficherEtat = !afficherEtat;
        }



        private void ChangementEtatPorteIhm()
        {
            if (porteOuverteIhm)
            {
                t = new Thread(new ThreadStart(ThreadMethodFermerPorte));
                porteOuverteIhm = false;
            }
            else
            {
                t = new Thread(new ThreadStart(ThreadMethodOuvrirPorte));
                porteOuverteIhm = true;
            }
            t.Start();
        }

        private void ThreadMethodOuvrirPorte()
        {
            int count = 0;
            while (count < 50)
            {
                Thread.Sleep(20);
                pictureBoxPorteG.Invoke(new MethodInvoker(delegate
                {
                    pictureBoxPorteG.Width -= 2;
                }));
                pictureBoxPorteD.Invoke(new MethodInvoker(delegate
                {
                    pictureBoxPorteD.Width -= 2;
                    pictureBoxPorteD.Location = new Point(pictureBoxPorteD.Location.X + 2, pictureBoxPorteD.Location.Y);
                }));
                count++;
            }
        }
        private void ThreadMethodFermerPorte()
        {
            int count = 0;
            while (count < 50)
            {
                Thread.Sleep(20);
                pictureBoxPorteG.Invoke(new MethodInvoker(delegate
                {
                    pictureBoxPorteG.Width += 2;
                }));
                pictureBoxPorteD.Invoke(new MethodInvoker(delegate
                {
                    pictureBoxPorteD.Width += 2;
                    pictureBoxPorteD.Location = new Point(pictureBoxPorteD.Location.X - 2, pictureBoxPorteD.Location.Y);
                }));
                count++;
            }
        }
    }
}