
namespace evaluarea_studentilor_in_sesiune
{
    partial class FormLogareAdministrator
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
            this.labelBunVenitAdmin = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonActivareCont = new System.Windows.Forms.Button();
            this.dataGridViewInfomatiiSuplimentareCont = new System.Windows.Forms.DataGridView();
            this.dataGridViewConturiInactiveDezecativate = new System.Windows.Forms.DataGridView();
            this.panelMeniu = new System.Windows.Forms.Panel();
            this.buttonAsociereprofesorDisciplinaGrupa = new System.Windows.Forms.Button();
            this.buttonAdaugaGrupele = new System.Windows.Forms.Button();
            this.labelMeniu = new System.Windows.Forms.Label();
            this.pictureBoxMeniu = new System.Windows.Forms.PictureBox();
            this.buttonConturiInactiveSauDezacrivate = new System.Windows.Forms.Button();
            this.buttonAdaugaSpecializarw = new System.Windows.Forms.Button();
            this.buttonAdaugaDisciplina = new System.Windows.Forms.Button();
            this.buttonAdaugaStudentProfesor = new System.Windows.Forms.Button();
            this.buttonConturiInAdministrare = new System.Windows.Forms.Button();
            this.panelLabel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxDelogare = new System.Windows.Forms.PictureBox();
            this.timerAnimareMeniu = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInfomatiiSuplimentareCont)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConturiInactiveDezecativate)).BeginInit();
            this.panelMeniu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMeniu)).BeginInit();
            this.panelLabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDelogare)).BeginInit();
            this.SuspendLayout();
            // 
            // labelBunVenitAdmin
            // 
            this.labelBunVenitAdmin.AutoSize = true;
            this.labelBunVenitAdmin.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelBunVenitAdmin.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labelBunVenitAdmin.Location = new System.Drawing.Point(183, 37);
            this.labelBunVenitAdmin.Name = "labelBunVenitAdmin";
            this.labelBunVenitAdmin.Size = new System.Drawing.Size(796, 55);
            this.labelBunVenitAdmin.TabIndex = 0;
            this.labelBunVenitAdmin.Text = "Bun venit domnul/doamna Administrator\r\n";
            this.labelBunVenitAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::evaluarea_studentilor_in_sesiune.Properties.Resources.books_2596809_19201;
            this.panel1.Controls.Add(this.buttonActivareCont);
            this.panel1.Controls.Add(this.dataGridViewInfomatiiSuplimentareCont);
            this.panel1.Controls.Add(this.dataGridViewConturiInactiveDezecativate);
            this.panel1.Controls.Add(this.panelMeniu);
            this.panel1.Controls.Add(this.panelLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1904, 1041);
            this.panel1.TabIndex = 1;
            // 
            // buttonActivareCont
            // 
            this.buttonActivareCont.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonActivareCont.FlatAppearance.BorderSize = 0;
            this.buttonActivareCont.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.buttonActivareCont.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.buttonActivareCont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonActivareCont.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonActivareCont.ForeColor = System.Drawing.SystemColors.WindowText;
            this.buttonActivareCont.Image = global::evaluarea_studentilor_in_sesiune.Properties.Resources._9004846_tick_check_mark_accept_icon;
            this.buttonActivareCont.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonActivareCont.Location = new System.Drawing.Point(953, 410);
            this.buttonActivareCont.Name = "buttonActivareCont";
            this.buttonActivareCont.Size = new System.Drawing.Size(214, 54);
            this.buttonActivareCont.TabIndex = 6;
            this.buttonActivareCont.Text = "Activare cont";
            this.buttonActivareCont.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonActivareCont.UseVisualStyleBackColor = false;
            this.buttonActivareCont.Visible = false;
            this.buttonActivareCont.Click += new System.EventHandler(this.buttonActivareCont_Click);
            // 
            // dataGridViewInfomatiiSuplimentareCont
            // 
            this.dataGridViewInfomatiiSuplimentareCont.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewInfomatiiSuplimentareCont.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInfomatiiSuplimentareCont.Location = new System.Drawing.Point(532, 532);
            this.dataGridViewInfomatiiSuplimentareCont.Name = "dataGridViewInfomatiiSuplimentareCont";
            this.dataGridViewInfomatiiSuplimentareCont.RowTemplate.Height = 25;
            this.dataGridViewInfomatiiSuplimentareCont.Size = new System.Drawing.Size(983, 172);
            this.dataGridViewInfomatiiSuplimentareCont.TabIndex = 5;
            this.dataGridViewInfomatiiSuplimentareCont.Visible = false;
            // 
            // dataGridViewConturiInactiveDezecativate
            // 
            this.dataGridViewConturiInactiveDezecativate.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewConturiInactiveDezecativate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewConturiInactiveDezecativate.Location = new System.Drawing.Point(588, 248);
            this.dataGridViewConturiInactiveDezecativate.Name = "dataGridViewConturiInactiveDezecativate";
            this.dataGridViewConturiInactiveDezecativate.RowTemplate.Height = 25;
            this.dataGridViewConturiInactiveDezecativate.Size = new System.Drawing.Size(579, 156);
            this.dataGridViewConturiInactiveDezecativate.TabIndex = 4;
            this.dataGridViewConturiInactiveDezecativate.Visible = false;
            this.dataGridViewConturiInactiveDezecativate.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewConturiInactiveDezecativate_CellContentClick);
            this.dataGridViewConturiInactiveDezecativate.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewConturiInactiveDezecativate_CellFormatting);
            // 
            // panelMeniu
            // 
            this.panelMeniu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelMeniu.Controls.Add(this.buttonAsociereprofesorDisciplinaGrupa);
            this.panelMeniu.Controls.Add(this.buttonAdaugaGrupele);
            this.panelMeniu.Controls.Add(this.labelMeniu);
            this.panelMeniu.Controls.Add(this.pictureBoxMeniu);
            this.panelMeniu.Controls.Add(this.buttonConturiInactiveSauDezacrivate);
            this.panelMeniu.Controls.Add(this.buttonAdaugaSpecializarw);
            this.panelMeniu.Controls.Add(this.buttonAdaugaDisciplina);
            this.panelMeniu.Controls.Add(this.buttonAdaugaStudentProfesor);
            this.panelMeniu.Controls.Add(this.buttonConturiInAdministrare);
            this.panelMeniu.Location = new System.Drawing.Point(3, 2);
            this.panelMeniu.MaximumSize = new System.Drawing.Size(365, 1036);
            this.panelMeniu.MinimumSize = new System.Drawing.Size(365, 125);
            this.panelMeniu.Name = "panelMeniu";
            this.panelMeniu.Size = new System.Drawing.Size(365, 1036);
            this.panelMeniu.TabIndex = 3;
            // 
            // buttonAsociereprofesorDisciplinaGrupa
            // 
            this.buttonAsociereprofesorDisciplinaGrupa.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonAsociereprofesorDisciplinaGrupa.FlatAppearance.BorderSize = 3;
            this.buttonAsociereprofesorDisciplinaGrupa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAsociereprofesorDisciplinaGrupa.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAsociereprofesorDisciplinaGrupa.ForeColor = System.Drawing.Color.White;
            this.buttonAsociereprofesorDisciplinaGrupa.Image = global::evaluarea_studentilor_in_sesiune.Properties.Resources._8666769_link_connection_icon;
            this.buttonAsociereprofesorDisciplinaGrupa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAsociereprofesorDisciplinaGrupa.Location = new System.Drawing.Point(3, 816);
            this.buttonAsociereprofesorDisciplinaGrupa.Name = "buttonAsociereprofesorDisciplinaGrupa";
            this.buttonAsociereprofesorDisciplinaGrupa.Size = new System.Drawing.Size(348, 105);
            this.buttonAsociereprofesorDisciplinaGrupa.TabIndex = 7;
            this.buttonAsociereprofesorDisciplinaGrupa.Text = "Asociere profesor , disciplina, grupa";
            this.buttonAsociereprofesorDisciplinaGrupa.UseVisualStyleBackColor = true;
            this.buttonAsociereprofesorDisciplinaGrupa.Click += new System.EventHandler(this.buttonAsociereprofesorDisciplinaGrupa_Click);
            // 
            // buttonAdaugaGrupele
            // 
            this.buttonAdaugaGrupele.FlatAppearance.BorderSize = 3;
            this.buttonAdaugaGrupele.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.buttonAdaugaGrupele.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonAdaugaGrupele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdaugaGrupele.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAdaugaGrupele.ForeColor = System.Drawing.Color.White;
            this.buttonAdaugaGrupele.Image = global::evaluarea_studentilor_in_sesiune.Properties.Resources._8666718_plus_circle_icon3;
            this.buttonAdaugaGrupele.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdaugaGrupele.Location = new System.Drawing.Point(3, 702);
            this.buttonAdaugaGrupele.Name = "buttonAdaugaGrupele";
            this.buttonAdaugaGrupele.Size = new System.Drawing.Size(348, 105);
            this.buttonAdaugaGrupele.TabIndex = 4;
            this.buttonAdaugaGrupele.Text = "Adauga grupele";
            this.buttonAdaugaGrupele.UseVisualStyleBackColor = true;
            this.buttonAdaugaGrupele.Click += new System.EventHandler(this.buttonAdaugaGrupele_Click);
            // 
            // labelMeniu
            // 
            this.labelMeniu.AutoSize = true;
            this.labelMeniu.ForeColor = System.Drawing.Color.White;
            this.labelMeniu.Location = new System.Drawing.Point(84, 12);
            this.labelMeniu.Name = "labelMeniu";
            this.labelMeniu.Size = new System.Drawing.Size(117, 47);
            this.labelMeniu.TabIndex = 5;
            this.labelMeniu.Text = "Meniu";
            // 
            // pictureBoxMeniu
            // 
            this.pictureBoxMeniu.Image = global::evaluarea_studentilor_in_sesiune.Properties.Resources._3_bar_menu;
            this.pictureBoxMeniu.Location = new System.Drawing.Point(9, 12);
            this.pictureBoxMeniu.Name = "pictureBoxMeniu";
            this.pictureBoxMeniu.Size = new System.Drawing.Size(69, 50);
            this.pictureBoxMeniu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMeniu.TabIndex = 4;
            this.pictureBoxMeniu.TabStop = false;
            this.pictureBoxMeniu.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // buttonConturiInactiveSauDezacrivate
            // 
            this.buttonConturiInactiveSauDezacrivate.FlatAppearance.BorderSize = 3;
            this.buttonConturiInactiveSauDezacrivate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.buttonConturiInactiveSauDezacrivate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonConturiInactiveSauDezacrivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConturiInactiveSauDezacrivate.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonConturiInactiveSauDezacrivate.ForeColor = System.Drawing.Color.White;
            this.buttonConturiInactiveSauDezacrivate.Image = global::evaluarea_studentilor_in_sesiune.Properties.Resources._8666688_user_x_icon;
            this.buttonConturiInactiveSauDezacrivate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonConturiInactiveSauDezacrivate.Location = new System.Drawing.Point(3, 127);
            this.buttonConturiInactiveSauDezacrivate.Name = "buttonConturiInactiveSauDezacrivate";
            this.buttonConturiInactiveSauDezacrivate.Size = new System.Drawing.Size(348, 105);
            this.buttonConturiInactiveSauDezacrivate.TabIndex = 3;
            this.buttonConturiInactiveSauDezacrivate.Text = "Conturi inactive sau dezactivate";
            this.buttonConturiInactiveSauDezacrivate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonConturiInactiveSauDezacrivate.UseVisualStyleBackColor = true;
            this.buttonConturiInactiveSauDezacrivate.Click += new System.EventHandler(this.buttonConturiInactiveSauDezacrivate_Click);
            // 
            // buttonAdaugaSpecializarw
            // 
            this.buttonAdaugaSpecializarw.FlatAppearance.BorderSize = 3;
            this.buttonAdaugaSpecializarw.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.buttonAdaugaSpecializarw.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonAdaugaSpecializarw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdaugaSpecializarw.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAdaugaSpecializarw.ForeColor = System.Drawing.Color.White;
            this.buttonAdaugaSpecializarw.Image = global::evaluarea_studentilor_in_sesiune.Properties.Resources._8666718_plus_circle_icon2;
            this.buttonAdaugaSpecializarw.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdaugaSpecializarw.Location = new System.Drawing.Point(3, 242);
            this.buttonAdaugaSpecializarw.Name = "buttonAdaugaSpecializarw";
            this.buttonAdaugaSpecializarw.Size = new System.Drawing.Size(348, 105);
            this.buttonAdaugaSpecializarw.TabIndex = 2;
            this.buttonAdaugaSpecializarw.Text = "   Adauga specializare";
            this.buttonAdaugaSpecializarw.UseVisualStyleBackColor = true;
            this.buttonAdaugaSpecializarw.Click += new System.EventHandler(this.buttonAdaugaSpecializarw_Click);
            // 
            // buttonAdaugaDisciplina
            // 
            this.buttonAdaugaDisciplina.FlatAppearance.BorderSize = 3;
            this.buttonAdaugaDisciplina.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.buttonAdaugaDisciplina.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonAdaugaDisciplina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdaugaDisciplina.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAdaugaDisciplina.ForeColor = System.Drawing.Color.White;
            this.buttonAdaugaDisciplina.Image = global::evaluarea_studentilor_in_sesiune.Properties.Resources._8666718_plus_circle_icon1;
            this.buttonAdaugaDisciplina.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdaugaDisciplina.Location = new System.Drawing.Point(3, 357);
            this.buttonAdaugaDisciplina.Name = "buttonAdaugaDisciplina";
            this.buttonAdaugaDisciplina.Size = new System.Drawing.Size(348, 105);
            this.buttonAdaugaDisciplina.TabIndex = 2;
            this.buttonAdaugaDisciplina.Text = "Adauga disciplina";
            this.buttonAdaugaDisciplina.UseVisualStyleBackColor = true;
            this.buttonAdaugaDisciplina.Click += new System.EventHandler(this.buttonAdaugaDisciplina_Click);
            // 
            // buttonAdaugaStudentProfesor
            // 
            this.buttonAdaugaStudentProfesor.FlatAppearance.BorderSize = 3;
            this.buttonAdaugaStudentProfesor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.buttonAdaugaStudentProfesor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonAdaugaStudentProfesor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdaugaStudentProfesor.Font = new System.Drawing.Font("Times New Roman", 18.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAdaugaStudentProfesor.ForeColor = System.Drawing.Color.White;
            this.buttonAdaugaStudentProfesor.Image = global::evaluarea_studentilor_in_sesiune.Properties.Resources._8666546_user_plus_icon;
            this.buttonAdaugaStudentProfesor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdaugaStudentProfesor.Location = new System.Drawing.Point(3, 472);
            this.buttonAdaugaStudentProfesor.Name = "buttonAdaugaStudentProfesor";
            this.buttonAdaugaStudentProfesor.Size = new System.Drawing.Size(348, 105);
            this.buttonAdaugaStudentProfesor.TabIndex = 2;
            this.buttonAdaugaStudentProfesor.Text = "Adauga student/profesor";
            this.buttonAdaugaStudentProfesor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAdaugaStudentProfesor.UseVisualStyleBackColor = true;
            this.buttonAdaugaStudentProfesor.Click += new System.EventHandler(this.buttonAdaugaStudentProfesor_Click);
            // 
            // buttonConturiInAdministrare
            // 
            this.buttonConturiInAdministrare.FlatAppearance.BorderSize = 3;
            this.buttonConturiInAdministrare.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.buttonConturiInAdministrare.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonConturiInAdministrare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConturiInAdministrare.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonConturiInAdministrare.ForeColor = System.Drawing.Color.White;
            this.buttonConturiInAdministrare.Image = global::evaluarea_studentilor_in_sesiune.Properties.Resources._8666620_database_icon;
            this.buttonConturiInAdministrare.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonConturiInAdministrare.Location = new System.Drawing.Point(3, 587);
            this.buttonConturiInAdministrare.Name = "buttonConturiInAdministrare";
            this.buttonConturiInAdministrare.Size = new System.Drawing.Size(348, 105);
            this.buttonConturiInAdministrare.TabIndex = 2;
            this.buttonConturiInAdministrare.Text = "  Conturi in administarare";
            this.buttonConturiInAdministrare.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonConturiInAdministrare.UseVisualStyleBackColor = true;
            this.buttonConturiInAdministrare.Click += new System.EventHandler(this.buttonConturiInAdministrare_Click);
            // 
            // panelLabel
            // 
            this.panelLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelLabel.Controls.Add(this.pictureBox1);
            this.panelLabel.Controls.Add(this.pictureBoxDelogare);
            this.panelLabel.Controls.Add(this.labelBunVenitAdmin);
            this.panelLabel.ForeColor = System.Drawing.Color.Gray;
            this.panelLabel.Location = new System.Drawing.Point(365, 2);
            this.panelLabel.Name = "panelLabel";
            this.panelLabel.Size = new System.Drawing.Size(1551, 125);
            this.panelLabel.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::evaluarea_studentilor_in_sesiune.Properties.Resources._403020_avatar_male_support_user_headset_icon;
            this.pictureBox1.Location = new System.Drawing.Point(1001, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(99, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBoxDelogare
            // 
            this.pictureBoxDelogare.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxDelogare.Image = global::evaluarea_studentilor_in_sesiune.Properties.Resources._4400629;
            this.pictureBoxDelogare.Location = new System.Drawing.Point(1476, 71);
            this.pictureBoxDelogare.Name = "pictureBoxDelogare";
            this.pictureBoxDelogare.Size = new System.Drawing.Size(60, 51);
            this.pictureBoxDelogare.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxDelogare.TabIndex = 7;
            this.pictureBoxDelogare.TabStop = false;
            this.pictureBoxDelogare.Click += new System.EventHandler(this.pictureBoxDelogare_Click);
            // 
            // timerAnimareMeniu
            // 
            this.timerAnimareMeniu.Interval = 10;
            this.timerAnimareMeniu.Tick += new System.EventHandler(this.timerAnimareMeniu_Tick);
            // 
            // FormLogareAdministrator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.Name = "FormLogareAdministrator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormLogareAdministrator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormLogareAdministrator_FormClosed);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInfomatiiSuplimentareCont)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConturiInactiveDezecativate)).EndInit();
            this.panelMeniu.ResumeLayout(false);
            this.panelMeniu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMeniu)).EndInit();
            this.panelLabel.ResumeLayout(false);
            this.panelLabel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDelogare)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelBunVenitAdmin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelLabel;
        private System.Windows.Forms.Timer timerAnimareMeniu;
        private System.Windows.Forms.Panel panelMeniu;
        private System.Windows.Forms.Label labelMeniu;
        private System.Windows.Forms.PictureBox pictureBoxMeniu;
        private System.Windows.Forms.Button buttonConturiInactiveSauDezacrivate;
        private System.Windows.Forms.Button buttonAdaugaSpecializarw;
        private System.Windows.Forms.Button buttonAdaugaDisciplina;
        private System.Windows.Forms.Button buttonAdaugaStudentProfesor;
        private System.Windows.Forms.Button buttonConturiInAdministrare;
        private System.Windows.Forms.Button buttonAdaugaGrupele;
        private System.Windows.Forms.DataGridView dataGridViewConturiInactiveDezecativate;
        private System.Windows.Forms.DataGridView dataGridViewInfomatiiSuplimentareCont;
        private System.Windows.Forms.Button buttonActivareCont;
        private System.Windows.Forms.PictureBox pictureBoxDelogare;
        private System.Windows.Forms.Button buttonAsociereprofesorDisciplinaGrupa;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}