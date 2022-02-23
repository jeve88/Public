namespace WinFormsAscenseur
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.porte3 = new WinFormsControlLibraryAscenseur.Porte();
            this.porte2 = new WinFormsControlLibraryAscenseur.Porte();
            this.porte1 = new WinFormsControlLibraryAscenseur.Porte();
            this.porte0 = new WinFormsControlLibraryAscenseur.Porte();
            this.porte_1 = new WinFormsControlLibraryAscenseur.Porte();
            this.pictureBoxAscenseur = new System.Windows.Forms.PictureBox();
            this.pictureBoxCable1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxCable2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAscenseur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCable2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // porte3
            // 
            this.porte3.BackColor = System.Drawing.Color.Transparent;
            this.porte3.Location = new System.Drawing.Point(29, 13);
            this.porte3.Margin = new System.Windows.Forms.Padding(20);
            this.porte3.Name = "porte3";
            this.porte3.Size = new System.Drawing.Size(192, 129);
            this.porte3.TabIndex = 0;
            // 
            // porte2
            // 
            this.porte2.BackColor = System.Drawing.Color.Transparent;
            this.porte2.Location = new System.Drawing.Point(29, 163);
            this.porte2.Margin = new System.Windows.Forms.Padding(20);
            this.porte2.Name = "porte2";
            this.porte2.Size = new System.Drawing.Size(192, 129);
            this.porte2.TabIndex = 1;
            // 
            // porte1
            // 
            this.porte1.BackColor = System.Drawing.Color.Transparent;
            this.porte1.Location = new System.Drawing.Point(29, 313);
            this.porte1.Margin = new System.Windows.Forms.Padding(20);
            this.porte1.Name = "porte1";
            this.porte1.Size = new System.Drawing.Size(192, 129);
            this.porte1.TabIndex = 2;
            // 
            // porte0
            // 
            this.porte0.BackColor = System.Drawing.Color.Transparent;
            this.porte0.Location = new System.Drawing.Point(29, 463);
            this.porte0.Margin = new System.Windows.Forms.Padding(20);
            this.porte0.Name = "porte0";
            this.porte0.Size = new System.Drawing.Size(192, 129);
            this.porte0.TabIndex = 3;
            // 
            // porte_1
            // 
            this.porte_1.BackColor = System.Drawing.Color.Transparent;
            this.porte_1.Location = new System.Drawing.Point(29, 613);
            this.porte_1.Margin = new System.Windows.Forms.Padding(20);
            this.porte_1.Name = "porte_1";
            this.porte_1.Size = new System.Drawing.Size(192, 129);
            this.porte_1.TabIndex = 4;
            // 
            // pictureBoxAscenseur
            // 
            this.pictureBoxAscenseur.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBoxAscenseur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxAscenseur.Location = new System.Drawing.Point(39, 1006);
            this.pictureBoxAscenseur.Name = "pictureBoxAscenseur";
            this.pictureBoxAscenseur.Size = new System.Drawing.Size(147, 149);
            this.pictureBoxAscenseur.TabIndex = 5;
            this.pictureBoxAscenseur.TabStop = false;
            // 
            // pictureBoxCable1
            // 
            this.pictureBoxCable1.BackColor = System.Drawing.Color.Black;
            this.pictureBoxCable1.Location = new System.Drawing.Point(123, -46);
            this.pictureBoxCable1.Name = "pictureBoxCable1";
            this.pictureBoxCable1.Size = new System.Drawing.Size(5, 1053);
            this.pictureBoxCable1.TabIndex = 6;
            this.pictureBoxCable1.TabStop = false;
            // 
            // pictureBoxCable2
            // 
            this.pictureBoxCable2.BackColor = System.Drawing.Color.Black;
            this.pictureBoxCable2.Location = new System.Drawing.Point(96, -46);
            this.pictureBoxCable2.Name = "pictureBoxCable2";
            this.pictureBoxCable2.Size = new System.Drawing.Size(5, 1053);
            this.pictureBoxCable2.TabIndex = 7;
            this.pictureBoxCable2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.pictureBoxAscenseur);
            this.panel1.Controls.Add(this.pictureBoxCable2);
            this.panel1.Controls.Add(this.pictureBoxCable1);
            this.panel1.Location = new System.Drawing.Point(-20, -553);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 1400);
            this.panel1.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(265, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(246, 749);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.porte_1);
            this.Controls.Add(this.porte0);
            this.Controls.Add(this.porte1);
            this.Controls.Add(this.porte2);
            this.Controls.Add(this.porte3);
            this.Controls.Add(this.panel1);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAscenseur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCable2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private WinFormsControlLibraryAscenseur.Porte porte3;
        private WinFormsControlLibraryAscenseur.Porte porte2;
        private WinFormsControlLibraryAscenseur.Porte porte1;
        private WinFormsControlLibraryAscenseur.Porte porte0;
        private WinFormsControlLibraryAscenseur.Porte porte_1;
        private PictureBox pictureBoxAscenseur;
        private PictureBox pictureBoxCable1;
        private PictureBox pictureBoxCable2;
        private Panel panel1;
        private Button button1;
    }
}