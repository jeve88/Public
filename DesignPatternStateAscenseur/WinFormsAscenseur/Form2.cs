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

namespace WinFormsAscenseur
{
    public partial class Form2 : Form
    {
        private Ascenseur? ascenseur;
        Thread? t;

        public Form2()
        {
            InitializeComponent();

        }
        public Form2(Ascenseur _ascenseur)
        {
            InitializeComponent();

            ascenseur = _ascenseur;

            porte_1.InitialiserPorte(ascenseur.etages[-1],true,false);
            porte0.InitialiserPorte(ascenseur.etages[0]);
            porte1.InitialiserPorte(ascenseur.etages[1]);
            porte2.InitialiserPorte(ascenseur.etages[2]);
            porte3.InitialiserPorte(ascenseur.etages[3],false,true);

            ascenseur.EventChangementEtage += ThreadMethodChangementEtage;


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            porte_1.MajIhm();
            porte0.MajIhm();
            porte1.MajIhm();
            porte2.MajIhm();
            porte3.MajIhm();
            
        }

      
        private void ThreadMethodChangementEtage(bool _monte)
        {
            if (_monte)
            {
                t = new Thread(new ThreadStart(ThreadMonte));
                t.Start();
            }
            else
            {
                t = new Thread(new ThreadStart(ThreadDescend));
                t.Start();
            }

        }

        private void ThreadMonte()
        {
            int count = 0;
            while (count < 50)
            {
                Thread.Sleep(40);
                panel1.Invoke(new MethodInvoker(delegate
                {
                    panel1.Location = new Point(panel1.Location.X, panel1.Location.Y - 3);
                }));
                count++;
            }
        }

        private void ThreadDescend()
        {
            int count = 0;
            while (count < 50)
            {
                Thread.Sleep(40);
                panel1.Invoke(new MethodInvoker(delegate
                {
                    panel1.Location = new Point(panel1.Location.X, panel1.Location.Y + 3);
                }));
                count++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Location = new Point(panel1.Location.X, panel1.Location.Y-5);  
        }
    }
}
