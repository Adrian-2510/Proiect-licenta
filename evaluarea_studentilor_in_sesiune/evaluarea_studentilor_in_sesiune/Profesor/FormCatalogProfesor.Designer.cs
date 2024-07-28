
namespace evaluarea_studentilor_in_sesiune
{
    partial class FormCatalogProfesor
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
            this.dataGridViewCatalogProfesor = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonDeblocheaza = new System.Windows.Forms.Button();
            this.comboBoxGrupa = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxDisciplina = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNumeStudent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonInapoi = new System.Windows.Forms.Button();
            this.checkBoxTotCatlogul = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCatalogProfesor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCatalogProfesor
            // 
            this.dataGridViewCatalogProfesor.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewCatalogProfesor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCatalogProfesor.Location = new System.Drawing.Point(107, 190);
            this.dataGridViewCatalogProfesor.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridViewCatalogProfesor.Name = "dataGridViewCatalogProfesor";
            this.dataGridViewCatalogProfesor.RowTemplate.Height = 25;
            this.dataGridViewCatalogProfesor.Size = new System.Drawing.Size(1133, 461);
            this.dataGridViewCatalogProfesor.TabIndex = 0;
            this.dataGridViewCatalogProfesor.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewCatalogProfesor_CellFormatting);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(242, 1862);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 48);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buttonDeblocheaza
            // 
            this.buttonDeblocheaza.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonDeblocheaza.Image = global::evaluarea_studentilor_in_sesiune.Properties.Resources._1519785_cutter_eraser_office_pencil_remove_icon;
            this.buttonDeblocheaza.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDeblocheaza.Location = new System.Drawing.Point(107, 713);
            this.buttonDeblocheaza.Name = "buttonDeblocheaza";
            this.buttonDeblocheaza.Size = new System.Drawing.Size(357, 88);
            this.buttonDeblocheaza.TabIndex = 2;
            this.buttonDeblocheaza.Text = "Deblocheaza/Blocheaza";
            this.buttonDeblocheaza.UseVisualStyleBackColor = true;
            this.buttonDeblocheaza.Click += new System.EventHandler(this.buttonDeblocheaza_Click);
            // 
            // comboBoxGrupa
            // 
            this.comboBoxGrupa.FormattingEnabled = true;
            this.comboBoxGrupa.Location = new System.Drawing.Point(1249, 243);
            this.comboBoxGrupa.Name = "comboBoxGrupa";
            this.comboBoxGrupa.Size = new System.Drawing.Size(643, 39);
            this.comboBoxGrupa.TabIndex = 3;
            this.comboBoxGrupa.SelectedIndexChanged += new System.EventHandler(this.comboBoxGrupa_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1249, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "Grupa:";
            // 
            // comboBoxDisciplina
            // 
            this.comboBoxDisciplina.FormattingEnabled = true;
            this.comboBoxDisciplina.Location = new System.Drawing.Point(1249, 390);
            this.comboBoxDisciplina.Name = "comboBoxDisciplina";
            this.comboBoxDisciplina.Size = new System.Drawing.Size(643, 39);
            this.comboBoxDisciplina.TabIndex = 5;
            this.comboBoxDisciplina.SelectedIndexChanged += new System.EventHandler(this.comboBoxDisciplina_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1249, 356);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 31);
            this.label2.TabIndex = 6;
            this.label2.Text = "Disciplina:";
            // 
            // textBoxNumeStudent
            // 
            this.textBoxNumeStudent.Location = new System.Drawing.Point(107, 142);
            this.textBoxNumeStudent.Name = "textBoxNumeStudent";
            this.textBoxNumeStudent.Size = new System.Drawing.Size(547, 39);
            this.textBoxNumeStudent.TabIndex = 7;
            this.textBoxNumeStudent.TextChanged += new System.EventHandler(this.textBoxNumeStudent_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(107, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 31);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nume student:";
            // 
            // buttonInapoi
            // 
            this.buttonInapoi.Location = new System.Drawing.Point(1586, 896);
            this.buttonInapoi.Name = "buttonInapoi";
            this.buttonInapoi.Size = new System.Drawing.Size(263, 88);
            this.buttonInapoi.TabIndex = 9;
            this.buttonInapoi.Text = "Inapoi";
            this.buttonInapoi.UseVisualStyleBackColor = true;
            this.buttonInapoi.Click += new System.EventHandler(this.buttonInapoi_Click);
            // 
            // checkBoxTotCatlogul
            // 
            this.checkBoxTotCatlogul.AutoSize = true;
            this.checkBoxTotCatlogul.Location = new System.Drawing.Point(1249, 616);
            this.checkBoxTotCatlogul.Name = "checkBoxTotCatlogul";
            this.checkBoxTotCatlogul.Size = new System.Drawing.Size(330, 35);
            this.checkBoxTotCatlogul.TabIndex = 10;
            this.checkBoxTotCatlogul.Text = "Afisarea tuturor studentilor";
            this.checkBoxTotCatlogul.UseVisualStyleBackColor = true;
            this.checkBoxTotCatlogul.CheckedChanged += new System.EventHandler(this.checkBoxTotCatlogul_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::evaluarea_studentilor_in_sesiune.Properties.Resources._285638_pencil_icon;
            this.pictureBox1.Location = new System.Drawing.Point(763, 660);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(477, 354);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::evaluarea_studentilor_in_sesiune.Properties.Resources._285638_pencil_icon;
            this.pictureBox2.Location = new System.Drawing.Point(1664, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(218, 203);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // FormCatalogProfesor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.checkBoxTotCatlogul);
            this.Controls.Add(this.buttonInapoi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxNumeStudent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxDisciplina);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxGrupa);
            this.Controls.Add(this.buttonDeblocheaza);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewCatalogProfesor);
            this.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormCatalogProfesor";
            this.Text = "FormCatalogProfesor";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCatalogProfesor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCatalogProfesor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonDeblocheaza;
        private System.Windows.Forms.ComboBox comboBoxGrupa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDisciplina;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNumeStudent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonInapoi;
        private System.Windows.Forms.CheckBox checkBoxTotCatlogul;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}