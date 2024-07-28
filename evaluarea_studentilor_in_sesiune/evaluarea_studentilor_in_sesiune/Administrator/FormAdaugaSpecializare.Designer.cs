
namespace evaluarea_studentilor_in_sesiune
{
    partial class FormAdaugaSpecializare
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownNumarAniSDeStudiu = new System.Windows.Forms.NumericUpDown();
            this.buttonInapoi = new System.Windows.Forms.Button();
            this.buttonStergeSpeicializarea = new System.Windows.Forms.Button();
            this.buttonActualizeazaSpecializarea = new System.Windows.Forms.Button();
            this.buttonAdaugaaSpecializre = new System.Windows.Forms.Button();
            this.listBoxSpecializare = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDenumireSpecializare = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumarAniSDeStudiu)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.numericUpDownNumarAniSDeStudiu);
            this.panel1.Controls.Add(this.buttonInapoi);
            this.panel1.Controls.Add(this.buttonStergeSpeicializarea);
            this.panel1.Controls.Add(this.buttonActualizeazaSpecializarea);
            this.panel1.Controls.Add(this.buttonAdaugaaSpecializre);
            this.panel1.Controls.Add(this.listBoxSpecializare);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxDenumireSpecializare);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1924, 1061);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(335, 395);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(305, 40);
            this.label3.TabIndex = 9;
            this.label3.Text = "Numar ani de studiu";
            // 
            // numericUpDownNumarAniSDeStudiu
            // 
            this.numericUpDownNumarAniSDeStudiu.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericUpDownNumarAniSDeStudiu.Location = new System.Drawing.Point(646, 391);
            this.numericUpDownNumarAniSDeStudiu.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDownNumarAniSDeStudiu.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNumarAniSDeStudiu.Name = "numericUpDownNumarAniSDeStudiu";
            this.numericUpDownNumarAniSDeStudiu.Size = new System.Drawing.Size(120, 44);
            this.numericUpDownNumarAniSDeStudiu.TabIndex = 8;
            this.numericUpDownNumarAniSDeStudiu.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // buttonInapoi
            // 
            this.buttonInapoi.Location = new System.Drawing.Point(1603, 927);
            this.buttonInapoi.Name = "buttonInapoi";
            this.buttonInapoi.Size = new System.Drawing.Size(281, 87);
            this.buttonInapoi.TabIndex = 7;
            this.buttonInapoi.Text = "Inapoi";
            this.buttonInapoi.UseVisualStyleBackColor = true;
            this.buttonInapoi.Click += new System.EventHandler(this.buttonInapoi_Click);
            // 
            // buttonStergeSpeicializarea
            // 
            this.buttonStergeSpeicializarea.Image = global::evaluarea_studentilor_in_sesiune.Properties.Resources._6217227_bin_fly_garbage_trash_icon1;
            this.buttonStergeSpeicializarea.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonStergeSpeicializarea.Location = new System.Drawing.Point(1458, 764);
            this.buttonStergeSpeicializarea.Name = "buttonStergeSpeicializarea";
            this.buttonStergeSpeicializarea.Size = new System.Drawing.Size(361, 63);
            this.buttonStergeSpeicializarea.TabIndex = 6;
            this.buttonStergeSpeicializarea.Text = "Sterge specializarea";
            this.buttonStergeSpeicializarea.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonStergeSpeicializarea.UseVisualStyleBackColor = true;
            this.buttonStergeSpeicializarea.Click += new System.EventHandler(this.buttonStergeSpeicializarea_Click);
            // 
            // buttonActualizeazaSpecializarea
            // 
            this.buttonActualizeazaSpecializarea.Location = new System.Drawing.Point(972, 421);
            this.buttonActualizeazaSpecializarea.Name = "buttonActualizeazaSpecializarea";
            this.buttonActualizeazaSpecializarea.Size = new System.Drawing.Size(318, 89);
            this.buttonActualizeazaSpecializarea.TabIndex = 5;
            this.buttonActualizeazaSpecializarea.Text = "Actualizeaza specializarea";
            this.buttonActualizeazaSpecializarea.UseVisualStyleBackColor = true;
            this.buttonActualizeazaSpecializarea.Click += new System.EventHandler(this.buttonActualizeazaSpecializarea_Click);
            // 
            // buttonAdaugaaSpecializre
            // 
            this.buttonAdaugaaSpecializre.Location = new System.Drawing.Point(972, 352);
            this.buttonAdaugaaSpecializre.Name = "buttonAdaugaaSpecializre";
            this.buttonAdaugaaSpecializre.Size = new System.Drawing.Size(318, 63);
            this.buttonAdaugaaSpecializre.TabIndex = 4;
            this.buttonAdaugaaSpecializre.Text = "Adauga specializare";
            this.buttonAdaugaaSpecializre.UseVisualStyleBackColor = true;
            this.buttonAdaugaaSpecializre.Click += new System.EventHandler(this.buttonAdaugaaSpecializre_Click);
            // 
            // listBoxSpecializare
            // 
            this.listBoxSpecializare.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.listBoxSpecializare.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBoxSpecializare.FormattingEnabled = true;
            this.listBoxSpecializare.HorizontalScrollbar = true;
            this.listBoxSpecializare.ItemHeight = 23;
            this.listBoxSpecializare.Location = new System.Drawing.Point(1363, 298);
            this.listBoxSpecializare.Name = "listBoxSpecializare";
            this.listBoxSpecializare.Size = new System.Drawing.Size(456, 441);
            this.listBoxSpecializare.TabIndex = 3;
            this.listBoxSpecializare.Click += new System.EventHandler(this.listBoxSpecializare_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(312, 306);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(328, 40);
            this.label2.TabIndex = 2;
            this.label2.Text = "Denumire specializare";
            // 
            // textBoxDenumireSpecializare
            // 
            this.textBoxDenumireSpecializare.Location = new System.Drawing.Point(646, 298);
            this.textBoxDenumireSpecializare.Name = "textBoxDenumireSpecializare";
            this.textBoxDenumireSpecializare.Size = new System.Drawing.Size(644, 48);
            this.textBoxDenumireSpecializare.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(805, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(427, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Adauga specializarea";
            // 
            // FormAdaugaSpecializare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 40F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1061);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "FormAdaugaSpecializare";
            this.Text = "FormAdaugaSpecializare";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumarAniSDeStudiu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxSpecializare;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDenumireSpecializare;
        private System.Windows.Forms.Button buttonStergeSpeicializarea;
        private System.Windows.Forms.Button buttonActualizeazaSpecializarea;
        private System.Windows.Forms.Button buttonAdaugaaSpecializre;
        private System.Windows.Forms.Button buttonInapoi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownNumarAniSDeStudiu;
    }
}