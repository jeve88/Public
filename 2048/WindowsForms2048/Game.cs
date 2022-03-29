using ClassLibrary_2048;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms2048
{
    public partial class Game : Form
    {
        Grille maGrille;
        List<Grille> retours;
        List<Grille> nexts;
        bool down;
        bool gameOver;
        bool firstMouve;


        public Game()
        {
            InitializeComponent();

            if (LoadGame("autosave"))
            {
                down = false;
                gameOver = false;
                firstMouve = false;
                nexts = new List<Grille>();
            }
            else
            {
                NewGame();
            }
        }

        private void NewGame()
        {
            maGrille = new Grille(4);
            retours = new List<Grille>();
            nexts = new List<Grille>();
            down = false;
            gameOver = false;
            firstMouve = true;

            InitialiseTagsGrille();

            maGrille.NouveauChiffre();
            maGrille.NouveauChiffre();

            MajIhm();
            UpDown();
        }
        private void FinDePartie()
        {
            MajIhm();
            MessageBox.Show("Bravo! Vous avez atteint 2048...");
        }

        private void InitialiseTagsGrille()
        {
            maGrille.ViensDePasser2048 += FinDePartie;

            label_0_0.Tag = maGrille.grille[0, 0];
            label_0_1.Tag = maGrille.grille[0, 1];
            label_0_2.Tag = maGrille.grille[0, 2];
            label_0_3.Tag = maGrille.grille[0, 3];
            label_1_0.Tag = maGrille.grille[1, 0];
            label_1_1.Tag = maGrille.grille[1, 1];
            label_1_2.Tag = maGrille.grille[1, 2];
            label_1_3.Tag = maGrille.grille[1, 3];
            label_2_0.Tag = maGrille.grille[2, 0];
            label_2_1.Tag = maGrille.grille[2, 1];
            label_2_2.Tag = maGrille.grille[2, 2];
            label_2_3.Tag = maGrille.grille[2, 3];
            label_3_0.Tag = maGrille.grille[3, 0];
            label_3_1.Tag = maGrille.grille[3, 1];
            label_3_2.Tag = maGrille.grille[3, 2];
            label_3_3.Tag = maGrille.grille[3, 3];

            if (maGrille.largeur == 5)
            {
                label_0_4.Tag = maGrille.grille[0, 4];
                label_1_4.Tag = maGrille.grille[1, 4];
                label_2_4.Tag = maGrille.grille[2, 4];
                label_3_4.Tag = maGrille.grille[3, 4];
                label_4_0.Tag = maGrille.grille[4, 0];
                label_4_1.Tag = maGrille.grille[4, 1];
                label_4_2.Tag = maGrille.grille[4, 2];
                label_4_3.Tag = maGrille.grille[4, 3];
                label_4_4.Tag = maGrille.grille[4, 4];
            }
            else
            {
                label_0_4.Tag = maGrille.grille[0, 0];
                label_1_4.Tag = maGrille.grille[0, 0];
                label_2_4.Tag = maGrille.grille[0, 0];
                label_3_4.Tag = maGrille.grille[0, 0];
                label_4_0.Tag = maGrille.grille[0, 0];
                label_4_1.Tag = maGrille.grille[0, 0];
                label_4_2.Tag = maGrille.grille[0, 0];
                label_4_3.Tag = maGrille.grille[0, 0];
                label_4_4.Tag = maGrille.grille[0, 0];
            }
        }

        public void MajIhm()
        {
            foreach (Label label in panel_game.Controls)
            {
                label.Font = new Font("Univers 47 CondensedLight", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label.Text = ((Cases)label.Tag).saValeur.ToString();

                switch (((Cases)label.Tag).saValeur)
                {
                    case 0:
                        label.ResetText();
                        label.BackColor = Color.Gray;
                        break;
                    case 2:
                        label.BackColor = Color.White;
                        label.ForeColor = SystemColors.ControlText;
                        break;
                    case 4:
                        label.BackColor = Color.AntiqueWhite;
                        label.ForeColor = SystemColors.ControlText;
                        break;
                    case 8:
                        label.BackColor = Color.SandyBrown;
                        label.ForeColor = Color.AntiqueWhite;
                        break;
                    case 16:
                        label.BackColor = Color.LightSalmon;
                        label.ForeColor = Color.AntiqueWhite;
                        break;
                    case 32:
                        label.BackColor = Color.Coral;
                        label.ForeColor = Color.AntiqueWhite;
                        break;
                    case 64:
                        label.BackColor = Color.Tomato;
                        label.ForeColor = Color.AntiqueWhite;
                        break;
                    case 128:
                        label.BackColor = Color.FromArgb(238, 205, 115);
                        label.ForeColor = Color.AntiqueWhite;
                        break;
                    case 256:
                        label.BackColor = Color.FromArgb(238, 201, 98);
                        label.ForeColor = Color.AntiqueWhite;
                        break;
                    case 512:
                        label.BackColor = Color.FromArgb(238, 198, 80);
                        label.ForeColor = Color.AntiqueWhite;
                        break;
                    case 1024:
                        label.BackColor = Color.FromArgb(238, 195, 60);
                        label.ForeColor = Color.AntiqueWhite;
                        break;
                    case 2048:
                        label.BackColor = Color.FromArgb(238, 193, 40);
                        label.ForeColor = Color.AntiqueWhite;
                        break;
                    case 4096:
                        label.BackColor = Color.FromArgb(255, 35, 35);
                        label.ForeColor = Color.AntiqueWhite;
                        break;
                    case 8192:
                        label.BackColor = Color.FromArgb(255, 29, 31);
                        label.ForeColor = Color.AntiqueWhite;
                        break;
                    case 131072:
                        label.BackColor = Color.FromArgb(255, 29, 31);
                        label.ForeColor = Color.AntiqueWhite;
                        label.Text = label.Text[0].ToString() + label.Text[1].ToString() + label.Text[2].ToString() + "K";
                        label.Font = new Font("Univers 47 CondensedLight", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        break;
                    default:
                        label.BackColor = Color.FromArgb(255, 29, 31);
                        label.ForeColor = Color.AntiqueWhite;
                        label.Text = label.Text[0].ToString() + label.Text[1].ToString() + "K";
                        break;
                }
            }
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.Q:
                    if (maGrille.DeplacementGauchePossible())
                    {
                        retours.Add(new Grille(maGrille));
                        maGrille.DeplacementGauche();
                        maGrille.NouveauChiffre();
                        MajIhm();
                        gameOver = false;
                        if (firstMouve)
                        {
                            firstMouve = false;
                            if (down)
                            {
                                UpDown();
                            }
                        }
                        if (nexts.Count > 0)
                        {
                            nexts = new List<Grille>();
                        }
                    }
                    break;
                case Keys.Up:
                case Keys.Z:
                    if (maGrille.DeplacementHautPossible())
                    {
                        retours.Add(new Grille(maGrille));
                        maGrille.DeplacementHaut();
                        maGrille.NouveauChiffre();
                        MajIhm();
                        gameOver = false;
                        if (firstMouve)
                        {
                            firstMouve = false;
                            if (down)
                            {
                                UpDown();
                            }
                        }
                        if (nexts.Count > 0)
                        {
                            nexts = new List<Grille>();
                        }
                    }
                    break;
                case Keys.Right:
                case Keys.D:
                    if (maGrille.DeplacementDroitePossible())
                    {
                        retours.Add(new Grille(maGrille));
                        maGrille.DeplacementDroite();
                        maGrille.NouveauChiffre();
                        MajIhm();
                        gameOver = false;
                        if (firstMouve)
                        {
                            firstMouve = false;
                            if (down)
                            {
                                UpDown();
                            }
                        }
                        if (nexts.Count > 0)
                        {
                            nexts = new List<Grille>();
                        }
                    }
                    break;
                case Keys.Down:
                case Keys.S:
                    if (maGrille.DeplacementBasPossible())
                    {
                        retours.Add(new Grille(maGrille));
                        maGrille.DeplacementBas();
                        maGrille.NouveauChiffre();
                        MajIhm();
                        gameOver = false;
                        if (firstMouve)
                        {
                            firstMouve = false;
                            if (down)
                            {
                                UpDown();
                            }
                        }
                        if (nexts.Count > 0)
                        {
                            nexts = new List<Grille>();
                        }
                    }
                    break;
                case Keys.Back:
                    RetourArriere();
                    break;
                case Keys.Insert:
                    Avancer();
                    break;
                default: break;
            }

            if (!maGrille.DeplacementBasPossible() &&
                !maGrille.DeplacementDroitePossible() &&
                !maGrille.DeplacementGauchePossible() &&
                !maGrille.DeplacementHautPossible() &&
                gameOver == false)
            {
                gameOver = true;
                MessageBox.Show("GAME OVER");
            }
        }

        private void RetourArriere()
        {
            if (retours.Count > 0)
            {
                nexts.Add(new Grille(maGrille));

                maGrille = new Grille(retours.Last());

                retours.RemoveAt(retours.Count - 1);
                InitialiseTagsGrille();
                MajIhm();
            }
        }
        private void Avancer()
        {
            if (nexts.Count > 0)
            {
                retours.Add(new Grille(maGrille));

                maGrille = new Grille(nexts.Last());
                nexts.RemoveAt(nexts.Count - 1);
                InitialiseTagsGrille();
                MajIhm();
            }
        }

        private void label_next_Click(object sender, EventArgs e)
        {
            Avancer();
        }

        private void label_back_Click(object sender, EventArgs e)
        {
            RetourArriere();
        }

        private void label_down_Click(object sender, EventArgs e)
        {
            UpDown();
        }

        private void UpDown()
        {
            if (down)
            {
                this.Height = this.Height - 44;
                label_down.Text = "▼";
                panel_commands.Visible = false;
                label_down.Location = new Point(label_down.Location.X, label_down.Location.Y - 40);
                down = false;
            }
            else
            {
                this.Height = this.Height + 44;
                label_down.Text = "▲";
                label_down.Location = new Point(label_down.Location.X, label_down.Location.Y + 40);
                panel_commands.Visible = true;
                down = true;
            }
        }

        private void label_switch_Click(object sender, EventArgs e)
        {
            label_0_4.Visible = !label_0_4.Visible;
            label_1_4.Visible = !label_1_4.Visible;
            label_2_4.Visible = !label_2_4.Visible;
            label_3_4.Visible = !label_3_4.Visible;
            label_4_0.Visible = !label_4_0.Visible;
            label_4_1.Visible = !label_4_1.Visible;
            label_4_2.Visible = !label_4_2.Visible;
            label_4_3.Visible = !label_4_3.Visible;
            label_4_4.Visible = !label_4_4.Visible;

            if (label_0_4.Visible)
            {
                UpDown();
                maGrille = new Grille(5);
                retours = new List<Grille>();
                nexts = new List<Grille>();

                InitialiseTagsGrille();


                maGrille.NouveauChiffre();
                maGrille.NouveauChiffre();

                MajIhm();

                this.Size = new Size(395, 429);
                this.panel_game.Location = new Point(12, 12);
                this.panel_commands.Location = new Point(50, 370);
                this.label_down.Location = new Point(182, 372);
                label_switch.Text = "4X4";
            }
            else
            {
                NewGame();

                this.Size = new Size(321, 355);
                this.panel_game.Location = new Point(12, -65);
                this.panel_commands.Location = new Point(12, 290);
                this.label_down.Location = new Point(144, 292);
                label_switch.Text = "5X5";
            }
        }

        private void label_save_Click(object sender, EventArgs e)
        {
            maGrille.ViensDePasser2048 -= FinDePartie;
            if (maGrille.largeur == 4)
            {
                if ((File.Exists("grille44.bin") &&
                    MessageBox.Show("Une partie est déjà sauvegardé,\nVoulez-vous l'ecraser?", "Save...", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    || !File.Exists("grille44.bin"))
                {
                    Serialisation.Serialize(maGrille, "grille44.bin");

                    if (File.Exists("retour44.bin"))
                    {
                        File.Delete("retour44.bin");
                    }
                    Serialisation.SerializeList(retours, "retour44.bin");

                    if (File.Exists("nexts44.bin"))
                    {
                        File.Delete("nexts44.bin");
                    }
                    if (nexts.Count > 0)
                    {
                        Serialisation.SerializeList(nexts, "nexts44.bin");
                    }
                }
            }
            else
            {
                if ((File.Exists("grille55.bin") &&
                    MessageBox.Show("Une partie est déjà sauvegardé,\nVoulez-vous l'ecraser?", "Save...", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    || !File.Exists("grille55.bin"))
                {
                    Serialisation.Serialize(maGrille, "grille55.bin");

                    if (File.Exists("retour55.bin"))
                    {
                        File.Delete("retour55.bin");
                    }
                    Serialisation.SerializeList(retours, "retour55.bin");

                    if (File.Exists("nexts55.bin"))
                    {
                        File.Delete("nexts55.bin");
                    }
                    if (nexts.Count > 0)
                    {
                        Serialisation.SerializeList(nexts, "nexts55.bin");
                    }

                }
            }
            maGrille.ViensDePasser2048 += FinDePartie;
            UpDown();
        }

        private void SaveGame(string _saveName)
        {
            maGrille.ViensDePasser2048 -= FinDePartie;

            Serialisation.Serialize(maGrille, _saveName + ".bin");

            if (File.Exists(_saveName + "_retour.bin"))
            {
                File.Delete(_saveName + "_retour.bin");
            }
            Serialisation.SerializeList(retours, _saveName + "_retour.bin");

            if (File.Exists(_saveName + "_nexts.bin"))
            {
                File.Delete(_saveName + "_nexts.bin");
            }
            if (nexts.Count > 0)
            {
                Serialisation.SerializeList(nexts, _saveName + "_nexts.bin");
            }

            maGrille.ViensDePasser2048 += FinDePartie;
        }

        private bool LoadGame(string _saveName)
        {
            if (File.Exists(_saveName + ".bin"))
            {
                maGrille = Serialisation.Deserialize(_saveName + ".bin");
                retours = Serialisation.DeserializeList(_saveName + "_retour.bin");
                if (File.Exists(_saveName + "_nexts.bin"))
                {
                    nexts = Serialisation.DeserializeList(_saveName + "_nexts.bin");
                }
                else
                {
                    nexts = new List<Grille>();
                }
                InitialiseTagsGrille();
                MajIhm();

                return true;
            }
            else
            {
                return false;
            }
        }

        private void label_load_Click(object sender, EventArgs e)
        {
            if (firstMouve || MessageBox.Show("Voulez-vous vraiment charger la sauvegarde?\nLa partie en cours sera perdue...", "Load...", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (maGrille.largeur == 4 && File.Exists("grille44.bin"))
                {
                    maGrille = Serialisation.Deserialize("grille44.bin");
                    retours = Serialisation.DeserializeList("retour44.bin");
                    if (File.Exists("nexts44.bin"))
                    {
                        nexts = Serialisation.DeserializeList("nexts44.bin");
                    }
                    InitialiseTagsGrille();
                    MajIhm();
                }
                else if (maGrille.largeur == 5 && File.Exists("grille55.bin"))
                {
                    maGrille = Serialisation.Deserialize("grille55.bin");
                    retours = Serialisation.DeserializeList("retour55.bin");
                    if (File.Exists("nexts55.bin"))
                    {
                        nexts = Serialisation.DeserializeList("nexts55.bin");
                    }
                    InitialiseTagsGrille();
                    MajIhm();
                }
                else
                {
                    MessageBox.Show("Pas de fichier de sauvegarde présent !");
                }
                UpDown();
            }
        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!firstMouve)
            {
                //maGrille.ViensDePasser2048 -= FinDePartie;

                //Serialisation.Serialize(maGrille, "autosave.bin");
                //Serialisation.SerializeList(retours, "autosave_retour.bin");
                //if (nexts.Count > 0)
                //{
                //    Serialisation.SerializeList(nexts, "autosave_nexts.bin");
                //}

                SaveGame("autosave");
            }
        }
    }
}
