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
    public partial class Form2 : Form
    {
        private TextBox[] textBoxTab;
        private string[] messages;
        private Cocotte.Couleur couleurChoisie;

        public Form2()
        {
            messages = Serialisation.DeserializeMessages("messages.bin");
            couleurChoisie = Cocotte.Couleur.cyan;

            InitializeComponent();

            textBoxLine1.Tag = 0;
            textBoxLine2.Tag = 1;
            textBoxLine3.Tag = 2;
            textBoxLine4.Tag = 3;
            textBoxLine5.Tag = 4;
            textBoxTab = new TextBox[5]
                { textBoxLine1, textBoxLine2, textBoxLine3, textBoxLine4, textBoxLine5 };


            pictureBoxMignaCyan.Tag = Cocotte.Couleur.cyan;
            pictureBoxMignaRouge.Tag = Cocotte.Couleur.rouge;
            pictureBoxMignaViolet.Tag = Cocotte.Couleur.violet;
            pictureBoxMignaJaune.Tag = Cocotte.Couleur.jaune;
            pictureBoxMignaRose.Tag = Cocotte.Couleur.rose;
            pictureBoxMignaBleu.Tag = Cocotte.Couleur.bleu;
            pictureBoxMignaOrange.Tag = Cocotte.Couleur.orange;
            pictureBoxMignaVert.Tag = Cocotte.Couleur.vert;

            AffichageMessage();
        }


        #region MouseEnter/Leave
        private void pictureBox_Valider_MouseEnter(object sender, EventArgs e)
        {
            pictureBox_Valider.Image = Properties.Resources.Valider_over;
        }

        private void pictureBox_Valider_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_Valider.Image = Properties.Resources.Valider;
        }

        private void pictureBox_Annuler_MouseEnter(object sender, EventArgs e)
        {
            pictureBox_Annuler.Image = Properties.Resources.Annuler_over;
        }

        private void pictureBox_Annuler_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_Annuler.Image = Properties.Resources.Annuler;
        }
        private void pictureBoxMigna_MouseEnter(object sender, EventArgs e)
        {
            switch (((Cocotte.Couleur)((PictureBox)sender).Tag))
            {
                case Cocotte.Couleur.cyan:
                    ((PictureBox)sender).Image = Properties.Resources.mignaCyan_hover;
                    break;
                case Cocotte.Couleur.rouge:
                    ((PictureBox)sender).Image = Properties.Resources.mignaRouge_hover;
                    break;
                case Cocotte.Couleur.violet:
                    ((PictureBox)sender).Image = Properties.Resources.mignaViolet_Hover;
                    break;
                case Cocotte.Couleur.jaune:
                    ((PictureBox)sender).Image = Properties.Resources.mignaJaune_Hover;
                    break;
                case Cocotte.Couleur.rose:
                    ((PictureBox)sender).Image = Properties.Resources.mignaRose_Hover;
                    break;
                case Cocotte.Couleur.bleu:
                    ((PictureBox)sender).Image = Properties.Resources.mignaBleu_Hover;
                    break;
                case Cocotte.Couleur.orange:
                    ((PictureBox)sender).Image = Properties.Resources.mignaOrange_Hover;
                    break;
                case Cocotte.Couleur.vert:
                    ((PictureBox)sender).Image = Properties.Resources.mignaVert_Hover;
                    break;
            }
        }

        private void pictureBoxMigna_MouseLeave(object sender, EventArgs e)
        {
            switch (((Cocotte.Couleur)((PictureBox)sender).Tag))
            {
                case Cocotte.Couleur.cyan:
                    ((PictureBox)sender).Image = Properties.Resources.mignaCyan;
                    break;
                case Cocotte.Couleur.rouge:
                    ((PictureBox)sender).Image = Properties.Resources.mignaRouge;
                    break;
                case Cocotte.Couleur.violet:
                    ((PictureBox)sender).Image = Properties.Resources.mignaViolet;
                    break;
                case Cocotte.Couleur.jaune:
                    ((PictureBox)sender).Image = Properties.Resources.mignaJaune;
                    break;
                case Cocotte.Couleur.rose:
                    ((PictureBox)sender).Image = Properties.Resources.mignaRose;
                    break;
                case Cocotte.Couleur.bleu:
                    ((PictureBox)sender).Image = Properties.Resources.mignaBleu;
                    break;
                case Cocotte.Couleur.orange:
                    ((PictureBox)sender).Image = Properties.Resources.mignaOrange;
                    break;
                case Cocotte.Couleur.vert:
                    ((PictureBox)sender).Image = Properties.Resources.mignaVert;
                    break;
            }
        }
        #endregion

        private void pictureBox_Valider_Click(object sender, EventArgs e)
        {
            SauvegardeMessage();
            Serialisation.SerializeMessages(messages, "messages.bin");
            Close();
        }

        private void pictureBox_Annuler_Click(object sender, EventArgs e)
        {
            Close();
        }



        private void pictureBoxMigna_Click(object sender, EventArgs e)
        {
            SauvegardeMessage();

            couleurChoisie = (Cocotte.Couleur)((PictureBox)sender).Tag;

            AffichageMessage();

            ChangementCouleurBulle(sender);

            textBoxLine1.Focus();
            //textBoxLine1.SelectionStart = textBoxLine1.Text.Length;
        }

        private void SauvegardeMessage()
        {
            messages[(int)couleurChoisie] = "";
            for (int i = 0; i < 5; i++)
            {
                messages[(int)couleurChoisie] += "[" + textBoxTab[i].Text + "]";
            }
        }

        private void AffichageMessage()
        {
            string copieMessage = messages[(int)couleurChoisie];

            for (int i = 0; i < 5; i++)
            {
                textBoxTab[i].Text = "";
                copieMessage = copieMessage.Substring(1, copieMessage.Length - 1);
                while (copieMessage[0] != ']')
                {
                    textBoxTab[i].Text += copieMessage[0];
                    copieMessage = copieMessage.Substring(1, copieMessage.Length - 1);
                }
                copieMessage = copieMessage.Substring(1, copieMessage.Length - 1);
            }
        }


        private void ChangementCouleurBulle(object sender)
        {
            switch (((Cocotte.Couleur)((PictureBox)sender).Tag))
            {
                case Cocotte.Couleur.cyan:
                    pictureBoxBulle.Image = Properties.Resources.bulle_Cyan;
                    textBoxLine1.BackColor =
                        textBoxLine2.BackColor =
                        textBoxLine3.BackColor =
                        textBoxLine4.BackColor =
                        textBoxLine5.BackColor = Color.FromArgb(153, 217, 234);
                    pictureBox_Effacer.Image = Properties.Resources.effacer_cyan2;
                    break;
                case Cocotte.Couleur.rouge:
                    pictureBoxBulle.Image = Properties.Resources.bulle_Rouge;
                    textBoxLine1.BackColor =
                        textBoxLine2.BackColor =
                        textBoxLine3.BackColor =
                        textBoxLine4.BackColor =
                        textBoxLine5.BackColor = Color.FromArgb(237, 28, 36);
                    pictureBox_Effacer.Image = Properties.Resources.effacer_rouge;
                    break;
                case Cocotte.Couleur.violet:
                    pictureBoxBulle.Image = Properties.Resources.bulle_Violet;
                    textBoxLine1.BackColor =
                        textBoxLine2.BackColor =
                        textBoxLine3.BackColor =
                        textBoxLine4.BackColor =
                        textBoxLine5.BackColor = Color.FromArgb(163, 73, 164);
                    pictureBox_Effacer.Image = Properties.Resources.effacer_Violet;
                    break;
                case Cocotte.Couleur.jaune:
                    pictureBoxBulle.Image = Properties.Resources.bulle_Jaune;
                    textBoxLine1.BackColor =
                        textBoxLine2.BackColor =
                        textBoxLine3.BackColor =
                        textBoxLine4.BackColor =
                        textBoxLine5.BackColor = Color.FromArgb(255, 201, 14);
                    pictureBox_Effacer.Image = Properties.Resources.effacer_Jaune;
                    break;
                case Cocotte.Couleur.rose:
                    pictureBoxBulle.Image = Properties.Resources.bulle_Rose;
                    textBoxLine1.BackColor =
                        textBoxLine2.BackColor =
                        textBoxLine3.BackColor =
                        textBoxLine4.BackColor =
                        textBoxLine5.BackColor = Color.FromArgb(255, 174, 201);
                    pictureBox_Effacer.Image = Properties.Resources.effacer_Rose;
                    break;
                case Cocotte.Couleur.bleu:
                    pictureBoxBulle.Image = Properties.Resources.bulle_Bleu;
                    textBoxLine1.BackColor =
                        textBoxLine2.BackColor =
                        textBoxLine3.BackColor =
                        textBoxLine4.BackColor =
                        textBoxLine5.BackColor = Color.FromArgb(63, 72, 204);
                    pictureBox_Effacer.Image = Properties.Resources.effacer_Bleu;
                    break;
                case Cocotte.Couleur.orange:
                    pictureBoxBulle.Image = Properties.Resources.bulle_Orange;
                    textBoxLine1.BackColor =
                        textBoxLine2.BackColor =
                        textBoxLine3.BackColor =
                        textBoxLine4.BackColor =
                        textBoxLine5.BackColor = Color.FromArgb(255, 127, 39);
                    pictureBox_Effacer.Image = Properties.Resources.effacer_Orange;
                    break;
                case Cocotte.Couleur.vert:
                    pictureBoxBulle.Image = Properties.Resources.bulle_Vert;
                    textBoxLine1.BackColor =
                        textBoxLine2.BackColor =
                        textBoxLine3.BackColor =
                        textBoxLine4.BackColor =
                        textBoxLine5.BackColor = Color.FromArgb(181, 230, 29);
                    pictureBox_Effacer.Image = Properties.Resources.effacer_Vert1;
                    break;
            }
        }

        private void pictureBox_Effacer_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                textBoxTab[i].Clear();
            }
            textBoxLine1.Focus();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }

      

        private void textBoxLine1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)((TextBox)sender).Tag != 4 &&
            ((TextBox)sender).Text.Length == ((TextBox)sender).MaxLength)
            {
                string[] temp = ((TextBox)sender).Text.Split(' ');
                ((TextBox)sender).Text = ((TextBox)sender).Text.Substring(0, ((TextBox)sender).Text.Length - temp[temp.Length - 1].Length);
                textBoxTab[(int)((TextBox)sender).Tag + 1].Clear();
                textBoxTab[(int)((TextBox)sender).Tag + 1].Text = temp[temp.Length - 1];
                textBoxTab[(int)((TextBox)sender).Tag + 1].Focus();
                textBoxTab[(int)((TextBox)sender).Tag + 1].SelectionStart = textBoxTab[(int)((TextBox)sender).Tag + 1].Text.Length;
            }
            else if (
                (int)((TextBox)sender).Tag != 0 &&
                string.IsNullOrEmpty(((TextBox)sender).Text) &&
                e.KeyChar == (char)Keys.Back)
            {
                textBoxTab[(int)((TextBox)sender).Tag - 1].Focus();
                textBoxTab[(int)((TextBox)sender).Tag - 1].SelectionStart = textBoxTab[(int)((TextBox)sender).Tag - 1].Text.Length;
            }
        }
    }
}
