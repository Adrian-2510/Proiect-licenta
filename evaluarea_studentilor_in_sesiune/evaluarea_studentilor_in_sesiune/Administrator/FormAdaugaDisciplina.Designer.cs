
namespace evaluarea_studentilor_in_sesiune
{
    partial class FormAdaugaDisciplina
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
            this.buttonStergereDisciplina = new System.Windows.Forms.Button();
            this.buttonActulizeazaDisciplina = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCautareDisciplina = new System.Windows.Forms.TextBox();
            this.buttonInapoi = new System.Windows.Forms.Button();
            this.listBoxDiscipline = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDescriereDisciplina = new System.Windows.Forms.TextBox();
            this.buttonAdaugaDisciplina = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDenumireDisciplina = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonStergereDisciplina);
            this.panel1.Controls.Add(this.buttonActulizeazaDisciplina);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxCautareDisciplina);
            this.panel1.Controls.Add(this.buttonInapoi);
            this.panel1.Controls.Add(this.listBoxDiscipline);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxDescriereDisciplina);
            this.panel1.Controls.Add(this.buttonAdaugaDisciplina);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxDenumireDisciplina);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1904, 1041);
            this.panel1.TabIndex = 2;
            // 
            // buttonStergereDisciplina
            // 
            this.buttonStergereDisciplina.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonStergereDisciplina.Location = new System.Drawing.Point(1430, 754);
            this.buttonStergereDisciplina.Name = "buttonStergereDisciplina";
            this.buttonStergereDisciplina.Size = new System.Drawing.Size(173, 91);
            this.buttonStergereDisciplina.TabIndex = 11;
            this.buttonStergereDisciplina.Text = "Stergere disicipina";
            this.buttonStergereDisciplina.UseVisualStyleBackColor = true;
            this.buttonStergereDisciplina.Click += new System.EventHandler(this.buttonStergereDisciplina_Click);
            // 
            // buttonActulizeazaDisciplina
            // 
            this.buttonActulizeazaDisciplina.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonActulizeazaDisciplina.Location = new System.Drawing.Point(1689, 754);
            this.buttonActulizeazaDisciplina.Name = "buttonActulizeazaDisciplina";
            this.buttonActulizeazaDisciplina.Size = new System.Drawing.Size(173, 91);
            this.buttonActulizeazaDisciplina.TabIndex = 10;
            this.buttonActulizeazaDisciplina.Text = "Actualizare disciplina";
            this.buttonActulizeazaDisciplina.UseVisualStyleBackColor = true;
            this.buttonActulizeazaDisciplina.Click += new System.EventHandler(this.buttonActulizeazaDisciplina_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(1430, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 36);
            this.label4.TabIndex = 9;
            this.label4.Text = "Cautare:";
            // 
            // textBoxCautareDisciplina
            // 
            this.textBoxCautareDisciplina.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxCautareDisciplina.Location = new System.Drawing.Point(1430, 245);
            this.textBoxCautareDisciplina.Name = "textBoxCautareDisciplina";
            this.textBoxCautareDisciplina.Size = new System.Drawing.Size(432, 44);
            this.textBoxCautareDisciplina.TabIndex = 8;
            this.textBoxCautareDisciplina.TextChanged += new System.EventHandler(this.textBoxCautareDisciplina_TextChanged);
            // 
            // buttonInapoi
            // 
            this.buttonInapoi.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonInapoi.Location = new System.Drawing.Point(1680, 970);
            this.buttonInapoi.Name = "buttonInapoi";
            this.buttonInapoi.Size = new System.Drawing.Size(182, 59);
            this.buttonInapoi.TabIndex = 7;
            this.buttonInapoi.Text = "Inapoi";
            this.buttonInapoi.UseVisualStyleBackColor = true;
            this.buttonInapoi.Click += new System.EventHandler(this.buttonInapoi_Click);
            // 
            // listBoxDiscipline
            // 
            this.listBoxDiscipline.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBoxDiscipline.FormattingEnabled = true;
            this.listBoxDiscipline.HorizontalScrollbar = true;
            this.listBoxDiscipline.ItemHeight = 27;
            this.listBoxDiscipline.Location = new System.Drawing.Point(1430, 298);
            this.listBoxDiscipline.Name = "listBoxDiscipline";
            this.listBoxDiscipline.Size = new System.Drawing.Size(432, 436);
            this.listBoxDiscipline.TabIndex = 6;
            this.listBoxDiscipline.Click += new System.EventHandler(this.listBoxDiscipline_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(337, 378);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(293, 40);
            this.label3.TabIndex = 5;
            this.label3.Text = "Descriere disciplina";
            // 
            // textBoxDescriereDisciplina
            // 
            this.textBoxDescriereDisciplina.Location = new System.Drawing.Point(646, 368);
            this.textBoxDescriereDisciplina.Multiline = true;
            this.textBoxDescriereDisciplina.Name = "textBoxDescriereDisciplina";
            this.textBoxDescriereDisciplina.Size = new System.Drawing.Size(481, 50);
            this.textBoxDescriereDisciplina.TabIndex = 4;
            this.textBoxDescriereDisciplina.TextChanged += new System.EventHandler(this.textBoxDescriereDisciplina_TextChanged);
            // 
            // buttonAdaugaDisciplina
            // 
            this.buttonAdaugaDisciplina.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAdaugaDisciplina.Location = new System.Drawing.Point(1133, 368);
            this.buttonAdaugaDisciplina.Name = "buttonAdaugaDisciplina";
            this.buttonAdaugaDisciplina.Size = new System.Drawing.Size(220, 50);
            this.buttonAdaugaDisciplina.TabIndex = 3;
            this.buttonAdaugaDisciplina.Text = "Adauga disciplina";
            this.buttonAdaugaDisciplina.UseVisualStyleBackColor = true;
            this.buttonAdaugaDisciplina.Click += new System.EventHandler(this.buttonAdaugaDisciplina_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(330, 303);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(300, 40);
            this.label2.TabIndex = 2;
            this.label2.Text = "Denumire disciplina";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(805, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 55);
            this.label1.TabIndex = 1;
            this.label1.Text = "Adauga disciplina";
            // 
            // textBoxDenumireDisciplina
            // 
            this.textBoxDenumireDisciplina.Location = new System.Drawing.Point(646, 298);
            this.textBoxDenumireDisciplina.Name = "textBoxDenumireDisciplina";
            this.textBoxDenumireDisciplina.Size = new System.Drawing.Size(644, 44);
            this.textBoxDenumireDisciplina.TabIndex = 0;
            // 
            // FormAdaugaDisciplina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormAdaugaDisciplina";
            this.Text = "FormAdaugaDisciplina";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxDenumireDisciplina;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAdaugaDisciplina;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDescriereDisciplina;
        private System.Windows.Forms.Button buttonInapoi;
        private System.Windows.Forms.ListBox listBoxDiscipline;
        private System.Windows.Forms.TextBox textBoxCautareDisciplina;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonActulizeazaDisciplina;
        private System.Windows.Forms.Button buttonStergereDisciplina;
    }
}