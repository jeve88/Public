namespace WinFormsAscenseur
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelAscenseur = new System.Windows.Forms.Panel();
            this.labelFlecheDescendre = new System.Windows.Forms.Label();
            this.labelFlecheMonter = new System.Windows.Forms.Label();
            this.buttonEtages = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button0 = new System.Windows.Forms.Button();
            this.button_1 = new System.Windows.Forms.Button();
            this.buttonEtat = new System.Windows.Forms.Button();
            this.labelEtage = new System.Windows.Forms.Label();
            this.labelEtat = new System.Windows.Forms.Label();
            this.pictureBox19 = new System.Windows.Forms.PictureBox();
            this.pictureBox18 = new System.Windows.Forms.PictureBox();
            this.pictureBox17 = new System.Windows.Forms.PictureBox();
            this.pictureBoxPorteD = new System.Windows.Forms.PictureBox();
            this.pictureBoxPorteG = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelAscenseur.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPorteD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPorteG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelAscenseur
            // 
            this.panelAscenseur.Controls.Add(this.labelFlecheDescendre);
            this.panelAscenseur.Controls.Add(this.labelFlecheMonter);
            this.panelAscenseur.Controls.Add(this.buttonEtages);
            this.panelAscenseur.Controls.Add(this.button3);
            this.panelAscenseur.Controls.Add(this.button2);
            this.panelAscenseur.Controls.Add(this.button1);
            this.panelAscenseur.Controls.Add(this.button0);
            this.panelAscenseur.Controls.Add(this.button_1);
            this.panelAscenseur.Controls.Add(this.buttonEtat);
            this.panelAscenseur.Controls.Add(this.labelEtage);
            this.panelAscenseur.Controls.Add(this.labelEtat);
            this.panelAscenseur.Controls.Add(this.pictureBox19);
            this.panelAscenseur.Controls.Add(this.pictureBox18);
            this.panelAscenseur.Controls.Add(this.pictureBox17);
            this.panelAscenseur.Controls.Add(this.pictureBoxPorteD);
            this.panelAscenseur.Controls.Add(this.pictureBoxPorteG);
            this.panelAscenseur.Controls.Add(this.pictureBox1);
            this.panelAscenseur.Location = new System.Drawing.Point(12, 12);
            this.panelAscenseur.Name = "panelAscenseur";
            this.panelAscenseur.Size = new System.Drawing.Size(396, 513);
            this.panelAscenseur.TabIndex = 0;
            // 
            // labelFlecheDescendre
            // 
            this.labelFlecheDescendre.AutoSize = true;
            this.labelFlecheDescendre.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelFlecheDescendre.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelFlecheDescendre.Location = new System.Drawing.Point(220, 20);
            this.labelFlecheDescendre.Margin = new System.Windows.Forms.Padding(3);
            this.labelFlecheDescendre.Name = "labelFlecheDescendre";
            this.labelFlecheDescendre.Size = new System.Drawing.Size(28, 25);
            this.labelFlecheDescendre.TabIndex = 15;
            this.labelFlecheDescendre.Text = "▼";
            // 
            // labelFlecheMonter
            // 
            this.labelFlecheMonter.AutoSize = true;
            this.labelFlecheMonter.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelFlecheMonter.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelFlecheMonter.Location = new System.Drawing.Point(147, 20);
            this.labelFlecheMonter.Margin = new System.Windows.Forms.Padding(3);
            this.labelFlecheMonter.Name = "labelFlecheMonter";
            this.labelFlecheMonter.Size = new System.Drawing.Size(28, 25);
            this.labelFlecheMonter.TabIndex = 14;
            this.labelFlecheMonter.Text = "▲";
            // 
            // buttonEtages
            // 
            this.buttonEtages.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.buttonEtages.Font = new System.Drawing.Font("Segoe UI", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonEtages.Location = new System.Drawing.Point(350, 442);
            this.buttonEtages.Name = "buttonEtages";
            this.buttonEtages.Size = new System.Drawing.Size(31, 23);
            this.buttonEtages.TabIndex = 5;
            this.buttonEtages.Text = "Etages";
            this.buttonEtages.UseVisualStyleBackColor = false;
            this.buttonEtages.Click += new System.EventHandler(this.buttonEtages_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(352, 203);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(29, 23);
            this.button3.TabIndex = 4;
            this.button3.Tag = "3";
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(352, 232);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(29, 23);
            this.button2.TabIndex = 3;
            this.button2.Tag = "2";
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(352, 261);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 23);
            this.button1.TabIndex = 2;
            this.button1.Tag = "1";
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button_Click);
            // 
            // button0
            // 
            this.button0.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button0.Location = new System.Drawing.Point(352, 290);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(29, 23);
            this.button0.TabIndex = 1;
            this.button0.Tag = "0";
            this.button0.Text = "0";
            this.button0.UseVisualStyleBackColor = true;
            this.button0.Click += new System.EventHandler(this.button_Click);
            // 
            // button_1
            // 
            this.button_1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_1.Location = new System.Drawing.Point(352, 319);
            this.button_1.Name = "button_1";
            this.button_1.Size = new System.Drawing.Size(29, 23);
            this.button_1.TabIndex = 0;
            this.button_1.Tag = "-1";
            this.button_1.Text = "-1";
            this.button_1.UseVisualStyleBackColor = true;
            this.button_1.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonEtat
            // 
            this.buttonEtat.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.buttonEtat.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonEtat.Location = new System.Drawing.Point(13, 442);
            this.buttonEtat.Name = "buttonEtat";
            this.buttonEtat.Size = new System.Drawing.Size(30, 23);
            this.buttonEtat.TabIndex = 9;
            this.buttonEtat.Text = "Etat";
            this.buttonEtat.UseVisualStyleBackColor = false;
            this.buttonEtat.Click += new System.EventHandler(this.buttonEtat_Click);
            // 
            // labelEtage
            // 
            this.labelEtage.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelEtage.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelEtage.ForeColor = System.Drawing.Color.Lime;
            this.labelEtage.Location = new System.Drawing.Point(181, 16);
            this.labelEtage.Name = "labelEtage";
            this.labelEtage.Size = new System.Drawing.Size(33, 30);
            this.labelEtage.TabIndex = 5;
            this.labelEtage.Text = "1";
            this.labelEtage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelEtat
            // 
            this.labelEtat.AutoSize = true;
            this.labelEtat.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelEtat.Location = new System.Drawing.Point(54, 467);
            this.labelEtat.Name = "labelEtat";
            this.labelEtat.Size = new System.Drawing.Size(285, 40);
            this.labelEtat.TabIndex = 10;
            this.labelEtat.Text = "Etat : Porte ouverte";
            // 
            // pictureBox19
            // 
            this.pictureBox19.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox19.Location = new System.Drawing.Point(11, 14);
            this.pictureBox19.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox19.Name = "pictureBox19";
            this.pictureBox19.Size = new System.Drawing.Size(372, 34);
            this.pictureBox19.TabIndex = 12;
            this.pictureBox19.TabStop = false;
            // 
            // pictureBox18
            // 
            this.pictureBox18.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox18.Location = new System.Drawing.Point(11, 48);
            this.pictureBox18.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox18.Name = "pictureBox18";
            this.pictureBox18.Size = new System.Drawing.Size(34, 419);
            this.pictureBox18.TabIndex = 11;
            this.pictureBox18.TabStop = false;
            // 
            // pictureBox17
            // 
            this.pictureBox17.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox17.Location = new System.Drawing.Point(349, 48);
            this.pictureBox17.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox17.Name = "pictureBox17";
            this.pictureBox17.Size = new System.Drawing.Size(34, 419);
            this.pictureBox17.TabIndex = 10;
            this.pictureBox17.TabStop = false;
            // 
            // pictureBoxPorteD
            // 
            this.pictureBoxPorteD.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBoxPorteD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPorteD.Location = new System.Drawing.Point(197, 48);
            this.pictureBoxPorteD.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxPorteD.Name = "pictureBoxPorteD";
            this.pictureBoxPorteD.Size = new System.Drawing.Size(152, 419);
            this.pictureBoxPorteD.TabIndex = 7;
            this.pictureBoxPorteD.TabStop = false;
            // 
            // pictureBoxPorteG
            // 
            this.pictureBoxPorteG.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBoxPorteG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPorteG.Location = new System.Drawing.Point(45, 48);
            this.pictureBoxPorteG.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxPorteG.Name = "pictureBoxPorteG";
            this.pictureBoxPorteG.Size = new System.Drawing.Size(152, 419);
            this.pictureBoxPorteG.TabIndex = 6;
            this.pictureBoxPorteG.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox1.Location = new System.Drawing.Point(28, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(333, 433);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 537);
            this.Controls.Add(this.panelAscenseur);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelAscenseur.ResumeLayout(false);
            this.panelAscenseur.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPorteD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPorteG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelAscenseur;
        private Label labelEtage;
        private Button button3;
        private Button button2;
        private Button button1;
        private Button button0;
        private Button button_1;
        private PictureBox pictureBoxPorteD;
        private PictureBox pictureBoxPorteG;
        private System.Windows.Forms.Timer timer1;
        private Button buttonEtages;
        private Button buttonEtat;
        private Label labelEtat;
        private PictureBox pictureBox19;
        private PictureBox pictureBox18;
        private PictureBox pictureBox17;
        private PictureBox pictureBox1;
        private Label labelFlecheDescendre;
        private Label labelFlecheMonter;
    }
}