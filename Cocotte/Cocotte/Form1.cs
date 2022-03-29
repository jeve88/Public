using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cocotte
{
    public partial class Form1 : Form
    {
        Cocotte maCocotte;

        public Form1()
        {
            maCocotte = new Cocotte();

            InitializeComponent();

            pictureBoxChoixCyan.Tag = Cocotte.Couleur.cyan;
            pictureBoxChoixRouge.Tag = Cocotte.Couleur.rouge;
            pictureBoxChoixViolet.Tag = Cocotte.Couleur.violet;
            pictureBoxChoixJaune.Tag = Cocotte.Couleur.jaune;
            pictureBoxChoixRose.Tag = Cocotte.Couleur.rose;
            pictureBoxChoixBleu.Tag = Cocotte.Couleur.bleu;
            pictureBoxChoixOrange.Tag = Cocotte.Couleur.orange;
            pictureBoxChoixVert.Tag = Cocotte.Couleur.vert;


            maCocotte.MouvementsTermine += AffichageDesChoix;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (maCocotte.NbrMouvAFaire)
            {
                case int n when n > 20: timer1.Interval = 30; break;
                case int n when n > 15: timer1.Interval = 100; break;
                case int n when n > 10: timer1.Interval = 200; break;
                case int n when n > 5: timer1.Interval = 350; break;
                default: timer1.Interval = 500; break;
            }

            maCocotte.MouvementsDeCocotte();
            labelNbrLance.Text = maCocotte.NbrMouvAFaire.ToString();

            switch (maCocotte.AffEnCours)
            {
                case Cocotte.Affichage.carre:
                    pictureBoxCocotte.Image = Properties.Resources.carre;
                    break;
                case Cocotte.Affichage.position1:
                    pictureBoxCocotte.Image = Properties.Resources.position1;
                    break;
                case Cocotte.Affichage.position2:
                    pictureBoxCocotte.Image = Properties.Resources.position2;
                    break;
            }
        }


        private void AffichageDesChoix()
        {
            timer1.Enabled = false;
            if (maCocotte.Position1)
            {
                pictureBoxChoixCyan.Visible = true;
                pictureBoxChoixRouge.Visible = true;
                pictureBoxChoixJaune.Visible = true;
                pictureBoxChoixViolet.Visible = true;
            }
            else
            {
                pictureBoxChoixRose.Visible = true;
                pictureBoxChoixBleu.Visible = true;
                pictureBoxChoixOrange.Visible = true;
                pictureBoxChoixVert.Visible = true;
            }
        }

        private void MasquageDesChoix()
        {
            if (maCocotte.Position1)
            {
                pictureBoxChoixCyan.Visible = false;
                pictureBoxChoixRouge.Visible = false;
                pictureBoxChoixJaune.Visible = false;
                pictureBoxChoixViolet.Visible = false;
            }
            else
            {
                pictureBoxChoixRose.Visible = false;
                pictureBoxChoixBleu.Visible = false;
                pictureBoxChoixOrange.Visible = false;
                pictureBoxChoixVert.Visible = false;
            }
        }

        private string TransformerMessage(string _aTransformer)
        {
            string retour = "";

            for (int i = 0; i < 5; i++)
            {
                //if (_aTransformer[1]==']')
                //{
                //    retour += "\r";
                //    _aTransformer = _aTransformer.Substring(2, _aTransformer.Length - 2);
                //}
                //else
                //{
                _aTransformer = _aTransformer.Substring(1, _aTransformer.Length - 1);
                while (_aTransformer[0] != ']')
                {
                    retour += _aTransformer[0];
                    _aTransformer = _aTransformer.Substring(1, _aTransformer.Length - 1);
                }
                _aTransformer = _aTransformer.Substring(1, _aTransformer.Length - 1);
                if (i < 4)
                {
                    retour += "\r";
                }
                // }
            }
            MessageBox.Show("a" + retour + "a");
            return retour;
        }

        private void pictureBoxChoix_Click(object sender, EventArgs e)
        {
            maCocotte.couleurChoisie = (Cocotte.Couleur)((PictureBox)sender).Tag;
            MasquageDesChoix();

            pictureBoxImgLabelNbr.Visible = false;
            labelNbrLance.Visible = false;

            pictureBoxBtnRestart.Visible = true;

            switch (maCocotte.couleurChoisie)
            {
                case Cocotte.Couleur.cyan:
                    labelHG.BackColor = Color.FromArgb(153, 217, 234);
                    labelHG.Text = maCocotte.Message();
                    labelHG.Visible = true;
                    pictureBoxHG.Image = Properties.Resources.bulleHG_Cyan;
                    pictureBoxHG.Visible = true;
                    pictureBoxCocotte.Image = Properties.Resources.choixCyan;
                    break;
                case Cocotte.Couleur.rouge:
                    labelHD.BackColor = Color.FromArgb(237, 28, 36);
                    labelHD.Text = maCocotte.Message();
                    labelHD.Visible = true;
                    pictureBoxHD.Image = Properties.Resources.bulleHD_Rouge;
                    pictureBoxHD.Visible = true;
                    pictureBoxCocotte.Image = Properties.Resources.choixRouge;
                    break;
                case Cocotte.Couleur.violet:
                    labelBG.BackColor = Color.FromArgb(163, 73, 164);
                    labelBG.Text = maCocotte.Message();
                    labelBG.Visible = true;
                    pictureBoxBG.Image = Properties.Resources.bulleBG_Violet;
                    pictureBoxBG.Visible = true;
                    pictureBoxCocotte.Image = Properties.Resources.choixViolet;
                    break;
                case Cocotte.Couleur.jaune:
                    labelBD.BackColor = Color.FromArgb(255, 201, 14);
                    labelBD.Text = maCocotte.Message();
                    labelBD.Visible = true;
                    pictureBoxBD.Image = Properties.Resources.bulleBD_Jaune;
                    pictureBoxBD.Visible = true;
                    pictureBoxCocotte.Image = Properties.Resources.choixJaune;
                    break;
                case Cocotte.Couleur.rose:
                    labelHG.BackColor = Color.FromArgb(255, 174, 201);
                    labelHG.Text = maCocotte.Message();
                    labelHG.Visible = true;
                    pictureBoxHG.Image = Properties.Resources.bulleHG_Rose;
                    pictureBoxHG.Visible = true;
                    pictureBoxCocotte.Image = Properties.Resources.choixRose;
                    break;
                case Cocotte.Couleur.bleu:
                    labelHD.BackColor = Color.FromArgb(63, 72, 204);
                    labelHD.Text = maCocotte.Message();
                    labelHD.Visible = true;
                    pictureBoxHD.Image = Properties.Resources.bulleHD_Bleu;
                    pictureBoxHD.Visible = true;
                    pictureBoxCocotte.Image = Properties.Resources.choixBleu;
                    break;
                case Cocotte.Couleur.orange:
                    labelBG.BackColor = Color.FromArgb(255, 127, 39);
                    labelBG.Text = maCocotte.Message();
                    labelBG.Visible = true;
                    pictureBoxBG.Image = Properties.Resources.bulleBG_Orange;
                    pictureBoxBG.Visible = true;
                    pictureBoxCocotte.Image = Properties.Resources.choixOrange;
                    break;
                case Cocotte.Couleur.vert:
                    labelBD.BackColor = Color.FromArgb(181, 230, 29);
                    labelBD.Text = maCocotte.Message();
                    labelBD.Visible = true;
                    pictureBoxBD.Image = Properties.Resources.bulleBD_Vert;
                    pictureBoxBD.Visible = true;
                    pictureBoxCocotte.Image = Properties.Resources.choixVert;
                    break;
            }
        }

        private void textBoxNbrLance_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxNbrLance.Text))
            {
                maCocotte.NbrMouvAFaire = int.Parse(textBoxNbrLance.Text);
                //int nbrLance = int.Parse(textBoxNbrLance.Text);
                //if (nbrLance > 0)
                //{
                //    maCocotte.NbrMouvAFaire = nbrLance;
                //}
            }
        }

        private void textBoxNbrLance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Start();
            }
            else if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void pictureBoxBtnStart_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void Start()
        {
            if (maCocotte.NbrMouvAFaire > 0)
            {
                pictureBox_Parametre.Visible = false;
                timer1.Enabled = true;
                pictureBoxBtnStart.Visible = false;
                //pictureBoxImgLabelNbr.Visible = false;
                textBoxNbrLance.Visible = false;
                labelNbrLance.Text = maCocotte.NbrMouvAFaire.ToString();
                labelNbrLance.Visible = true;
            }
        }




        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Start();
            }
        }


        private void pictureBoxBtnRestart_Click(object sender, EventArgs e)
        {
            pictureBox_Parametre.Visible = true;

            timer1.Interval = 10;

            textBoxNbrLance.Clear();
            maCocotte = new Cocotte();
            maCocotte.MouvementsTermine += AffichageDesChoix;

            pictureBoxBtnStart.Visible = true;
            pictureBoxImgLabelNbr.Visible = true;
            textBoxNbrLance.Visible = true;
            labelNbrLance.Visible = false;

            labelBD.Visible = false;
            labelBG.Visible = false;
            labelHD.Visible = false;
            labelHG.Visible = false;

            pictureBoxBD.Visible = false;
            pictureBoxBG.Visible = false;
            pictureBoxHD.Visible = false;
            pictureBoxHG.Visible = false;

            pictureBoxCocotte.Image = Properties.Resources.carre;

            pictureBoxBtnRestart.Visible = false;
            textBoxNbrLance.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.StartPosition = FormStartPosition.CenterParent;
            form2.ShowDialog();
            maCocotte = new Cocotte();
            maCocotte.MouvementsTermine += AffichageDesChoix;
        }

        #region MouseEnter/Leave
        private void pictureBoxBtnRestart_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxBtnRestart.Image = Properties.Resources.Restart_over;
        }

        private void pictureBoxBtnRestart_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxBtnRestart.Image = Properties.Resources.Restart;

        }
        private void pictureBoxBtnStart_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxBtnStart.Image = Properties.Resources.Start;
        }

        private void pictureBoxBtnStart_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxBtnStart.Image = Properties.Resources.Start_over;
        }
        private void pictureBox_Parametre_MouseEnter(object sender, EventArgs e)
        {
            pictureBox_Parametre.Image = Properties.Resources.parametre_over;
        }

        private void pictureBox_Parametre_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_Parametre.Image = Properties.Resources.parametre;
        }
        #endregion

        private void pictureBox_Parametre_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            maCocotte = new Cocotte();
            maCocotte.MouvementsTermine += AffichageDesChoix;
        }
    }

}
