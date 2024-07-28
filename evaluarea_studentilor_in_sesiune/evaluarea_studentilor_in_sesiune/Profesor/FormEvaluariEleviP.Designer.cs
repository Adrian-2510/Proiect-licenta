
namespace evaluarea_studentilor_in_sesiune
{
    partial class FormEvaluariEleviP
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
            this.dataGridViewEvaluariElevi = new System.Windows.Forms.DataGridView();
            this.comboBoxGrupa = new System.Windows.Forms.ComboBox();
            this.comboBoxDisciplina = new System.Windows.Forms.ComboBox();
            this.labelGrupa = new System.Windows.Forms.Label();
            this.labelDisciplina = new System.Windows.Forms.Label();
            this.textBoxEvaluare = new System.Windows.Forms.TextBox();
            this.labelEvalure = new System.Windows.Forms.Label();
            this.checkBoxToate = new System.Windows.Forms.CheckBox();
            this.buttonInapoi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvaluariElevi)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewEvaluariElevi
            // 
            this.dataGridViewEvaluariElevi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEvaluariElevi.Location = new System.Drawing.Point(12, 246);
            this.dataGridViewEvaluariElevi.Name = "dataGridViewEvaluariElevi";
            this.dataGridViewEvaluariElevi.RowTemplate.Height = 25;
            this.dataGridViewEvaluariElevi.Size = new System.Drawing.Size(1880, 556);
            this.dataGridViewEvaluariElevi.TabIndex = 0;
            this.dataGridViewEvaluariElevi.DoubleClick += new System.EventHandler(this.dataGridViewEvaluariElevi_DoubleClick);
            // 
            // comboBoxGrupa
            // 
            this.comboBoxGrupa.FormattingEnabled = true;
            this.comboBoxGrupa.Location = new System.Drawing.Point(541, 192);
            this.comboBoxGrupa.Name = "comboBoxGrupa";
            this.comboBoxGrupa.Size = new System.Drawing.Size(813, 48);
            this.comboBoxGrupa.TabIndex = 2;
            this.comboBoxGrupa.SelectedIndexChanged += new System.EventHandler(this.comboBoxGrupa_SelectedIndexChanged);
            // 
            // comboBoxDisciplina
            // 
            this.comboBoxDisciplina.FormattingEnabled = true;
            this.comboBoxDisciplina.Location = new System.Drawing.Point(1360, 192);
            this.comboBoxDisciplina.Name = "comboBoxDisciplina";
            this.comboBoxDisciplina.Size = new System.Drawing.Size(532, 48);
            this.comboBoxDisciplina.TabIndex = 3;
            this.comboBoxDisciplina.SelectedIndexChanged += new System.EventHandler(this.comboBoxDisciplina_SelectedIndexChanged);
            // 
            // labelGrupa
            // 
            this.labelGrupa.AutoSize = true;
            this.labelGrupa.BackColor = System.Drawing.Color.Transparent;
            this.labelGrupa.ForeColor = System.Drawing.Color.Transparent;
            this.labelGrupa.Location = new System.Drawing.Point(541, 149);
            this.labelGrupa.Name = "labelGrupa";
            this.labelGrupa.Size = new System.Drawing.Size(115, 40);
            this.labelGrupa.TabIndex = 4;
            this.labelGrupa.Text = "Grupa:";
            // 
            // labelDisciplina
            // 
            this.labelDisciplina.AutoSize = true;
            this.labelDisciplina.BackColor = System.Drawing.Color.Transparent;
            this.labelDisciplina.ForeColor = System.Drawing.Color.White;
            this.labelDisciplina.Location = new System.Drawing.Point(1360, 149);
            this.labelDisciplina.Name = "labelDisciplina";
            this.labelDisciplina.Size = new System.Drawing.Size(168, 40);
            this.labelDisciplina.TabIndex = 5;
            this.labelDisciplina.Text = "Disciplina:";
            // 
            // textBoxEvaluare
            // 
            this.textBoxEvaluare.Location = new System.Drawing.Point(12, 192);
            this.textBoxEvaluare.Name = "textBoxEvaluare";
            this.textBoxEvaluare.Size = new System.Drawing.Size(476, 48);
            this.textBoxEvaluare.TabIndex = 6;
            this.textBoxEvaluare.TextChanged += new System.EventHandler(this.textBoxEvaluare_TextChanged);
            // 
            // labelEvalure
            // 
            this.labelEvalure.AutoSize = true;
            this.labelEvalure.BackColor = System.Drawing.Color.Transparent;
            this.labelEvalure.ForeColor = System.Drawing.Color.White;
            this.labelEvalure.Location = new System.Drawing.Point(12, 149);
            this.labelEvalure.Name = "labelEvalure";
            this.labelEvalure.Size = new System.Drawing.Size(149, 40);
            this.labelEvalure.TabIndex = 7;
            this.labelEvalure.Text = "Evaluare:";
            // 
            // checkBoxToate
            // 
            this.checkBoxToate.AutoSize = true;
            this.checkBoxToate.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxToate.ForeColor = System.Drawing.Color.White;
            this.checkBoxToate.Location = new System.Drawing.Point(1779, 808);
            this.checkBoxToate.Name = "checkBoxToate";
            this.checkBoxToate.Size = new System.Drawing.Size(113, 44);
            this.checkBoxToate.TabIndex = 8;
            this.checkBoxToate.Text = "Toate";
            this.checkBoxToate.UseVisualStyleBackColor = false;
            this.checkBoxToate.CheckedChanged += new System.EventHandler(this.checkBoxToate_CheckedChanged);
            // 
            // buttonInapoi
            // 
            this.buttonInapoi.Location = new System.Drawing.Point(1660, 903);
            this.buttonInapoi.Name = "buttonInapoi";
            this.buttonInapoi.Size = new System.Drawing.Size(220, 76);
            this.buttonInapoi.TabIndex = 9;
            this.buttonInapoi.Text = "Inapoi";
            this.buttonInapoi.UseVisualStyleBackColor = true;
            this.buttonInapoi.Click += new System.EventHandler(this.buttonInapoi_Click);
            // 
            // FormEvaluariEleviP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 40F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::evaluarea_studentilor_in_sesiune.Properties.Resources.glasses_1052010_1920;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.buttonInapoi);
            this.Controls.Add(this.checkBoxToate);
            this.Controls.Add(this.labelEvalure);
            this.Controls.Add(this.textBoxEvaluare);
            this.Controls.Add(this.labelDisciplina);
            this.Controls.Add(this.labelGrupa);
            this.Controls.Add(this.comboBoxDisciplina);
            this.Controls.Add(this.comboBoxGrupa);
            this.Controls.Add(this.dataGridViewEvaluariElevi);
            this.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "FormEvaluariEleviP";
            this.Text = "FormEvaluariEleviP";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvaluariElevi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewEvaluariElevi;
        private System.Windows.Forms.ComboBox comboBoxGrupa;
        private System.Windows.Forms.ComboBox comboBoxDisciplina;
        private System.Windows.Forms.Label labelGrupa;
        private System.Windows.Forms.Label labelDisciplina;
        private System.Windows.Forms.TextBox textBoxEvaluare;
        private System.Windows.Forms.Label labelEvalure;
        private System.Windows.Forms.CheckBox checkBoxToate;
        private System.Windows.Forms.Button buttonInapoi;
    }
}